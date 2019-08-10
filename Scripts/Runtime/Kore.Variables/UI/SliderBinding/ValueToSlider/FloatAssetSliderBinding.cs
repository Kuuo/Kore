using UnityEngine;
using UnityEngine.UI;
using Kore.Events;

namespace Kore.Variables.UI
{
    [AddComponentMenu("Kore/UI/SliderBinding/FloatAssetSliderBinding")]
    public class FloatAssetSliderBinding : AbstractGameEventListener<float>
    {
        public Slider slider;
        public FloatAsset value;
        public FloatReference minValue;
        public FloatReference maxValue;

        protected override GameEvent<float> listeningEvent => value.OnValueChanged;

        protected override void OnEnable()
        {
            base.OnEnable();
            UpdateSlider(value);
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
