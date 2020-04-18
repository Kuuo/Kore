using UnityEngine;

namespace Kore.Events
{
    public abstract class AbstractGameEventListener<T, TGameEvent>
        : MonoBehaviour, IGameEventListener<T>
        where TGameEvent : GameEvent<T>
    {
        [SerializeField] private TGameEvent listeningEvent;

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

        public abstract void Response(T arg);
    }
}
