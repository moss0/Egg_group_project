using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParent : MonoBehaviour
{
    public Transform masterParent;
    public bool playerOnTrigger;

    private GameObject _player;
    
    void Start()
    {
        _player = GameObject.Find("Player");

        playerOnTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnTrigger = true;
            _player.transform.SetParent(masterParent, true);
            
            if (masterParent != null)
            {
                print("Egg is parented with: " + masterParent.name);
            }
            else
            {
                print("Egg is parented with: parentless trigger");
            }      
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnTrigger = false;

            if (masterParent != null)
            {
                print("Egg is no longer parented with: " + masterParent.name);
            }
            else 
            {
                print("Egg is no longer parented with: parentless trigger");
            }
                
            _player.transform.SetParent(null);
            
        }
    }
}
