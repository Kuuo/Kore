using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnAnimatorMoveEvent")]
    public class OnAnimatorMoveEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnAnimatorMove()
        {
            Event.Invoke();
        }
    }
}
