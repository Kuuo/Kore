using UnityEngine;
using System.Collections.Generic;

namespace Kore.Events
{
    [CreateAssetMenu(menuName = "Kore/GameEvent/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        protected List<AbstractGameEventListener> listeners = new List<AbstractGameEventListener>();

        public void Raise()
        {
            for (int i = 0, len = listeners.Count; i < len; i++)
            {
                if (listeners[i]) listeners[i].Response();
            }
        }

        public void AddListener(AbstractGameEventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void RemoveListener(AbstractGameEventListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}
