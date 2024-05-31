using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Weapon
    {
        public string Name { get; set; }
        public int AttackBonus { get; set; }
        public string SpecialAbility { get; set; }

        public Weapon(string name, int attackBonus, string specialAbility)
        {
            Name = name;
            AttackBonus = attackBonus;
            SpecialAbility = specialAbility;
        }

        public override string ToString()
        {
            return $"{Name} (Attack Bonus: {AttackBonus}, Special: {SpecialAbility})";
        }
    }
}
