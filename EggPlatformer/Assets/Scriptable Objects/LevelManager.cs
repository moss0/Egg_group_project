using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelManager")] //, menuName = ""
public class LevelManager : ScriptableObject
{
    public enum MyScenes { NotSet, LevelSelect, MainMenu, Level_1, Level_2, Level_3, Level_4 }

    private bool playerAlive;
    public bool PlayerAlive
    {
        get { return playerAlive; }
        set { playerAlive = value; }
    }

    private bool[] levelNumberBeat = new bool[5];

    //private void Awake()
    //{
    //    playerAlive = true;
    //}
}
