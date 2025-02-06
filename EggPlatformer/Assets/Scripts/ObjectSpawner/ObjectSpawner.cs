using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject trigger;
    public GameObject prefabToSpawn;
    public List<Transform> objectSpawnPositions = new List<Transform>();
    public int numberToSpawn;
    public float forceScale;
    
    
    private Rigidbody _rb;
    private Transform _player;
    private Vector3 _towardPlayer;
    void Start()
    {
        _rb = prefabToSpawn.GetComponent<Rigidbody>();
        _player = GameObject.FindWithTag("Player").transform;

        Renderer triggerRenderer = trigger.GetComponent<Renderer>();
        triggerRenderer.enabled = false;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.GetChild(0).GetComponent<Collider>();
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                foreach (Transform spawnPos in objectSpawnPositions)
                {
                    Instantiate(prefabToSpawn, spawnPos);
                    Vector3 v = spawnPos.position - _player.position;
                    spawnPos.GetComponent<Rigidbody>().AddForce(v.normalized * forceScale);
                }
            }
        }
    }
}
