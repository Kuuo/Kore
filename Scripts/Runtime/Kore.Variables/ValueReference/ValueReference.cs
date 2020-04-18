using System.Collections.Generic;
using UnityEngine;
using Kore.Events;

namespace Kore.Variables
{
    public abstract class ValueReference<T, TValueAsset, TGameEvent>
        where T : struct
        where TValueAsset : ValueAsset<T, TGameEvent>
        where TGameEvent : GameEvent<T>
    {
        public bool useLocalValue = true;
        [SerializeField] protected T localValue = default;
        [SerializeField] protected TValueAsset valueAsset;

        private EqualityComparer<T> equalityComparer => EqualityComparer<T>.Default;

        public T Value
        {
            get { return useLocalValue ? localValue : valueAsset.Value; }
            set
            {
                if (equalityComparer.Equals(value, Value)) return;

                if (useLocalValue)
                {
                    localValue = value;
                }
                else
                {
                    valueAsset.Value = value;
                }
            }
        }

        public static implicit operator T(ValueReference<T, TValueAsset, TGameEvent> reference) => reference.Value;
    }
}
