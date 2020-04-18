using UnityEngine;
using Kore.Events;

namespace Kore.Variables.UIBinding
{
    [AddComponentMenu("Kore/ValueAssetUIBinding/Slider/SliderToValue/SliderIntAssetBinding")]
    public class SliderIntAssetBinding : SliderValueAssetBinding<int, IntAsset, IntGameEvent>
    {
    }
}
