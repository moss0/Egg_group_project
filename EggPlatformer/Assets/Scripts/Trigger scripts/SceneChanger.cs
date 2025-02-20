using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public LevelManager.MyScenes scene;
    
    public bool endOfLevelWarp;

    private LevelManager.MyScenes _previousScene = LevelManager.MyScenes.NotSet;

    public void ChangeScene()
    {
        switch (scene)
        {
            case LevelManager.MyScenes.NotSet:
                _previousScene = LevelManager.MyScenes.NotSet;
                Debug.LogWarning("Scene not set.");
                break;

            case LevelManager.MyScenes.LevelSelect:
                //_previousScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene("LevelSelect");
                break;

            case LevelManager.MyScenes.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            
            case LevelManager.MyScenes.Level_1:
                SceneManager.LoadScene("Level_1");
                break;

            case LevelManager.MyScenes.Level_2:
                SceneManager.LoadScene("Level_2");
                break;

            case LevelManager.MyScenes.Level_3:
                SceneManager.LoadScene("Level_3");
                break;

            case LevelManager.MyScenes.Level_4:
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
