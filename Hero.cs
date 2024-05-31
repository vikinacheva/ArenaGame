using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Attackk { get; set; }
        public Weapon EquippedWeapon { get; set; }

        public Hero(string name, int health, int attack)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            Attackk = attack;
        }

        public void EquipWeapon(Weapon weapon)
        {
            EquippedWeapon = weapon;
            Console.WriteLine($"{Name} has equipped {weapon}");
        }

        public virtual int GetAttack()
        {
            return Attackk + (EquippedWeapon?.AttackBonus ?? 0);
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public void ReceiveHealing(int heal)
        {
            Health += heal;
            if (Health > MaxHealth) Health = MaxHealth;
        }

        public virtual int Heal()
        {
            return 0;
        }

        public bool IsDead => Health <= 0;

        public abstract void Attack(Hero opponent);
    }
}
