using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kore.ScreenControl
{
    [AddComponentMenu("Kore/ScreenControl/ResulotionControl")]
    public class ResulotionControl : MonoBehaviour
    {
        public TMP_Dropdown dropdown;
        public int minResolutionWidth = 640;

        private List<Resolution> resolutions;

        private void Start()
        {
            resolutions = new List<Resolution>();
            dropdown.ClearOptions();

            foreach (var item in Screen.resolutions)
            {
                if (item.width < minResolutionWidth) continue;

                resolutions.Add(item);
                dropdown.options.Add(new TMP_Dropdown.OptionData($"{item.width} x {item.height}"));

                if (item.width == Screen.width && item.height == Screen.height)
                {
                    dropdown.SetValueWithoutNotify(resolutions.Count - 1);
                }
            }

            dropdown.onValueChanged.AddListener(SetResolution);
            dropdown.RefreshShownValue();
        }

        private void OnDestroy()
        {
            dropdown.onValueChanged.RemoveListener(SetResolution);
        }

        private void SetResolution(int index)
        {
            var resolution = resolutions[index];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }
    }
}
