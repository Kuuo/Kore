using UnityEngine;
using Kore.Events;

namespace Kore.Variables
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Value/Float")]
    public class FloatAsset : NumberAsset<float, FloatGameEvent>
    {
        public void Add(float amount) => Value += amount;

        public void Add(FloatAsset asset) => Value += asset.Value;

        public override void Set(int newValue) => Value = newValue;

        public override void Set(float newValue) => Value = newValue;
    }
}
