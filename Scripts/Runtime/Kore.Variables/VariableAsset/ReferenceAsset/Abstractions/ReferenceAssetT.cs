namespace Kore.Variables
{
    public abstract class ReferenceAsset<T> : ReferenceAsset
        where T : class
    {
        [UnityEngine.SerializeField]
        protected T reference;

        public T Reference
        {
            get => reference;
            set => reference = value;
        }

        public void Release() => reference = null;

        public override string ToString() => reference.ToString();
    }
}
