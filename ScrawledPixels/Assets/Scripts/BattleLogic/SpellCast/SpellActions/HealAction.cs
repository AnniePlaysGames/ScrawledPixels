using System;
using UnityEngine;

namespace ScrawledPixels.BattleLogic.SpellCast
{
    public class HealAction : SpellAction
    {
        [SerializeField] private int _healValue;
        
        public override void DoAction(UnitFighter target)
        {
            target.ApplyHeal(_healValue);
        }
    }
}