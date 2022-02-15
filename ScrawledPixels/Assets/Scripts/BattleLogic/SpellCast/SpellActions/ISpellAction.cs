using System;
using UnityEngine;

namespace ScrawledPixels.BattleLogic.SpellCast
{
    public interface ISpellAction
    {
        public void DoAction(Unit target);
    }
}
