using System;
using TMPro;
using UnityEngine;

namespace ScrawledPixels.BattleLogic
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Unit : MonoBehaviour
    {
        public Action onDeath;
        [SerializeField] private UnitData _data;
        protected int _damage;
        protected int _health;
        protected int _armor;

        public virtual void Init(UnitData data)
        {
            _damage = data.Damage;
            _health = data.Health;
            _armor = data.Armor;
        }
        
        public void ApplyDamage(int damage)
        {
            if (damage > 0)
            {
                _health -= damage - _armor;
                if (_health <= 0)
                {
                    onDeath.Invoke();;
                }
            }
            else
            {
                Debug.LogWarning("Damage < 1");
            }
        }

        public void ApplyHeal(int healingValue)
        {
            if (healingValue > 0)
            {
                _health += healingValue;
            }
            else
            {
                Debug.LogWarning("healingValue < 1");
            }
        }

        public void ApplyArmorDamage(int damage)
        {
            if (damage > 0)
            {
                _armor -= damage;
            }
            else
            {
                Debug.LogWarning("Armor Damage < 1");
            }
        }

        public void IncreaseArmor(int value)
        {
            if (value > 0)
            {
                _armor += value;
            }
            else
            {
                Debug.LogWarning("Armor increase value < 0");
            }
        }
    }
}