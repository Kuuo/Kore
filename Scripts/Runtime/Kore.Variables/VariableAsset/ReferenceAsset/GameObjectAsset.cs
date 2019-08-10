using UnityEngine;

namespace Kore.Variables
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Reference/GameObject",
                     fileName = "GameObject Reference")]
    public class GameObjectAsset : ReferenceAsset<GameObject>
    {
        public void SetActive(bool active)
        {
            Reference.SetActive(active);
        }

        public void ReverseActivity()
        {
            Reference.SetActive(!Reference.activeSelf);
        }
    }
}
