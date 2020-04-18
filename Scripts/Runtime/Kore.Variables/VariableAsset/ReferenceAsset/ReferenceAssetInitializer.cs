using UnityEngine;

namespace Kore.Variables
{
    [AddComponentMenu("Kore/Variables/ReferenceAssetInitializer")]
    public class ReferenceAssetInitializer : MonoBehaviour
    {
        public ReferenceAsset asset;
        public UnityEngine.Object target;

        private void Awake()
        {
            asset.Set(target);
        }

        private void OnDestroy()
        {
            asset.Release();
        }
    }
}
