using UnityEngine;
using UnityEditor;

namespace Kore.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SceneNameAttribute))]
    public class SceneNamePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                Debug.LogError("[SceneNameAttribute] can only be used at string field",
                               property.serializedObject.targetObject);
                return;
            }

            var oldScenePath = property.stringValue;
            var oldSceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(oldScenePath);

            var newSceneAsset = EditorGUI.ObjectField(position, property.displayName, oldSceneAsset, typeof(SceneAsset), false) as SceneAsset;

            if (newSceneAsset == oldSceneAsset) return;

            var buildScenes = EditorBuildSettings.scenes;

            var newScenePath = AssetDatabase.GetAssetPath(newSceneAsset);
            int newIndex = ArrayUtility.FindIndex(buildScenes, s => s.path == newScenePath);

            if (newIndex == -1)
            {
                Debug.LogError($"Scene [{newScenePath}] is not in the build menu");
                return;
            }

            property.stringValue = newScenePath;
        }
    }
}
