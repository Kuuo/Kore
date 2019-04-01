using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    public abstract class OnCollisionEvent : MonoBehaviour
    {
        public LayerMask acceptLayer;
        public CollisionUnityEvent Event;

        protected bool TryRaiseEvent(Collision colllision)
        {
            if (acceptLayer.Contains(colllision.collider))
            {
                Event.Invoke(colllision);
                return true;
            }
            return false;
        }
    }
}
