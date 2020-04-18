using UnityEngine;
using Kore.Events;

namespace Kore.Variables
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Value/Bool")]
    public class BoolAsset : ValueAsset<bool, BoolGameEvent>
    {
    }
}
