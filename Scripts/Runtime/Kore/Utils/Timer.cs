using System;
using UnityEngine;
using Kore.Variables;

namespace Kore
{
    [Serializable]
    public class Timer
    {
        public FloatReference length;

        public event Action onTimed;

        public float remaining => isRunning ? length - elapsed : 0f;

        public float progress => isRunning ? Mathf.Clamp01(elapsed / length) : 1f;

        public bool isRunning => elapsed >= 0f;

        private float elapsed = -1f;

        public Timer(float length = 1f)
        {
            this.length = new FloatReference { Value = length };
        }

        public void Tick() => Tick(Time.deltaTime);

        public void Tick(float deltaTime)
        {
            if (!isRunning) return;

            elapsed += deltaTime;

            if (elapsed >= length)
            {
                elapsed = -1f;
                onTimed?.Invoke();
            }
        }

        public void Start() => elapsed = 0f;

        public void Stop() => elapsed = -1f;
    }
}
