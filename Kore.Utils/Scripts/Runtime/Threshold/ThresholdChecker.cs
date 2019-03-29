using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Kore.Utils
{
    public abstract class ThresholdChecker<T> : MonoBehaviour
        where T : struct, IComparable<T>
    {
        [SerializeField] protected bool shouldCheckAll;

        protected abstract Threshold<T>[] thresholds { get; set; }

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
        // TODO: Make a CustomEditor
        /// Method ThresholdChecker`1.SortThresholds cannot be used for menu commands because class ThresholdChecker`1 is an open generic type.
        // [UnityEditor.MenuItem("Sort Thresholds")]
        protected void SortThresholds()
        {
            thresholds = thresholds.OrderBy(m => m.Value).ToArray();
            // Array.Sort(thresholds);
        }
    }
#endif
}
