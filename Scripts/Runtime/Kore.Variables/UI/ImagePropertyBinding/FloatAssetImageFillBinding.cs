using UnityEngine;
using UnityEngine.UI;
using Kore.Events;

namespace Kore.Variables.UI
{
    [AddComponentMenu("Kore/UI/ImagePropertyBinding/FloatAssetImageFillBinding")]
    public class FloatAssetImageFillBinding : AbstractGameEventListener<float>
    {
        public Image image;
        public FloatAsset floatAsset;

        protected override GameEvent<float> listeningEvent => floatAsset.OnValueChanged;

        public void UpdateImageFill(float newValue)
        {
            image.fillAmount = Mathf.Clamp01(newValue);
        }

        public override void Response(float arg)
        {
            UpdateImageFill(arg);
        }
    }
}
