using System;
using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using Kore.Editor;

namespace Kore.Schedule.Editor
{
    [CustomEditor(typeof(ScheduleRunner))]
    public partial class ScheduleRunnerEditor : UnityEditor.Editor
    {
        private SerializedProperty repeatProp;
        private SerializedProperty scheduleProp;

        private ReorderableList reorderableList;

        private ScheduleRunner Target => target as ScheduleRunner;
        private GameObject SchedulablesHolder
        {
            get
            {
                var holderTransform = Target.transform.Find(SchedulablesHolderName);
                if (!holderTransform)
                {
                    var newHolder = new GameObject(SchedulablesHolderName);
                    holderTransform = newHolder.transform;
                    holderTransform.position = Vector3.zero;
                    holderTransform.parent = Target.transform;
                }
                return holderTransform.gameObject;
            }
        }

        private const float DropdownWidth = 260f;
        private const string SchedulablesHolderName = "SchedulablesHolder";

        public void OnEnable()
        {
            repeatProp = serializedObject.FindProperty(nameof(ScheduleRunner.repeat));
            scheduleProp = serializedObject.FindProperty(nameof(ScheduleRunner.schedule));

            reorderableList = new ReorderableList(serializedObject, scheduleProp)
            {
                drawHeaderCallback = drawHeaderCallback,
                drawElementCallback = drawElementCallback,
                onAddDropdownCallback = onAddDropdownCallback,
                onRemoveCallback = onRemoveCallback
            };
        }

        private void onRemoveCallback(ReorderableList list)
        {
            int index = list.index;
            DestroyImmediate(Target.schedule[index]);
            ArrayUtility.RemoveAt(ref Target.schedule, index);

            if (Target.schedule.Length == 0)
            {
                DestroyImmediate(SchedulablesHolder);
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(repeatProp);
            reorderableList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }

        private void drawHeaderCallback(Rect rect)
        {
            EditorGUI.LabelField(rect, scheduleProp.displayName);
        }

        private void drawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            rect.y += 2;
            rect.height -= 4;
            EditorGUI.PropertyField(rect, scheduleProp.GetArrayElementAtIndex(index), GUIContent.none);
        }

        private void onAddDropdownCallback(Rect buttonRect, ReorderableList list)
        {
            var dropdown = new SubTypesDropdown(typeof(Schedulable), AddSchedulable);

            buttonRect.xMin = buttonRect.xMax - DropdownWidth;
            dropdown.Show(buttonRect);
        }

        private void AddSchedulable(Type schedulableType)
        {
            var newSchedulable = SchedulablesHolder.AddComponent(schedulableType) as Schedulable;
            ArrayUtility.Add(ref Target.schedule, newSchedulable);
        }
    }
}
