using System;
using UnityEngine;

namespace Assets.Scripts.Sound
{
    class ScoreManagerAudioController : MonoBehaviour
    {
        [SerializeField]
        private AudioClip winSound;
        [SerializeField]
        private AudioClip loseSound;
        [SerializeField]
        private AudioSource audioSource;
        [SerializeField]
        private ScoreManager scoreManager;

        private void Start()
        {
            if (audioSource == null)
            {
                Debug.LogError("AudioSource reference is missing");
                return;
            }

            if (scoreManager == null)
            {
                Debug.LogError("ScoreManager reference is missing");
                return;
            }
            scoreManager.OnWin += PlayWinSound;
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            player.OnDeath += PlayLoseSound;
        }

        private void PlayLoseSound()
        {
            audioSource.PlayOneShot(loseSound);
        }

        private void PlayWinSound()
        {
            audioSource.PlayOneShot(winSound);
        }
    }
}
