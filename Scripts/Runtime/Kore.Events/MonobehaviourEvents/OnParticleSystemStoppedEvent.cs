using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnParticleSystemStoppedEvent")]
    public class OnParticleSystemStoppedEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnParticleSystemStopped()
        {
            Event.Invoke();
        }
    }
}
