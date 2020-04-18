using UnityEngine;
using UnityEngine.UI;
using Kore.Events;

namespace Kore.Variables.UIBinding
{
    public abstract class SliderValueAssetBinding<T, TNumberAsset, TGameEvent> : MonoBehaviour
        where T : struct
        where TNumberAsset : NumberAsset<T, TGameEvent>
        where TGameEvent : GameEvent<T>
    {
        public TNumberAsset numberAsset;
        public Slider slider;

        protected virtual void OnEnable()
        {
            slider.onValueChanged.AddListener(UpdateAssetValue);
            UpdateAssetValue(slider.value);
        }

        protected virtual void OnDisable()
        {
            slider.onValueChanged.RemoveListener(UpdateAssetValue);
        }

        protected void UpdateAssetValue(float newValue)
        {
            numberAsset.Set(newValue);
        }
    }
}
