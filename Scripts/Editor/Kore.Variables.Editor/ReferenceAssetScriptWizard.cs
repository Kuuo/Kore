using System.IO;
using UnityEditor;
using Kore.Editor;

namespace Kore.Variables.Editor
{
    public class ReferenceAssetScriptWizard : ScriptableWizard
    {
        public string nameSpace = "Kore.Variables";
        public string referenceTypeName;

        public const string templatePath = "Packages/com.kl6g.kore/Resources/ScriptTemplates/ReferenceAsset_ScriptTemplate.txt";
        public const string nameSpaceContentHolder = "#NAMESPACE#";
        public const string referenceTypeContentHolder = "#REFERENCETYPE#";

        private const string EditorPrefKeyNameSpace = "ReferenceAssetScriptWizard-NameSpace";

        private void OnEnable()
        {
            if (EditorPrefs.HasKey(EditorPrefKeyNameSpace))
            {
                nameSpace = EditorPrefs.GetString(EditorPrefKeyNameSpace);
            }
        }

        private void OnDisable()
        {
            EditorPrefs.SetString(EditorPrefKeyNameSpace, nameSpace);
        }

        private void OnWizardUpdate()
        {
            isValid = !string.IsNullOrEmpty(referenceTypeName);
        }

        private void OnWizardCreate()
        {
            Create(nameSpace, referenceTypeName);
        }

        public static void Create(string nameSpace, string typeName)
        {
            string scriptFileName = typeName + "Asset.cs";
            string currentSelectPath = PathUtil.GetCurrentSelectionDirectory();
            string destPath = Path.Combine(currentSelectPath, scriptFileName);

            var creator = new ScriptCreator()
                          .AddMacroReplace(nameSpaceContentHolder, nameSpace)
                          .AddMacroReplace(referenceTypeContentHolder, typeName);

            creator.Create(templatePath, destPath);
        }

        [MenuItem("Kore/New Script/ReferenceAsset")]
        private static void CreateWindow()
        {
            DisplayWizard<ReferenceAssetScriptWizard>("Create ReferenceAsset Script");
        }
    }
}
