using UnityEngine;

namespace Kore.Variables
{
    public abstract class ReferenceAsset<T> : ReferenceAsset
        where T : class
    {
        [SerializeField] protected T reference;

        public T Reference
        {
            get => reference;
            set => reference = value;
        }

        public override void Set(Object obj) => Reference = obj as T;
        public void Set(T obj) => Reference = obj;

        public override void Release() => reference = null;

        public override string ToString() => reference.ToString();
    }
}
