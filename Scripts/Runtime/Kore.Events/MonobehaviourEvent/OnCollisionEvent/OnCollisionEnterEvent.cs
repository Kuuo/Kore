using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/OnCollisionEnterEvent")]
    public class OnCollisionEnterEvent : OnCollisionEvent
    {
        private void OnCollisionEnter(Collision collision)
        {
            TryRaiseEvent(collision);
        }
    }
}
