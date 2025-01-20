using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public bool playerAlive = true;
    private void Awake()
    {
        playerAlive = true;
    }
}
