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

        public Action<Type> onTypeSelected;

        private AdvancedDropdownItem root;
        private Dictionary<string, Type> name2Type;

        protected SubTypesDropdown(AdvancedDropdownState state) : base(state)
        {
            minimumSize = new Vector2(200f, 300f);
        }

        public SubTypesDropdown(Type parentType, Action<Type> onTypeSelectedCallback) :
            this(new AdvancedDropdownState())
        {
            root = new AdvancedDropdownItem(parentType.Name);

            var subTypes = parentType.GetInstantiatableSubClasses();
            name2Type = new Dictionary<string, Type>();

            subTypes.ForEach(type => Add(type));

            onTypeSelected = onTypeSelectedCallback;
        }

        public void Add(Type subType)
        {
            string typeName = subType?.Name ?? "None";

            name2Type.Add(typeName, subType);
            root.AddChild(new AdvancedDropdownItem(typeName));
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            return root;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            var type = name2Type[item.name];
            onTypeSelected?.Invoke(type);
        }
    }
}
