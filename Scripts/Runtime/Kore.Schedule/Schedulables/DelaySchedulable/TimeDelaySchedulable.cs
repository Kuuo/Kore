using System.Collections;
using UnityEngine;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedulables/TimeDelay")]
    public class TimeDelaySchedulable : Schedulable
    {
        public float time;
        public bool useRealTime;

        protected override IEnumerator ScheduleCoroutine()
        {
            if (useRealTime)
            {
                yield return new WaitForSecondsRealtime(time);
            }
            else
            {
                yield return new WaitForSeconds(time);
            }
        }
    }
}
