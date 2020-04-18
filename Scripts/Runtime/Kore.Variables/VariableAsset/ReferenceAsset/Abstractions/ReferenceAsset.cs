using UnityEngine;

namespace Kore.Variables
{
    public abstract class ReferenceAsset : ScriptableObject
    {
        public abstract void Set(Object obj);

        public abstract void Release();
    }
}
