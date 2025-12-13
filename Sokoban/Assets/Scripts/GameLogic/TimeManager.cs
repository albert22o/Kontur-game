using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private ScoreManager scoreManager;
    private float startTime;
    private bool isRunning = false;

    private void Awake()
    {
        StartTimer();

        if (scoreManager == null)
            Debug.LogError("ScoreManager reference is missing in TimeManager.");
        scoreManager.OnWin += SaveTime;
    }

    private void SaveTime()
    {
        var currentTime = GetCurrentTime();
        var levelName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        var bestTime = PlayerPrefs.GetFloat(levelName + "_BestTime", float.MaxValue);
        PlayerPrefs.SetFloat(levelName + "_BestTime", Math.Min(currentTime, bestTime));

        ResetTimer();
    }

    private void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    private void ResetTimer()
    {
        startTime = 0f;
        isRunning = false;
    }

    private float GetCurrentTime()
    {
        if (!isRunning)
            return 10000f;
        return Time.time - startTime;
    }
}
