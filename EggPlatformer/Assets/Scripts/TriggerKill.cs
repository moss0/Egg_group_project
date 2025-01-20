using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerKill : MonoBehaviour
{
    private GameObject player;
    public GameObject eggBrokenPrefab;
    private void Start()
    {
        player = GameObject.Find("Player");
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
            Debug.Log("instantiate");
            //Instantiate(eggBrokenPrefab, playerStoreTransform.transform.position, playerStoreTransform.transform.rotation);

            // show retry menu which reloads scene
        }
    }
}
