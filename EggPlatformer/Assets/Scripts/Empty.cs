using UnityEngine;

public class Empty : MonoBehaviour
{
    public bool drawDebugLineToParent;
    
    private Transform parent;

    void Start()
    {
        parent = transform.parent;
    }

    
    void Update()
    {
        if (parent != null)
        {
            if (drawDebugLineToParent)
                Debug.DrawLine(transform.position, parent.position, Color.cyan);
        }
        
    }
}
