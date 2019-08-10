using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [CreateAssetMenu(menuName = "Kore/GameEvent/IntGameEvent")]
    public class IntGameEvent : GameEvent<int>
    {
        public IntUnityEvent persistResponse;

        protected override UnityEvent<int> persistListener => persistResponse;
    }
}
