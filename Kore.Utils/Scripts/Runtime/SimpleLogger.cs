using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Kore/Util/SimpleLogger")]
public class SimpleLogger : ScriptableObject
{
    private static ILogger logger = Debug.unityLogger;

    public LogType logType = LogType.Log;
    public string tag = "<color=blue>SimpleLogger</color>";


    public void Log(string message)
    {
        logger.Log(logType, tag, message, this);
    }

    public void Log(UnityEngine.Object obj)
    {
        logger.Log(logType, tag, obj as object, this);
    }
}
