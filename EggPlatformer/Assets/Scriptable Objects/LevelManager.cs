using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelManager")] //, menuName = ""
public class LevelManager : ScriptableObject
{
    private bool playerAlive;

    public bool PlayerAlive
    {
        get { return playerAlive; }
        set { playerAlive = value; }
    }

    private void Awake()
    {
        playerAlive = true;
    }
}
