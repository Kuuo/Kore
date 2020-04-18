using UnityEngine;

namespace Kore.Events
{
    [CreateAssetMenu(menuName = "Kore/GameEvent/StringGameEvent")]
    public class StringGameEvent : GameEvent<string>
    {
        [SerializeField] protected StringUnityEvent persistEvent = new StringUnityEvent();

        public override void Invoke(string arg)
        {
            persistEvent.Invoke(arg);
            base.Invoke(arg);
        }
    }
}
