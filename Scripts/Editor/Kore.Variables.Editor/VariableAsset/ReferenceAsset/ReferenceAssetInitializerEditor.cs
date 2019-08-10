using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using Kore.Editor;
using System;

namespace Kore.Variables.Editor
{
    [CustomEditor(typeof(ReferenceAssetInitializer))]
    public class ReferenceAssetInitializerEditor : UnityEditor.Editor
    {
        private ReferenceAssetInitializer Target => target as ReferenceAssetInitializer;

        private SerializedProperty configListProp;

        private ReorderableList reorderableList;

        private readonly string propNameDataList = nameof(ReferenceAssetInitializer.configList);
        private readonly string propNameAsset = nameof(ReferenceAssetInitializer.InitConfig.asset);
        private readonly string propNameTarget = nameof(ReferenceAssetInitializer.InitConfig.target);
        private readonly float spaceBetweenField = 8f;

        protected void OnEnable()
        {
            configListProp = serializedObject.FindProperty(propNameDataList);

            reorderableList = ReorderableListHelper.CreateSimple(serializedObject, configListProp)
                                                   .OnHeader(DrawListHeaderCallBack)
                                                   .OnDrawElement(DrawDataElementCallBack);
        }

        private void DrawListHeaderCallBack(Rect rect)
        {
            rect.x += 16f;
            rect.width /= 2f;
            EditorGUI.LabelField(rect, "Asset");

            rect.x += rect.width;
            EditorGUI.LabelField(rect, "Target");
        }

        private void DrawDataElementCallBack(Rect rect, int index, bool isActive, bool isFocused)
        {
            rect.y += 2;
            rect.height -= 4;

            var config = configListProp.GetArrayElementAtIndex(index);

            var assetProp = config.FindPropertyRelative(propNameAsset);
            var targetProp = config.FindPropertyRelative(propNameTarget);

            rect.width = (rect.width - spaceBetweenField) / 2f;
            EditorGUI.ObjectField(rect, assetProp, GUIContent.none);

            rect.x += rect.width + spaceBetweenField;
            EditorGUI.ObjectField(rect, targetProp, Target.configList[index].referenceType, GUIContent.none);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.Space();
            reorderableList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
