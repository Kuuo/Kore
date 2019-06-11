using UnityEditor;
using Kore.Variables;
using Kore.Events;

namespace Kore.Variables.Editor
{
    [CustomEditor(typeof(FloatAsset))]
    public class FloatAssetEditor : ValueAssetEditor<float, FloatAsset, FloatGameEvent>
    {
    }
}
