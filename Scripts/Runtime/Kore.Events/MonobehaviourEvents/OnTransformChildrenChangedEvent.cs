using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnTransformChildrenChangedEvent")]
    public class OnTransformChildrenChangedEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnTransformChildrenChanged()
        {
            Event.Invoke();
        }
    }
}
