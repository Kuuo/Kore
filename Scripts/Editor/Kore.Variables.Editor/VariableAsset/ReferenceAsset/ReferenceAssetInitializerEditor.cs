using System;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using Kore.Editor;

namespace Kore.Variables.Editor
{
    [CustomEditor(typeof(ReferenceAssetInitializer))]
    public class ReferenceAssetInitializerEditor : UnityEditor.Editor
    {
        private ReferenceAssetInitializer Target => target as ReferenceAssetInitializer;

        public Type referenceType => Target.asset.GetType().BaseType.GenericTypeArguments[0];

        private SerializedProperty propAsset;
        private SerializedProperty propTarget;

        private readonly string propNameAsset = nameof(ReferenceAssetInitializer.asset);
        private readonly string propNameTarget = nameof(ReferenceAssetInitializer.target);

        protected void OnEnable()
        {
            propAsset = serializedObject.FindProperty(propNameAsset);
            propTarget = serializedObject.FindProperty(propNameTarget);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            using (var checkScope = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(propAsset);

                if (checkScope.changed)
                    serializedObject.ApplyModifiedProperties();
            }

            if (!propAsset.objectReferenceValue) return;

            if (propTarget.objectReferenceValue && propTarget.objectReferenceValue.GetType() != referenceType)
            {
                propTarget.objectReferenceValue = null;
                serializedObject.ApplyModifiedProperties();
            }

            using (var checkScope = new EditorGUI.ChangeCheckScope())
            {
                propTarget.objectReferenceValue =
                    EditorGUILayout.ObjectField(
                        propTarget.displayName, propTarget.objectReferenceValue, referenceType, true);

                if (checkScope.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
