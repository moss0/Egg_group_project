using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParent : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

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
            player.transform.SetParent(transform.parent, true);
            if (transform.parent != null)
            {
                print("Egg is parented with: " + transform.parent.name);
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
            if (transform.parent != null)
            {
                print("Egg is no longer parented with: " + transform.parent.name);
            }
            else 
            {
                print("Egg is no longer parented with: parentless trigger");
            }
                
            player.transform.SetParent(null);
            
        }
    }
}
