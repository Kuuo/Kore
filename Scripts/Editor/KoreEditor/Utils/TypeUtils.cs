using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

namespace Kore.Editor.Utils
{
    public static class TypeUtils
    {
        public static List<Type> GetInstantiatableSubClassOf(Type type)
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
