using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnApplicationPauseEvent")]
    public class OnApplicationPauseEvent : MonoBehaviour
    {
        public BoolUnityEvent Event;

        private void OnApplicationPause(bool isPaused)
        {
            Event.Invoke(isPaused);
        }
    }
}
