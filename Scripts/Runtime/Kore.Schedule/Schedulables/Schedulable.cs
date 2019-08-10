using System.Collections;
using UnityEngine;

namespace Kore.Schedule
{
    public abstract class Schedulable : MonoBehaviour
    {
        protected Coroutine coroutine;

        protected abstract IEnumerator ScheduleCoroutine();

        public IEnumerator RunCoroutine()
        {
            yield return coroutine = StartCoroutine(ScheduleCoroutine());
        }

        public void RunDirectly()
        {
            StartCoroutine(RunCoroutine());
        }

        public void Stop()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
        }
    }
}
