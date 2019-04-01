using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/GameObject/DelayedGameObjectDestroyer")]
    public class DelayedGameObjectDestroyer : GameObjectDestroyer
    {
        public float delay;

        public override void Destroy(GameObject gameObject)
        {
            Object.Destroy(gameObject, delay);
        }
    }
}
