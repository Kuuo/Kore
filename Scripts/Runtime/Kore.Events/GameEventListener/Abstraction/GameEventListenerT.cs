using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    public abstract class GameEventListener<T, TGameEvent, TUnityEvent>
        : AbstractGameEventListener<T, TGameEvent>
        where TGameEvent : GameEvent<T>
        where TUnityEvent : UnityEvent<T>
    {
        [SerializeField] protected TUnityEvent response;

        public override void Response(T arg)
        {
            response?.Invoke(arg);
        }
    }
}
