using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestarter : MonoBehaviour
{
    [SerializeField]
    private string mainMenuSceneName = "MainMenu";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ReloadCurrentScene();
        if (Input.GetKeyDown(KeyCode.Escape))
            ExitToMainMenu();
    }

    private void ExitToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    private void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
