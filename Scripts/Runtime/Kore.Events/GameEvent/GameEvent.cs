using UnityEngine;
using System.Collections.Generic;

namespace Kore.Events
{
    [CreateAssetMenu(menuName = "Kore/GameEvent/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        protected List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise()
        {
            for (int i = 0, len = listeners.Count; i < len; i++)
            {
                listeners[i]?.Response();
            }
        }

        public void AddListener(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void RemoveListener(GameEventListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}
