using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/FixedUpdateEvent")]
    public class FixedUpdateEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void FixedUpdate()
        {
            Event.Invoke();
        }
    }
}
