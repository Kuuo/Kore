using UnityEngine;
using Kore;

namespace Kore.Variables
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Value/String")]
    public class StringAsset : ValueAsset
    {
        [TextArea]
        public string value;

        public override object objectValue => value;
    }
}
