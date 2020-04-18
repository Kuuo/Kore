using UnityEngine;
using UnityEngine.UI;
using Kore.Events;

namespace Kore.Variables.UIBinding
{
    [AddComponentMenu("Kore/ValueAssetUIBinding/ImageProperty/FloatAssetImageFillBinding")]
    public class FloatAssetImageFillBinding : ValueAssetUIBinding<float, FloatAsset, FloatGameEvent>
    {
        public Image image;

        public override void Response(float arg)
        {
            image.fillAmount = Mathf.Clamp01(arg);
        }
    }
}
