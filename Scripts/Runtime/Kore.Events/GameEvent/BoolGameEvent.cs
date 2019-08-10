using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [CreateAssetMenu(menuName = "Kore/GameEvent/BoolGameEvent")]
    public class BoolGameEvent : GameEvent<bool>
    {
        public BoolUnityEvent persistResponse;

        protected override UnityEvent<bool> persistListener => persistResponse;
    }
}
