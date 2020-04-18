using UnityEngine;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Listeners/StringGameEventListener")]
    public class StringGameEventListener : GameEventListener<string, StringGameEvent, StringUnityEvent>
    {
    }
}
