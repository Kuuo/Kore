using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Variables
{
    public abstract class ReferenceListAsset : ScriptableObject
    {
        public abstract void Add(Object obj);

        public abstract bool Remove(Object obj);

        public abstract void Clear();
    }

    public abstract class ReferenceListAsset<T> : ReferenceListAsset, IList<T>, ICollection<T>
        where T : class
    {
        [SerializeField] protected List<T> data = new List<T>();

        public int Count => data.Count;

        public bool IsReadOnly => (data as IList<T>).IsReadOnly;

        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        public override void Add(Object obj) => Add(obj as T);
        public override void Clear() => data.Clear();

        public void Add(ReferenceListAsset<T> listAsset)
        {
            data.AddRange(listAsset.data);
        }

        public void Add(T item) => data.Add(item);

        public override bool Remove(Object obj) => Remove(obj as T);
        public bool Remove(T item) => data.Remove(item);

        public int IndexOf(T item) => data.IndexOf(item);

        public void Insert(int index, T item) => data.Insert(index, item);

        public void RemoveAt(int index) => data.RemoveAt(index);

        public bool Contains(T item) => data.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => data.CopyTo(array, arrayIndex);

        bool ICollection<T>.Remove(T item) => data.Remove(item);

        public IEnumerator<T> GetEnumerator() => data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => data.GetEnumerator();
    }
}
