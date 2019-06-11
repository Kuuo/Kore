using System.Collections;
using UnityEngine;

namespace Kore.Schedule
{
    public abstract class Schedulable : MonoBehaviour
    {
        public bool runDirectlyOnStart;

        protected Coroutine coroutine;

        protected abstract IEnumerator ScheduleCoroutine();

        public IEnumerator Run()
        {
            yield return coroutine = StartCoroutine(ScheduleCoroutine());
        }

        public void RunDirectly()
        {
            StartCoroutine(Run());
        }

        public void Stop()
        {
            if (coroutine == null) return;
            StopCoroutine(coroutine);
        }

        private void Start()
        {
            if (runDirectlyOnStart)
            {
                RunDirectly();
            }
        }
    }
}
