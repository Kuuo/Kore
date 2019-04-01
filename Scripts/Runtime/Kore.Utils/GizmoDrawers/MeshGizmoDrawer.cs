using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/GizmoDrawers/MeshGizmoDrawer")]
    public class MeshGizmoDrawer : GizmoDrawer
    {
        public Mesh mesh;
        public Vector3 scale = Vector3.one;
        public bool solidMode;

        protected override void Draw()
        {
            if (solidMode)
            {
                Gizmos.DrawMesh(mesh, transform.position, Quaternion.identity, scale);
            }
            else
            {
                Gizmos.DrawWireMesh(mesh, transform.position, Quaternion.identity, scale);
            }
        }
    }
}
