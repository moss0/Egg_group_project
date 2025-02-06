using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnTrigger : MonoBehaviour
{
    //public bool within;

    private void Start()
    {
        //within = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                //within = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //within = false;
        }
    }
}
