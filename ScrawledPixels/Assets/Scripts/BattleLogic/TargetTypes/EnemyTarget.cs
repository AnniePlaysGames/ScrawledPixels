using ScrawledPixels.InputSystem;
using UnityEngine;

namespace ScrawledPixels.BattleLogic.TargetTypes
{
    class EnemyTarget : TargetType
    {
        [SerializeField] private InputTargetHandler _inputTargetHandler;
        public override Unit GetTarget()
        {
            return _inputTargetHandler.TouchedTarget();
        }
    }
}