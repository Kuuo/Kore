using UnityEngine;

namespace Kore.Variables
{
    [System.Serializable]
    public class BoolReference : ValueReference<bool>
    {
        [SerializeField]
        protected BoolAsset asset;

        protected override ValueAsset<bool> valueAsset => asset;
    }
}
