using UnityEngine;

namespace ScrawledPixels.BattleLogic.SpellCast
{
    public class DamageAction : SpellAction
    {
        [SerializeField] private int _damageCount;

        public override void DoAction(Unit target)
        {
            target.ApplyDamage(_damageCount);
        }
    }
}
