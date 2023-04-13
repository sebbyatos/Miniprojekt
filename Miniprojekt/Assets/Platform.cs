using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour, IInteractable
{
    public bool hasToBeActivated;
    private bool isActivated;

    public List<Transform> points;
    private int nextPoint;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        isActivated = !hasToBeActivated;
        nextPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActivated) return;

        if(Vector3.Distance(transform.position, points[nextPoint].position) < 0.05f) {
            nextPoint = (nextPoint + 1) % (points.Count);
        }

        transform.position += (points[nextPoint].position - transform.position).normalized * speed * Time.deltaTime;
    }

    public void Interact() {
        isActivated = true;
    }

    private void OnCollisionEnter(Collision other) {
        other.transform.parent = transform;
    }

    private void OnCollisionExit(Collision other) {
        other.transform.parent = null;
    }
}
