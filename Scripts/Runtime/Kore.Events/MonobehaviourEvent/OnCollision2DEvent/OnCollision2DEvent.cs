using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    public abstract class OnCollision2DEvent : MonoBehaviour
    {
        public LayerMask acceptLayer;
        public Collision2DUnityEvent Event;

        protected bool TryRaiseEvent(Collision2D colllision)
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
