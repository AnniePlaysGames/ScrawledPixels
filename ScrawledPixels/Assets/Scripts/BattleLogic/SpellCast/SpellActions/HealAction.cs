using System;
using UnityEngine;

namespace ScrawledPixels.BattleLogic.SpellCast
{
    public class HealAction : SpellAction
    {
        [SerializeField] private int _healValue;
        
        public override void DoAction(Unit target)
        {
            target.ApplyHeal(_healValue);
        }
    }
}