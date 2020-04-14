using UnityEngine;
using Kore;

namespace Kore
{
    public static class Vector2Extensions
    {
        public static float RandomRange(this Vector2 v) => Random.Range(v.x, v.y);

        public static Vector2 With(this Vector2 v, float? x = null, float? y = null)
        {
            return new Vector2(x ?? v.x, y ?? v.y);
        }

        public static void SetWith(this Vector2 v, float? x = null, float? y = null)
        {
            v.Set(x ?? v.x, y ?? v.y);
        }

        public static float SqrDistance(this Vector2 from, Vector2 to)
        {
            float dx = from.x - to.x;
            float dy = from.y - to.y;
            return dx * dx + dy * dy;
        }

        public static (int index, float sqrDist) NearestSqr(this Vector2 source, params Vector2[] targets)
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

        public static (int index, float dist) Nearest(this Vector2 source, params Vector2[] targets)
        {
            var nearestSqr = source.NearestSqr(targets);
            nearestSqr.sqrDist = Mathf.Sqrt(nearestSqr.sqrDist);
            return nearestSqr;
        }
    }
}
