using System;
using UnityEngine;
using UnityEditor;
using Kore;

namespace Kore.Editor
{
    [CustomPropertyDrawer(typeof(AutoHookAttribute))]
    public class AutoHookAttributeDrawer : PropertyDrawer
    {
        private Type componentType;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            property.serializedObject.Update();
            componentType = property.GetFieldType();

            if (!componentType.IsSubclassOf(typeof(Component)))
            {
                Debug.LogError("[AutoHookAttribute] can only be used at Component field.",
                                property.serializedObject.targetObject);
                EditorGUI.LabelField(position, label: label.text, label2: "[AutoHook] ERROR");
                return;
            }

            if (property.objectReferenceValue)
            {
                EditorGUI.BeginChangeCheck();

                property.objectReferenceValue =
                    EditorGUI.ObjectField(position, label, property.objectReferenceValue, componentType, true);

                if (EditorGUI.EndChangeCheck())
                {
                    property.serializedObject.ApplyModifiedProperties();
                }
            }
            else
            {
                position = EditorGUI.PrefixLabel(position, label);
                if (GUI.Button(position, $"AutoHook {componentType.Name}", EditorStyles.miniButton))
                {
                    property.objectReferenceValue = TryAutoHookTarget(property);
                    property.serializedObject.ApplyModifiedProperties();
                }
            }
            EditorGUI.EndProperty();
        }

        private Component TryAutoHookTarget(SerializedProperty property)
        {
            var targetObj = property.serializedObject.targetObject as Component;

            var compoennt = targetObj.gameObject.GetOrAddComponent(componentType);

            return compoennt;
        }
    }
}
