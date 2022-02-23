using TMPro;
using UnityEngine;

namespace ScrawledPixels.BattleLogic
{
    [CreateAssetMenu(fileName = "NewEnemy", menuName = "Game/Enemy", order = 51)]
    public class EnemyData : ScriptableObject
    {
        public int Id => _id;
        [SerializeField] private int _id;
        
        public string Name => _name;
        [SerializeField] private string _name;

        public Sprite Sprite => _sprite;
        [SerializeField] private Sprite _sprite;
        
        public int Health => _health;
        [SerializeField] private int _health;

        public int Damage => _damage;
        [SerializeField] private int _damage;

        public int Armor => _armor;
        [SerializeField] private int _armor;

    }
}