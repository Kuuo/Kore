using UnityEngine;
using Kore.Events;

namespace Kore.Variables
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Value/Int")]
    public class IntAsset : NumberAsset<int>
    {
        [SerializeField]
        private IntGameEvent _onValueChangeEvent;

        public override GameEvent<int> OnValueChanged
        {
            get { return _onValueChangeEvent; }
            set { _onValueChangeEvent = value as IntGameEvent; }
        }

        public override int intValue { get => Value; set => Value = value; }
        public override float floatValue { get => Value; set => Value = (int)value; }

        public void Add(int amount) => Value += amount;

        public void Add(IntAsset asset) => Value += asset.Value;

        public void Set(IntAsset asset) => Value = asset.Value;
    }
}
