using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

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
                volumeSlider.value = Mathf.Pow(10, value / 20);
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        private void SetVolume(float sliderValue)
        {
            float dbValue = Mathf.Log10(Mathf.Max(0.0001f, sliderValue)) * 20;
            audioMixer.SetFloat(groupName, dbValue);
        }
    }
}
