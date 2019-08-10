using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Variables
{
    public abstract class ReferenceListAsset : ScriptableObject
    {
        public abstract void Add(object obj);

        public abstract void Clear();

        protected virtual void OnDisable() => Clear();
    }

    public abstract class ReferenceListAsset<T> : ReferenceListAsset, IList<T>
        where T : class
    {
        [SerializeField] protected List<T> data = new List<T>();

        public int Count => ((IList<T>)data).Count;

        public bool IsReadOnly => ((IList<T>)data).IsReadOnly;

        public T this[int index]
        {
            get => ((IList<T>)data)[index];
            set => ((IList<T>)data)[index] = value;
        }

        public override void Add(object obj) => Add(obj as T);
        public override void Clear() => data.Clear();

        public void Add(ReferenceListAsset<T> listAsset)
        {
            data.AddRange(listAsset.data);
        }

        public void Add(T item) => data.Add(item);

        public int IndexOf(T item) => ((IList<T>)data).IndexOf(item);

        public void Insert(int index, T item) => ((IList<T>)data).Insert(index, item);

        public void RemoveAt(int index) => ((IList<T>)data).RemoveAt(index);

        public bool Contains(T item) => ((IList<T>)data).Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => ((IList<T>)data).CopyTo(array, arrayIndex);

        bool ICollection<T>.Remove(T item) => ((IList<T>)data).Remove(item);

        public IEnumerator<T> GetEnumerator() => ((IList<T>)data).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IList<T>)data).GetEnumerator();
    }
}
