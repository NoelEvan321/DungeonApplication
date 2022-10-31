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
                case Race.Human:
                    break;
                case Race.Elf:
                    HitChance += 5;
                    MaxLife += 5;
                    Life += 5;
                    Block -= 5;
                    break;
                case Race.Gnome:
                    MaxLife += 15;
                    Life += 15;
                    Block -= 15;
                    break;
                case Race.Orc:
                    HitChance -= 5;
                    MaxLife -= 10;
                    Life -= 10;
                    Block += 20;
                    break;
                case Race.Kahjiit:
                    HitChance += 20;
                    MaxLife += 10;
                    Life += 10;
                    Block -= 20;
                    break;
                case Race.Hobbit:
                    HitChance -= 5;
                    MaxLife += 20;
                    Life += 20;
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
                case Race.Hobbit:
                    description = "Potatoes and adventures";
                    break;
                case Race.Human:
                    description = "Are you Human? Or are you dancer?";
                    break;
            }
                    
            return base.ToString() + $"\nWeapon:\n{EquippedWeapon}\n" +
                $"Description: {description}";
        }
    }
}
