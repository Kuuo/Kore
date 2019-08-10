using UnityEngine;
using UnityEngine.UI;
using Kore;

namespace Kore.Variables.UI
{
    public abstract class SliderValueAssetBinding<T> : MonoBehaviour
        where T : struct
    {
        public Slider slider;

        protected abstract NumberAsset<T> _asset { get; }

        protected virtual void OnEnable()
        {
            slider.onValueChanged.AddListener(UpdateAssetValue);
        }

        protected virtual void OnDisable()
        {
            slider.onValueChanged.RemoveListener(UpdateAssetValue);
        }

        protected void UpdateAssetValue(float newValue)
        {
            _asset.floatValue = newValue;
        }
    }
}
