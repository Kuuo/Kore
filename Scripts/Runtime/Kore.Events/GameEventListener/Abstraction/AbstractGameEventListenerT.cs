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
            listeningEvent.AddListener(this);
        }

        protected virtual void OnDisable()
        {
            listeningEvent.RemoveListener(this);
        }

        public abstract void Response(T arg);
    }
}
