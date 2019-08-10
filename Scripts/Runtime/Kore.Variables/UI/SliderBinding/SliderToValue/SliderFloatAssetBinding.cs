using UnityEngine;
using UnityEngine.UI;
using Kore;

namespace Kore.Variables.UI
{
    [AddComponentMenu("Kore/UI/SliderBinding/SliderFloatAssetBinding")]
    public class SliderFloatAssetBinding : SliderValueAssetBinding<float>
    {
        public FloatAsset asset;

        protected override NumberAsset<float> _asset => asset;
    }
}
