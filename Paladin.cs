using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Paladin : Hero
    {
        private const int CriticalStrikeChance = 20; // Chance of triggering a critical strike (%)
        private const double CriticalStrikeMultiplier = 1.5; // Multiplier for critical strike damage
        private static readonly Random random = new Random();

        public Paladin(string name, int health, int attack) : base(name, health, attack) { }

        public override int GetAttack()
        {
            int attack = base.GetAttack();
            // Paladin specific attack logic if needed
            if (ThrowDice(CriticalStrikeChance))
            {
                int criticalDamage = (int)(attack * CriticalStrikeMultiplier);
                Console.WriteLine($"{Name} triggers a critical strike for {criticalDamage} additional damage!");
                attack += criticalDamage;
            }
            return attack;
        }

        public override void TakeDamage(int damage)
        {
            // Paladin specific damage logic if needed
            base.TakeDamage(damage);
        }

        public override int Heal()
        {
            int heal = 7; // Paladins heal 7 health points
            return heal;
        }

        public override void Attack(Hero opponent)
        {
            // Implement attack logic specific to Paladin
            Console.WriteLine($"{Name} attacks {opponent.Name}!");
            opponent.TakeDamage(GetAttack());
        }

        private bool ThrowDice(int chance)
        {
            return random.Next(100) < chance;
        }
    }
}
