using UnityEngine;
using Kore;

namespace Kore.Variables
{
    [AddComponentMenu("Kore/Variables/ReferenceListAssetInitializer")]
    public class ReferenceListAssetInitializer : MonoBehaviour
    {
        public ReferenceListAsset listAsset;

        public Object[] targets;

        private void Awake()
        {
            System.Array.ForEach(targets, t => listAsset.Add(t));
        }

        private void OnDestroy()
        {
            System.Array.ForEach(targets, t => listAsset.Remove(t));
        }
    }
}
