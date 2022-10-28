using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Potion : Product
    {
        public string Type { get; set; }
        public string Rarity { get; set; }
        public int Replenishment { get; set; }
        public Potion(string type, string name, string rarity, int replenishment, int price, int purchaseLevel) : base(price, name, purchaseLevel)
        {
            Type = type;
            Rarity = rarity;
            Replenishment = replenishment;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nPotion Type: {Type}\t" +
                $"Rarity: {Rarity}\t" + $"Replenishment: {Replenishment}";
        }

    }
}
