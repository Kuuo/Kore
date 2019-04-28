using UnityEditor;
using Kore.Variables;
using Kore.Events;

namespace Kore.Variables.Editor
{
    [CustomEditor(typeof(IntAsset))]
    public class IntAssetEditor : ValueAssetEditor<int, IntAsset, IntGameEvent>
    {
    }
}
