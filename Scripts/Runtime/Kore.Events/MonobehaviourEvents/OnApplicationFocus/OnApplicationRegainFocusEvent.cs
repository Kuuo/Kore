using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnApplicationRegainFocusEvent")]
    public class OnApplicationRegainFocusEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus) Event.Invoke();
        }
    }
}
