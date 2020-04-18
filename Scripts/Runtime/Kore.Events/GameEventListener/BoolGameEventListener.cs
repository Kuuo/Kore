using UnityEngine;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Listeners/BoolGameEventListener")]
    public class BoolGameEventListener : GameEventListener<bool, BoolGameEvent, BoolUnityEvent>
    {
    }
}
