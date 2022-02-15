using System;
using UnityEngine;

namespace ScrawledPixels.BattleLogic
{
    public class Player : Unit
    {
        [SerializeField] private PlayerData _data;

        public override void Init(UnitData data)
        {
            base.Init(_data);
        }
    }
}