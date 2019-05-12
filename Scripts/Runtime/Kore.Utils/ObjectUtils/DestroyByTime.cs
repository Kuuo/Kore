using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore.Utils
{
    [AddComponentMenu("Kore/Utils/Object/Destroy By Time")]
    public class DestroyByTime : MonoBehaviour
    {
        public float time;

        void Start()
        {
            Destroy(gameObject, time);
        }
    }
}
