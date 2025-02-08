using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public GameObject masterParent;
    public bool objectSpawnerScript;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectSpawnerScript)
            {
                masterParent.GetComponent<ObjectSpawner>().InstanceSpawner();
            }
        }
    }
}
