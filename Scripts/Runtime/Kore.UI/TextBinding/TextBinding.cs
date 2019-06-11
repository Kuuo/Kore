using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kore.UI
{
    public abstract class TextBinding<TValue> : MonoBehaviour
    {
        public TMP_Text bindText;
        public string format = "G";
        [SerializeField] protected bool setValuOnEnable = true;

        protected abstract TValue value { get; }

        protected virtual void OnEnable()
        {
            if (setValuOnEnable)
            {
                SetText(value);
            }
        }

        protected virtual void SetText(TValue newValue)
        {
            string text = string.Format($"{{0:{format}}}", newValue);
            bindText.text = text;
        }
    }
}
