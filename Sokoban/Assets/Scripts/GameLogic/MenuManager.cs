using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject winPanel;
        [SerializeField]
        private ScoreManager scoreManager;
        [SerializeField]
        private string mainMenuSceneName = "MainMenu";

        private void Start()
        {
            scoreManager.OnWin += HandleWin;
        }

        private void HandleWin()
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        public void ExitToMainMenu()
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}