using UnityEngine;

namespace ScrawledPixels.BattleLogic
{
    public class EnemyData : UnitData
    {
        public Sprite Sprite => _sprite;
        [SerializeField] private Sprite _sprite;
        public int ExperienceReward => _experienceReward;
        [SerializeField] private int _experienceReward;
        public int CoinsReward => _coinsReward;
        [SerializeField] private int _coinsReward;
    }
}