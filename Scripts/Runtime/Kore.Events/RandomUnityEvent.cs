using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/RandomUnityEvent")]
    public class RandomUnityEvent : UnityEventRaiser
    {
        [Range(0, 1f)] public float chance = .5f;

        public override void Raise()
        {
            if (Random.value <= chance)
            {
                base.Raise();
            }
        }

        public override void DelayedRaise(float delay)
        {
            if (Random.value <= chance)
            {
                base.DelayedRaise(delay);
            }
        }
    }
}
