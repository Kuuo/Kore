using UnityEngine;

namespace Kore.Variables
{
    public abstract class ValueAsset : ScriptableObject
    {
        public abstract object objectValue { get; }

        public override string ToString() => objectValue.ToString();
    }
}
