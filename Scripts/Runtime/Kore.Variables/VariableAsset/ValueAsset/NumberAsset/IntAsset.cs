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

        public void Add(int amount) => Value += amount;

        public void Add(IntAsset asset) => Value += asset.Value;

        public void Set(IntAsset asset) => Value = asset.Value;
    }
}
