using UnityEngine;

namespace Assets.Scripts.Sound
{
    class ScoreManagerAudioController : MonoBehaviour
    {
        [SerializeField]
        private AudioClip winSound;
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
            audioSource.volume = PlayerPrefs.GetFloat("MasterVolume", 1f);

            if (scoreManager == null)
            {
                Debug.LogError("ScoreManager reference is missing");
                return;
            }
            scoreManager.OnWin += PlayWinSound;
        }

        private void PlayWinSound()
        {
            audioSource.PlayOneShot(winSound);
        }
    }
}
