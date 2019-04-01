using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnEnableEvent")]
    public class OnEnableEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnEnable()
        {
            Event.Invoke();
        }
    }
}
