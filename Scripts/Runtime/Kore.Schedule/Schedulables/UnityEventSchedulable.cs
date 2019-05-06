using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedulables/UnityEvent")]
    public class UnityEventSchedulable : Schedulable
    {
        public UnityEvent Event;

        protected override IEnumerator ScheduleCoroutine()
        {
            Event.Invoke();
            yield break;
        }
    }
}
