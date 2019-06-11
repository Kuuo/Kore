using System.Collections;
using UnityEngine;


namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedulables/AnimationDelay")]
    public class AnimationDelaySchedulable : AbstractTimeDelaySchedulable
    {
        public AnimationClip clip;

        protected override float time => clip.length;
    }
}
