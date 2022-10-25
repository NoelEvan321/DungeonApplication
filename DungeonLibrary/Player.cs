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
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        //maybe a character property. Store as a readline so user can decide on a backstory.

        //Constructors // Collect
        public Player(string name, int hitChance, int block, int maxLife, Race characterRace, Weapon equippedWeapon) : base(name, hitChance, block, maxLife)
        {
            //handle unique assignment
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;

            switch (CharacterRace)
            {
                case Race.human:
                    HitChance -= 5;
                    MaxLife += 5;
                    Block += 10;
                    break;
                case Race.elf:
                    HitChance += 5;
                    MaxLife += 5;
                    Block -= 5;
                    break;
                case Race.gnome:
                    MaxLife += 15;
                    Block -= 15;
                    break;
                case Race.orc:
                    HitChance -= 5;
                    MaxLife -= 10;
                    Block += 20;
                    break;
                case Race.kahjiit:
                    HitChance += 20;
                    MaxLife += 10;
                    Block -= 20;
                    break;
                case Race.hobitses:
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
                case Race.elf:
                    description = "Elves have pointy ears!";
                    break;
                case Race.gnome:
                    description = "Gnomes enjoy long walks in the garden!";
                    break;
                case Race.orc:
                    description = "*grunt*";
                    break;
                case Race.kahjiit:
                    description = "Khajiit has wares.";
                    break;
                case Race.hobitses:
                    description = "Potatoes and journeys";
                    break;
                case Race.human:
                    description = "Are you Human? Or are you dancer?";
                    break;
            }
                    
            return base.ToString() + $"\nWeapon:\n{EquippedWeapon}\nBlock: {Block}\n" +
                $"Description: {description}";
        }
    }
}
