using UnityEngine;
using UnityEngine.UI;
using Kore.Events;

namespace Kore.Variables.UIBinding
{
    [AddComponentMenu("Kore/ValueAssetUIBinding/Slider/ValueToSlider/FloatAssetSliderBinding")]
    public class FloatAssetSliderBinding : ValueAssetUIBinding<float, FloatAsset, FloatGameEvent>
    {
        public Slider slider;
        public FloatReference minValue;
        public FloatReference maxValue;

        protected override void OnEnable()
        {
            base.OnEnable();
            UpdateSlider(valueAsset.Value);
        }

        public void UpdateSlider(float newValue)
        {
            slider.value = MathUtils.Remap(newValue, minValue, maxValue, slider.minValue, slider.maxValue);
        }

        public override void Response(float arg)
        {
            UpdateSlider(arg);
        }
    }
}
