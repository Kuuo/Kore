using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/Listeners/GameEventListener")]
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [SerializeField] private GameEvent listeningEvent;
        [SerializeField] private UnityEvent eventHandle = new UnityEvent();

        protected virtual void OnEnable()
        {
            if (listeningEvent)
            {
                listeningEvent.AddListener(this);
            }
        }

        protected virtual void OnDisable()
        {
            if (listeningEvent)
            {
                listeningEvent.RemoveListener(this);
            }
        }

        public virtual void Response()
        {
            eventHandle?.Invoke();
        }
    }
}
