using UnityEngine;
using Kore.Conditions;

namespace Kore.Variables
{
    [CreateAssetMenu(menuName = "Kore/ConditionCheck/ValueCheck/Bool")]
    public class BoolValueCheck : ConditionCheck
    {
        public BoolAsset asset;
        public bool needValue;

        protected override bool Check()
        {
            return asset.Value == needValue;
        }
    }
}