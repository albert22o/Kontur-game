using UnityEngine;

namespace Assets.Scripts.Sound
{
    class GameAudioController : MonoBehaviour
    {
        [SerializeField]
        private AudioClip WinSound;
        [SerializeField]
        private AudioSource audioSource;
        [SerializeField]
        private ScoreManager scoreManager;

        private void Start()
        {
            if (audioSource == null)
                return;
            audioSource.volume = PlayerPrefs.GetFloat("MasterVolume", 1f);

            if (scoreManager == null)
                return;
            scoreManager.OnWin += PlayWinSound;
        }

        private void PlayWinSound()
        {
            audioSource.PlayOneShot(WinSound);
        }
    }
}
