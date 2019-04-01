using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnCollisionExitEvent")]
    public class OnCollisionExitEvent : OnCollisionEvent
    {
        private void OnCollisionExit(Collision collision)
        {
            TryRaiseEvent(collision);
        }
    }
}
