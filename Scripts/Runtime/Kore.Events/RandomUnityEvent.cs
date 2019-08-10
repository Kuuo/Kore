using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/RandomUnityEvent")]
    public class RandomUnityEvent : MonoBehaviour
    {
        [SerializeField] private bool raiseOnAwake = true;
        [SerializeField] private UnityEvent Event = new UnityEvent();

        private void Awake()
        {
            if (raiseOnAwake)
            {
                Raise();
            }
        }

        public virtual void Raise()
        {
            if (Random.value > .5f)
            {
                Event?.Invoke();
            }
        }
    }
}
