using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParent : MonoBehaviour
{
    private GameObject player;

    public bool playerOnTrigger;
    void Start()
    {
        player = GameObject.Find("Player");

        playerOnTrigger = false;

        Renderer thisRenderer = GetComponent<Renderer>();
        thisRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.SetParent(transform.parent.parent, true);
            if (transform.parent.parent != null)
            {
                playerOnTrigger = true;
                print("Egg is parented with: " + transform.parent.parent.name);
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
            if (transform.parent.parent != null)
            {
                playerOnTrigger = false;
                print("Egg is no longer parented with: " + transform.parent.parent.name);
            }
            else 
            {
                print("Egg is no longer parented with: parentless trigger");
            }
                
            player.transform.SetParent(null);
            
        }
    }
}
