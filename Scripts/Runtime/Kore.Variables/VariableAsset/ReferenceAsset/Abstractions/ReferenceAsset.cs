using UnityEngine;

namespace Kore.Variables
{
    public abstract class ReferenceAsset : ScriptableObject
    {
        public abstract void Set(UnityEngine.Object obj);

        public abstract void Release();

        protected virtual void OnDisable()
        {
            Release();
        }
    }
}
