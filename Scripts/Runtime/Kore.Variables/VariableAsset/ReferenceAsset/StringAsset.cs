using UnityEngine;

namespace Kore.Variables
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Reference/String")]
    public class StringAsset : ReferenceAsset<string>
    {
        public static implicit operator string(StringAsset asset) => asset.reference;
    }
}
