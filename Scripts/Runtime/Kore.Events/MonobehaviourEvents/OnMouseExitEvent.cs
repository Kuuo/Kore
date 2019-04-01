using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnMouseExitEvent")]
    public class OnMouseExitEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnMouseExit()
        {
            Event.Invoke();
        }
    }
}
