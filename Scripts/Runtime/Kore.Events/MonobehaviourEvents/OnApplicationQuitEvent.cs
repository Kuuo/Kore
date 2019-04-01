using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnApplicationQuitEvent")]
    public class OnApplicationQuitEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnApplicationQuit()
        {
            Event.Invoke();
        }
    }
}
