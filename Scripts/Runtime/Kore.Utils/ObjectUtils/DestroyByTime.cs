using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/Object/Destroy By Time")]
    public class DestroyByTime : MonoBehaviour
    {
        public float time;

        private void Start()
        {
            Destroy(gameObject, time);
        }
    }
}
