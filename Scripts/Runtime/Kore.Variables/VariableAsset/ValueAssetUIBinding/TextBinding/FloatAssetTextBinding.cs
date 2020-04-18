using UnityEngine;
using Kore.Events;

namespace Kore.Variables.UIBinding
{
    [AddComponentMenu("Kore/ValueAssetUIBinding/Text/FloatAssetTextBinding")]
    public class FloatAssetTextBinding : ValueAssetTextBinding<float,FloatAsset,FloatGameEvent>
    {
    }
}
