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

        public abstract void Response();
    }
}
