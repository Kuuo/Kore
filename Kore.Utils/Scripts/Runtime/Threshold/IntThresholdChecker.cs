using UnityEngine;
using UnityEngine.Events;
using Kore.Events;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/Threshold/IntThresholdChecker")]
    public class IntThresholdChecker : ThresholdChecker<int>
    {
        public IntThreshold[] Thresholds;

        public IntUnityEvent OnValueChanged;

        protected override Threshold<int>[] thresholds
        {
            get { return Thresholds; }
            set { Thresholds = value as IntThreshold[]; }
        }

        protected override UnityEvent<int> onValueChanged => OnValueChanged;
    }
}
