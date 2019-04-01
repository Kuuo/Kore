using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/LateUpdateEvent")]
    public class LateUpdateEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void LateUpdate()
        {
            Event.Invoke();
        }
    }
}
