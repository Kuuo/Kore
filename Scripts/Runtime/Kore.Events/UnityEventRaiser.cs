using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/UnityEventRaiser")]
    public class UnityEventRaiser : MonoBehaviour
    {
        public bool raiseOnStart;
        public UnityEvent Event;

        private void Start()
        {
            if (raiseOnStart)
            {
                Raise();
            }
        }

        [ContextMenu("Raise Event")]
        public virtual void Raise()
        {
            Event.Invoke();
        }

        public virtual void DelayedRaise(float delay)
        {
            Invoke(nameof(UnityEventRaiser.Raise), delay);
        }
    }
}
