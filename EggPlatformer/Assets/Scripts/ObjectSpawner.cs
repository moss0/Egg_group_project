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

    private Collider _trigger;
    private Transform _player;
    private bool _noMore;

    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
        _trigger = transform.GetChild(0).GetComponent<Collider>();
    }

    public void InstanceSpawner()
    {
        if (_noMore == false)
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
                    Destroy(instance, 10f);
                }
                //_reuseable == true ? _noMore = false : _noMore = true;
                
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
