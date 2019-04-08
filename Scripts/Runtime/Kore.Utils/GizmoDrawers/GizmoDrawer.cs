using UnityEngine;

namespace Kore.Utils
{
    public abstract class GizmoDrawer : MonoBehaviour
    {
        public Color color = Color.grey;

        private void OnDrawGizmosSelected()
        {
            Color preColor = Gizmos.color;
            Gizmos.color = color;

            Matrix4x4 preMatrix = Gizmos.matrix;
            if (UseTransformMatrix())
            {
                Gizmos.matrix = transform.localToWorldMatrix;
            }

            Draw();

            if (UseTransformMatrix())
            {
                Gizmos.color = preColor;
                Gizmos.matrix = preMatrix;
            }
        }

        protected abstract void Draw();

        protected virtual bool UseTransformMatrix() => true;
    }
}
