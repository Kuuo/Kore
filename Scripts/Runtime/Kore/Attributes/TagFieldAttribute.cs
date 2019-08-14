using System;
using UnityEngine;

namespace Kore
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class TagFieldAttribute : PropertyAttribute
    {
    }
}
