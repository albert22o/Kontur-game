using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Scripts.Sound
{
    class GeneralSoundController : MonoBehaviour
    {
        [SerializeField]
        private Slider volumeSlider;
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private string groupName;
        private void Start()
        {
            if (volumeSlider == null)
            {
                Debug.LogError("Volume Slider reference is missing");
                return;
            }
            if (audioMixer.GetFloat(groupName,out var value))
                volumeSlider.value = value + 80;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        private void SetVolume(float newVolume)
        {
            audioMixer.SetFloat(groupName, newVolume - 80);
        }
    }
}
