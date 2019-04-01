using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnTriggerEnter2DEvent")]
    public class OnTriggerEnter2DEvent : OnTrigger2DEvent
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            TryRaiseEvent(collider);
        }
    }
}
