using System;
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
        public string scriptName;

        private ReorderableList templateList;
        private ReorderableList macroReplaceList;

        private string selectionPath => PathUtils.GetCurrentSelectionPath();
        private string destPath => Path.Combine(selectionPath, scriptName + ".cs");

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

            templateList = new ReorderableList(templates, typeof(string), false, true, false, false);
            templateList.footerHeight = 1f;

            templateList.drawHeaderCallback = (rect) =>
            {
                EditorGUI.LabelField(rect, "Script Templates");
            };

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
                scriptName = pair.Replace;
            }
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();
            scriptName = EditorGUILayout.TextField("Script Name", scriptName);
            EditorGUILayout.Space();

            templateList.DoLayoutList();
            DrawRefreshArea();
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            if (macroReplaceList != null)
            {
                macroReplaceList.DoLayoutList();

                bool inputComplete = !macroReplacePairs.Any(pair => string.IsNullOrEmpty(pair.Replace));

                if (!inputComplete)
                {
                    EditorGUILayout.HelpBox("Macro Replace is not complete", MessageType.Warning);
                }
                else
                {
                    DrawCreateArea();
                }
            }
        }

        private void DrawRefreshArea()
        {
            if (GUILayout.Button("Refresh Templates"))
            {
                UpdateTemplateList();
                Repaint();
            }
        }

        private void DrawCreateArea()
        {
            if (string.IsNullOrEmpty(scriptName))
            {
                EditorGUILayout.HelpBox("Script Name is Empty", MessageType.Warning);
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

        [MenuItem("Kore/New Script/From Template")]
        private static void CreateWindow()
        {
            var window = GetWindow<ScriptCreatWindow>();
            window.minSize = new Vector2(400f, 120f);
            window.titleContent = new GUIContent("Script Create");
            window.Show();
        }
    }
}
