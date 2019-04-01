using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnPostRenderEvent")]
    public class OnPostRenderEvent : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnPostRender()
        {
            Event.Invoke();
        }
    }
}
