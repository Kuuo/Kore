using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Kore.Events
{
    [CreateAssetMenu(menuName = "Kore/GameEvent/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        public UnityEvent persistListener;

        protected List<UnityAction> listeners = new List<UnityAction>();

        public virtual void Raise()
        {
            persistListener?.Invoke();

            for (int i = 0, len = listeners.Count; i < len; i++)
            {
                listeners[i]?.Invoke();
            }
        }

        public void AddListener(UnityAction listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void RemoveListener(UnityAction listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}
