using TMPro;
using Kore.Events;

namespace Kore.Variables.UI
{
    public abstract class ValueAssetTextBinding<TValue> : AbstractGameEventListener<TValue>
        where TValue : struct
    {
        public TMP_Text bindText;
        public string format = "G";

        protected TValue value => valueAsset.Value;

        protected abstract ValueAsset<TValue> valueAsset { get; }

        protected override GameEvent<TValue> listeningEvent => valueAsset.OnValueChanged;

        protected override void OnEnable()
        {
            SetText(value);
            base.OnEnable();
        }

        public virtual void SetText(TValue newValue)
        {
            string text = string.Format($"{{0:{format}}}", newValue);
            bindText.text = text;
        }

        public override void Response(TValue arg)
        {
            SetText(arg);
        }
    }
}
