using UnityEngine;

namespace Kore.Variables
{
    [System.Serializable]
    public class FloatReference : ValueReference<float>
    {
        [SerializeField]
        protected FloatAsset asset;

        protected override ValueAsset<float> valueAsset => asset;
    }
}
