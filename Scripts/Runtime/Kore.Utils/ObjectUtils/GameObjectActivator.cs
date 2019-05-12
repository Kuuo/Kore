using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/Object/GameObject Activator")]
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

        public void ReverseActiveState(GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
