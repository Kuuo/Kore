using UnityEditor;
using Kore.Variables;
using Kore.Events;

namespace Kore.Variables.Editor
{
    [CustomEditor(typeof(BoolAsset))]
    public class BoolAssetEditor : ValueAssetEditor<bool, BoolAsset, BoolGameEvent>
    {
    }
}
