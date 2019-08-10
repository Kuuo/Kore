using System;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Variables
{
    [Serializable]
    public abstract class Threshold<T> : IComparable<Threshold<T>>
        where T : struct, IComparable<T>
    {
        protected enum ValueChangeState
        {
            Ascended, Reached, Descended
        }

        [SerializeField] private T value = default;

        [SerializeField] private UnityEvent onAscended = new UnityEvent();
        [SerializeField] private UnityEvent onReached = new UnityEvent();
        [SerializeField] private UnityEvent onDescended = new UnityEvent();

        public T Value => value;

        private ValueChangeState valueChangeState;

        public bool Check(T newValue)
        {
            var compare = newValue.CompareTo(value);

            if (compare == 0 && valueChangeState != ValueChangeState.Reached)
            {
                onReached.Invoke();
                valueChangeState = ValueChangeState.Reached;
                return true;
            }

            if (compare > 0 && valueChangeState != ValueChangeState.Ascended)
            {
                onAscended.Invoke();
                valueChangeState = ValueChangeState.Ascended;
                return true;
            }

            if (compare < 0 && valueChangeState != ValueChangeState.Descended)
            {
                onDescended.Invoke();
                valueChangeState = ValueChangeState.Descended;
                return true;
            }

            return false;
        }

        public int CompareTo(Threshold<T> other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
