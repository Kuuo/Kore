using UnityEngine;
using UnityEngine.Events;
using Kore.Events;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/Simple Keyboard Event")]
    public class SimpleKeyboardEvent : MonoBehaviour
    {
        public KeyCode keyCode = KeyCode.F12;
        public UnityEvent Event;

        private void Update()
        {
            if (Input.GetKeyUp(keyCode))
            {
                Event.Invoke();
            }
        }
    }
}
