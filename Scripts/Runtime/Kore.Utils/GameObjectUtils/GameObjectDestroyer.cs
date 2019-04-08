using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/GameObject/GameObjectDestroyer")]
    public class GameObjectDestroyer : MonoBehaviour
    {
        float delay = 0f;

        public virtual void Destroy(GameObject gameObject)
        {
            Object.Destroy(gameObject, delay);
        }
    }
}
