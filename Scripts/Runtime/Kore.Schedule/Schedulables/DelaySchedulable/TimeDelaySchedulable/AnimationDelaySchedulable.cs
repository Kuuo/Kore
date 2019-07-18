using System.Collections;
using UnityEngine;


namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedulables/Animation Delay Schedulable")]
    public class AnimationDelaySchedulable : AbstractTimeDelaySchedulable
    {
        public AnimationClip clip;

        protected override float time => clip.length;
    }
}
