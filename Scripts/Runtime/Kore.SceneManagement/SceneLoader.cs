using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kore.SceneManagement
{
    [AddComponentMenu("Kore/SceneManagement/SceneLoader")]
    public class SceneLoader : MonoBehaviour
    {
        public SceneReference target;
        public LoadSceneMode mode = LoadSceneMode.Single;

        public void Load() => Load(target.scenePath);
        public void Load(SceneReference sceneReference) => Load(sceneReference.scenePath);
        public void ReloadActiveScene() => Load(SceneManager.GetActiveScene().name);
        private void Load(string sceneName, LoadSceneMode mode = LoadSceneMode.Single) =>
            SceneManager.LoadScene(sceneName, mode);

        public AsyncOperation LoadAsync() => LoadAsync(target.scenePath);
        public AsyncOperation ReloadActiveSceneAsync() => LoadAsync(SceneManager.GetActiveScene().name);
        private AsyncOperation LoadAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single) =>
            SceneManager.LoadSceneAsync(sceneName, mode);
    }
}
