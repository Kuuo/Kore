using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnCollisionEnterEvent")]
    public class OnCollisionEnterEvent : OnCollisionEvent
    {
        private void OnCollisionEnter(Collision collision)
        {
            TryRaiseEvent(collision);
        }
    }
}
