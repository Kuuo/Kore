using UnityEngine;

namespace Kore.Variables
{
    [System.Serializable]
    public class IntReference : ValueReference<int>
    {
        [SerializeField]
        protected IntAsset asset;

        protected override ValueAsset<int> valueAsset => asset;
    }
}
