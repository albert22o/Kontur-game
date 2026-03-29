using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField]
    private string mainMenuSceneName = "MainMenu";
    [SerializeField]
    private GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ReloadCurrentScene();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
            ShowPauseMenu();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void ShowPauseMenu()
    {
        pauseMenuUI.SetActive(true);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        ResumeGame();
    }

    public void GameResumePressed()
    {
        ResumeGame();
        pauseMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            return;
        }
        Time.timeScale = 1f; // Resume the game
        Application.Quit();
    }
}
