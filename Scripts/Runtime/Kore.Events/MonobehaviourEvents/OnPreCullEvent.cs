using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnPreCullEvent")]
    public class OnPreCullEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnPreCull()
        {
            Event.Invoke();
        }
    }
}
