using UnityEngine;
using Kore.Events;

namespace Kore.Variables.UIBinding
{
    public abstract class ValueAssetUIBinding<TValue, TValueAsset, TGameEvent>
        : MonoBehaviour, IGameEventListener<TValue>
        where TValue : struct
        where TValueAsset : ValueAsset<TValue, TGameEvent>
        where TGameEvent : GameEvent<TValue>
    {
        [SerializeField] protected TValueAsset valueAsset;

        protected TGameEvent onValueChanged => valueAsset.OnValueChanged;

        protected virtual void OnEnable()
        {
            if (onValueChanged)
            {
                onValueChanged.AddListener(this);
            }
        }

        protected virtual void OnDisable()
        {
            if (onValueChanged)
            {
                onValueChanged.RemoveListener(this);
            }
        }

        public abstract void Response(TValue arg);
    }
}
