using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [CreateAssetMenu(menuName = "Kore/GameEvent/FloatGameEvent")]
    public class FloatGameEvent : GameEvent<float>
    {
        public FloatUnityEvent persistResponse;

        protected override UnityEvent<float> persistListener => persistResponse;
    }
}
