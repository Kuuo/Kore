using UnityEngine;

namespace Kore.Utils.GizmoDrawers
{
    [AddComponentMenu("Kore/Utils/GizmoDrawers/FrustumGizmoDrawer")]
    public class FrustumGizmoDrawer : GizmoDrawer
    {
        public float fov = 60f;
        public float maxRange = 50f;
        public float minRange = .1f;
        public float aspect = 1.77778f;

        protected override void Draw()
        {
            Gizmos.DrawFrustum(Vector3.zero, fov, maxRange, minRange, aspect);
        }
    }
}
