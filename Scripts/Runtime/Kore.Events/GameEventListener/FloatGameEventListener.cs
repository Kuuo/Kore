using UnityEngine;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Listeners/FloatGameEventListener")]
    public class FloatGameEventListener : GameEventListener<float, FloatGameEvent, FloatUnityEvent>
    {
    }
}
