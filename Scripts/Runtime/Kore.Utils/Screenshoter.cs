using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/Screenshoter")]
    public class Screenshoter : MonoBehaviour
    {
        public void TakeShot()
        {
            TakeShotToDesktop();
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("Kore/Utils/Take Screenshot %F12")]
#endif
        public static void TakeShotToDesktop()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string sceneName = SceneManager.GetActiveScene().name;
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");

            string fileName = sceneName + "_" + time + ".png";
            string fullPath = Path.Combine(desktopPath, fileName);
            ScreenCapture.CaptureScreenshot(fullPath);

            print("Screenshot taken at [" + fullPath + "]");
        }
    }
}
