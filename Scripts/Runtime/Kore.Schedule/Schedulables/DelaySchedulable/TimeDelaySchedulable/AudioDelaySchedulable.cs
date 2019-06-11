using UnityEngine;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedulables/AudioDelay")]
    public class AudioDelaySchedulable : AbstractTimeDelaySchedulable
    {
        public AudioClip clip;

        protected override float time => clip.length;
    }
}
