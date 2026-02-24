using UnityEngine;

public class FirstLevelActivator : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("Level 1_IsLocked", 0);
    }
}
