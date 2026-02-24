using UnityEngine;

public class FirstLevelActivator : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("Level 1_IsLocked", 0);
    }

    public void LockLevels()
    {
        PlayerPrefs.SetInt("Level 2_IsLocked", 1);
        PlayerPrefs.SetInt("Level 3_IsLocked", 1);
    }
}
