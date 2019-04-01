using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [System.Serializable]
    public class Joint2DUnityEvent : UnityEvent<Joint2D> { }

    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnJointBreak2DEvent")]
    public class OnJointBreak2DEvent : MonoBehaviour
    {
        public Joint2DUnityEvent Event;

        private void OnJointBreak2D(Joint2D joint)
        {
            Event.Invoke(joint);
        }
    }
}
