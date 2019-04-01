using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [System.Serializable]
    public class ControllerColliderHitUnityEvent : UnityEvent<ControllerColliderHit> { }

    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnControllerColliderHitEvent")]
    public class OnControllerColliderHitEvent : MonoBehaviour
    {
        public ControllerColliderHitUnityEvent Event;

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Event.Invoke(hit);
        }
    }
}
