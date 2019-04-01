using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Listeners/GameEventListener")]
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent listeningEvent;
        public UnityEvent eventHandle;

        private void OnEnable()
        {
            listeningEvent.AddListener(this);
        }

        private void OnDisable()
        {
            listeningEvent.RemoveListener(this);
        }

        public void Response()
        {
            eventHandle?.Invoke();
        }
    }
}
