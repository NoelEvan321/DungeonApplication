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
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //Constructors // Collect
        public Player(string name, int hitChance, int block, int maxLife, Race characterRace, Weapon equippedWeapon) : base(name, hitChance, block, maxLife)
        {
            //handle unique assignment
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;

            switch (CharacterRace)
            {
                case Race.Human:
                    HitChance -= 5;
                    MaxLife += 5;
                    Block += 10;
                    break;
                case Race.Elf:
                    HitChance += 5;
                    MaxLife += 5;
                    Block -= 5;
                    break;
                case Race.Gnome:
                    MaxLife += 15;
                    Block -= 15;
                    break;
                case Race.Orc:
                    HitChance -= 5;
                    MaxLife -= 10;
                    Block += 20;
                    break;
                case Race.Kahjiit:
                    HitChance += 20;
                    MaxLife += 10;
                    Block -= 20;
                    break;
                case Race.Hobitses:
                    HitChance -= 5;
                    MaxLife += 20;
                    Block += 5;
                    break;
            }//end switch
        }
        public Player()
        {

        }

        //Methods // Monkeys
        public override int CalcDamage()
        {
            return new Random().Next(EquippedWeapon.MinDamage,EquippedWeapon.MaxDamage + 1);
        }
        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }
        public override string ToString()
        {
            string description = CharacterRace.ToString().Replace('_',' ');
            switch (CharacterRace)
            {
                case Race.Elf:
                    description = "Elves have pointy ears!";
                    break;
                case Race.Gnome:
                    description = "Gnomes enjoy long walks in the garden!";
                    break;
                case Race.Orc:
                    description = "*grunt*";
                    break;
                case Race.Kahjiit:
                    description = "Khajiit has wares.";
                    break;
                case Race.Hobitses:
                    description = "Potatoes and journeys";
                    break;
                case Race.Human:
                    description = "Are you Human? Or are you dancer?";
                    break;
            }
                    
            return base.ToString() + $"\nWeapon:\n{EquippedWeapon}\nBlock: {Block}\n" +
                $"Description: {description}";
        }
    }
}
