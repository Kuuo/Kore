using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Kore.Utils
{
    [CreateAssetMenu(menuName = "Kore/Utils/Simple Logger")]
    public class SimpleLogger : ScriptableObject
    {
        private static ILogger logger = Debug.unityLogger;

        public LogType logType = LogType.Log;
        public Color tagColor = Color.black;
        public string tag = "SimpleLogger";

        private string coloredTag =>
            $"<color=#{ColorUtility.ToHtmlStringRGB(tagColor)}>{tag}</color>";

        public void Log(string message) => logger.Log(logType, coloredTag, message, this);

        public void LogPlainObject(object obj) => Log(obj.ToString());

        public void Log(UnityObject obj) => Log(obj.ToString());

        public void LogObjectName(UnityObject obj) => Log(obj.name);

        public void LogPosition(Transform transform) => LogPlainObject(transform.position);
    }
}
