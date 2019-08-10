using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [CreateAssetMenu(menuName = "Kore/GameEvent/StringGameEvent")]
    public class StringGameEvent : GameEvent<string>
    {
        public StringUnityEvent persistResponse;

        protected override UnityEvent<string> persistListener => persistResponse;
    }
}
