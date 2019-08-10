using UnityEngine;
using UnityEditor;
using System.IO;

namespace Kore.Editor
{
    public class PathUtils
    {
        public static string GetCurrentSelectionPath()
        {
            var path = "";
            var obj = Selection.activeObject;

            if (obj == null) return null;

            path = AssetDatabase.GetAssetPath(obj);

            if (string.IsNullOrEmpty(path)) return null;

            return Directory.Exists(path) ? path : new FileInfo(path).Directory.FullName;
        }
    }
}
