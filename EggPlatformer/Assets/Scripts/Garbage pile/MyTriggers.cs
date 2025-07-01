//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
/*
 * 
 * Failed attempt to group trigger classes into one single class
 * It was a bad idea, I think
 * 
public enum TriggerType {NotSet, Kill, Parenter, LevelWin, SceneChange}
public class MyTriggers : MonoBehaviour
{
    public TriggerType triggerType;
    public GameObject eggBrokenPrefab;

    private bool _onTriggerEnter, _onTriggerStay, _onTriggerExit;
    //private TriggerStateBouncer bouncer;
    
    private GameObject _player;
    
    private GameObject _levelManager;
    private LevelManager _levelManagerScriptRef;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");

        _levelManager = GameObject.Find("LevelManager");
        _levelManagerScriptRef = _levelManager.GetComponent<LevelManager>();

        Renderer thisRenderer = GetComponent<Renderer>();
        thisRenderer.enabled = false;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerTypeDecider();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerTypeDecider();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerTypeDecider();
        }
    }

    private void TriggerTypeDecider()
    {
        switch (triggerType)
        {
            case TriggerType.NotSet:
                Debug.LogWarning("Trigger not set!");
                break;
            case TriggerType.Kill:

                break;
            case TriggerType.Parenter:
                
                break;
            case TriggerType.LevelWin:
                
                break;
            case TriggerType.SceneChange:
                
                break;
            default:
                Debug.LogWarning("Unknown trigger type");
                break;
        }
    }

    private void TriggerKill_Enter()
    {
        Transform playerStoreTransform = _player.transform;

        Renderer renderer = _player.GetComponent<Renderer>();
        renderer.enabled = false;

        Rigidbody rb = _player.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;

        Collider collider = _player.GetComponent<Collider>();
        collider.enabled = false;

        Instantiate(eggBrokenPrefab, playerStoreTransform.transform.position, playerStoreTransform.transform.rotation);
        _levelManagerScriptRef.playerAlive = false;
    }

    private void TriggerParenter_Enter()
    {
        _player.transform.SetParent(transform.parent, true);
        if (transform.parent != null)
        {
            print("Egg is parented with: " + transform.parent.name);
        }
        else
        {
            print("Egg is parented with: parentless trigger");
        }
    }

    private void TriggerParenter_Exit()
    {
        if (transform.parent != null)
        {
            print("Egg is no longer parented with: " + transform.parent.name);
        }
        else
        {
            print("Egg is no longer parented with: parentless trigger");
        }

        _player.transform.SetParent(null);
    }

    private void TriggerLevelWin_Enter()
    {

    }

    private void TriggerSceneChange_Enter()
    {

    }
}
*/
