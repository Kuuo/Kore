using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Events
{
    public abstract class AbstractGameEventListener : MonoBehaviour
    {
        public GameEvent listeningEvent;

        protected virtual void OnEnable()
        {
            listeningEvent.AddListener(this);
        }

        protected virtual void OnDisable()
        {
            listeningEvent.RemoveListener(this);
        }

        public abstract void Response();
    }
}
