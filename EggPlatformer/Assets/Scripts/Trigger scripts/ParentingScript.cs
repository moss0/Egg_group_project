using UnityEngine;

public class ParentingScript : MonoBehaviour
{
    private GameObject _player;
    
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    public void ParentAdd()
    {
        _player.transform.SetParent(transform, true);
            
        if (transform != null)
        {
            print("Egg is parented with: " + transform.name);
        }
        else
        {
            print("Egg is parented with: parentless trigger");
        }
    }

    public void ParentRemove()
    {
        if (transform != null)
        {
            print("Egg is no longer parented with: " + transform.name);
        }
        else 
        {
            print("Egg is no longer parented with: parentless trigger");
        }

        _player.transform.SetParent(null);
    }
}
