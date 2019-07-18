using UnityEngine;
using System.Collections.Generic;

namespace Kore.Events
{
    public abstract class GameEvent<T> : ScriptableObject
    {
        protected List<AbstractGameEventListener<T>> _listeners = new List<AbstractGameEventListener<T>>();

        public void Raise(T arg)
        {
            for (int i = 0, len = _listeners.Count; i < len; i++)
            {
                if (_listeners[i]) _listeners[i].Response(arg);
            }
        }

        public void AddListener(AbstractGameEventListener<T> listener)
        {
            if (!_listeners.Contains(listener))
            {
                _listeners.Add(listener);
            }
        }

        public void RemoveListener(AbstractGameEventListener<T> listener)
        {
            if (_listeners.Contains(listener))
            {
                _listeners.Remove(listener);
            }
        }
    }
}
