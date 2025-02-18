using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject deadMenu;
    public GameObject escKeyText;
    public GameObject optionsMenu;
    public LevelManager levelManager;

    private bool _gamePaused = false;

    private void Start()
    {
        ResumeGame();
        deadMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && levelManager.PlayerAlive)
        {
            if (!_gamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
            if (optionsMenu)
            {

            }
        }
        else if (!levelManager.PlayerAlive)
        {
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        deadMenu.SetActive(true);
        escKeyText.SetActive(false);
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    public void PauseGame()
    {
        _gamePaused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        _gamePaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
    }
    
    public void ResetScene()
    {
        levelManager.PlayerAlive = true;
        string currentSceneName = SceneManager.GetActiveScene().name;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(currentSceneName);
    }

    public void OptionsMenuEnter()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true );
    }

    public void OptionsMenuExit()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeFrameRate()
    {
        Application.targetFrameRate = 60;
    }
}
