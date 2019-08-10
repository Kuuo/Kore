using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kore.SceneManagement
{
    [AddComponentMenu("Kore/SceneManagement/SceneLoader")]
    public class SceneLoader : MonoBehaviour
    {
        [SceneIndex] public int target;
        public LoadSceneMode mode = LoadSceneMode.Single;

        public void Load() => LoadAt(target);
        public void ReloadActiveScene() => LoadAt(SceneManager.GetActiveScene().buildIndex);
        private void LoadAt(int index) => SceneManager.LoadScene(index, mode);

        public AsyncOperation LoadAsync() => LoadAtAsync(target);
        public AsyncOperation ReloadActiveSceneAsync() => LoadAtAsync(SceneManager.GetActiveScene().buildIndex);
        private AsyncOperation LoadAtAsync(int index) => SceneManager.LoadSceneAsync(index, mode);
    }
}
