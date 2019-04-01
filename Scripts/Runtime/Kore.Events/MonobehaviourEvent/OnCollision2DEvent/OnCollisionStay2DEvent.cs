using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/OnCollisionStay2DEvent")]
    public class OnCollisionStay2DEvent : OnCollision2DEvent
    {
        private void OnCollisionStay2D(Collision2D collision)
        {
            TryRaiseEvent(collision);
        }
    }
}
