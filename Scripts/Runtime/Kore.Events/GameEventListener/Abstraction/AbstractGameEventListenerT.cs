using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Events
{
    public abstract class AbstractGameEventListener<T> : MonoBehaviour
    {
        protected abstract GameEvent<T> listeningEvent { get; }

        protected virtual void OnEnable()
        {
            if (listeningEvent)
            {
                listeningEvent.AddListener(Response);
            }
        }

        protected virtual void OnDisable()
        {
            if (listeningEvent)
            {
                listeningEvent.RemoveListener(Response);
            }
        }

        public abstract void Response(T arg);
    }
}
