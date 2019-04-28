using System.Collections;
using UnityEngine;

namespace Kore.Schedule
{
    [System.Serializable]
    public class AudioDelaySchedulable : Schedulable
    {
        public AudioClip clip;

        public override IEnumerator Run()
        {
            yield return new WaitForSeconds(clip.length);
        }
    }
}
