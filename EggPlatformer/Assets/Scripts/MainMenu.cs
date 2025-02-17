using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LevelManager levelManager;

    public void StartGameButton()
    {
        SceneManager.LoadScene("LevelSelect");
        levelManager.PlayerAlive = true;
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
