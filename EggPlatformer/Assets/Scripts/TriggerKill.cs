using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerKill : MonoBehaviour
{
    private GameObject player;
    public GameObject eggBrokenPrefab;

    private GameObject levelManager;
    private LevelManager levelManagerScriptRef;
    private void Start()
    {
        player = GameObject.Find("Player");
        
        Renderer thisRenderer = GetComponent<Renderer>();
        thisRenderer.enabled = false;
        
        levelManager = GameObject.Find("LevelManager");
        levelManagerScriptRef = levelManager.GetComponent<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform playerStoreTransform = player.transform;
            
            Renderer renderer = player.GetComponent<Renderer>();
            renderer.enabled = false;

            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;

            Collider collider = player.GetComponent<Collider>();
            collider.enabled = false;

            Instantiate(eggBrokenPrefab, playerStoreTransform.transform.position, playerStoreTransform.transform.rotation);
            levelManagerScriptRef.playerAlive = false;
        }
    }
}
