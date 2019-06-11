using Kore.UI;

namespace Kore.Variables.UI
{
    public abstract class ValueAssetTextBinding<TValue> : TextBinding<TValue>
        where TValue : struct
    {
        protected abstract ValueAsset<TValue> valueAsset { get; }

        protected override void OnEnable()
        {
            base.OnEnable();
            valueAsset.OnValueChanged?.AddListener(SetText);
        }

        private void OnDisable()
        {
            valueAsset.OnValueChanged?.RemoveListener(SetText);
        }
    }
}
