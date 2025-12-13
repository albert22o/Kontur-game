using System;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player";
    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField]
    private TextMeshProUGUI turnCountText;
    private PlayerController playerController;
    private int turnCount = 0;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag(playerTag).GetComponent<PlayerController>();
        if (playerController == null)
            Debug.LogError("PlayerController not found on the player object.");
        playerController.OnMoveEnd += HandleTurnEnd;

        if (scoreManager == null)
            Debug.LogError("ScoreManager reference is missing in TurnManager.");
        scoreManager.OnWin += HandleWin;
    }

    private void HandleTurnEnd()
    {
        turnCount++;
        turnCountText.text = $"Turns: {turnCount}";
    }

    private void HandleWin()
    {
        var levelName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        var bestTurnCount = PlayerPrefs.GetInt(levelName + "_BestTurns", int.MaxValue);
        PlayerPrefs.SetInt(levelName + "_BestTurns", Math.Min(turnCount, bestTurnCount));
    }
}
