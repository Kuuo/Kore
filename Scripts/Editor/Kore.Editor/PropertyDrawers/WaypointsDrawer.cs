using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;

namespace Kore.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(Waypoints))]
    public class WaypointsDrawer : PropertyDrawer
    {
        private ReorderableList reorderableList;
        private SerializedProperty listProp;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return reorderableList?.GetHeight() ?? EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();

            listProp = property.FindPropertyRelative(nameof(Waypoints.list));
            reorderableList = ReorderableListHelper.CreateSimple(listProp.serializedObject, listProp)
                                                   .OnElementHeight(GetElementHeightCallback)
                                                   .OnDrawElement(DrawElementCallback);
            reorderableList.DoList(position);

            if (EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
            }
        }

        private float GetElementHeightCallback(int index)
        {
            return EditorGUIUtility.singleLineHeight * 2 + 6;
        }

        private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            var curPoseProp = listProp.GetArrayElementAtIndex(index);

            var positionProp = curPoseProp.FindPropertyRelative(nameof(Waypoints.Pose.position));
            var rotationProp = curPoseProp.FindPropertyRelative(nameof(Waypoints.Pose.rotation));

            var drawRect = new Rect(rect);
            drawRect.height -= 4;
            drawRect.y += 2;
            drawRect.height = EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(drawRect, positionProp);

            drawRect.y += 2 + EditorGUIUtility.singleLineHeight;

            var newRotation = EditorGUI.Vector3Field(drawRect, rotationProp.displayName, rotationProp.quaternionValue.eulerAngles);
            rotationProp.quaternionValue = Quaternion.Euler(newRotation);

            // EditorGUI.PropertyField(drawRect, rotationProp);
        }
    }
}
