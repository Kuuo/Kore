using UnityEngine;

namespace Kore
{
    public static class LayerMaskExtensions
    {
        public static bool Contains(this LayerMask mask, int other)
        {
            return (mask.value & (1 << other)) != 0;
        }

        public static bool Contains(this LayerMask mask, Component component)
        {
            return mask.Contains(component.gameObject.layer);
        }
    }
}
