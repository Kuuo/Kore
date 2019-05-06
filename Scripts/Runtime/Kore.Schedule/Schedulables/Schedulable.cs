using System.Collections;
using UnityEngine;

namespace Kore.Schedule
{
    public abstract class Schedulable : MonoBehaviour
    {
        protected Coroutine coroutine;

        protected abstract IEnumerator ScheduleCoroutine();

        public IEnumerator Run()
        {
            yield return coroutine = StartCoroutine(ScheduleCoroutine());
        }

        // Provide for UnityEvent use
        public void Execute()
        {
            Run();
        }

        public void Stop()
        {
            if (coroutine == null) return;
            StopCoroutine(coroutine);
        }
    }
}
