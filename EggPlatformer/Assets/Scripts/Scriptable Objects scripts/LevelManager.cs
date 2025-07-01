using UnityEngine;

[CreateAssetMenu(fileName = "LevelManager")] //, menuName = ""
public class LevelManager : ScriptableObject
{
    public enum MyScenes { NotSet, LevelSelect, MainMenu, Level_1, Level_2, Level_3, Level_4 }

    public bool playerAlive;
    /*
    public bool PlayerAlive
    {
        get { return playerAlive; }
        set { playerAlive = value; }
    }
    */
    public int currentLevelNumber;

    public bool[] levelNumberBeat = new bool[5];

    private void Awake()
    {
        playerAlive = true;
        currentLevelNumber = 0;
    }
}
