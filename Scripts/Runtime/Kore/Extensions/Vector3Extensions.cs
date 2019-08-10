using UnityEngine;
using Kore;

namespace Kore
{
    public static class Vector3Extensions
    {
        public static float SqrDistance(this Vector3 from, Vector3 to)
        {
            float dx = from.x - to.x;
            float dy = from.y - to.y;
            float dz = from.z - to.z;
            return dx * dx + dy * dy + dz * dz;
        }

        public static (int index, float sqrDist) NearestSqr(this Vector3 source, params Vector3[] targets)
        {
            if (targets == null)
                throw new System.NullReferenceException($"Parameter {nameof(targets)} is null");

            (int index, float sqrDist) ret = (-1, float.MaxValue);

            float tempDist;
            for (int i = 0, len = targets.Length; i < len; i++)
            {
                tempDist = source.SqrDistance(targets[i]);

                if (tempDist < ret.sqrDist)
                {
                    ret.index = i;
                    ret.sqrDist = tempDist;
                }
            }

            return ret;
        }

        public static (int index, float dist) Nearest(this Vector3 source, params Vector3[] targets)
        {
            var nearestSqr = source.NearestSqr(targets);
            nearestSqr.sqrDist = Mathf.Sqrt(nearestSqr.sqrDist);
            return nearestSqr;
        }
    }
}
