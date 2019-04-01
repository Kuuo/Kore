using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnWillRenderObjectEvent")]
    public class OnWillRenderObjectEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnWillRenderObject()
        {
            Event.Invoke();
        }
    }
}
