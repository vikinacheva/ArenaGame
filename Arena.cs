using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class BattleEvent
    {
        public Hero Attacker { get; set; }
        public Hero Defender { get; set; }
        public int Damage { get; set; }
        public int Heal { get; set; }
    }

    public interface IArenaBattleListener
    {
        void OnBattleTurn(BattleEvent e);
    }

    public class BattleLogger : IArenaBattleListener
    {
        public void OnBattleTurn(BattleEvent e)
        {
            Console.WriteLine($"{e.Attacker.Name} attacks {e.Defender.Name} for {e.Damage} damage.");
            if (e.Heal > 0)
            {
                Console.WriteLine($"{e.Attacker.Name} heals for {e.Heal} health points.");
            }
        }
    }

    public class Arena
    {
        public Hero HeroA { get; private set; }
        public Hero HeroB { get; private set; }
        private static readonly Random Random = new Random();

        public IArenaBattleListener BattleListener { get; set; }

        public Arena(Hero a, Hero b)
        {
            HeroA = a;
            HeroB = b;
        }

        public Hero Battle()
        {
            Hero attacker, defender;

            #region Determine Who is First
            if (Random.Next(2) == 0)
            {
                attacker = HeroA;
                defender = HeroB;
            }
            else
            {
                attacker = HeroB;
                defender = HeroA;
            }
            #endregion

            while (true)
            {
                int damage = attacker.GetAttack();
                defender.TakeDamage(damage);

                int heal = attacker.Heal();
                if (heal > 0)
                {
                    attacker.ReceiveHealing(heal);
                }

                if (BattleListener != null)
                {
                    BattleEvent e = new BattleEvent
                    {
                        Attacker = attacker,
                        Defender = defender,
                        Damage = damage,
                        Heal = heal
                    };
                    BattleListener.OnBattleTurn(e);
                }

                if (defender.IsDead) return attacker;

                // Swap the heroes
                Hero tmp = attacker;
                attacker = defender;
                defender = tmp;
            }
        }
    }
}
