using UnityEngine;

namespace Kore.Events
{
    [CreateAssetMenu(menuName = "Kore/GameEvent/FloatGameEvent")]
    public class FloatGameEvent : GameEvent<float>
    {
        [SerializeField] protected FloatUnityEvent persistEvent = new FloatUnityEvent();

        public override void Invoke(float arg)
        {
            persistEvent.Invoke(arg);
            base.Invoke(arg);
        }
    }
}
