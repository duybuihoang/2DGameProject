using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DuyBui
{
    public class AudioSliderManager : MonoBehaviour
    {
        public Slider SFXSlider;
        public Slider BGMSlider;

        private void Start()
        {
            SFXSlider.value = AudioManager.Instance.sfxSource.volume;
            BGMSlider.value = AudioManager.Instance.bgmSource.volume;

            SFXSlider.onValueChanged.AddListener(OnSliderSFXValueChanged);
            BGMSlider.onValueChanged.AddListener(OnSliderBGMValueChanged);
        }

        private void OnDestroy()
        {
            SFXSlider.onValueChanged.RemoveListener(OnSliderSFXValueChanged);
            BGMSlider.onValueChanged.RemoveListener(OnSliderBGMValueChanged);
        }

        void OnSliderSFXValueChanged(float value)
        {
            AudioManager.Instance.SetSFXVolume(value);
        }

        void OnSliderBGMValueChanged(float value)
        {
            AudioManager.Instance.SetBGMVolume(value);

        }

    }
}
