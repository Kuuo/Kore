using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnAnimatorIKEvent")]
    public class OnAnimatorIKEvent : MonoBehaviour
    {
        public IntUnityEvent Event;

        private void OnAnimatorIK(int layer)
        {
            Event.Invoke(layer);
        }
    }
}
