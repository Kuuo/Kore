using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnRenderImageEvent")]
    public class OnRenderImageEvent : MonoBehaviour
    {
        [System.Serializable]
        public class RenderImageUnityEvent : UnityEvent<RenderTexture, RenderTexture> { }

        public RenderImageUnityEvent Event;

        private void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Event.Invoke(src, dest);
        }
    }
}
