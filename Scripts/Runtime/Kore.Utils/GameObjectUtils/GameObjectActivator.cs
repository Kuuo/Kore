using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/GameObject/GameObjectActivator")]
    public class GameObjectActivator : MonoBehaviour
    {
        public void Activate(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public void Deactivate(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        public void ReverseActive(GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
