using UnityEngine;

namespace Assets.Scripts.Sound
{
    [RequireComponent(typeof(PlayerController))]
    class PlayerSoundController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;
        [SerializeField]
        private AudioClip moveSound;
        [SerializeField]
        private AudioClip cantMoveSound;
        private void Start()
        {
            if (audioSource == null)
                return;

            audioSource.volume = PlayerPrefs.GetFloat("MasterVolume", 1f);
            var playerController = GetComponent<PlayerController>();
            playerController.OnMoveStart += () => PlaySound(moveSound);
            playerController.OnCantMove += () => PlaySound(cantMoveSound);
        }

        private void PlaySound(AudioClip audioClip)
        {
            if (audioSource == null || audioClip == null)
                return;
            audioSource.PlayOneShot(audioClip);
        }
    }
}
