using System.Collections;
using UnityEngine;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedule Runner")]
    public class ScheduleRunner : Schedulable
    {
        [UnityEngine.Serialization.FormerlySerializedAs("runDirectlyOnStart")]
        public bool runOnStart;
        public int repeat = 1;
        public Schedulable[] schedule = new Schedulable[0];

        private int round = 0;

        public const int RepeatInfCount = -1;

        private bool ShouldRunning => repeat == RepeatInfCount || (repeat > 0 && round < repeat);

        protected override IEnumerator ScheduleCoroutine()
        {
            round = 0;
            int length = schedule.Length;

            while (ShouldRunning)
            {
                for (int i = 0; i < length; i++)
                {
                    if (schedule[i]) yield return schedule[i].RunCoroutine();
                }
                round++;
            }
        }

        private void Start()
        {
            if (runOnStart)
            {
                RunDirectly();
            }
        }
    }
}
