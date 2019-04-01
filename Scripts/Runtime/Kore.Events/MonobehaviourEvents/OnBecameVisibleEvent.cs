using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnBecameVisibleEvent")]
    public class OnBecameVisibleEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnBecameVisible()
        {
            Event.Invoke();
        }
    }
}
