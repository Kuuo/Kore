using UnityEngine;

namespace Kore.Events
{
    [CreateAssetMenu(menuName = "Kore/GameEvent/BoolGameEvent")]
    public class BoolGameEvent : GameEvent<bool>
    {
        [SerializeField] protected BoolUnityEvent persistEvent = new BoolUnityEvent();

        public override void Invoke(bool arg)
        {
            persistEvent.Invoke(arg);
            base.Invoke(arg);
        }
    }
}
