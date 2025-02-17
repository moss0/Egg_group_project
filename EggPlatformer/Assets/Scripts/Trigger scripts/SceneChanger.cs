using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public enum MyScenes { NotSet, LevelSelect, MainMenu, Level_1, Level_2, Level_3, Level_4 }
    public MyScenes scene;
    public bool endOfLevelWarp;

    

    public void ChangeScene()
    {
        switch (scene)
        {
            case MyScenes.NotSet:
                Debug.LogWarning("Scene not set.");
                break;

            case MyScenes.LevelSelect:
                SceneManager.LoadScene("LevelSelect");
                break;

            case MyScenes.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            
            case MyScenes.Level_1:
                SceneManager.LoadScene("Level_1");
                break;

            case MyScenes.Level_2:
                SceneManager.LoadScene("Level_2");
                break;

            case MyScenes.Level_3:
                SceneManager.LoadScene("Level_3");
                break;

            case MyScenes.Level_4:
                SceneManager.LoadScene("Level_4");
                break;

            default:
                Debug.LogWarning("Scene not found.");
                break;
        }
    }
    private void CameFrom()
    {

    }
}
