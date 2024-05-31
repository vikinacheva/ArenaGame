using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ArenaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create weapons
            Weapon sword = new Weapon("Sword", 5, "None");
            Weapon axe = new Weapon("Axe", 7, "Armor Break");
            Weapon bow = new Weapon("Bow", 3, "Long Range");
            Weapon dagger = new Weapon("Dagger", 4, "Critical Strike");

            // Create heroes
            Hero[] heroes = new Hero[]
            {
                new Knight("Sir Arthur", 100, 10),
                new Mage("Gandalf", 80, 15),
                new Paladin("Sir Lancelot", 110, 8),
                new Archer("Legolas", 90, 12),
                new Berserker("Conan", 95, 14),
                new Rogue("Shadow", 85, 13)
            };

            // Randomly select two different heroes
            Random random = new Random();
            int index1 = random.Next(heroes.Length);
            int index2;
            do
            {
                index2 = random.Next(heroes.Length);
            } while (index2 == index1);

            Hero hero1 = heroes[index1];
            Hero hero2 = heroes[index2];

            // Equip weapons for heroes
            switch (hero1)
            {
                case Knight _:
                    hero1.EquipWeapon(sword);
                    break;
                case Mage _:
                    hero1.EquipWeapon(bow);
                    break;
                case Paladin _:
                    hero1.EquipWeapon(sword);
                    break;
                case Archer _:
                    hero1.EquipWeapon(bow);
                    break;
                case Berserker _:
                    hero1.EquipWeapon(dagger);
                    break;
                case Rogue _:
                    hero1.EquipWeapon(dagger);
                    break;
            }

            switch (hero2)
            {
                case Knight _:
                    hero2.EquipWeapon(sword);
                    break;
                case Mage _:
                    hero2.EquipWeapon(bow);
                    break;
                case Paladin _:
                    hero2.EquipWeapon(sword);
                    break;
                case Archer _:
                    hero2.EquipWeapon(bow);
                    break;
                case Berserker _:
                    hero2.EquipWeapon(dagger);
                    break;
                case Rogue _:
                    hero2.EquipWeapon(dagger);
                    break;
            }

            // Display the battle lineup
            Console.WriteLine($"Today's battle: {hero1.Name} vs {hero2.Name}!");

            // Start the battle
            BattleLogger logger = new BattleLogger();
            Arena arena = new Arena(hero1, hero2);
            arena.BattleListener = logger;
            Hero winner = arena.Battle();

            Console.WriteLine($"{winner.Name} wins the battle!");
        }
    }
}
