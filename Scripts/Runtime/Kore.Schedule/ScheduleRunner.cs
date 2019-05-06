using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/ScheduleRunner")]
    public class ScheduleRunner : Schedulable
    {
        public int repeat = 1;
        public Schedulable[] schedule = new Schedulable[0];

        private int round = 0;

        private const int RepeatInfCount = -1;

        private bool ShouldRunning => repeat == RepeatInfCount || (repeat > 0 && round < repeat);

        protected override IEnumerator ScheduleCoroutine()
        {
            round = 0;
            while (ShouldRunning)
            {
                for (int i = 0, length = schedule.Length; i < length; i++)
                {
                    yield return schedule[i].Run();
                }
                round++;
            }
        }


#if UNITY_EDITOR
        private void OnValidate()
        {
            repeat = Mathf.Max(repeat, RepeatInfCount);
        }
#endif
    }
}
