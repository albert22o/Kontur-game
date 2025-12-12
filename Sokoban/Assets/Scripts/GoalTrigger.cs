using System;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public Action<string> OnTriggerEntered;
    public Action<string> OnTriggerExited;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEntered?.Invoke(other.tag);
    }
    private void OnTriggerExit(Collider other)
    {
        OnTriggerExited?.Invoke(other.tag);
    }
}
