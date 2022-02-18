using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ScrawledPixels.BattleLogic
{
    public sealed class EnemyFighter : UnitFighter
    {
        private string _name;
        public override string Name => _name;
        
        private int _health;
        public override int Health { get => _health; protected set => _health = value; }

        private int _damage;
        public override int Damage { get => _damage; protected set => _damage = value; }

        private int _armor;
        public override int Armor { get => _armor; protected set => _armor = value; }

        public void AttachData(EnemyData data)
        {
            _name = data.Name;
            GetComponent<SpriteRenderer>().sprite = data.Sprite;
            
            _health = data.Health;
            _damage = data.Damage;
            _armor = data.Armor;
        }
    }
}