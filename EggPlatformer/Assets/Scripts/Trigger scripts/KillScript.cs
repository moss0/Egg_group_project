using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KillScript : MonoBehaviour
{
    public GameObject eggBrokenPrefab;

    private GameObject _player;
    private GameObject levelManager;
    private LevelManager levelManagerScriptRef;

    private void Start()
    {
        _player = GameObject.Find("Player");

        levelManager = GameObject.Find("LevelManager");
        levelManagerScriptRef = levelManager.GetComponent<LevelManager>();
    }

    public void KillPlayer()
    {
        _player.transform.parent = null;

        Transform playerStoreTransform = _player.transform;
            
        Renderer renderer = _player.GetComponent<Renderer>();
        renderer.enabled = false;

        Rigidbody rb = _player.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;

        Collider collider = _player.GetComponent<Collider>();
        collider.enabled = false;

        Instantiate(eggBrokenPrefab, playerStoreTransform.transform.position, playerStoreTransform.transform.rotation);
        levelManagerScriptRef.playerAlive = false;
    }
}
