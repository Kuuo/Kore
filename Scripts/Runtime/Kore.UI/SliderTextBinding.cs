using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kore.UI
{
    [AddComponentMenu("Kore/UI/SliderTextBinding")]
    public class SliderTextBinding : MonoBehaviour
    {
        public Slider slider;
        public TextMeshProUGUI text;
        public string format = "F2";

        public void Start()
        {
            SetText(slider.value);
        }

        private void OnEnable()
        {
            slider.onValueChanged.AddListener(SetText);
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(SetText);
        }

        private void SetText(float value)
        {
            text.text = value.ToString(format);
        }
    }
}
