using UnityEngine;
using System.Collections.Generic;

namespace Kore.Events
{
    public abstract class GameEvent<T> : ScriptableObject
    {
        protected readonly List<IGameEventListener<T>> listeners = new List<IGameEventListener<T>>();

        public virtual void Invoke(T arg)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                try
                {
                    listeners[i].Response(arg);
                }
                catch (System.Exception ex)
                {
                    Debug.Log(ex);
                }
            }
        }

        public void AddListener(IGameEventListener<T> listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void RemoveListener(IGameEventListener<T> listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}
