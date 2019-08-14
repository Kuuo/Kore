using System;
using UnityEngine;
using UnityEditor;

namespace Kore.Editor
{
    public static class SerializedPropertyExtensions
    {
        public static Type GetFieldType(this SerializedProperty property)
        {
            var objType = property.serializedObject.targetObject.GetType();
            var fieldInfo = objType.GetField(property.propertyPath);
            return fieldInfo.FieldType;
        }
    }
}
