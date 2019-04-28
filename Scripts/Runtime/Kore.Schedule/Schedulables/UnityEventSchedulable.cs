using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Schedule
{
    [System.Serializable]
    public class UnityEventSchedulable : Schedulable
    {
        public UnityEvent Event;

        public override IEnumerator Run()
        {
            Event.Invoke();
            yield break;
        }
    }
}
