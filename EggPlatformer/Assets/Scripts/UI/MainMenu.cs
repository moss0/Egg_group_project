using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LevelManager levelManager;

    public void StartGameButton()
    {
        SceneManager.LoadScene("LevelSelect");
        levelManager.playerAlive = true;
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
