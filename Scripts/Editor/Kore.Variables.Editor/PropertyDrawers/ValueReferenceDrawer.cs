using UnityEditor;
using UnityEngine;
using Kore.Variables;

namespace Kore.Variables.Editor
{
    [CustomPropertyDrawer(typeof(IntReference))]
    [CustomPropertyDrawer(typeof(FloatReference))]
    [CustomPropertyDrawer(typeof(BoolReference))]
    public class ValueReferenceDrawer : PropertyDrawer
    {
        private readonly string[] popupOptions = { "Use Local", "Use Asset" };

        private readonly GUIStyle popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
        {
            imagePosition = ImagePosition.ImageOnly
        };

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            // Get properties
            SerializedProperty useLocal = property.FindPropertyRelative("useLocalValue");
            SerializedProperty localValue = property.FindPropertyRelative("localValue");
            SerializedProperty valueAsset = property.FindPropertyRelative("valueAsset");

            // Calculate rect for configuration button
            Rect buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int result = EditorGUI.Popup(buttonRect, useLocal.boolValue ? 0 : 1, popupOptions, popupStyle);

            useLocal.boolValue = result == 0;

            EditorGUI.PropertyField(position,
                useLocal.boolValue ? localValue : valueAsset,
                GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}
