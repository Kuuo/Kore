﻿using System.Collections;
using UnityEngine;

namespace Kore.Schedule
{
    public abstract class AbstractTimeDelaySchedulable : Schedulable
    {
        public bool useRealTime;

        protected abstract float time { get; }

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
