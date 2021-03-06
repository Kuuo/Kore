﻿using UnityEngine;

namespace Kore.Utils.GizmoDrawers
{
    [AddComponentMenu("Kore/Utils/GizmoDrawers/SphereGizmoDrawer")]
    public class SphereGizmoDrawer : GizmoDrawer
    {
        public float radius = 1f;
        public bool solidMode;

        protected override bool UseTransformMatrix() => false;

        protected override void Draw()
        {
            if (solidMode)
            {
                Gizmos.DrawSphere(transform.position, radius);
            }
            else
            {
                Gizmos.DrawWireSphere(transform.position, radius);
            }
        }
    }
}
