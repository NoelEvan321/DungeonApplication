using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //make it public!
    public class Weapon
    {
        //Full Qualified CTOR

        //Nicely Formatted ToString()


        //Fields // Funny
        private int _minDamage;
        private int _maxDamage;
        private string? _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        private WeaponType _type;

        //Properties // People
        public int MaxDamage
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
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }

        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }

        public WeaponType Type
        {
            get { return _type;}
            set { _type = value; }
        }

        public int MinDamage
        {
            get { return _minDamage; }
            // Min Damage shouldn't exceed MaxDamage, and shouldn't be less than 1
            set
            {
                _minDamage = (value > 0 && value <= MaxDamage ? value : 1);
                //If the value passed is greater than zero && less than or equal to max damage,
                //assign that value to _minDamage. Otherwise, assign 1 to _minDamage.

                //this.MinDamage++, += 5, could send it over MaxDamage, we don't want that.

                /*
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
                 */
            }//end set with business rules
        }//end MinDamage Prop


        //Constructors // Collect
        public Weapon(int maxDamage, string name, int bonusHitChance, bool isTwoHanded, 
            WeaponType type, int minDamage)
        {
            //Assignment
            //Property = parameter,
            //PascalCase = camelCase
            //Any properties with business rules that rely on other properties MUST come AFTER
            //those other properties are set.
            MaxDamage = maxDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            Type = type;
            MinDamage = minDamage;
        }

        //Methods // Monkeys
        public override string ToString()
        {
            //return base.ToString();
            //Namespace.ClassName
            return $"{Name}\t{MinDamage} to {MaxDamage} Damage\n" +
                   $"Bonus Hit: {BonusHitChance}%\n" +
                   $"Type: {Type}\t\t{(IsTwoHanded ? "Two-Handed" : "One-Handed")}";
        }//end 
    }
}
