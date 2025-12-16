using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Scripts.Sound
{
    class GeneralSoundController : MonoBehaviour
    {
        [SerializeField]
        private Slider volumeSlider;
        private void Start()
        {
            if (volumeSlider == null)
                return;

            var currentVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);

            volumeSlider.value = currentVolume;

            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        private void SetVolume(float newVolume)
        {
            if (newVolume <= 0)
                PlayerPrefs.SetFloat("MasterVolume", -80f);
            else
                PlayerPrefs.SetFloat("MasterVolume", newVolume);
        }
    }
}
