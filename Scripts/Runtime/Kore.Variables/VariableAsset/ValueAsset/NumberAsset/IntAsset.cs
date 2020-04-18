using UnityEngine;
using Kore.Events;

namespace Kore.Variables
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Value/Int")]
    public class IntAsset : NumberAsset<int, IntGameEvent>
    {
        public void Add(int amount) => Value += amount;

        public void Add(IntAsset asset) => Value += asset.Value;

        public override void Set(int newValue) => Value = newValue;

        public override void Set(float newValue) => Value = (int)newValue;
    }
}
