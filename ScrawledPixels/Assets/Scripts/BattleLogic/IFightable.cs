namespace ScrawledPixels.BattleLogic
{
    public interface IFightable
    {
        public int Id { get; }
        public string Name { get; }
        public int Health { get; }
        public int Damage { get;  }
        public int Armor { get; }

        public void ApplyDamage(int damageValue);
        public void ApplyArmorDamage(int armorDamageValue);
        public void IncreaseArmor(int increaseValue);
        public void ApplyHeal(int healValue);
    }
}