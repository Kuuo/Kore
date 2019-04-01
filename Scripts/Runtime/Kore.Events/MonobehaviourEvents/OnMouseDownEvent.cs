using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnMouseDownEvent")]
    public class OnMouseDownEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnMouseDown()
        {
            Event.Invoke();
        }
    }
}
