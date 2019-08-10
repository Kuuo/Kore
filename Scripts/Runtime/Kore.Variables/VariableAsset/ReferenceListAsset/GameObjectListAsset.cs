using System.Linq;
using UnityEngine;

namespace Kore.Variables
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/ReferenceList/GameObjectList",
                     fileName = "GameObject Reference List")]
    public class GameObjectListAsset : ReferenceListAsset<GameObject>
    {
        public void Add(GameObjectListAsset asset)
        {
            base.Add(asset);
        }

        public GameObject[] GetAlives()
        {
            return data.Where(go => go != null && go.activeInHierarchy).ToArray();
        }

        public void SetActiveAll(bool active)
        {
            data.ForEach(go =>
            {
                if (go) go.SetActive(active);
            });
        }
    }
}
