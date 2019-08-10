namespace Kore.Variables
{
    public class FloatThresholdChecker : ThresholdChecker<float>
    {
        public FloatThreshold[] thresholds;

        protected override Threshold<float>[] Thresholds => thresholds;
    }
}
