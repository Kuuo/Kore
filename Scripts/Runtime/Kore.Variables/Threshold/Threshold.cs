using System;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Variables
{
    [Serializable]
    public class Threshold<T> : IComparable<Threshold<T>>
        where T : struct, IComparable<T>
    {
        [SerializeField] protected T value;
        [SerializeField] private UnityEvent onAscended = new UnityEvent();
        [SerializeField] private UnityEvent onReached = new UnityEvent();
        [SerializeField] private UnityEvent onDescended = new UnityEvent();

        public T Value => value;

        private bool hasAscended;
        private bool hasDescended;

        public bool Check(T newValue)
        {
            int compare = newValue.CompareTo(value);

            if (compare == 0 && (hasAscended || hasDescended))
            {
                onReached.Invoke();
                hasAscended = false;
                hasDescended = false;
                return true;
            }
            else if (!hasAscended && compare > 0)
            {
                onAscended.Invoke();
                hasAscended = true;
                hasDescended = false;
                return true;
            }
            else if (!hasDescended && compare < 0)
            {
                onDescended.Invoke();
                hasAscended = false;
                hasDescended = true;
                return true;
            }

            return false;
        }

        public int CompareTo(Threshold<T> other)
        {
            return value.CompareTo(other.value);
        }
    }
}
