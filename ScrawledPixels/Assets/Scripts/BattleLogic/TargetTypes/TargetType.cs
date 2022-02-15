using System;
using UnityEngine;

namespace ScrawledPixels.BattleLogic.TargetTypes
{
    public abstract class TargetType : ITargetType
    {
        public abstract Unit GetTarget();
    }
}