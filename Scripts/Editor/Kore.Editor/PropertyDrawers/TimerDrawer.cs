using UnityEngine;
using UnityEditor;
using Kore;

namespace Kore.Editor
{
    [CustomPropertyDrawer(typeof(Timer))]
    public class TimerDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var lengthProp = property.FindPropertyRelative(nameof(Timer.length));

            label = EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, lengthProp, label);

            if (EditorGUI.EndChangeCheck())
            {
                lengthProp.serializedObject.ApplyModifiedProperties();
            }
            EditorGUI.EndProperty();
        }
    }
}
