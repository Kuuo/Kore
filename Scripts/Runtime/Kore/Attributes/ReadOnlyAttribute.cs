using UnityEngine;

namespace Kore
{
    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public class ReadOnlyAttribute : PropertyAttribute
    {
    }
}
