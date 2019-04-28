using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

namespace Kore
{
    public static class TypeExtensions
    {
        public static List<Type> GetInstantiatableSubClasses(this Type type)
        {
            var ret = new List<Type>();
            Array.ForEach(AppDomain.CurrentDomain.GetAssemblies(), a =>
            {
                ret.AddRange(a.GetTypes().Where(t => !t.IsAbstract && t.IsSubclassOf(type)));
            });
            return ret;
        }
    }
}
