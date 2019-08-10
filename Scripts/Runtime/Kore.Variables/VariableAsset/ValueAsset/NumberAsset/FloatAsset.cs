﻿using UnityEngine;
using Kore.Events;

namespace Kore.Variables
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Value/Float")]
    public class FloatAsset : NumberAsset<float>
    {
        [SerializeField]
        private FloatGameEvent _onValueChangeEvent;

        public override GameEvent<float> OnValueChanged
        {
            get { return _onValueChangeEvent; }
            set { _onValueChangeEvent = value as FloatGameEvent; }
        }

        public void Add(float amount) => Value += amount;

        public void Add(FloatAsset asset) => Value += asset.Value;

        public void Set(FloatAsset asset) => Value = asset.Value;
    }
}