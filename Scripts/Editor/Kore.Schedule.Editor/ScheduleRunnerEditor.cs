using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;

namespace Kore.Schedule.Editor
{
    [CustomEditor(typeof(ScheduleRunner))]
    public class ScheduleRunnerEditor : UnityEditor.Editor
    {
        private SerializedProperty scheduleProp;

        private ReorderableList reorderableList;

        public void OnEnable()
        {
            scheduleProp = serializedObject.FindProperty(nameof(ScheduleRunner.schedule));

            reorderableList = new ReorderableList(serializedObject, scheduleProp)
            {
                drawHeaderCallback = drawHeaderCallback,
                drawElementCallback = drawElementCallback,
                // onAddDropdownCallback = onAddDropdownCallback
            };
        }

        private void drawHeaderCallback(Rect rect)
        {
            EditorGUI.LabelField(rect, "Schedule");
        }

        private void drawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            rect.y += 2;
            rect.height -= 4;
            EditorGUI.PropertyField(rect, scheduleProp.GetArrayElementAtIndex(index), GUIContent.none);
        }

        private void onAddDropdownCallback(Rect buttonRect, ReorderableList list)
        {
            // EditorGUI.Popup()
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
