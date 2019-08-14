using System;
using System.Collections.Generic;
using UnityEditor;

namespace Kore.Editor
{
    public static class EditorBuildSettingsUtil
    {
        private static void AddBuildSettingsSceneUnChecked(string sceneAssetPath, bool enabled = true)
        {
            var list = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes)
            {
                new EditorBuildSettingsScene(sceneAssetPath, enabled)
            };

            EditorBuildSettings.scenes = list.ToArray();
        }

        public static void AddBuildSettingsScene(string sceneAssetPath, bool enabled = true)
        {
            if (string.IsNullOrEmpty(sceneAssetPath))
                throw new ArgumentException($"Argument {nameof(sceneAssetPath)} is null or empty.");

            var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(sceneAssetPath);

            if (sceneAsset == null)
                throw new ArgumentException($"Asset at {sceneAssetPath} is not a valid SceneAsset.");

            AddBuildSettingsSceneUnChecked(sceneAssetPath, enabled);
        }

        public static void AddBuildSettingsScene(SceneAsset sceneAsset, bool enabled = true)
        {
            if (sceneAsset == null)
                throw new ArgumentNullException(nameof(sceneAsset));

            string sceneAssetPath = AssetDatabase.GetAssetPath(sceneAsset);

            if (string.IsNullOrEmpty(sceneAssetPath))
                throw new ArgumentException($"{nameof(sceneAsset)} is not a valid asset.");

            AddBuildSettingsSceneUnChecked(sceneAssetPath, enabled);
        }

        public static (EditorBuildSettingsScene scene, int index) FindBuildSettinsScene(SceneAsset sceneAsset)
        {
            if (sceneAsset == null)
                return (null, -1);

            string sceneAssetPath = AssetDatabase.GetAssetPath(sceneAsset);

            if (string.IsNullOrEmpty(sceneAssetPath))
                return (null, -1);

            var scenes = EditorBuildSettings.scenes;
            string sceneAssetGUID = AssetDatabase.AssetPathToGUID(sceneAssetPath);

            for (int i = 0, len = scenes.Length; i < len; i++)
            {
                if (scenes[i].guid.ToString() == sceneAssetGUID) return (scenes[i], i);
            }

            return (null, -1);
        }

        public static void OpenBuildSettings()
        {
            EditorApplication.ExecuteMenuItem("File/Build Settings...");
        }
    }
}
