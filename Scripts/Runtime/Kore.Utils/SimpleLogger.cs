using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Kore.Utils
{
    [CreateAssetMenu(menuName = "Kore/Utils/Simple Logger")]
    public class SimpleLogger : ScriptableObject
    {
        private static ILogger logger = Debug.unityLogger;

        public LogType logType = LogType.Log;

        [TextArea]
        public string tag = "<color=grey>SimpleLogger</color>";


        public void Log(string message) => logger.Log(logType, tag, message, this);

        public void Log(object obj) => Log(obj.ToString());

        public void Log(UnityObject obj) => Log(obj);

        public void LogObjectName(UnityObject obj) => Log(obj.name);

        public void Log(Transform transform) => Log(transform.position);
    }
}
