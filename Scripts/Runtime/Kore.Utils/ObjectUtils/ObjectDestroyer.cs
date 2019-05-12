using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/Object/Object Destroyer")]
    public class ObjectDestroyer : MonoBehaviour
    {
        public float delay = 0f;

        public void Destroy(GameObject obj)
        {
            DoDestroy(obj);
        }

        public void Destroy(Component obj)
        {
            DoDestroy(obj);
        }

        public void DestroyImmediate(GameObject obj)
        {
            DoDestroyImmediate(obj);
        }

        public void DestroyImmediate(Component obj)
        {
            DoDestroyImmediate(obj);
        }

        private void DoDestroy(Object obj)
        {
            Object.Destroy(obj, delay);
        }

        private void DoDestroyImmediate(Object obj)
        {
            Object.Destroy(obj);
        }
    }
}
