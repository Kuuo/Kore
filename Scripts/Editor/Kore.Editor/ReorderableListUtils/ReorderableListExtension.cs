using System;
using UnityEngine;
using UnityEditorInternal;

namespace Kore.Editor
{
    public static class ReorderableListExtension
    {
        #region Callback Chain
        public static ReorderableList OnDrawFooter(this ReorderableList list,
             ReorderableList.FooterCallbackDelegate callback)
        {
            list.drawFooterCallback = callback;
            return list;
        }

        public static ReorderableList OnDrawElement(this ReorderableList list,
             ReorderableList.ElementCallbackDelegate callback)
        {
            list.drawElementCallback = callback;
            return list;
        }

        public static ReorderableList OnElementHeight(this ReorderableList list,
             ReorderableList.ElementHeightCallbackDelegate callback)
        {
            list.elementHeightCallback = callback;
            return list;
        }

        public static ReorderableList OnCanAdd(this ReorderableList list,
             ReorderableList.CanAddCallbackDelegate callback)
        {
            list.onCanAddCallback = callback;
            return list;
        }

        public static ReorderableList OnReorderWithDetails(this ReorderableList list,
             ReorderableList.ReorderCallbackDelegateWithDetails callback)
        {
            list.onReorderCallbackWithDetails = callback;
            return list;
        }

        public static ReorderableList OnReorder(this ReorderableList list,
             ReorderableList.ReorderCallbackDelegate callback)
        {
            list.onReorderCallback = callback;
            return list;
        }

        public static ReorderableList OnSelect(this ReorderableList list,
             ReorderableList.SelectCallbackDelegate callback)
        {
            list.onSelectCallback = callback;
            return list;
        }

        public static ReorderableList OnAdd(this ReorderableList list,
             ReorderableList.AddCallbackDelegate callback)
        {
            list.onAddCallback = callback;
            return list;
        }

        public static ReorderableList OnAddDropdown(this ReorderableList list,
             ReorderableList.AddDropdownCallbackDelegate callback)
        {
            list.onAddDropdownCallback = callback;
            return list;
        }

        public static ReorderableList OnRemove(this ReorderableList list,
             ReorderableList.RemoveCallbackDelegate callback)
        {
            list.onRemoveCallback = callback;
            return list;
        }

        public static ReorderableList OnChanged(this ReorderableList list,
             ReorderableList.ChangedCallbackDelegate callback)
        {
            list.onChangedCallback = callback;
            return list;
        }

        public static ReorderableList OnCanRemove(this ReorderableList list,
             ReorderableList.CanRemoveCallbackDelegate callback)
        {
            list.onCanRemoveCallback = callback;
            return list;
        }

        public static ReorderableList OnHeader(this ReorderableList list,
             ReorderableList.HeaderCallbackDelegate callback)
        {
            list.drawHeaderCallback = callback;
            return list;
        }

        public static ReorderableList OnDrawNoneElement(this ReorderableList list,
             ReorderableList.DrawNoneElementCallback callback)
        {
            list.drawNoneElementCallback = callback;
            return list;
        }
        #endregion
    }
}
