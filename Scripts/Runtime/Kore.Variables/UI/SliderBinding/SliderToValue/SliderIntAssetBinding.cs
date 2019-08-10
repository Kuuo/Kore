using UnityEngine;
using UnityEngine.UI;
using Kore;

namespace Kore.Variables.UI
{
    [AddComponentMenu("Kore/UI/SliderBinding/SliderIntAssetBinding")]
    public class SliderIntAssetBinding : SliderValueAssetBinding<int>
    {
        public IntAsset asset;

        protected override NumberAsset<int> _asset => asset;
    }
}
