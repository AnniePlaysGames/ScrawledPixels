using UnityEngine;

namespace ScrawledPixels.BattleLogic
{
    public abstract class UnitFighter : MonoBehaviour, IFightable
    {
        public abstract string Name { get; }
        public abstract int Health { get; protected set; }
        public abstract int Damage { get; protected set; }
        public abstract int Armor { get; protected set; }

        public void ApplyArmorDamage(int armorDamageValue)
        {
            Debug.Log($"{Name} Apply {armorDamageValue} damage to armor");
        }

        public void ApplyDamage(int damageValue)
        {
            if (damageValue > 0)
            {
                Health -= damageValue;
                Debug.Log($"{Name} Apply {damageValue} damage");
                Debug.Log(Health);
            }
        }
        
        public void IncreaseArmor(int increaseValue)
        {
            Debug.Log($"{Name} Apply {increaseValue} increase to armor");
        }

        public void ApplyHeal(int healValue)
        {
            Debug.Log($"{Name} Apply {healValue} heal");
        }
    }
}