using UnityEngine;

public class MakeInvisWhilePlay : MonoBehaviour
{
    void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.enabled = false;
    }
}
