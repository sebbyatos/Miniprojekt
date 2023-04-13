using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerShoot : MonoBehaviour
{
    [Header("Line Renderer Settings")]
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform gunMuzzle;
    
    [Header("Impact Particle System Settings")]
    [SerializeField] private GameObject particleCollision;
    [SerializeField] private int particlePoolSize;
    [SerializeField] private float wallDistance;

    [Header("Thickness")] 
    [SerializeField] private float maxThickness;
    [SerializeField] private float changeRate;

    private ReflectionController[] _particlePool;
    private List<RaycastHit> _hitPoints;

    private bool isClear;

    private void Awake()
    {
        _hitPoints = new List<RaycastHit>();
        //Fill Particle Pool
        _particlePool = new ReflectionController[particlePoolSize];
        for (int i = 0; i < particlePoolSize; i++)
        {
            GameObject go = Instantiate(particleCollision);
            _particlePool[i] = go.GetComponent<ReflectionController>();
            _particlePool[i].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        lineRenderer.startWidth = 0;
        lineRenderer.endWidth = lineRenderer.startWidth;
        
        for (int i = 0; i < _particlePool.Length; i++)
        {
            _particlePool[i].SetScaleMultiply(0);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
        else
        {
            ClearShot();
        }
    }

    private void ClearShot()
    {
        if (isClear) return;

        lineRenderer.startWidth = Mathf.Clamp(lineRenderer.startWidth - changeRate * Time.deltaTime, 0, maxThickness);
        lineRenderer.endWidth = lineRenderer.startWidth;
        
        for (int i = 0; i < _particlePool.Length; i++)
        {
            _particlePool[i].SetScaleMultiply(lineRenderer.startWidth / maxThickness);
        }
        
        UpdateCollisionParticles();

        if (lineRenderer.startWidth == 0)
        {
            _hitPoints.Clear();
            UpdateCollisionParticles();
            isClear = true;
        }
    }
    
    public void Shoot()
    {
        if (lineRenderer.startWidth != maxThickness)
        {
            lineRenderer.startWidth = Mathf.Clamp(lineRenderer.startWidth + changeRate * Time.deltaTime, 0, maxThickness);
            lineRenderer.endWidth = lineRenderer.startWidth;

            for (int i = 0; i < _particlePool.Length; i++)
            {
                _particlePool[i].SetScaleMultiply(lineRenderer.startWidth / maxThickness);
            }
        }

        isClear = false;
        _hitPoints.Clear();
        lineRenderer.positionCount = 1;
        ShootRecursive(gunMuzzle.position, transform.forward);
        UpdateCollisionParticles();
    }
    
    private void ShootRecursive(Vector3 startPos, Vector3 direction)
    {
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, startPos);

        lineRenderer.positionCount += 1;
        RaycastHit hit;
        if (Physics.Raycast(startPos, direction, out hit, 50))
        {
            _hitPoints.Add(hit);

            if (hit.collider.CompareTag("Mirror"))
            {
                ShootRecursive(hit.point, Vector3.Reflect(direction, hit.normal));
                return;
            }

            if (hit.collider.CompareTag("Receiver"))
            {
                hit.collider.GetComponent<LaserReceiver>().LightReceiver();
            }
            
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, startPos + direction * 10);
            Debug.DrawRay(startPos, direction * 10, Color.red, 3);
        }
    }

    private void UpdateCollisionParticles()
    {
        for (int i = 0; i < _particlePool.Length; i++)
        {
            if (_hitPoints.Count > i)
            {
                _particlePool[i].gameObject.SetActive(true);
                _particlePool[i].transform.position = _hitPoints[i].point + _hitPoints[i].normal * (wallDistance * lineRenderer.startWidth / maxThickness);
            }
            else
            {
                _particlePool[i].gameObject.SetActive(false);
            }
        }
    }
}
