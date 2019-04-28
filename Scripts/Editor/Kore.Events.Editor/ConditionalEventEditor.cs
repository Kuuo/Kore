using UnityEngine;
using UnityEditor;
using Kore.Events;

namespace Kore.Events.Editor
{
    [CustomEditor(typeof(ConditionalEvent))]
    public class ConditionalEventEditor : UnityEditor.Editor
    {
        private SerializedProperty actionsProp;

        private readonly string actionsPropName = nameof(ConditionalEvent.actions);

        private void OnEnable()
        {
            actionsProp = serializedObject.FindProperty(actionsPropName);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.Space();

            for (int i = 0; i < actionsProp.arraySize; i++)
            {
                var prop = actionsProp.GetArrayElementAtIndex(i);
                DoConditionalActionDraw(prop, i);
            }

            DoAddButtonDraw();
            EditorGUILayout.Space();
            serializedObject.ApplyModifiedProperties();
        }

        private void DoConditionalActionDraw(SerializedProperty prop, int index)
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUI.indentLevel++;

            if (EditorGUILayout.PropertyField(prop))
            {
                var curProp = prop.Copy();
                if (curProp.NextVisible(true))
                {
                    do
                    {
                        EditorGUILayout.PropertyField(curProp, true);
                    } while (curProp.NextVisible(false));
                }
                GUILayout.Space(6f);
                if (GUILayout.Button("Remove This Entry"))
                {
                    actionsProp.DeleteArrayElementAtIndex(index);
                }
                GUILayout.Space(6f);
            }
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
        }

        private void DoAddButtonDraw()
        {
            GUILayout.Space(6f);
            if (GUILayout.Button("Add New Entry", GUILayout.Height(24f)))
            {
                actionsProp.arraySize++;
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
