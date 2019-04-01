using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnCollisionStayEvent")]
    public class OnCollisionStayEvent : OnCollisionEvent
    {
        private void OnCollisionStay(Collision collision)
        {
            TryRaiseEvent(collision);
        }
    }
}
