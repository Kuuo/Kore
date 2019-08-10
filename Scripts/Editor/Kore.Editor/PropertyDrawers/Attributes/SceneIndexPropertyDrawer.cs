using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Kore.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SceneIndexAttribute))]
    public class SceneIndexPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Integer)
            {
                EditorGUI.LabelField(position, "SceneIndexAttribute ERROR", EditorStyles.boldLabel);
                Debug.LogError("[SceneIndexAttribute] can only be used at int field",
                               property.serializedObject.targetObject);
                return;
            }

            int oldIndex = property.intValue;
            var buildScenes = EditorBuildSettings.scenes;

            if (oldIndex < 0 || oldIndex >= buildScenes.Length)
            {
                Debug.LogError("SceneIndex error", property.serializedObject.targetObject);
                return;
            }

            var oldScenePath = buildScenes[oldIndex].path;
            var oldSceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(oldScenePath);

            var newSceneAsset = EditorGUI.ObjectField(position, property.displayName, oldSceneAsset, typeof(SceneAsset), false) as SceneAsset;

            if (newSceneAsset == oldSceneAsset) return;

            var newScenePath = AssetDatabase.GetAssetPath(newSceneAsset);
            int newIndex = ArrayUtility.FindIndex(buildScenes, s => s.path == newScenePath);

            if (newIndex == -1)
            {
                var newList = new List<EditorBuildSettingsScene>(buildScenes);
                newList.Add(new EditorBuildSettingsScene(newScenePath, true));
                EditorBuildSettings.scenes = newList.ToArray();

                newIndex = buildScenes.Length - 1;
                Debug.Log($"Scene [{newScenePath}] has been added to the build settings");
            }

            buildScenes[newIndex].enabled = true;
            property.intValue = newIndex;
        }
    }
}
