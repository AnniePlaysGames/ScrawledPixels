using UnityEngine;

namespace ScrawledPixels.BattleLogic.SpellCast
{
    public class ArmorDamageAction : SpellAction
    {
        [SerializeField] private int _armorDamageValue;
        public override void DoAction(Unit target)
        {
            target.ApplyArmorDamage(_armorDamageValue);
        }
    }
}