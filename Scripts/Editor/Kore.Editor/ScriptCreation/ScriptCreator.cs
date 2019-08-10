using System.Collections.Generic;
using System.IO;

namespace Kore.Editor
{
    public partial class ScriptCreator
    {
        public string TemplatePath { get; set; }
        public string DestPath { get; set; }
        public List<MacroReplacePair> MacroReplacePairs { get; set; }

        public ScriptCreator AddMacroReplace(MacroReplacePair pair)
        {
            if (MacroReplacePairs == null)
            {
                MacroReplacePairs = new List<MacroReplacePair>(6);
            }

            if (!MacroReplacePairs.Contains(pair))
            {
                MacroReplacePairs.Add(pair);
            }

            return this;
        }

        public ScriptCreator AddMacroReplace(string macro, string replace)
        {
            return AddMacroReplace(new MacroReplacePair { Macro = macro, Replace = replace });
        }

        public void Create(string templatePath, string destPath)
        {
            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"Template file {templatePath} Not Found");
            }

            string templateContent = File.ReadAllText(templatePath);

            foreach (var pair in MacroReplacePairs)
            {
                templateContent = templateContent.Replace(pair.Macro, pair.Replace);
            }

            File.WriteAllText(destPath, templateContent);

            UnityEditor.AssetDatabase.Refresh();
        }
    }
}
