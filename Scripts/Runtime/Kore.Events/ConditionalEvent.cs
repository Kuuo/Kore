using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Kore.Conditions;

namespace Kore.Events
{
    [AddComponentMenu("Kore/Events/ConditionalEvent")]
    public class ConditionalEvent : MonoBehaviour
    {
        [System.Serializable]
        public class ConditionalAction
        {
            [TextArea]
            public string description;
            public List<ConditionCheck> conditions;
            public UnityEvent action;

            public bool Satisfied => conditions.Count > 0 ?
                conditions.TrueForAll(c => c.Satisfied) : true;

            public bool TryInvoke()
            {
                if (Satisfied)
                {
                    action.Invoke();
                    return true;
                }
                return false;
            }
        }

        public List<ConditionalAction> actions;

        public void Raise()
        {
            foreach (var a in actions)
            {
                if (a.TryInvoke()) return;
            }
        }
    }
}
