using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Utils
{
    public abstract class ThresholdChecker<T> : MonoBehaviour
        where T : struct, IComparable<T>
    {
        protected abstract Threshold<T>[] thresholds { get; }

        protected abstract UnityEvent<T> onValueChanged { get; }


        protected void OnEnable()
        {
            onValueChanged.AddListener(Check);
        }


        protected void OnDisable()
        {
            onValueChanged.RemoveListener(Check);
        }


        // TODO: Do we have to check each threshold?
        public void Check(T newValue)
        {
            foreach (var t in thresholds)
            {
                t.Check(newValue);
            }
        }


        // TODO: This should be in-Editor context menu only
        protected void SortThresholds()
        {
            Array.Sort(thresholds);
        }
    }
}
