using UnityEngine;
using Kore.Events;

namespace Kore.Variables.UIBinding
{
    [AddComponentMenu("Kore/ValueAssetUIBinding/Text/IntAssetTextBinding")]
    public class IntAssetTextBinding : ValueAssetTextBinding<int, IntAsset, IntGameEvent>
    {
    }
}
