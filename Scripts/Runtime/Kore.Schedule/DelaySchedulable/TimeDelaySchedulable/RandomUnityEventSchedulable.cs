using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Kore;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedulables/RandomUnityEventSchedulable")]
    public class RandomUnityEventSchedulable : TimeDelaySchedulable
    {
        public bool alwaysDelay;
        [Range(0, 1f)] public float chance = 0.5f;
        public UnityEvent Event;

        protected override IEnumerator ScheduleCoroutine()
        {
            bool shouldRaise = Random.value <= chance;

            if (shouldRaise || alwaysDelay)
            {
                yield return StartCoroutine(base.ScheduleCoroutine());
            }

            if (shouldRaise)
            {
                Event.Invoke();
            }
        }
    }
}
