using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;

    public Rigidbody _rb;

    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        direction.Normalize();
        _rb.velocity = new Vector3(direction.x * _speed, _rb.velocity.y, direction.z * _speed);
    }
}
