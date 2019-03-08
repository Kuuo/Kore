using UnityEditor;
using Kore.Variables;
using Kore.Events;

namespace KoreEditor.Variables
{
    [CustomEditor(typeof(IntAsset))]
    public class IntAssetEditor : ValueAssetEditor<int, IntAsset, IntGameEvent>
    {
    }
}