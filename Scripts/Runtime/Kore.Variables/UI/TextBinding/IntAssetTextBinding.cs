using UnityEngine;

namespace Kore.Variables.UI
{
    [AddComponentMenu("Kore/UI/TextBinding/IntAssetTextBinding")]
    public class IntAssetTextBinding : ValueAssetTextBinding<int>
    {
        public IntAsset asset;

        protected override ValueAsset<int> valueAsset => asset;

        protected override int value => asset.Value;
    }
}
