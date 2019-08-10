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
    }
}
