using System.Collections;
using UnityEngine;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedulables/AudioDelay")]
    public class AudioDelaySchedulable : Schedulable
    {
        public AudioClip clip;

        protected override IEnumerator ScheduleCoroutine()
        {
            yield return new WaitForSeconds(clip.length);
        }
    }
}
