using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedulables/FrameDelaySchedulable")]
    public class FrameDelaySchedulable : Schedulable
    {
        public int count = 1;

        protected override IEnumerator ScheduleCoroutine()
        {
            for (int i = 0; i < count; i++)
            {
                yield return null;
            }
        }
    }
}
