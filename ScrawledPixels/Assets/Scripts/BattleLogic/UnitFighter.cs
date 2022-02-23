using System;
using Unity.Mathematics;
using UnityEngine;

namespace ScrawledPixels.BattleLogic
{
    public abstract class UnitFighter : MonoBehaviour, IFightable
    {
        public event Action onDeath;
        
        public abstract int Id { get; }
        public abstract string Name { get; }
        public abstract int Health { get; protected set; }
        public abstract int Damage { get; protected set; }
        public abstract int Armor { get; protected set; }

        public void ApplyDamage(int damageValue)
        {
            int appliedDamage = damageValue - Armor;
            Health -= Math.Clamp((appliedDamage), 0, appliedDamage);
            Debug.Log($"{Name} Apply {damageValue} damage" 
                      + $"\n{Name} Health = {Health}");
            
            if (Health <= 0)
            {
                onDeath?.Invoke();
            }
        }
        
        public void ApplyHeal(int healValue)
        {
            Health += Math.Clamp(healValue, 0, healValue);
            Debug.Log($"{Name} Apply {healValue} heal " +
                      $"n{Name} Health = {Health}" );
        }
        
        public void IncreaseArmor(int increaseValue)
        {
            Armor += Math.Clamp(increaseValue, 0, increaseValue);
            Debug.Log($"{Name} Apply {increaseValue} increase to armor" 
                      + $"\n{Name} Armor = {Armor}");
        }
        
        public void ApplyArmorDamage(int armorDamageValue)
        {
            Armor -= Math.Clamp(armorDamageValue, 0, armorDamageValue);
            Debug.Log($"{Name} Apply {armorDamageValue} damage to armor " +
                      $"\n{Name} Armor = {Armor}");
        }
    }
}