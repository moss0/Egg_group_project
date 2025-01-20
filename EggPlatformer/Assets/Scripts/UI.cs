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
    private bool gamePaused = false;
    private LevelManager levelManager;
    void Start()
    {
        ResumeGame();
        deadMenu.SetActive(false);
        levelManager = levelManager.GetComponent<LevelManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && levelManager.playerAlive)
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
        else if (!levelManager.playerAlive)
        {
            deadMenu.SetActive(true);
            escKeyText.SetActive(false);
            pauseMenu.SetActive(false);
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
