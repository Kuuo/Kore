using System.Collections;
using UnityEngine;

namespace Kore.Schedule
{
    [System.Serializable]
    public class TimeDelaySchedulable : Schedulable
    {
        public float time;
        public bool useRealTime;

        public override IEnumerator Run()
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
