using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

namespace Kore.Editor
{
    public class SubTypesDropdown : AdvancedDropdown
    {
        public Vector2 MinWindowSize
        {
            get => minimumSize;
            set => minimumSize = value;
        }

        private Type parentType;
        private List<Type> subTypes;
        private Dictionary<string, Type> name2Type;
        private Action<Type> onTypeSelected;

        protected SubTypesDropdown(AdvancedDropdownState state) : base(state)
        {
            minimumSize = new Vector2(200f, 300f);
        }

        public SubTypesDropdown(Type parentType, Action<Type> onTypeSelectedCallback) :
            this(new AdvancedDropdownState())
        {
            this.parentType = parentType;
            subTypes = parentType.GetInstantiatableSubClasses();

            name2Type = new Dictionary<string, Type>();
            foreach (var st in subTypes)
            {
                name2Type.Add(st.Name, st);
            }

            onTypeSelected = onTypeSelectedCallback;
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var root = new AdvancedDropdownItem(parentType.Name);

            foreach (var st in subTypes)
            {
                root.AddChild(new AdvancedDropdownItem(st.Name));
            }

            return root;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            var type = name2Type[item.name];
            onTypeSelected.Invoke(type);
        }
    }
}
