using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnParticleTriggerEvent")]
    public class OnParticleTriggerEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnParticleTrigger()
        {
            Event.Invoke();
        }
    }
}
