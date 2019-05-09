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

            EditorGUILayout.PropertyField(prop, true);

            // if (EditorGUILayout.PropertyField(prop))
            // {
            //     var curProp = prop.Copy();
            //     if (curProp.NextVisible(true))
            //     {
            //         do
            //         {
            //             EditorGUILayout.PropertyField(curProp, true);
            //         } while (curProp.NextVisible(false));
            //     }
            //     GUILayout.Space(6f);
            //     if (GUILayout.Button("Remove This Entry"))
            //     {
            //         actionsProp.DeleteArrayElementAtIndex(index);
            //     }
            //     GUILayout.Space(6f);
            // }
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
        }

        private void DoAddButtonDraw()
        {
            GUILayout.Space(6f);

            var addButtonContent = new GUIContent("Add New Entry");
            var addButtonWidth = 160f;

            var buttonRect = GUILayoutUtility.GetRect(addButtonContent, GUI.skin.button);
            buttonRect.x += (buttonRect.width - addButtonWidth) / 2f;
            buttonRect.width = addButtonWidth;

            if (GUI.Button(buttonRect, addButtonContent))
            {
                actionsProp.arraySize++;
            }
        }
    }
}
