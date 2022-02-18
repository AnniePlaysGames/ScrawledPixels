using UnityEngine;

namespace ScrawledPixels.BattleLogic.SpellCast
{
    public abstract class SpellAction : ScriptableObject, ISpellAction
    {
        public abstract void DoAction(UnitFighter target);
    }
}