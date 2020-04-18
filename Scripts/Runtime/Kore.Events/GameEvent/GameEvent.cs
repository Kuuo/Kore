using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [CreateAssetMenu(menuName = "Kore/GameEvent/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        [SerializeField] protected UnityEvent persistListener;

        protected readonly List<IGameEventListener> listeners = new List<IGameEventListener>();

        public virtual void Raise()
        {
            persistListener?.Invoke();

            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                try
                {
                    listeners[i].Response();
                }
                catch (System.Exception ex)
                {
                    Debug.Log(ex);
                }
            }
        }

        public void AddListener(IGameEventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void RemoveListener(IGameEventListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}
