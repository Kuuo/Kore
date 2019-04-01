using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/StartEvent")]
    public class StartEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void Start()
        {
            Event.Invoke();
        }
    }
}
