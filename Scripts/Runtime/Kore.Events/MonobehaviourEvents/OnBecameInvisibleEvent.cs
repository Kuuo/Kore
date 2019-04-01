using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnBecameInvisibleEvent")]
    public class OnBecameInvisibleEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnBecameInvisible()
        {
            Event.Invoke();
        }
    }
}
