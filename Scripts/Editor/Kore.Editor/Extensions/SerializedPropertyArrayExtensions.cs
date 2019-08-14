using UnityEngine;
using UnityEditor;

namespace Kore.Editor
{
    public static class SerializedPropertyArrayExtensions
    {
        public static void AddArrayElement<T>(this SerializedProperty arrayProperty, T elementToAdd)
            where T : Object
        {
            if (!arrayProperty.isArray)
                throw new UnityException("SerializedProperty " + arrayProperty.name + " is not an array.");

            arrayProperty.serializedObject.Update();

            arrayProperty.InsertArrayElementAtIndex(arrayProperty.arraySize);
            arrayProperty.GetArrayElementAtIndex(arrayProperty.arraySize - 1).objectReferenceValue = elementToAdd;

            arrayProperty.serializedObject.ApplyModifiedProperties();
        }

        public static void AddArrayElementNull(this SerializedProperty arrayProperty) =>
            arrayProperty.AddArrayElement<Object>(null);


        public static void RemoveArrayElementAtIndex(this SerializedProperty arrayProperty, int index)
        {
            if (!arrayProperty.isArray)
                throw new UnityException("SerializedProperty " + arrayProperty.name + " is not an array.");

            if (index < 0 || index > arrayProperty.arraySize - 1)
                throw new System.IndexOutOfRangeException(
                    $"Index [{index}] out of range from SerializedProperty {arrayProperty.name}");

            arrayProperty.serializedObject.Update();

            // If there is a non-null element at the index, null it.
            if (arrayProperty.GetArrayElementAtIndex(index).objectReferenceValue)
                arrayProperty.DeleteArrayElementAtIndex(index);

            // Delete the null element from the array at the index.
            arrayProperty.DeleteArrayElementAtIndex(index);

            arrayProperty.serializedObject.ApplyModifiedProperties();
        }


        public static void RemoveArrayElement<T>(this SerializedProperty arrayProperty, T elementToRemove)
            where T : Object
        {
            if (!arrayProperty.isArray)
                throw new UnityException("SerializedProperty " + arrayProperty.name + " is not an array.");

            if (!elementToRemove) return;

            arrayProperty.serializedObject.Update();

            for (int i = 0; i < arrayProperty.arraySize; i++)
            {
                SerializedProperty elementProperty = arrayProperty.GetArrayElementAtIndex(i);

                if (elementProperty.objectReferenceValue == elementToRemove)
                {
                    arrayProperty.RemoveArrayElementAtIndex(i);
                    return;
                }
            }
        }
    }
}
