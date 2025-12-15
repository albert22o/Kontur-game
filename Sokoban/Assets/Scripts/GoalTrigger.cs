using System;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public Action<IScoreModifier> OnTriggerEntered;
    public Action<IScoreModifier> OnTriggerExited;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<IScoreModifier>(out var scoreModifier)) 
            return;
        OnTriggerEntered?.Invoke(scoreModifier);
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<IScoreModifier>(out var scoreModifier))
            return;
        OnTriggerExited?.Invoke(scoreModifier);
    }
}
