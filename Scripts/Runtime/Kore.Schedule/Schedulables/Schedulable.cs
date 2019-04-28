using System.Collections;
using UnityEngine;

namespace Kore.Schedule
{
    public abstract class Schedulable : MonoBehaviour
    {
        public abstract IEnumerator Run();
    }
}
