using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnJointBreakEvent")]
    public class OnJointBreakEvent : MonoBehaviour
    {
        public FloatUnityEvent Event;

        private void OnJointBreak(float breakForce)
        {
            Event.Invoke(breakForce);
        }
    }
}
