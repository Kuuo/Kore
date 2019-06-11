using UnityEngine;
using Kore.Events;

namespace Kore.Variables
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Value/Bool")]
    public class BoolAsset : ValueAsset<bool>
    {
        [SerializeField]
        private BoolGameEvent _onValueChangeEvent;

        public override GameEvent<bool> OnValueChanged
        {
            get { return _onValueChangeEvent; }
            set { _onValueChangeEvent = value as BoolGameEvent; }
        }

        public void Set(BoolAsset asset) => Value = asset.Value;

        public static implicit operator bool(BoolAsset v) => v.Value;
    }
}
