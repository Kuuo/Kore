using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/UpdateEvent")]
    public class UpdateEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void Update()
        {
            Event.Invoke();
        }
    }
}
