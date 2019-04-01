using UnityEngine;
using UnityEngine.Events;
using Kore.Conditions;

namespace Kore.Events
{
    public abstract class OnTrigger2DEvent : MonoBehaviour
    {
        public LayerMask acceptLayer;
        public Collider2DUnityEvent Event;

        protected bool TryRaiseEvent(Collider2D collider)
        {
            if (acceptLayer.Contains(collider))
            {
                Event.Invoke(collider);
                return true;
            }
            return false;
        }
    }
}
