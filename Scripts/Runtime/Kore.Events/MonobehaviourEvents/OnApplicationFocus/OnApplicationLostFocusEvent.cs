using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnApplicationLostFocusEvent")]
    public class OnApplicationLostFocusEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus) Event.Invoke();
        }
    }
}
