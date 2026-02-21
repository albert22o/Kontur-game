using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class WinMenuManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject winPanel;
        [SerializeField]
        private ScoreManager scoreManager;
        [SerializeField]
        private TurnManager turnManager;
        [SerializeField]
        private string mainMenuSceneName = "MainMenu";
        [SerializeField]
        private int fineTurnThreshold = 20;
        [SerializeField]
        private int goodTurnThreshold = 10;
        [SerializeField]
        private GameObject starPrefab;
        [SerializeField]
        private Transform starContainer;

        private void Start()
        {
            scoreManager.OnWin += HandleWin;
        }

        private void HandleWin()
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
            if (turnManager.TurnCount <= goodTurnThreshold)
            {
                StartCoroutine(ShowStars(3));
            }
            else if (turnManager.TurnCount <= fineTurnThreshold)
            {
                StartCoroutine(ShowStars(2));
            }
            else
            {
                StartCoroutine(ShowStars(1));
            }
        }

        private IEnumerator ShowStars(int v)
        {
            for (int i = 0; i < v; i++)
            {
                var star = Instantiate(starPrefab, starContainer);
                star.transform.localScale = Vector3.zero;
                StartCoroutine(AnimateStar(star.transform));
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }

        private IEnumerator AnimateStar(Transform transform)
        {
            float duration = 0.5f;
            float elapsed = 0f;
            while (elapsed < duration)
            {
                transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, elapsed / duration);
                elapsed += Time.unscaledDeltaTime;
                yield return null;
            }
            transform.localScale = Vector3.one;
        }

        public void ExitToMainMenu()
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}