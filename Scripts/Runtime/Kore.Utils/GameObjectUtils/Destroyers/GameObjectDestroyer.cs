using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/GameObject/GameObjectDestroyer")]
    public class GameObjectDestroyer : MonoBehaviour
    {
        public virtual void Destroy(GameObject gameObject)
        {
            Object.Destroy(gameObject);
        }
    }
}
