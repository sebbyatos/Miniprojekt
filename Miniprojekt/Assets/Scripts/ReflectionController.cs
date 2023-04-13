using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem1;
    [SerializeField] private float scale1;
    [SerializeField] private ParticleSystem _particleSystem2;
    [SerializeField] private float scale2;

    private void Awake()
    {
        _particleSystem1.transform.localScale = Vector3.one * scale1;
        _particleSystem2.transform.localScale = Vector3.one * scale2;
    }

    public void SetScaleMultiply(float mult)
    {
        _particleSystem1.transform.localScale = Vector3.one * scale1 * mult;
        _particleSystem2.transform.localScale = Vector3.one * scale2 * mult;
    }
}
