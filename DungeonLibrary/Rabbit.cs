using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Rabbit : Monster
    {
        //Fields // Funny

        //Properties // People
        public bool IsFluffy { get; set; }
        //Constructors // Collect
        //Default Ctor to set some basic values for a generic monster of this type
        public Rabbit()
        {
            MaxLife = 10;
            MaxDamage = 3;
            Name = "Baby Lapin";
            Life = MaxLife;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "It's just a cute little bunny... Why would you hurt it??";
            Rarity = "Common";
            IsFluffy = false;
        }
        //Parent compliant (Monster) Ctor 
        //Intellisense quick action on the Parent name in the class declaration.
        public Rabbit(string name, int maxLife, int hitChance, int block,
                      int maxDamage, int minDamage, string description, string rarity,
                      bool isFluffy)
            : base(name, maxLife, hitChance, block, maxDamage, minDamage, description, rarity)
        {
            IsFluffy = isFluffy;
        }
        //Methods // Monkeys

        public override string ToString()
        {
            return base.ToString() + (IsFluffy ? "It's fluffy" : "It's not so fluffy");
        }

        //Character CalcBlock = Block
        //Monster CalcBlock = Block
        //Rabbit CalcBlock = not block
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            //Apply a 50% increase to the rabbit's if it's fluffy
            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;
            }
            return calculatedBlock;
        }
    }
}
