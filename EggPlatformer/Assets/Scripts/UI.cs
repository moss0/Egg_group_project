using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool gamePaused = false;
    void Start()
    {
        ResumeGame();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!gamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
    }
    
    public void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
