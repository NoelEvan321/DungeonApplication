using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Turtle : Monster
    {
        public int BonusBlock { get; set; }
        public int HidePercent { get; set; }

        public Turtle(string name, int maxLife, int hitChance, int block, int maxDamage, int minDamage, string description, int bonusBlock, int hidePercent) 
            : base(name, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            //pass everything from Monster back to Monster using : base.
            //Handle unique turtlie things here

            BonusBlock = bonusBlock;
            HidePercent = hidePercent;
        }//end FQCTOR

        public Turtle()
        {
            //SET MAX VALUES FIRST!
            MaxLife = 6;
            MaxDamage = 3;
            Life = 6;
            MinDamage = 0;
            HitChance = 5;
            Block = 10;
            Name = "Baby Turtle";
            Description = "It's a cute baby turtle... keep it " +
                "away from the ooze.";
            BonusBlock = 5;
            HidePercent = 10;

        }//end default

        public override string ToString()
        {
            return base.ToString() + $"\n{HidePercent}% chance it will hide, granting {BonusBlock} bonus block.";
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            //Generate a random "percent" from 0-100
            int percent = new Random().Next(101);
            if (HidePercent >= percent)
            {
                //it's a success. Let the turtle hide!
                calculatedBlock += BonusBlock;
            }
            return calculatedBlock;
        }

    }
}
