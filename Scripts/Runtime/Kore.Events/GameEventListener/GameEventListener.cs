using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Listeners/GameEventListener")]
    public class GameEventListener : AbstractGameEventListener
    {
        public UnityEvent eventHandle;

        public override void Response()
        {
            eventHandle?.Invoke();
        }
    }
}
