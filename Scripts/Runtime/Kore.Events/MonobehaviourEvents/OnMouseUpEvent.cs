using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnMouseUpEvent")]
    public class OnMouseUpEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnMouseUp()
        {
            Event.Invoke();
        }
    }
}
