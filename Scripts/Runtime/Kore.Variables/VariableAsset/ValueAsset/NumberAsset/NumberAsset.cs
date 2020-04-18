using Kore.Events;

namespace Kore.Variables
{
    public abstract class NumberAsset<T, TGameEvent> : ValueAsset<T, TGameEvent>
        where T : struct
        where TGameEvent : GameEvent<T>
    {
        public abstract void Set(int newValue);
        public abstract void Set(float newValue);
    }
}
