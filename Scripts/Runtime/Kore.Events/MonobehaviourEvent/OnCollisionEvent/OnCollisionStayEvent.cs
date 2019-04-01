using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/OnCollisionStayEvent")]
    public class OnCollisionStayEvent : OnCollisionEvent
    {
        private void OnCollisionStay(Collision collision)
        {
            TryRaiseEvent(collision);
        }
    }
}
