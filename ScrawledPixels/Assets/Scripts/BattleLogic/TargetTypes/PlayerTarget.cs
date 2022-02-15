using UnityEngine;

namespace ScrawledPixels.BattleLogic.TargetTypes
{
    class PlayerTarget : TargetType
    {
        [SerializeField] private Player _player;

        public override Unit GetTarget()
        {
            return _player;
        }
    }
}