using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/UrlOpener")]
    public class UrlOpener : MonoBehaviour
    {
        public string url;

        public void Open()
        {
            Open(url);
        }

        public void Open(string url)
        {
            Application.OpenURL(url);
        }
    }
}
