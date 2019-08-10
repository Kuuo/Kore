using UnityEngine;
using UnityEditor;

namespace Kore.Editor
{
    [InitializeOnLoad]
    /// <summary>
    /// Drag & Drop a script asset to hierarchy window
    /// to create a new GameObject attached with a Component of the type
    /// that is implemented by the script
    /// </summary>
    public static class ComponentCreatByDragDrop
    {
        static ComponentCreatByDragDrop()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemCallback;
        }

        private static void HierarchyWindowItemCallback(int instanceID, Rect selectionRect)
        {
            if (Event.current.type == EventType.DragUpdated ||
                Event.current.type == EventType.DragPerform)
            {
                if (DragAndDrop.objectReferences.Length > 1) return;

                var dragObj = DragAndDrop.objectReferences[0];

                if (!(dragObj is MonoScript script)) return;

                var componentType = script.GetClass();

                if (!componentType.IsSubclassOf(typeof(Component))) return;

                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                if (Event.current.type == EventType.DragPerform)
                {
                    DragAndDrop.AcceptDrag();

                    var gameObject = new GameObject(script.name, componentType);
                    Selection.activeGameObject = gameObject;
                }

                Event.current.Use();
            }
        }
    }
}
