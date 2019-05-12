using System.Collections;
using UnityEngine;

namespace Kore.Schedule
{
    public abstract class Schedulable : MonoBehaviour
    {
        [SerializeField]
        protected bool runDirectlyOnStart;

        protected Coroutine coroutine;

        protected abstract IEnumerator ScheduleCoroutine();

        public IEnumerator Run()
        {
            yield return coroutine = StartCoroutine(ScheduleCoroutine());
        }

        // Provide for UnityEvent use
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
