using UnityEngine;

namespace Kore.Events
{
    [CreateAssetMenu(menuName = "Kore/GameEvent/IntGameEvent")]
    public class IntGameEvent : GameEvent<int>
    {
        [SerializeField] protected IntUnityEvent persistEvent = new IntUnityEvent();

        public override void Invoke(int arg)
        {
            persistEvent.Invoke(arg);
            base.Invoke(arg);
        }
    }
}
