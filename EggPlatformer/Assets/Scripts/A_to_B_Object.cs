using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_to_B_Object : MonoBehaviour
{
    public Transform target;
    public TriggerParent childTrigger;
    public bool waitTillOnTrigger;

    public float speed = 1.0f;

    private float _sinTime;
    private Vector3 _a, _b, _storage;
    private bool _arrivedAtDest;
    
    private void Start()
    {
        _a = transform.position;
        _b = target.position;
        
        _arrivedAtDest = false;
    }
    private void Update()
    {
        if (waitTillOnTrigger)
        {
            if (childTrigger.playerOnTrigger)
            {
                if (_arrivedAtDest == false) 
                {
                    sineLerp();
                }
            }
        }
        else
        {
            sineLerp();
        }

        Debug.DrawLine(_a, _b);
    }
    
    private void sineLerp()
    {
        _sinTime += Time.deltaTime * speed * 0.01f;
        _sinTime = Mathf.Clamp(_sinTime, 0, Mathf.PI);
        float t = evaluate(_sinTime);
        transform.position = Vector3.Lerp(_a, _b, t);
        if (transform.position == _b)
        {
            _storage = _a;
            _a = _b;
            _b = _storage;
            _sinTime = 0;
            _arrivedAtDest = true;
        }
    }
    
    public float evaluate(float x)
    {
        return 0.5f * Mathf.Sin(x - Mathf.PI / 2f) + 0.5f;
    }
}
