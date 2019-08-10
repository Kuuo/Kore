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
                Debug.LogError($"Scene [{newScenePath}] is not in the build menu");
                return;
            }

            property.intValue = newIndex;
        }
    }
}
