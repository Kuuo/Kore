using System.Collections.Generic;
using UnityRandom = UnityEngine.Random;

namespace Kore
{
    public static class IListExtensions
    {
        public static T Random<T>(IList<T> list) => list[UnityRandom.Range(0, list.Count)];
    }
}
