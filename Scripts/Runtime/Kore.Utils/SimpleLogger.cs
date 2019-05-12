using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Utils
{
    [CreateAssetMenu(menuName = "Kore/Utils/Simple Logger")]
    public class SimpleLogger : ScriptableObject
    {
        private static ILogger logger = Debug.unityLogger;

        public LogType logType = LogType.Log;

        [TextArea]
        public string tag = "<color=grey>SimpleLogger</color>";


        public void Log(string message)
        {
            logger.Log(logType, tag, message, this);
        }

        public void Log(UnityEngine.Object obj)
        {
            logger.Log(logType, tag, obj.ToString(), this);
        }
    }
}
