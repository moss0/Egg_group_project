using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public enum TriggerType { Kill, Spawning, Parenting, SceneChange }

    public GameObject masterParent;
    public TriggerType type;
    public bool playerOnTrigger;

    

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnTrigger = true;
            switch (type)
            {
                case TriggerType.Kill:
                    masterParent.GetComponent<KillScript>().KillPlayer();
                    return;
                case TriggerType.Spawning:
                    masterParent.GetComponent<ObjectSpawner>().InstanceSpawner();
                    return;
                case TriggerType.Parenting:
                    masterParent.GetComponent<ParentingScript>().ParentAdd();
                    return;
                case TriggerType.SceneChange:
                    masterParent.GetComponent<SceneChanger>().ChangeScene();
                    return;
                default:
                    Debug.LogWarning("Trigger not set");
                    return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnTrigger = false;
            switch (type)
            {
                case TriggerType.Kill:
                    
                    return;
                case TriggerType.Spawning:
                    
                    return;
                case TriggerType.Parenting:
                    masterParent.GetComponent<ParentingScript>().ParentRemove();
                    return;
                default:
                    Debug.LogWarning("Trigger not set");
                    return;
            }
        }
    }
    
    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (_type)
            {
                case TriggerType.Kill:

                    return;
                case TriggerType.Spawning:

                    return;
                case TriggerType.Parenting:

                    return;
                default:
                    Debug.LogWarning("Trigger not set");
                    return;
            }
        }
    }
    */
}
