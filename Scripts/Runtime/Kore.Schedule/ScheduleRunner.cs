using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/ScheduleRunner")]
    public class ScheduleRunner : MonoBehaviour
    {
        public Schedulable[] schedule = new Schedulable[0];

        public void Run()
        {
            StartCoroutine(RunCoroutine());
        }

        private IEnumerator RunCoroutine()
        {
            for (int i = 0, length = schedule.Length; i < length; i++)
            {
                yield return StartCoroutine(schedule[i].Run());
            }
        }
    }
}
