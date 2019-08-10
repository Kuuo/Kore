using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Variables
{
    public abstract class NumberAsset<T> : ValueAsset<T>
        where T : struct
    {
        public abstract int intValue { get; set; }
        public abstract float floatValue { get; set; }
    }
}
