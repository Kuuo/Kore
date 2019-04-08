using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/GizmoDrawers/SphereGizmoDrawer")]
    public class SphereGizmoDrawer : GizmoDrawer
    {
        public float radius = 1f;
        public bool solidMode;

        protected override bool setMatrix { get; set; } = false;

        protected override void Draw()
        {
            if (solidMode)
            {
                Gizmos.DrawSphere(transform.position, radius);
            }
            else
            {
                Gizmos.DrawWireSphere(transform.position, radius);
            }
        }
    }
}
