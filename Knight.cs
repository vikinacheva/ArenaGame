using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Knight : Hero
    {
        private const int DoubleDamageThreshold = 70; // Knight's double damage threshold
        private static readonly Random random = new Random();

        public Knight(string name, int health, int attack) : base(name, health, attack) { }

        public override int GetAttack()
        {
            int attack = base.GetAttack();
            // Knight specific attack logic if needed
            if (ThrowDice(DoubleDamageThreshold))
            {
                attack *= 2;
                Console.WriteLine($"{Name} triggers double damage for {attack}!");
            }
            return attack;
        }

        public override void TakeDamage(int damage)
        {
            // Knight specific damage logic if needed
            base.TakeDamage(damage);
        }

        public override int Heal()
        {
            int heal = 5; // Knights heal 5 health points
            return heal;
        }

        public override void Attack(Hero opponent)
        {
            // Implement attack logic specific to Knight
            Console.WriteLine($"{Name} attacks {opponent.Name}!");
            opponent.TakeDamage(GetAttack());
        }

        private bool ThrowDice(int threshold)
        {
            return random.Next(100) < threshold;
        }
    }
}
