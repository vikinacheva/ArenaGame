using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Archer : Hero
    {
        private const int CriticalShotChance = 20; // Chance of triggering Critical Shot (%)
        private const double CriticalShotMultiplier = 1.5; // Multiplier for critical shot damage
        private static readonly Random random = new Random();

        public Archer(string name, int health, int attack) : base(name, health, attack) { }

        public override int GetAttack()
        {
            int attack = base.GetAttack();
            // Archer specific attack logic if needed
            if (ThrowDice(CriticalShotChance))
            {
                int criticalDamage = (int)(attack * CriticalShotMultiplier);
                Console.WriteLine($"{Name} triggers a Critical Shot for {criticalDamage} additional damage!");
                attack += criticalDamage;
            }
            return attack;
        }

        public override void TakeDamage(int damage)
        {
            // Archer specific damage logic if needed
            base.TakeDamage(damage);
        }

        public override int Heal()
        {
            int heal = 4; // Archers heal 4 health points
            return heal;
        }

        public override void Attack(Hero opponent)
        {
            // Implement attack logic specific to Archer
            Console.WriteLine($"{Name} attacks {opponent.Name}!");
            opponent.TakeDamage(GetAttack());
        }

        private bool ThrowDice(int chance)
        {
            return random.Next(100) < chance;
        }
    }
}
