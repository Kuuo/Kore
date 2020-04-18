using TMPro;
using Kore.Events;
using UnityEngine.Events;

namespace Kore.Variables.UIBinding
{
    public abstract class ValueAssetTextBinding<TValue, TValueAsset, TGameEvent>
        : ValueAssetUIBinding<TValue, TValueAsset, TGameEvent>
        where TValue : struct
        where TValueAsset : ValueAsset<TValue, TGameEvent>
        where TGameEvent: GameEvent<TValue>
    {
        public TMP_Text bindText;
        public string format = "G";

        protected override void OnEnable()
        {
            base.OnEnable();
            SetText(valueAsset.Value);
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
