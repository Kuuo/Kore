using UnityEngine;

namespace Kore.Conditions
{
    public abstract class ConditionCheck : ScriptableObject
    {
        public virtual bool Satisfied => Check();

        protected abstract bool Check();
    }
}