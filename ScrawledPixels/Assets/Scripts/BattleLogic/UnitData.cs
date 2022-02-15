using UnityEngine;

namespace ScrawledPixels.BattleLogic
{
    public class UnitData : ScriptableObject
    {
        public int Health => _health;
        [SerializeField] private int _health;
        public int Damage => _damage;
        [SerializeField] private int _damage;
        public int Armor => _armor;
        [SerializeField ]private int _armor;
    }
}