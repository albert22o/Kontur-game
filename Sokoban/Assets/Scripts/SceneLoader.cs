using UnityEngine;

public static class SceneLoader
{
    public static string SceneName { get; private set; }
    public const string LoadingSceneName = "LoadingScene";
    public static void ChangeSceneByName(string sceneName)
    {
        Time.timeScale = 1f; // Resume the game
        SceneName = sceneName;
        UnityEngine.SceneManagement.SceneManager.LoadScene(LoadingSceneName);
    }


}
