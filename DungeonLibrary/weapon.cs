using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
       public class Weapon
    {
        //minDamage – int

        //maxDamage – int

        //name – string

        //bonusHitChance – int

       //isTwoHanded - bool
       //type - WeaponType

        //Full Qualified CTOR

        //Nicely Formatted ToString()
       
        // Funny People Collect Monkeys
        //Fields
        private WeaponType _type;
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        //Properties
        public WeaponType Type
        {
            get { return _type; }
            set { _type = value; }
        }
      
        private int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int BonusHitChance
        {
            get {  return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }
          public int MinDamage
        {
            get { return _minDamage; }
            //Min Damage shouldn't exceed MaxDamage, and shouldn't be less than 1
            set { 
                _minDamage = (value > 0 && value <= MaxDamage ? value : 1);
                //this.MinDamage++, +=5, could send it over MaxDamage, we don't want that.
            }
        }//end minDamage prop;
        //Constructors
        public Weapon(int maxDamage, string name, int bonusHitchance, WeaponType type, bool isTwoHanded, int minDamage)
        {
            //Assignment
            //Prperty = parameter, 
            //PascalCase = camelCase
            //ANy propeties with business rules that rely on other properties MUST come AFTER
            //those other properties are set.
            MaxDamage = maxDamage;
            Name = name;
            BonusHitChance = bonusHitchance;
            IsTwoHanded = isTwoHanded;
            Type = type;
            MinDamage = minDamage;
        }
        //Methods
        public override string ToString()
        {
            //return.base.ToString()
            //namespace.classname
            return $"{Name}\t{MinDamage} to {MaxDamage} Damage\n" + $"Bonus Hit: {BonusHitChance}%\n" +
                $"Type: {Type}\t\t{(IsTwoHanded ? "Two-Handed" : "One-Handed")}";
        }
    }
}
