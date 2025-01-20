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
        Transform playerStoreTransform = player.transform;
        Destroy(player);
        Debug.Log("instantiate");
        //Instantiate(eggBrokenPrefab, playerStoreTransform.transform.position, playerStoreTransform.transform.rotation);

        // show retry menu which reloads scene
    }
}
