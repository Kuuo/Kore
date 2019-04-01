using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnCollisionEnter2DEvent")]
    public class OnCollisionEnter2DEvent : OnCollision2DEvent
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            TryRaiseEvent(collision);
        }
    }
}
