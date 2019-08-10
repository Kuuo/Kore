using UnityRandom = UnityEngine.Random;

namespace Kore
{
    public static class ArrayExtensions
    {
        public static T Random<T>(this T[] array) => array[UnityRandom.Range(0, array.Length)];
    }
}
