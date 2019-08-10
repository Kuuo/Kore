using UnityEngine;
using Kore;

namespace Kore
{
    public static class MathUtils
    {
        public static float Remap(float value, float minFrom, float maxFrom, float minTo, float maxTo) =>
            minTo + (maxTo - minTo) * (value / (maxFrom - minFrom));

        public static int Remap(int value, int minFrom, int maxFrom, int minTo, int maxTo) =>
            minTo + (maxTo - minTo) * (value / (maxFrom - minFrom));
    }
}
