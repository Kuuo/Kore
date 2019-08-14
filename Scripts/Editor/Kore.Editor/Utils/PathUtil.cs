using UnityEngine;
using UnityEditor;

namespace Kore.Editor
{
    public class PathUtil
    {
        public static string GetCurrentSelectionDirectory()
        {
            var selectedObject = Selection.activeObject;

            if (selectedObject == null) return null;

            return GetAssetDirectory(selectedObject);
        }

        public static string GetAssetDirectory(Object asset)
        {
            var path = AssetDatabase.GetAssetPath(asset);

            if (string.IsNullOrEmpty(path)) return null;

            return AssetDatabase.IsValidFolder(path) ? path :
                path.Substring(0, path.LastIndexOf('/'));
        }
    }
}
