using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Schedule
{
    [System.Serializable]
    public class FrameDelaySchedulable : Schedulable
    {
        public int count = 1;

        public override IEnumerator Run()
        {
            for (int i = 0; i < count; i++)
            {
                yield return null;
            }
        }
    }
}
