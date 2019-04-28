using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnApplicationPausedEvent")]
    public class OnApplicationPausedEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnApplicationPause(bool isPaused)
        {
            if (isPaused) Event.Invoke();
        }
    }
}
