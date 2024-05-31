using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Rogue : Hero
    {
        private const int TripleDamageMagicLastDigit = 5;
        private const int HealEachNthRound = 3;
        private int attackCount;
        private static readonly Random random = new Random();

        public Rogue(string name, int health, int attack) : base(name, health, attack)
        {
            attackCount = 0;
        }

        public override int GetAttack()
        {
            int attack = base.GetAttack();
            if (attack % 25 == TripleDamageMagicLastDigit)
            {
                attack *= 3;
                Console.WriteLine($"{Name} triggers triple damage for {attack}!");
            }
            attackCount++;
            if (attackCount % HealEachNthRound == 0 && ThrowDice(25))
            {
                int heal = MaxHealth * 50 / 100;
                ReceiveHealing(heal);
                Console.WriteLine($"{Name} heals for {heal} health points.");
            }
            return attack;
        }

        public override void TakeDamage(int damage)
        {
            if (ThrowDice(30))
            {
                damage = 0;
                Console.WriteLine($"{Name} dodges the attack!");
            }
            base.TakeDamage(damage);
        }

        public override int Heal()
        {
            int heal = 2; // Rogues don't have inherent healing abilities
            return heal;
        }

        private bool ThrowDice(int chance)
        {
            return random.Next(100) < chance;
        }

        public override void Attack(Hero opponent)
        {
            // Implement attack logic specific to Rogue
            Console.WriteLine($"{Name} attacks {opponent.Name}!");
            opponent.TakeDamage(GetAttack());
        }
    }
}
