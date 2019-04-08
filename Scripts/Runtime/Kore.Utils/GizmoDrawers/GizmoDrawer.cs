using UnityEngine;

namespace Kore.Utils
{
    public abstract class GizmoDrawer : MonoBehaviour
    {
        public Color color = Color.grey;

        protected virtual bool setMatrix { get; set; } = true;

        private void OnDrawGizmosSelected()
        {
            Color preColor = Gizmos.color;
            Gizmos.color = color;

            Matrix4x4 preMatrix = Gizmos.matrix;
            if (setMatrix)
            {
                Gizmos.matrix = transform.localToWorldMatrix;
            }

            Draw();

            if (setMatrix)
            {
                Gizmos.color = preColor;
                Gizmos.matrix = preMatrix;
            }
        }

        protected abstract void Draw();
    }
}
