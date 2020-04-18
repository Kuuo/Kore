using UnityEngine;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Listeners/IntGameEventListener")]
    public class IntGameEventListener : GameEventListener<int, IntGameEvent, IntUnityEvent>
    {
    }
}
