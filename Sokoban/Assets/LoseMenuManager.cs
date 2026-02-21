using System;
using UnityEngine;

public class LoseMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject loseMenu;
    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.OnDeath += ShowLoseMenu;
    }

    private void ShowLoseMenu()
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }
}
