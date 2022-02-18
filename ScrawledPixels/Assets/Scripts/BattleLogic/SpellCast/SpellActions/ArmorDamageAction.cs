using UnityEngine;

namespace ScrawledPixels.BattleLogic.SpellCast
{
    public class ArmorDamageAction : SpellAction
    {
        [SerializeField] private int _armorDamageValue;
        public override void DoAction(UnitFighter target)
        {
            target.ApplyArmorDamage(_armorDamageValue);
        }
    }
}