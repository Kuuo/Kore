using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Variables
{
    [System.Serializable]
    public class IntThresholdChecker : ThresholdChecker<int>
    {
        public IntThreshold[] thresholds;

        protected override Threshold<int>[] Thresholds => thresholds;
    }
}
