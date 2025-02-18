using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInvisWhilePlay : MonoBehaviour
{
    void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.enabled = false;
    }
}
