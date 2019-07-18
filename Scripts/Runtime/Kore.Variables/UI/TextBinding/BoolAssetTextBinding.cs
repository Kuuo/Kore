using UnityEngine;

namespace Kore.Variables.UI
{
    [AddComponentMenu("Kore/UI/TextBinding/BoolAssetTextBinding")]
    public class BoolAssetTextBinding : ValueAssetTextBinding<bool>
    {
        public BoolAsset asset;

        protected override ValueAsset<bool> valueAsset => asset;
    }
}
