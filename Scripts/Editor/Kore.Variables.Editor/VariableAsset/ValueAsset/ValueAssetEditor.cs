using UnityEditor;
using UnityEngine;
using Kore.Events;

namespace Kore.Variables.Editor
{
    // TODO: use SerializedProperty instead
    public abstract class ValueAssetEditor<TValue, TAsset, TGameEvent> : UnityEditor.Editor
        where TValue : struct
        where TAsset : ValueAsset<TValue, TGameEvent>
        where TGameEvent : GameEvent<TValue>
    {
        private TAsset asset;

        private void OnEnable()
        {
            asset = target as TAsset;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();

            if (asset.OnValueChanged == null)
            {
                NoEventDraw();
            }
            else
            {
                ExistEventDraw();
            }
        }

        private void NoEventDraw()
        {
            if (GUILayout.Button("Create OnValueChanged Event"))
            {
                CreateEvent(asset);
            }
        }

        private void ExistEventDraw()
        {
            if (GUILayout.Button("Remove OnValueChanged Event"))
            {
                RemoveEvent(asset);
            }
        }

        public static void CreateEvent(ValueAsset<TValue, TGameEvent> asset)
        {
            var newEvent = CreateInstance<TGameEvent>();
            newEvent.name = $"On{asset.name}Changed";

            // Undo.RecordObject(newEvent, $"Created new {typeof(TGameEvent).Name} to {asset.name}");

            asset.OnValueChanged = newEvent;
            AssetDatabase.AddObjectToAsset(newEvent, asset);
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(newEvent));
        }

        public static void RemoveEvent(ValueAsset<TValue, TGameEvent> asset)
        {
            // Undo.RecordObject(asset, $"Remove {typeof(TGameEvent).Name} at {asset.name}");

            DestroyImmediate(asset.OnValueChanged, true);
            asset.OnValueChanged = null;
        }
    }
}
