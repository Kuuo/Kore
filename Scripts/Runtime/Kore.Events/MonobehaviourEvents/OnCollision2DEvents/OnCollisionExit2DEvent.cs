using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnCollisionExit2DEvent")]
    public class OnCollisionExit2DEvent : OnCollision2DEvent
    {
        private void OnCollisionExit2D(Collision2D collision)
        {
            TryRaiseEvent(collision);
        }
    }
}
