using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnTriggerEnterEvent")]
    public class OnTriggerEnterEvent : OnTriggerEvent
    {
        private void OnTriggerEnter(Collider collider)
        {
            TryRaiseEvent(collider);
        }
    }
}
