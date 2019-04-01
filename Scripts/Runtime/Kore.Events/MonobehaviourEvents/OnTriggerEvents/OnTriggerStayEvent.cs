using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnTriggerStayEvent")]
    public class OnTriggerStayEvent : OnTriggerEvent
    {
        private void OnTriggerStay(Collider collider)
        {
            TryRaiseEvent(collider);
        }
    }
}
