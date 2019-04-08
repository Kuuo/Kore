using UnityEditor;
using Kore.Variables;
using Kore.Events;

namespace Kore.Editor.Variables
{
    [CustomEditor(typeof(IntAsset))]
    public class IntAssetEditor : ValueAssetEditor<int, IntAsset, IntGameEvent>
    {
    }
}
