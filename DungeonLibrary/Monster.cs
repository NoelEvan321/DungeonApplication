using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //Fields // Funny
        //MinDamage as an int - can't be more than MaxDamage, or less than 0.
        private int _minDamage;


        //Properties // People
        //MaxDamage as an int
        public int MaxDamage { get; set; }
        //Description as a string
        public string Description { get; set; }
        //MinDamage as an int - can't be more than MaxDamage, or less than 0.
        public string Rarity { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value > 0 && value <= MaxDamage ? value : 1; }
        }
        //Constructors // Collect
        public Monster()
        {
        }

        public Monster(string name, int maxLife, int hitChance, int block, int maxDamage, int minDamage, string description, string rarity) : base(name, hitChance, block, maxLife)
        {
            //Remember to set MaxDamage first!!!
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
            Rarity = rarity;
        }
        //Methods // Monkeys
        public override string ToString()
        {
            return $"\n********** MONSTER **********\n" +
                   $"----- {Name} -----\n" +
                   $"Life: {Life} of {MaxLife}\n" +
                   $"Damage: {MinDamage} to {MaxDamage}  " +
                   $"Hit Chance: {HitChance}%\n" +
                   $"Block: {Block}\n" +
                   $"Rarity: {Rarity}\n" +
                   $"Description: {Description}";
        }
        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);

        }
        //TODO change monster names and descriptions
        public static Monster GetMonster()
        {
            Rabbit rabbit = new Rabbit(name: "White Rabbit", maxLife: 25, hitChance: 50, block: 20, maxDamage: 8, minDamage: 2, description: "That's no ordinary rabbit! Look at the bones!", rarity: "Uncommon", isFluffy: true);//Could add ascii art for my monsters.
            Rabbit babyRabbit = new Rabbit();

            Vampire vampire = new Vampire(name: "Dracula", maxLife: 30, hitChance: 70, block: 8, minDamage: 1, maxDamage: 8, description: "The father of all the undead", rarity: "Rare");

            Turtle turtle = new Turtle(name: "Mikey", maxLife: 25, hitChance: 50, block: 10, maxDamage: 4, minDamage: 1, description: "He is no longer a teenager, but he is still a mutant turtle", rarity: "Uncommon", bonusBlock: 3, hidePercent: 10);
            Turtle babyTurtle = new Turtle();

            Dragon dragon = new Dragon(name: "Smaug", maxLife: 35, hitChance: 65, block: 20, maxDamage: 15, minDamage: 1, description: "The last great dragon", rarity: "Rare", isScaly: true);
            Dragon babyDragon = new Dragon();

            List<Monster> monsters = new List<Monster>()
            {
                rabbit,
                babyRabbit, babyRabbit, babyRabbit,
                vampire,
                turtle,
                babyTurtle, babyTurtle, babyTurtle,
                dragon,
                babyDragon, babyDragon, babyDragon
            };
            int randomIndex = new Random().Next(monsters.Count);
            Monster monster = monsters[randomIndex];
            return monster;
        }
    }
}
