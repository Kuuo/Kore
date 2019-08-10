using UnityEngine;
using UnityEngine.UI;
using Kore.Events;

namespace Kore.Variables.UI
{
    [AddComponentMenu("Kore/UI/SliderBinding/IntAssetSliderBinding")]
    public class IntAssetSliderBinding : AbstractGameEventListener<int>
    {
        public Slider slider;
        public IntAsset value;
        public IntReference minValue;
        public IntReference maxValue;

        protected override GameEvent<int> listeningEvent => value.OnValueChanged;

        protected override void OnEnable()
        {
            base.OnEnable();
            UpdateSlider(value);
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
