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
#if UNITY_EDITOR
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string sceneName = SceneManager.GetActiveScene().name;
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");

            string fileBaseName = sceneName + "_" + time + ".png";
            string filename = Path.Combine(desktopPath, fileBaseName);
            ScreenCapture.CaptureScreenshot(filename);

            print("Screenshot taken at [" + filename + "]");
#endif
        }
    }
}
