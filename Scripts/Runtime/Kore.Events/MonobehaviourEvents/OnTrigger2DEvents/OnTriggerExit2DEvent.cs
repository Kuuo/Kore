using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnTriggerExit2DEvent")]
    public class OnTriggerExit2DEvent : OnTrigger2DEvent
    {
        private void OnTriggerExit2D(Collider2D collider)
        {
            TryRaiseEvent(collider);
        }
    }
}
