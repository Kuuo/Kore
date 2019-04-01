using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnMouseEnterEvent")]
    public class OnMouseEnterEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnMouseEnter()
        {
            Event.Invoke();
        }
    }
}
