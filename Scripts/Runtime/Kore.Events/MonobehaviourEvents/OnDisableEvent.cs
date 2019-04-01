using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnDisableEvent")]
    public class OnDisableEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnDisable()
        {
            Event.Invoke();
        }
    }
}
