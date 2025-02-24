using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public LevelManager.MyScenes scene;
    public LevelManager levelManager;
    public bool endOfLevelWarp;

    private void Start()
    {
        
    }

    public void ChangeScene()
    {
        switch (scene)
        {
            case LevelManager.MyScenes.NotSet:
                Debug.LogWarning("Scene not set.");
                break;

            case LevelManager.MyScenes.LevelSelect:
                LevelEndToLevelSelect();
                SceneManager.LoadScene("LevelSelect");
                break;

            case LevelManager.MyScenes.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            
            case LevelManager.MyScenes.Level_1:
                levelManager.currentLevelNumber = 1;
                SceneManager.LoadScene("Level_1");
                break;

            case LevelManager.MyScenes.Level_2:
                levelManager.currentLevelNumber = 2;
                SceneManager.LoadScene("Level_2");
                break;

            case LevelManager.MyScenes.Level_3:
                levelManager.currentLevelNumber = 3;
                SceneManager.LoadScene("Level_3");
                break;

            case LevelManager.MyScenes.Level_4:
                levelManager.currentLevelNumber = 4;
                SceneManager.LoadScene("Level_4");
                break;

            default:
                Debug.LogWarning("Scene not found.");
                break;
        }
    }
    private void LevelEndToLevelSelect()
    {
        if (endOfLevelWarp)
        {
            switch (levelManager.currentLevelNumber)
            {
                default:
                    break;

                case 1:
                    levelManager.levelNumberBeat[1] = true;
                    break;

                case 2:
                    levelManager.levelNumberBeat[2] = true;
                    break;
                
                case 3:
                    levelManager.levelNumberBeat[3] = true;
                    break;

                case 4:
                    levelManager.levelNumberBeat[4] = true;
                    break;
            }
            levelManager.levelNumberBeat[0] = true;
        }
    }
}
