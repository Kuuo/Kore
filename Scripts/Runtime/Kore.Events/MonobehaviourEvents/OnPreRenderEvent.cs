using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnPreRenderEvent")]
    public class OnPreRenderEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnPreRender()
        {
            Event.Invoke();
        }
    }
}
