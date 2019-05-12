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
#if UNITY_EDITOR
            [TextArea] public string description;
#endif

            public List<ConditionCheck> conditions;
            public UnityEvent action;

            public bool Satisfied => conditions.Count > 0 ?
                conditions.TrueForAll(c => c?.Satisfied ?? false) : true;

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

        [Tooltip("If checked, multiple satisfied conditional actions will be raised, otherwise, only the first satisfied one will be raised")]
        public bool checkAllConditions;
        public List<ConditionalAction> actions;

        [Tooltip("If checked, the Default Action will allways run despite of the checked conditions.")]
        public bool alwaysRunDefault;
        public UnityEvent defaultAction;

        public void Raise()
        {
            bool anySatisfied = false;
            foreach (var a in actions)
            {
                if (a.TryInvoke() && !checkAllConditions)
                {
                    anySatisfied = true;
                    break;
                }
            }

            if (!anySatisfied || alwaysRunDefault)
            {
                defaultAction.Invoke();
            }
        }
    }
}
