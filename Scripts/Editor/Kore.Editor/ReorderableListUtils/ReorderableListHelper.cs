using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace Kore.Editor
{
    public static class ReorderableListHelper
    {
        public static ReorderableList GetSimple(SerializedObject serializedObject, SerializedProperty property)
        {
            return new ReorderableList(serializedObject, property)
            {
                drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, property.displayName),
                drawElementCallback = (rect, index, isActive, isFocused) =>
                {
                    rect.y += 2;
                    rect.height -= 4;
                    EditorGUI.PropertyField(rect, property.GetArrayElementAtIndex(index), GUIContent.none);
                }
            };
        }
    }
}
