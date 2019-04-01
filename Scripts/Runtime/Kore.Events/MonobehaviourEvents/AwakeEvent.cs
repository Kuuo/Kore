using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/AwakeEvent")]
    public class AwakeEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void Awake()
        {
            Event.Invoke();
        }
    }
}
