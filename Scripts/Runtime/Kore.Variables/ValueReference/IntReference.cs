
namespace Kore.Variables
{
    [System.Serializable]
    public class IntReference : ValueReference<int>
    {
        [UnityEngine.SerializeField] protected IntAsset asset;

        protected override ValueAsset<int> valueAsset => asset;
    }
}
