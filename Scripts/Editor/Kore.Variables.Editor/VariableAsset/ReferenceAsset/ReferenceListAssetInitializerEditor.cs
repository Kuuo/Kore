using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using Kore;
using Kore.Editor;
using System;

namespace Kore.Variables.Editor
{
    [CustomEditor(typeof(ReferenceListAssetInitializer))]
    public class ReferenceListAssetInitializerEditor : UnityEditor.Editor
    {
        private ReferenceListAssetInitializer Target => target as ReferenceListAssetInitializer;

        private Type objType => Target.listAsset.GetType().BaseType.GenericTypeArguments[0];

        private SerializedProperty propListAsset;
        private SerializedProperty propTargets;

        private ReorderableList reorderableList;

        private readonly string propNameListAsset = nameof(ReferenceListAssetInitializer.listAsset);
        private readonly string propNameTargets = nameof(ReferenceListAssetInitializer.targets);

        private void OnEnable()
        {
            propListAsset = serializedObject.FindProperty(propNameListAsset);
            propTargets = serializedObject.FindProperty(propNameTargets);

            reorderableList = ReorderableListHelper.CreateSimple(serializedObject, propTargets)
                                                   .OnDrawElement(DrawTargetsElement);
        }

        private void DrawTargetsElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            rect.y += 2;
            rect.height -= 4;

            var targetProp = propTargets.GetArrayElementAtIndex(index);
            targetProp.objectReferenceValue = EditorGUI.ObjectField(rect, GUIContent.none, targetProp.objectReferenceValue, objType, true);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(propListAsset);

            if (propListAsset.objectReferenceValue)
            {
                reorderableList.DoLayoutList();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
