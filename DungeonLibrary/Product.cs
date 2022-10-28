using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Product
    {
        private int _price;
        private string? _name;
        private int _purchaseLevel;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int PurchaseLevel
        {
            get { return _purchaseLevel; }
            set { _purchaseLevel = value; }
        }
        public Product(int price, string name, int purchaseLevel)
        {
            Price = price;
            Name = name;
            PurchaseLevel = purchaseLevel;
        }
        public override string ToString()
        {
            return $"Product Price: {Price} " + $"Product Name: {Name}" +
                $"Required Level for Purchase: {PurchaseLevel}";
        }
    }
}
