using UnityEngine;
using UnityEngine.Events;
using Kore.Conditions;

namespace Kore.Events
{
    public abstract class OnTriggerEvent : MonoBehaviour
    {
        public LayerMask acceptLayer;
        public ColliderUnityEvent Event;

        protected bool TryRaiseEvent(Collider collider)
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
