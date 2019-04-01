using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/GizmoDrawers/CubeGizmoDrawer")]
    public class CubeGizmoDrawer : GizmoDrawer
    {
        public Vector3 scale = Vector3.one;
        public bool solidMode;

        protected override void Draw()
        {
            if (solidMode)
            {
                Gizmos.DrawCube(transform.position, scale);
            }
            else
            {
                Gizmos.DrawWireCube(transform.position, scale);
            }
        }
    }
}
