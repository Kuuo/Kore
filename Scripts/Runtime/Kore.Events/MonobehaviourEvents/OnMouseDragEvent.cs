using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnMouseDragEvent")]
    public class OnMouseDragEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnMouseDrag()
        {
            Event.Invoke();
        }
    }
}
