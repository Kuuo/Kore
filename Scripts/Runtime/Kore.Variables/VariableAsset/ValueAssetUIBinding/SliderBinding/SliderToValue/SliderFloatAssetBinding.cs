using UnityEngine;
using Kore.Events;

namespace Kore.Variables.UIBinding
{
    [AddComponentMenu("Kore/ValueAssetUIBinding/Slider/SliderToValue/SliderFloatAssetBinding")]
    public class SliderFloatAssetBinding : SliderValueAssetBinding<float, FloatAsset, FloatGameEvent>
    {
    }
}
