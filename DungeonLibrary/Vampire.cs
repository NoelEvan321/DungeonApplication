using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Vampire : Monster
    {
        public DateTime HourChangeBack { get; set; }

        public Vampire(string name, int maxLife, int hitChance, int block, int maxDamage, int minDamage, string description, string rarity) 
            : base(name, maxLife, hitChance, block, maxDamage, minDamage, description, rarity)
        {
            HourChangeBack = DateTime.Now;
            if (HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18)
            {
                HitChance += 10;
                Block += 10;
                MinDamage += 1;
                MaxDamage += 2;
            }
        }

        public override string ToString()
        {
            return base.ToString() + 
                (HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18 ? 
                "Empowered by the night" : "Weakened by the daylight" );
        }

    }
}
