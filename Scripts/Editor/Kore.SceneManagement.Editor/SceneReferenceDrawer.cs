using System;
using UnityEngine;
using UnityEditor;
using Kore.Editor;

namespace Kore.SceneManagement.Editor
{
    [CustomPropertyDrawer(typeof(SceneReference))]
    public class SceneReferenceDrawer : PropertyDrawer
    {
        private static string TOOLTIP_SCENE_MISSING = "Scene is not in build settings.";

        private static string TOOLTIP_SCENE_DISABLED = "Scene is not enebled in build settings.";

        private readonly string ERROR_SCENE_MISSING =
            TOOLTIP_SCENE_MISSING + "\nAdd it to the build settings now?";

        private readonly string ERROR_SCENE_DISABLED =
            TOOLTIP_SCENE_DISABLED + "\nEnable it in the build settings now?";

        private SerializedProperty sceneAssetProp;
        private SerializedProperty scenePathProp;
        private SerializedProperty sceneIndexProp;
        private SerializedProperty sceneEnabledProp;
        private SceneAsset sceneAsset;

        private GUIContent errorTooltip = new GUIContent("", "error");
        private GUIStyle errorStyle = "CN EntryErrorIconSmall";
        private GUIStyle warnStyle = "CN EntryWarnIconSmall";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            sceneAssetProp = property.FindPropertyRelative(nameof(SceneReference.sceneAsset));
            scenePathProp = property.FindPropertyRelative(nameof(SceneReference.scenePath));
            sceneIndexProp = property.FindPropertyRelative(nameof(SceneReference.sceneIndex));
            sceneEnabledProp = property.FindPropertyRelative(nameof(SceneReference.sceneEnabled));

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            UpdateSceneState();

            position = DisplayErrorsIfNecessary(position);

            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, sceneAssetProp, GUIContent.none, false);
            if (EditorGUI.EndChangeCheck())
            {
                UpdateSceneState();
                property.serializedObject.ApplyModifiedProperties();
            }

            EditorGUI.EndProperty();
        }

        private void UpdateSceneState()
        {
            sceneAsset = sceneAssetProp.objectReferenceValue as SceneAsset;

            if (sceneAsset == null)
            {
                SetErrorSceneState();
                return;
            }

            var search = EditorBuildSettingsUtil.FindBuildSettinsScene(sceneAsset);
            if (search.scene != null)
            {
                sceneIndexProp.intValue = search.index;
                scenePathProp.stringValue = search.scene.path;
                sceneEnabledProp.boolValue = search.scene.enabled;
            }
            else
            {
                SetErrorSceneState();
            }
        }

        private void SetErrorSceneState()
        {
            sceneIndexProp.intValue = -1;
            scenePathProp.stringValue = string.Empty;
            sceneEnabledProp.boolValue = false;
        }

        private void DisplayError(string message)
        {
            int choice = EditorUtility.DisplayDialogComplex("Scene Not In Build",
                message, "Yes", "No", "Open Build Settings");

            if (choice == 0)
            {
                EditorBuildSettingsUtil.AddBuildSettingsScene(sceneAsset);
                sceneIndexProp.intValue = EditorBuildSettings.scenes.Length - 1;
            }
            else if (choice == 2)
            {
                EditorBuildSettingsUtil.OpenBuildSettings();
            }
        }

        private Rect DisplayErrorsIfNecessary(Rect position)
        {
            if (sceneAsset == null) return position;

            Rect warningRect = new Rect(position) { width = 20f };

            if (sceneIndexProp.intValue < 0)
            {
                errorTooltip.tooltip = TOOLTIP_SCENE_MISSING;
                position.xMin = warningRect.xMax;
                if (GUI.Button(warningRect, errorTooltip, errorStyle))
                {
                    DisplayError(ERROR_SCENE_MISSING);
                }
            }
            else if (!sceneEnabledProp.boolValue)
            {
                errorTooltip.tooltip = TOOLTIP_SCENE_DISABLED;
                position.xMin = warningRect.xMax;
                if (GUI.Button(warningRect, errorTooltip, warnStyle))
                {
                    DisplayError(ERROR_SCENE_DISABLED);
                }
            }

            return position;
        }
    }
}
