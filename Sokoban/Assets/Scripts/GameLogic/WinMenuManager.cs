using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        [SerializeField]
        private Button NextLevelButton;


        private void Start()
        {
            scoreManager.OnWin += HandleWin;
        }

        private async void HandleWin()
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

            var currentName = SceneManager.GetActiveScene().name;

            var numberString = Regex.Match(currentName, @"\d+").Value;
            var nextLevelname = "";
            if (int.TryParse(numberString, out int currentLevel))
            {
                var nextLevel = currentLevel + 1;
                if (nextLevel > 3) 
                {
                    NextLevelButton.gameObject.SetActive(false);
                    return;
                }
                nextLevelname = currentName.Replace(numberString, nextLevel.ToString());
            }
            PlayerPrefs.SetInt(nextLevelname + "_IsLocked", 0);
            NextLevelButton.onClick.AddListener(() => SceneLoader.ChangeSceneByName(nextLevelname));
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
