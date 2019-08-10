using UnityEngine;
using Kore.Events;

namespace Kore.Variables
{
    public abstract class ValueAsset<T> : ValueAsset
        where T : struct
    {
        [SerializeField, UnityEngine.Serialization.FormerlySerializedAs("_value")]
        private T defaultValue = default;

        private T _value;

        public override object objectValue => _value;

        public abstract GameEvent<T> OnValueChanged { get; set; }

        public T Value
        {
            get => _value;
            set
            {
                if (value.Equals(_value)) return;

                _value = value;

                if (OnValueChanged)
                {
                    OnValueChanged.Invoke(_value);
                }
            }
        }

        protected virtual void OnEnable()
        {
            _value = defaultValue;
        }

        public static implicit operator T(ValueAsset<T> valueAsset) => valueAsset.Value;
    }
}
