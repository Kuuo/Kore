using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnRenderObjectEvent")]
    public class OnRenderObjectEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnRenderObject()
        {
            Event.Invoke();
        }
    }
}
