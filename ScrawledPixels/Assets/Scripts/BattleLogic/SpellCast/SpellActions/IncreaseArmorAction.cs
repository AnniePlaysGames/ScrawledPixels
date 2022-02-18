using UnityEngine;
using UnityEngine.InputSystem;

namespace ScrawledPixels.BattleLogic.SpellCast
{
    public class IncreaseArmorAction : SpellAction
    {
        [SerializeField] private int _increaseValue;
        
        public override void DoAction(UnitFighter target)
        {
            target.IncreaseArmor(_increaseValue);
        }
    }
}