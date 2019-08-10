using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Kore.Events
{
    public abstract class GameEvent<T> : ScriptableObject
    {
        protected abstract UnityEvent<T> persistListener { get; }

        protected List<UnityAction<T>> _listeners = new List<UnityAction<T>>();

        public virtual void Invoke(T arg)
        {
            persistListener?.Invoke(arg);

            for (int i = 0, len = _listeners.Count; i < len; i++)
            {
                _listeners[i]?.Invoke(arg);
            }
        }

        public void AddListener(UnityAction<T> listener)
        {
            if (!_listeners.Contains(listener))
            {
                _listeners.Add(listener);
            }
        }

        public void RemoveListener(UnityAction<T> listener)
        {
            if (_listeners.Contains(listener))
            {
                _listeners.Remove(listener);
            }
        }
    }
}
