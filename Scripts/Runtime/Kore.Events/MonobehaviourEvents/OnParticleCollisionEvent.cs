using UnityEngine;
using UnityEngine.Events;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/MonobehaviourEvents/OnParticleCollisionEvent")]
    public class OnParticleCollisionEvent : MonoBehaviour
    {
        public GameObjectUnityEvent Event;

        private void OnParticleCollision(GameObject gameObject)
        {
            Event.Invoke(gameObject);
        }
    }
}
