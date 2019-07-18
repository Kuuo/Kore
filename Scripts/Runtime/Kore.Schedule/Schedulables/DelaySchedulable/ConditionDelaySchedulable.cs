using System.Collections;
using Kore.Conditions;
using UnityEngine;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedulables/Condition Delay Schedulable")]
    public class ConditionDelaySchedulable : Schedulable
    {
        public ConditionCheck condition;
        public bool target;

        protected override IEnumerator ScheduleCoroutine()
        {
            yield return new WaitUntil(() => !(target ^ condition.Satisfied));
        }
    }
}
