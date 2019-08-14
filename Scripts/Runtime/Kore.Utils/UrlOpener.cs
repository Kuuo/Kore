using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/UrlOpener")]
    public class UrlOpener : MonoBehaviour
    {
        public string url;

        [ContextMenu("Open")]
        public void Open()
        {
            Open(url);
        }

        public void Open(Kore.Variables.StringAsset url)
        {
            Open(url.value);
        }

        public void Open(string url)
        {
            Application.OpenURL(url);
        }
    }
}
