using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnApplicationResumedEvent")]
    public class OnApplicationResumedEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnApplicationPause(bool isPaused)
        {
            if (!isPaused) Event.Invoke();
        }
    }
}
