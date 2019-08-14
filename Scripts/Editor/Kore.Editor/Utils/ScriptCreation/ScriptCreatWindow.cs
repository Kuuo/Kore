using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace Kore.Editor
{
    public class ScriptCreatWindow : EditorWindow
    {
        public List<string> templates;
        public List<MacroReplacePair> macroReplacePairs;
        public string currentTemplate;
        public string finalScriptName;

        private ReorderableList templateList;
        private ReorderableList macroReplaceList;

        private string selectionPath => PathUtil.GetCurrentSelectionDirectory();
        private string destPath => Path.Combine(selectionPath, finalScriptName + ".cs");

        private const string ScriptTemplateFilter = "_ScriptTemplate";
        private const string EditorPrefKeyScriptCreat = "EditorPref-ScriptCreat";

        private void OnEnable()
        {
            if (EditorPrefs.HasKey(EditorPrefKeyScriptCreat))
            {
                var json = EditorPrefs.GetString(EditorPrefKeyScriptCreat);
                EditorJsonUtility.FromJsonOverwrite(json, this);
            }

            UpdateTemplateList();
            UpdateMacroReplaceList();
        }

        private void OnDisable()
        {
            var json = EditorJsonUtility.ToJson(this);
            EditorPrefs.SetString(EditorPrefKeyScriptCreat, json);
        }

        private void UpdateTemplateList()
        {
            templates = AssetDatabase.FindAssets(ScriptTemplateFilter)
                                     .Select(id => AssetDatabase.GUIDToAssetPath(id))
                                     .ToList();

            templateList = new ReorderableList(templates, typeof(string), false, false, false, false);
            templateList.headerHeight = 3f;

            templateList.onSelectCallback = OnSelectTemplate;

            if (!string.IsNullOrEmpty(currentTemplate))
            {
                templateList.index = templates.IndexOf(currentTemplate);
            }
        }

        private void OnSelectTemplate(ReorderableList reorderableList)
        {
            var selectedTemplate = (string)reorderableList.list[reorderableList.index];

            if (selectedTemplate == currentTemplate) return;

            currentTemplate = selectedTemplate;

            UpdateMacroReplacePiars();
            UpdateMacroReplaceList();
        }

        private void UpdateMacroReplacePiars()
        {
            if (string.IsNullOrEmpty(currentTemplate)) return;

            var templateContent = File.ReadAllText(currentTemplate);

            var macroSet = new HashSet<string>();
            macroReplacePairs = new List<MacroReplacePair>(8);
            var regex = new Regex(@"[#]\w*[#]");
            var matchedMacros = regex.Matches(templateContent);

            foreach (var item in matchedMacros)
            {
                var macro = item.ToString();
                if (!macroSet.Contains(macro))
                {
                    macroSet.Add(macro);
                    macroReplacePairs.Add(new MacroReplacePair { Macro = macro });
                }
            }
        }

        private void UpdateMacroReplaceList()
        {
            if (macroReplacePairs == null) return;

            macroReplaceList = new ReorderableList(macroReplacePairs, typeof(MacroReplacePair), false, true, false, false);

            macroReplaceList.drawHeaderCallback = (rect) =>
            {
                rect.x += 6f;
                rect.width /= 2f;
                EditorGUI.LabelField(rect, "Macro");

                rect.x += rect.width;
                EditorGUI.LabelField(rect, "Replace");
            };

            macroReplaceList.drawElementCallback = DrawMacroReplaceElement;
        }

        private void DrawMacroReplaceElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            rect.y += 2;
            rect.height -= 4;

            var pair = macroReplaceList.list[index] as MacroReplacePair;

            rect.width = (rect.width - 8f) / 2f;
            EditorGUI.LabelField(rect, pair.Macro);

            rect.x += rect.width + 8f;
            pair.Replace = EditorGUI.TextField(rect, pair.Replace);

            if (pair.Macro == "#SCRIPTNAME#")
            {
                finalScriptName = pair.Replace;
            }
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical(EditorStyles.inspectorFullWidthMargins);
            GUILayout.Label("Choose Script Template:", EditorStyles.boldLabel);

            var refreshRect = GUILayoutUtility.GetLastRect();
            refreshRect.xMin = refreshRect.xMax - 100f;
            DrawRefreshArea(refreshRect);

            templateList.DoLayoutList();

            if (macroReplaceList != null)
            {
                GUILayout.Label("Set macro replaces:", EditorStyles.boldLabel);
                macroReplaceList.DoLayoutList();

                bool inputComplete = !macroReplacePairs.Any(pair => string.IsNullOrEmpty(pair.Replace));

                if (!inputComplete)
                {
                    EditorGUILayout.HelpBox("Macro replace is not complete", MessageType.Info);
                }
                else
                {
                    DrawCreateArea();
                }
            }
            EditorGUILayout.EndVertical();
        }

        private void DrawRefreshArea(Rect rect)
        {
            if (GUI.Button(rect, "Refresh"))
            {
                UpdateTemplateList();
                Repaint();
            }
        }

        private void DrawCreateArea()
        {
            finalScriptName = EditorGUILayout.TextField("Final Script Name", finalScriptName);
            EditorGUILayout.Space();

            if (string.IsNullOrEmpty(finalScriptName))
            {
                EditorGUILayout.HelpBox("Script Name is Empty", MessageType.Info);
                return;
            }
            if (string.IsNullOrEmpty(selectionPath))
            {
                EditorGUILayout.HelpBox("Please select a folder in project window as destination", MessageType.Warning);
                return;
            }

            GUILayout.Label("Script will be created at:", EditorStyles.boldLabel);
            GUILayout.Label(selectionPath);

            if (GUILayout.Button("Create"))
            {
                var creator = new ScriptCreator();

                macroReplacePairs.ForEach(p => creator.AddMacroReplace(p));

                creator.Create(currentTemplate, destPath);
            }
        }

        [MenuItem("Kore/New Script/From Template #&T")]
        private static void CreateWindow()
        {
            var window = GetWindow<ScriptCreatWindow>();
            window.minSize = new Vector2(400f, 120f);
            window.titleContent = new GUIContent("Script Create");
            window.Show();
        }
    }
}
