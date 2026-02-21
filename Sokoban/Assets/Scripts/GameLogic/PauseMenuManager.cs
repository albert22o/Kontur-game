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
            ShowPauseMenu();
    }

    public void ShowPauseMenu()
    {
        Time.timeScale = 0f; // Pause the game
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
        Time.timeScale = 1f; // Resume the game
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
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
