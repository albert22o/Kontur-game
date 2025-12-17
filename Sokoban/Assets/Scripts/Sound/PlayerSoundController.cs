using UnityEngine;

namespace Assets.Scripts.Sound
{
    [RequireComponent(typeof(PlayerController))]
    class PlayerSoundController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;
        private void Start()
        {
            if (audioSource == null)
            {
                Debug.LogError("AudioSource reference is missing");
                return; 
            }

            audioSource.volume = PlayerPrefs.GetFloat("MasterVolume", 1f);
            var playerController = GetComponent<PlayerController>();
        }

        public void PlaySound(AudioClip audioClip)
        {
            if (audioSource == null || audioClip == null)
                return;
            audioSource.PlayOneShot(audioClip);
        }
    }
}
