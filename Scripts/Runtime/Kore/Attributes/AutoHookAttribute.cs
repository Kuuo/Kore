using System;
using UnityEngine;

namespace Kore
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class AutoHookAttribute : PropertyAttribute
    {
    }
}
