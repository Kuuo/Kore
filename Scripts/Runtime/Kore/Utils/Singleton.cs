using UnityEngine;

namespace Kore
{
    public abstract class Singleton<T> : MonoBehaviour
        where T : Singleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get => _instance;
            protected set => _instance = value;
        }

        protected virtual void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this as T;
        }
    }
}
