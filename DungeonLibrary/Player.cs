using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //Fields // Funny
        //no fields

        //Properties // People
        //Race CharacterRace
        //EquippedWeapon Weapon

        //Constructors // Collect
        public Player(string name, int hitChance, int block, int maxLife) : base(name, hitChance, block, maxLife)
        {
            //handle unique assignment

            //potential expansion, not required
            //switch (CharacterRace)
            //{
            //    case Race.Elf:
            //        HitChance += 5;
            //        MaxHealth -= 5;
            //        break;
            //}
        }
        public Player()
        {

        }

        //Methods // Monkeys
        public override int CalcDamage()
        {
            //return a random value between the Weapon's min and max damage
            return 0;
        }
        public override int CalcHitChance()
        {
            return 0;
            //HitChance + Weapon BonusHitChance
        }
        public override string ToString()
        {
            //holding variable for the description
            //Switch on CharacterRace
            //case CharacterRace.Elf: 
            //  description = "Describe an Elf"
            //  break;
            return base.ToString();//+some unique description based on the player race.
            //hint, use a switch
        }
    }
}
