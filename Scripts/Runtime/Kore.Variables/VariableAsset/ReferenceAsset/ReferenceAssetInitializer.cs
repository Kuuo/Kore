using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Variables
{
    [AddComponentMenu("Kore/Variables/ReferenceAssetInitializer")]
    public class ReferenceAssetInitializer : MonoBehaviour
    {
        [Serializable]
        public class InitConfig
        {
            public ReferenceAsset asset;
            public UnityEngine.Object target;

            public Type referenceType => asset.GetType().BaseType.GenericTypeArguments[0];

            public void Set() => asset.Set(target);
        }

        public InitConfig[] configList = new InitConfig[0];

        private void Awake()
        {
            Array.ForEach(configList, config => config.Set());
        }
    }
}
