using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Berserker : Hero
    {
        private const int FrenzyChance = 25; // Chance of triggering Frenzy (%)
        private const double MaxFrenzyMultiplier = 1.5; // Maximum multiplier for Frenzy
        private static readonly Random random = new Random();

        public Berserker(string name, int health, int attack) : base(name, health, attack) { }

        public override int GetAttack()
        {
            int attack = base.GetAttack();
            // Berserker specific attack logic if needed
            if (ThrowDice(FrenzyChance))
            {
                double frenzyMultiplier = random.NextDouble() * MaxFrenzyMultiplier;
                int frenzyDamage = (int)(attack * frenzyMultiplier);
                Console.WriteLine($"{Name} triggers Frenzy for {frenzyMultiplier:N2}x damage!");
                attack += frenzyDamage;
            }
            return attack;
        }

        public override void TakeDamage(int damage)
        {
            // Berserker specific damage logic if needed
            base.TakeDamage(damage);
        }

        public override int Heal()
        {
            int heal = 10; // Berserkers heal 10 health points
            return heal;
        }

        public override void Attack(Hero opponent)
        {
            // Implement attack logic specific to Berserker
            Console.WriteLine($"{Name} attacks {opponent.Name}!");
            opponent.TakeDamage(GetAttack());
        }

        private bool ThrowDice(int chance)
        {
            return random.Next(100) < chance;
        }
    }
}
