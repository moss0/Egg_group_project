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
    public LevelManager levelManager;

    private bool _gamePaused = false;

    private void Start()
    {
        ResumeGame();
        deadMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && levelManager.playerAlive)
        {
            if (!_gamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
        else if (!levelManager.playerAlive)
        {
            deadMenu.SetActive(true);
            escKeyText.SetActive(false);
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
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
        string currentSceneName = SceneManager.GetActiveScene().name;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(currentSceneName);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
