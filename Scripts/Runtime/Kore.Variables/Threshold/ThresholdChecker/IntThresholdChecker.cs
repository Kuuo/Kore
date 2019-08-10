namespace Kore.Variables
{
    [System.Serializable]
    public class IntThresholdChecker : ThresholdChecker<int>
    {
        public IntThreshold[] thresholds;

        protected override Threshold<int>[] Thresholds => thresholds;
    }
}
