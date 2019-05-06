using System.Collections;
using Kore.Conditions;
using UnityEngine;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedulables/ConditionDelay")]
    public class ConditionDelaySchedulable : Schedulable
    {
        public ConditionCheck condition;
        public bool targetValue;

        protected override IEnumerator ScheduleCoroutine()
        {
            bool ret = condition.Satisfied;
            yield return new WaitUntil(() => targetValue ? ret : !ret);
        }
    }
}
