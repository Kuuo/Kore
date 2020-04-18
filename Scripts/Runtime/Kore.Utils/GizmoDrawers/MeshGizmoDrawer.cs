using UnityEngine;

namespace Kore.Utils.GizmoDrawers
{
    [AddComponentMenu("Kore/Utils/GizmoDrawers/MeshGizmoDrawer")]
    public class MeshGizmoDrawer : GizmoDrawer
    {
        public Mesh mesh;
        public Vector3 scale = Vector3.one;
        public bool solidMode;

        protected override bool UseTransformMatrix() => false;

        protected override void Draw()
        {
            if (solidMode)
            {
                Gizmos.DrawMesh(mesh, transform.position, transform.rotation, scale);
            }
            else
            {
                Gizmos.DrawWireMesh(mesh, transform.position, transform.rotation, scale);
            }
        }
    }
}
