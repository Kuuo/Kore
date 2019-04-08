using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/GizmoDrawers/LineGizmoDrawer")]
    public class LineGizmoDrawer : GizmoDrawer
    {
        public Transform lineEnd;

        protected override bool UseTransformMatrix() => false;

        protected override void Draw()
        {
            if (lineEnd)
            {
                Gizmos.DrawLine(transform.position, lineEnd.position);
            }
        }
    }
}
