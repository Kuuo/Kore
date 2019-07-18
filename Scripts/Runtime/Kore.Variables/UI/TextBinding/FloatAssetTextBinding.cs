using UnityEngine;

namespace Kore.Variables.UI
{
    [AddComponentMenu("Kore/UI/TextBinding/FloatAssetTextBinding")]
    public class FloatAssetTextBinding : ValueAssetTextBinding<float>
    {
        public FloatAsset asset;

        protected override ValueAsset<float> valueAsset => asset;
    }
}
