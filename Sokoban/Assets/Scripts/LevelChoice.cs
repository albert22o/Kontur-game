using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelChoice : MonoBehaviour
{
    [SerializeField]
    private string levelName;
    [SerializeField]
    private GameManager gameManager;
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
        levelNameText.text = levelName;
        var bestScore = PlayerPrefs.GetInt(levelName + "_BestTurns", -1);
        var bestTime = PlayerPrefs.GetFloat(levelName + "_BestTime", -1f);
        bestScoreText.text = bestScore != -1 ? $"Best Turns: {bestScore}" : "Best Turns: N/A";
        bestTimeText.text = bestTime != -1f ? $"Best Time: {bestTime:F2} s" : "Best Time: N/A";
        playButton.onClick.AddListener(LoadLevel);
    }
    public void LoadLevel()
    {
        gameManager.ChangeSceneByName(levelName);
    }
}
