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
        private SerializedProperty runDirectlyOnStartProp;
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
                    var newHolder = new GameObject(ScheduleHolderName);
                    holderTransform = newHolder.transform;
                    holderTransform.position = Vector3.zero;
                    holderTransform.parent = Target.transform;
                }
                return holderTransform.gameObject;
            }
        }

        private const float DropdownWidth = 260f;
        private const string ScheduleHolderName = "[ScheduleHolder]";

        public void OnEnable()
        {
            runDirectlyOnStartProp = serializedObject.FindProperty(nameof(ScheduleRunner.runDirectlyOnStart));
            repeatProp = serializedObject.FindProperty(nameof(ScheduleRunner.repeat));
            scheduleProp = serializedObject.FindProperty(nameof(ScheduleRunner.schedule));

            reorderableList = ReorderableListHelper.CreateSimple(serializedObject, scheduleProp)
                                                   .OnAddDropdown(OnAddDropdownCallback)
                                                   .OnRemove(OnRemoveCallback);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(runDirectlyOnStartProp);

            EditorGUILayout.PropertyField(repeatProp);
            if (repeatProp.intValue < ScheduleRunner.RepeatInfCount)
            {
                repeatProp.intValue = ScheduleRunner.RepeatInfCount;
            }

            reorderableList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }

        private void OnAddDropdownCallback(Rect buttonRect, ReorderableList list)
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
