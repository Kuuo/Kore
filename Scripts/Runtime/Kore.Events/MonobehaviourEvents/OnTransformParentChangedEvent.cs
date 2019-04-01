using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnTransformParentChangedEvent")]
    public class OnTransformParentChangedEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnTransformParentChanged()
        {
            Event.Invoke();
        }
    }
}
