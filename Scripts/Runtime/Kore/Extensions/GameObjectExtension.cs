using System;
using UnityEngine;

namespace Kore
{
    public static class GameObjectExtension
    {
        public static void EnableComponentsInChildren<T>(this GameObject go, bool enable)
            where T : Behaviour
        {
            var components = go.GetComponentsInChildren<T>();
            System.Array.ForEach(components, c => c.enabled = enable);
        }

        public static T GetOrAddComponent<T>(this GameObject go)
            where T : Component
        {
            if (go.TryGetComponent<T>(out T component))
            {
                return component;
            }

            return go.AddComponent<T>();
        }

        public static Component GetOrAddComponent(this GameObject go, Type type)
        {
            if (!type.IsSubclassOf(typeof(Component)))
                throw new ArgumentException($"Argument {nameof(type)} should be sub-class of Component");

            var component = go.GetComponent(type);

            if (!component) component = go.AddComponent(type);

            return component;
        }
    }
}
