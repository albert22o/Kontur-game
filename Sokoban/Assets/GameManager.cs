using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action OnWin;

    [SerializeField] 
    private string goalTag = "Goal";
    private int goalCount;
    private int score;

    private void Awake()
    {
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
            OnWin?.Invoke();
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
