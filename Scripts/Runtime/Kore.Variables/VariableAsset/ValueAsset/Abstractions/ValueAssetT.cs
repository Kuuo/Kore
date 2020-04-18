using System.Collections.Generic;
using UnityEngine;
using Kore.Events;

namespace Kore.Variables
{
    public abstract class ValueAsset<T, TGameEvent> : ValueAsset
        where T : struct
        where TGameEvent : GameEvent<T>
    {
        [SerializeField] protected T defaultValue = default;
        [SerializeField] protected TGameEvent onValueChanged;

        protected T currentValue;

        public TGameEvent OnValueChanged
        {
            get => onValueChanged;
            set => onValueChanged = value;
        }

        public override object objectValue => currentValue;

        private EqualityComparer<T> equalityComparer => EqualityComparer<T>.Default;

        public T Value
        {
            get => currentValue;
            set
            {
                if (equalityComparer.Equals(value, currentValue)) return;

                currentValue = value;

                if (onValueChanged)
                {
                    onValueChanged.Invoke(currentValue);
                }
            }
        }

        protected virtual void OnEnable()
        {
            currentValue = defaultValue;
        }

        public virtual void Set(ValueAsset<T, TGameEvent> valueAsset) => Value = valueAsset.Value;

        public override string ToString() => currentValue.ToString();

        public static implicit operator T(ValueAsset<T, TGameEvent> valueAsset) => valueAsset.Value;
    }
}
