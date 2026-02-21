using System.Collections;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject loadingMessage;
    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneLoader.SceneName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
                loadingMessage.SetActive(true);
            if (asyncLoad.progress >= 0.9f && Input.GetKeyDown(KeyCode.Space))
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
