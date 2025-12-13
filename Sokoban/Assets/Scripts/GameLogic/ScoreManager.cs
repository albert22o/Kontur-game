using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public event Action OnWin;

    [SerializeField] 
    private string goalTag = "Goal";
    private PlayerController player;
    private int goalCount;
    private int score;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (player == null)
            Debug.LogError("PlayerController not found on the player object.");

        var goals = GameObject.FindGameObjectsWithTag(goalTag);
        goalCount = goals.Length;
        foreach (var goal in goals) 
        {
            goal.GetComponent<GoalScript>().OnTriggerEntered += HandleGoalReached;
            goal.GetComponent<GoalScript>().OnTriggerExited += HandleGoalLost;
        }
    }

    private void HandleGoalLost(IScoreModifier scoreModifier)
    {
        score = scoreModifier.RevertScore(score);
        CheckWin();
    }

    private void HandleGoalReached(IScoreModifier scoreModifier)
    {
        score = scoreModifier.ModifyScore(score);
        CheckWin();
    }

    private void CheckWin()
    {
        if (score == goalCount)
        {
            if (player.IsMoving)
                player.OnMoveEnd += () => OnWin?.Invoke();
            else
                OnWin?.Invoke();
        }
    }

    private void OnDestroy()
    {
        var goals = GameObject.FindGameObjectsWithTag(goalTag);
        foreach (var goal in goals)
        {
            goal.GetComponent<GoalScript>().OnTriggerEntered -= HandleGoalReached;
            goal.GetComponent<GoalScript>().OnTriggerExited -= HandleGoalLost;
        }
    }
}
