using UnityEngine;

namespace ScrawledPixels.BattleLogic
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : Unit
    {
        [SerializeField] private EnemyData _data;
        private Sprite _sprite;

        public override void Init(UnitData data)
        {
            base.Init(_data);
            _sprite = _data.Sprite;
        }
    }
}