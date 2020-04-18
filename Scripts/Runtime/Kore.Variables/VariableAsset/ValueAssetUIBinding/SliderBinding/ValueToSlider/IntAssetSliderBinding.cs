using UnityEngine;
using UnityEngine.UI;
using Kore.Events;

namespace Kore.Variables.UIBinding
{
    [AddComponentMenu("Kore/ValueAssetUIBinding/Slider/ValueToSlider/IntAssetSliderBinding")]
    public class IntAssetSliderBinding : ValueAssetUIBinding<int, IntAsset, IntGameEvent>
    {
        public Slider slider;
        public IntReference minValue;
        public IntReference maxValue;

        protected override void OnEnable()
        {
            base.OnEnable();
            UpdateSlider(valueAsset.Value);
        }

        public void UpdateSlider(int newValue)
        {
            slider.value = MathUtils.Remap(newValue, minValue, maxValue, slider.minValue, slider.maxValue);
        }

        public override void Response(int arg)
        {
            UpdateSlider(arg);
        }
    }
}
