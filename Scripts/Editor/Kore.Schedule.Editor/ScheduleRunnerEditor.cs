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
        private SerializedProperty runOnStartProp;
        private SerializedProperty repeatProp;
        private SerializedProperty scheduleProp;

        private ReorderableList reorderableList;

        private ScheduleRunner Target => target as ScheduleRunner;
        private GameObject SchedulablesHolder
        {
            get
            {
                var holderTransform = Target.transform.Find(ScheduleHolderName);
                if (!holderTransform)
                {
                    holderTransform = (new GameObject(ScheduleHolderName)).transform;
                    holderTransform.parent = Target.transform;
                    holderTransform.localPosition = Vector3.zero;
                    holderTransform.localScale = Vector3.one;
                }
                return holderTransform.gameObject;
            }
        }

        private const float DropdownWidth = 260f;
        private const string ScheduleHolderName = "[ScheduleHolder]";

        public void OnEnable()
        {
            runOnStartProp = serializedObject.FindProperty(nameof(ScheduleRunner.runOnStart));
            repeatProp = serializedObject.FindProperty(nameof(ScheduleRunner.repeat));
            scheduleProp = serializedObject.FindProperty(nameof(ScheduleRunner.schedule));

            reorderableList = ReorderableListHelper.CreateSimple(serializedObject, scheduleProp)
                                                   .OnAddDropdown(OnAddDropdownCallback)
                                                   .OnRemove(OnRemoveCallback);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(runOnStartProp);

            EditorGUILayout.PropertyField(repeatProp);
            if (repeatProp.intValue < ScheduleRunner.RepeatInfCount)
            {
                repeatProp.intValue = ScheduleRunner.RepeatInfCount;
            }
            EditorGUILayout.Space();

            reorderableList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }

        private void OnAddDropdownCallback(Rect buttonRect, ReorderableList list)
        {
            var dropdown = new SubTypesDropdown(typeof(Schedulable), AddSchedulable);

            buttonRect.xMin = buttonRect.xMax - DropdownWidth;

            dropdown.Add(null);
            dropdown.Show(buttonRect);
        }

        private void AddSchedulable(Type schedulableType)
        {
            if (schedulableType == null)
            {
                ArrayUtility.Add(ref Target.schedule, null);
                return;
            }

            var newSchedulable = SchedulablesHolder.AddComponent(schedulableType) as Schedulable;
            ArrayUtility.Add(ref Target.schedule, newSchedulable);
        }

        private void OnRemoveCallback(ReorderableList list)
        {
            int index = list.index;
            DestroyImmediate(Target.schedule[index]);
            ArrayUtility.RemoveAt(ref Target.schedule, index);

            if (Target.schedule.Length == 0)
            {
                DestroyImmediate(SchedulablesHolder);
            }
        }
    }
}
