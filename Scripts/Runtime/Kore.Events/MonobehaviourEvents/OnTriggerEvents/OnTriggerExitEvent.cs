using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnTriggerExitEvent")]
    public class OnTriggerExitEvent : OnTriggerEvent
    {
        private void OnTriggerExit(Collider collider)
        {
            TryRaiseEvent(collider);
        }
    }
}
