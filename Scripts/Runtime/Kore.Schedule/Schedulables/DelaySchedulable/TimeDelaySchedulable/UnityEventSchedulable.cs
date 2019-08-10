using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedulables/Unity Event Schedulable")]
    public class UnityEventSchedulable : TimeDelaySchedulable
    {
        public UnityEvent Event;

        protected override IEnumerator ScheduleCoroutine()
        {
            yield return StartCoroutine(base.ScheduleCoroutine());

            Event.Invoke();
        }
    }
}
