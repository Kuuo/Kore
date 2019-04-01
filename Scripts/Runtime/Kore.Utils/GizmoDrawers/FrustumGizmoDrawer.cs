using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/GizmoDrawer/FrustumGizmoDrawer")]
    public class FrustumGizmoDrawer : GizmoDrawer
    {
        public float fov = 60f;
        public float maxRange = 50f;
        public float minRange = .1f;
        public float aspect = 1.77778f;

        protected override void Draw()
        {
            Gizmos.DrawFrustum(transform.position, fov, maxRange, minRange, aspect);
        }
    }
}
