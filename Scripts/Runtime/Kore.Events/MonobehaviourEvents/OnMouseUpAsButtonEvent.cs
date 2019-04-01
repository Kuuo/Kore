using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnMouseUpAsButtonEvent")]
    public class OnMouseUpAsButtonEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnMouseUpAsButton()
        {
            Event.Invoke();
        }
    }
}
