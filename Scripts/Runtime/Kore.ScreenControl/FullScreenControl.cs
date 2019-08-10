using UnityEngine;
using UnityEngine.UI;

namespace Kore.ScreenControl
{
    [AddComponentMenu("Kore/ScreenControl/FullScreenControl")]
    public class FullScreenControl : MonoBehaviour
    {
        public Toggle toggle;

        private void Start()
        {
            toggle.isOn = Screen.fullScreen;

            toggle.onValueChanged.AddListener(SwitchFullScreen);
        }

        private void OnDestroy()
        {
            toggle.onValueChanged.RemoveListener(SwitchFullScreen);
        }

        public void SwitchFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }
    }
}
