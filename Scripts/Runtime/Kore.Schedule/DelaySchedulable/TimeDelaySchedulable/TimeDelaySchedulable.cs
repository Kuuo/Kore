using UnityEngine;
using Kore.Variables;

namespace Kore.Schedule
{
    [AddComponentMenu("Kore/Schedule/Schedulables/TimeDelaySchedulable")]
    public class TimeDelaySchedulable : AbstractTimeDelaySchedulable
    {
        public FloatReference delay;

        protected override float time => delay;
    }
}
