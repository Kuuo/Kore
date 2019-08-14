using UnityEngine;
using UnityEditor;
using Kore;

namespace Kore.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(TagFieldAttribute))]
    public class TagFieldPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.LabelField(position, "TagFieldAttribute ERROR");
                Debug.Log("[TagFieldAttribute] can only be used at string field",
                           property.serializedObject.targetObject);
                return;
            }

            label = EditorGUI.BeginProperty(position, label, property);
            if (string.IsNullOrEmpty(property.stringValue))
            {
                property.stringValue = "Untagged";
            }

            property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
            EditorGUI.EndProperty();
        }
    }
}
