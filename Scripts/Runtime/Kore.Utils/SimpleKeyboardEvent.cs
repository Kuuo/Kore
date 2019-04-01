using UnityEngine;
using Kore.Events;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/Simple Keyboard Event")]
    public class SimpleKeyboardEvent : UnityEventRaiser
    {
        public KeyCode keyCode = KeyCode.F12;

        private void Update()
        {
            if (Input.GetKeyUp(keyCode))
            {
                Raise();
            }
        }
    }
}
