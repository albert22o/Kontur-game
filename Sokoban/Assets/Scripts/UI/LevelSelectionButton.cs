using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField]
    private string levelName;
    [SerializeField]
    private TextMeshProUGUI levelNameText;
    [SerializeField]
    private TextMeshProUGUI bestScoreText;
    [SerializeField]
    private TextMeshProUGUI bestTimeText;
    [SerializeField]
    private Button playButton;

    private void Start()
    {
        if (levelNameText == null || bestScoreText == null || bestTimeText == null || playButton == null)
        {
            Debug.LogError("One or more references are missing in LevelSelectionButton.");
            return;
        }
        levelNameText.text = levelName;
        var isLocked = PlayerPrefs.GetInt(levelName + "_IsLocked", 1) == 1;
        playButton.interactable = !isLocked;

        var bestScore = PlayerPrefs.GetInt(levelName + "_BestTurns", -1);
        bestScoreText.text = bestScore != -1 ? $"Best Turns: {bestScore}" : "Best Turns: N/A";

        var bestTime = PlayerPrefs.GetFloat(levelName + "_BestTime", -1f);
        bestTimeText.text = bestTime != -1f ? $"Best Time: {bestTime:F2} s" : "Best Time: N/A";

        playButton.onClick.AddListener(LoadLevel);
    }
    public void LoadLevel()
    {
        SceneLoader.ChangeSceneByName(levelName);
    }
}
