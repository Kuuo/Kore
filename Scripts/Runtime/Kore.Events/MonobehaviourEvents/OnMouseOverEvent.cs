using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnMouseOverEvent")]
    public class OnMouseOverEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnMouseOver()
        {
            Event.Invoke();
        }
    }
}
