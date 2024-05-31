using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Mage : Hero
    {
        private const int ArcaneSurgeChance = 30; // Chance of triggering Arcane Surge (%)
        private const double ArcaneSurgeMultiplier = 0.1; // Additional damage multiplier for Arcane Surge
        private static readonly Random random = new Random();

        public Mage(string name, int health, int attack) : base(name, health, attack) { }

        public override int GetAttack()
        {
            int attack = base.GetAttack();
            // Mage specific attack logic if needed
            if (ThrowDice(ArcaneSurgeChance))
            {
                int additionalDamage = (int)(MaxHealth * ArcaneSurgeMultiplier);
                attack += additionalDamage;
                Console.WriteLine($"{Name} triggers Arcane Surge for {additionalDamage} additional damage!");
            }
            return attack;
        }

        public override void TakeDamage(int damage)
        {
            // Mage specific damage logic if needed
            base.TakeDamage(damage);
        }

        public override int Heal()
        {
            int heal = 8; // Mages heal 8 health points
            return heal;
        }

        public override void Attack(Hero opponent)
        {
            // Implement attack logic specific to Mage
            Console.WriteLine($"{Name} attacks {opponent.Name}!");
            opponent.TakeDamage(GetAttack());
        }

        private bool ThrowDice(int chance)
        {
            return random.Next(100) < chance;
        }
    }
}
