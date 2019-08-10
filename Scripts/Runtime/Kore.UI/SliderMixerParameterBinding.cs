using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Kore.UI
{
    [AddComponentMenu("Kore/UI/SliderMixerParameterBinding")]
    public class SliderMixerParameterBinding : MonoBehaviour
    {
        public Slider slider;
        public AudioMixer mixer;
        public string mixerParameter;

        public float maxValue = 0.0f;
        public float minValue = -80.0f;

        private void OnEnable()
        {
            mixer.GetFloat(mixerParameter, out float value);

            slider.SetValueWithoutNotify((value - minValue) / (maxValue - minValue));

            slider.onValueChanged.AddListener(SliderValueChange);
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(SliderValueChange);
        }

        public void SliderValueChange(float value)
        {
            mixer.SetFloat(mixerParameter, minValue + value * (maxValue - minValue));
        }
    }
}
