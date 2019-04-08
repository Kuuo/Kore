using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/GizmoDrawers/RayGizmoDrawer")]
    public class RayGizmoDrawer : GizmoDrawer
    {
        public Vector3 direction = Vector3.one;

        protected override bool UseTransformMatrix() => false;

        protected override void Draw()
        {
            Gizmos.DrawRay(transform.position, direction);
        }
    }
}
