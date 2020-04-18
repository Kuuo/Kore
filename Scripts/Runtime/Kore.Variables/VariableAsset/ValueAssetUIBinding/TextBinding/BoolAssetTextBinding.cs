using UnityEngine;
using Kore.Events;

namespace Kore.Variables.UIBinding
{
    [AddComponentMenu("Kore/ValueAssetUIBinding/Text/BoolAssetTextBinding")]
    public class BoolAssetTextBinding : ValueAssetTextBinding<bool,BoolAsset,BoolGameEvent>
    {
    }
}
