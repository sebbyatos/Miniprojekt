using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        //transform.rotation = quaternion.Euler(transform.rotation.x, transform.rotation.y + speed * Time.deltaTime, transform.rotation.z);
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
