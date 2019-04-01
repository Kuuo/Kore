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
            Draw();
            Gizmos.color = preColor;
        }

        protected abstract void Draw();
    }
}
