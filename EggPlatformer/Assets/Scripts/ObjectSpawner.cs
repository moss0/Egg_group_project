using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObjectSpawner : MonoBehaviour
{
    public int numberToSpawn;
    public GameObject objectToSpawn;
    public Transform objectSpawnPosition;
    
    private Rigidbody _rb;
    private Transform player;
    private Vector3 towardPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _rb = objectToSpawn.GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;

        Renderer thisRenderer = GetComponent<Renderer>();
        thisRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        objectSpawnPosition.transform.LookAt(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                var obj = Instantiate(objectToSpawn, objectSpawnPosition);
                obj.GetComponent<Rigidbody>().AddForce(Vector3.forward);
            }
        }
    }
}
