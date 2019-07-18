using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedulables/Unity Event Schedulable")]
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
