using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnApplicationFocusEvent")]
    public class OnApplicationFocusEvent : MonoBehaviour
    {
        public BoolUnityEvent Event;

        private void OnApplicationFocus(bool hasFocus)
        {
            Event.Invoke(hasFocus);
        }
    }
}
