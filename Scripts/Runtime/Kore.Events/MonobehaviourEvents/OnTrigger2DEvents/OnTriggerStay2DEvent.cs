using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnTriggerStay2DEvent")]
    public class OnTriggerStay2DEvent : OnTrigger2DEvent
    {
        private void OnTriggerStay2D(Collider2D collider)
        {
            TryRaiseEvent(collider);
        }
    }
}
