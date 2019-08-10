using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Variables
{
    public abstract class ValueReference<T> where T : struct
    {
        public bool useLocalValue = true;
        [SerializeField] protected T localValue = default;
        protected abstract ValueAsset<T> valueAsset { get; }

        public T Value
        {
            get { return useLocalValue ? localValue : valueAsset.Value; }
            set
            {
                if (value.Equals(Value)) return;

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

        public static implicit operator T(ValueReference<T> reference) => reference.Value;
    }
}
