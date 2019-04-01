using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnDestroyEvent")]
    public class OnDestroyEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnDestroy()
        {
            Event.Invoke();
        }
    }
}
