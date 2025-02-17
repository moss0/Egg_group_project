using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KillScript : MonoBehaviour
{
    public GameObject eggBrokenPrefab;
    public LevelManager levelManager;

    private GameObject _player;
    
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    public void KillPlayer()
    {
        _player.transform.parent = null;

        Transform playerStoreTransform = _player.transform;

        _player.GetComponent<Renderer>().enabled = false;
        
        Rigidbody rb = _player.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;

        Collider collider = _player.GetComponent<Collider>();
        collider.enabled = false;

        Instantiate(eggBrokenPrefab, playerStoreTransform.transform.position, playerStoreTransform.transform.rotation);
        levelManager.PlayerAlive = false;
    }
}
