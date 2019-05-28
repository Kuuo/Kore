using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Variables
{
    public abstract class ThresholdChecker<T> where T : struct, IComparable<T>
    {
        [SerializeField] protected bool shouldCheckAll;

        protected abstract Threshold<T>[] Thresholds { get; }

        public void Check(T newValue)
        {
            bool checkSuccess = false;
            foreach (var t in Thresholds)
            {
                checkSuccess = t.Check(newValue);
                if (!shouldCheckAll && checkSuccess)
                {
                    return;
                }
            }
        }


#if UNITY_EDITOR
        [ContextMenu("Sort Thresholds")]
        protected void SortThresholds()
        {
            Array.Sort(Thresholds);
        }
#endif
    }
}
