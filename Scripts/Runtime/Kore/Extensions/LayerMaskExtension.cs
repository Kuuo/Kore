using UnityEngine;

namespace Kore
{
    public static class LayerMaskExtension
    {
        public static bool Contains(this LayerMask mask, int other)
        {
            return (mask.value & (1 << other)) != 0;
        }
    }
}
