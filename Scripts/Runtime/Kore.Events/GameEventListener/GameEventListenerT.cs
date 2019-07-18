using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    public abstract class GameEventListener<T> : AbstractGameEventListener<T>
    {
        protected abstract UnityEvent<T> eventHandle { get; }

        public override void Response(T arg)
        {
            eventHandle?.Invoke(arg);
        }
    }
}
