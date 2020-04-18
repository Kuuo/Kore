using UnityEngine;

namespace Kore.Conditions
{
    [CreateAssetMenu(menuName = "Kore/ConditionCheck/LayerCheck")]
    public class LayerCheck : ScriptableObject
    {
        public LayerMask acceptLayer;

        public bool Accept(GameObject go)
        {
            return Accept(go.layer);
        }

        public bool Accept(Component component)
        {
            return Accept(component.gameObject.layer);
        }

        public bool Accept(int layer)
        {
            return acceptLayer.Contains(layer);
        }
    }
}
