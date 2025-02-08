using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float prefabScale = 1f;
    public List<Transform> objectSpawnPositions = new List<Transform>();
    public int numberToSpawn;
    public float forceScale;
    public bool _reuseable;

    private Transform _player;
    private bool _noMore;
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;

        Renderer triggerRenderer = GetComponent<Renderer>();
        triggerRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _noMore == false)
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                foreach (Transform spawnPos in objectSpawnPositions)
                {
                    var instance = Instantiate(prefabToSpawn, spawnPos);
                    Vector3 v = _player.position - spawnPos.position;
                    instance.GetComponent<Rigidbody>().AddForce(v.normalized * forceScale);
                    instance.transform.parent = null;
                    instance.transform.localScale = new Vector3(1f,1f,1f) * prefabScale;
                }
                if (_reuseable)
                {
                    _noMore = false;
                }
                else
                {
                    _noMore = true;
                }
            }
        }
    }

    //transform.GetChild(0).GetComponent<Collider>();
}
