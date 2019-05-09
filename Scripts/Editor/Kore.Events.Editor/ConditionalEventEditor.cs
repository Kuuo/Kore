using UnityEngine;
using UnityEditor;
using Kore.Events;
using Kore.Editor;

namespace Kore.Events.Editor
{
    [CustomEditor(typeof(ConditionalEvent))]
    public class ConditionalEventEditor : UnityEditor.Editor
    {
        private SerializedProperty checkAllConditionsProp;
        private SerializedProperty actionsProp;

        private readonly string checkAllConditionsPropName = nameof(ConditionalEvent.checkAllConditions);
        private readonly string actionsPropName = nameof(ConditionalEvent.actions);

        private void OnEnable()
        {
            checkAllConditionsProp = serializedObject.FindProperty(checkAllConditionsPropName);
            actionsProp = serializedObject.FindProperty(actionsPropName);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(checkAllConditionsProp);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Conditional Actions", EditorStyles.boldLabel);

            for (int i = 0; i < actionsProp.arraySize; i++)
            {
                var prop = actionsProp.GetArrayElementAtIndex(i);
                DoConditionalActionDraw(prop, i);
            }

            DoAddButtonDraw();
            serializedObject.ApplyModifiedProperties();
        }

        private void DoConditionalActionDraw(SerializedProperty prop, int index)
        {
            using (new EditorGUILayout.VerticalScope(GUI.skin.box))
            using (new EditorGUI.IndentLevelScope())
            {
                bool expanded = EditorGUILayout.PropertyField(prop);
                DoRemoveButtonDraw(index);

                if (expanded)
                {
                    var descProp = prop.FindPropertyRelative(nameof(ConditionalEvent.ConditionalAction.description));
                    var conditionsProp = prop.FindPropertyRelative(nameof(ConditionalEvent.ConditionalAction.conditions));
                    var actionProp = prop.FindPropertyRelative(nameof(ConditionalEvent.ConditionalAction.action));

                    EditorGUILayout.PropertyField(descProp);
                    EditorGUILayout.PropertyField(conditionsProp, true);
                    EditorGUILayout.PropertyField(actionProp);
                }
            }
        }

        private void DoRemoveButtonDraw(int index)
        {
            var iconToolbarMinus = new GUIContent(EditorGUIUtility.IconContent("Toolbar Minus"))
            {
                tooltip = "Right Click To Remove This Entry"
            };

            Vector2 iconSize = GUIStyle.none.CalcSize(iconToolbarMinus);
            var lastRect = GUILayoutUtility.GetLastRect();

            Rect removeBtnRect = new Rect(lastRect.xMax - iconSize.x - 8f, lastRect.y, iconSize.x, iconSize.y);
            if (GUI.Button(removeBtnRect, iconToolbarMinus, GUIStyle.none))
            {
                actionsProp.DeleteArrayElementAtIndex(index);
                serializedObject.ApplyModifiedProperties();
            }
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
