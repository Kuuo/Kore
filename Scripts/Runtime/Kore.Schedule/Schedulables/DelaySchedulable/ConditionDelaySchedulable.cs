using System.Collections;
using Kore.Conditions;
using UnityEngine;

namespace Kore.Schedule
{
    [System.Serializable]
    public class ConditionDelaySchedulable : Schedulable
    {
        public ConditionCheck condition;
        public bool targetValue;

        public override IEnumerator Run()
        {
            bool ret = condition.Satisfied;
            yield return new WaitUntil(() => targetValue ? ret : !ret);
        }
    }
}
