using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Variables
{
    public abstract class ThresholdChecker<T> : MonoBehaviour
        where T : struct, IComparable<T>
    {
        [SerializeField] protected bool shouldCheckAll;

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


        public void Check(T newValue)
        {
            bool checkSuccess = false;
            foreach (var t in thresholds)
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
            Array.Sort(thresholds);
        }
    }
#endif
}
