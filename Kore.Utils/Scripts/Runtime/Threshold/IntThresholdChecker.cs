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

        protected override Threshold<int>[] thresholds => Thresholds;

        protected override UnityEvent<int> onValueChanged => onValueChanged;
    }
}
