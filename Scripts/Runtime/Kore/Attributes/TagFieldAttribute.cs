using System;
using UnityEngine;
using Kore;

namespace Kore
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class TagFieldAttribute : PropertyAttribute
    {
    }
}
