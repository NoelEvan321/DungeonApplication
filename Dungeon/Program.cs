using DungeonLibrary;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            //Title & Introduction

            #region Title / Introduction

            Console.Title = "Grr's Song";

            Console.WriteLine("Welcome to Grr's Dungeon!\nHe sings DoomDoomDoomDoomDoom\n");

            #endregion

            #region Possible Expansion-levels

            //Possible Expansion: 
            //TODO set level to monsters killed
            //int[] levels = { 5, 12, 20, 30, 45 };//Use with experience property in Character
            //inherited down to Player and Monster, to scale levelling.

            #endregion


            //Variable to Track Score

            int score = 0;
            int level = score;//could make some rules on this to require 3 or 4 kills to advance a level.

            #region Product List 
            //Product Object Creation
            Weapon sword = new Weapon(8, "Long Sword", 10, false, WeaponType.Sword, 1, 0, 0);
            Weapon dagger = new Weapon(10, "Short Blade", 7, false, WeaponType.Knife, 2, 35, 1);
            Weapon mace = new Weapon(15, "Mace", 8, false, WeaponType.Blunt, 10, 40, 2);
            Weapon maceBig = new Weapon(25, "Spikey", 5, true, WeaponType.Blunt, 10, 100, 4);
            Weapon daggerBig = new Weapon(20, "Sting", 10, false, WeaponType.Knife, 18, 100, 4);
            Weapon bow = new Weapon(20, "Yew Bow", 15, true, WeaponType.Projectile, 15, 150, 4);
            Weapon swordBig = new Weapon(50, "Excaliburrrrr", 15, true, WeaponType.Sword, 25, 400, 5);
            Potion potionSmall = new Potion("Health", "Small Potion", "Common", 10, 10, 1);
            Potion potionNormal = new Potion("Health", "Normal Potion", "Uncommon", 20, 50, 1);
            Potion potionBig = new Potion("Health", "Big Potion", "Uncommon", 50, 150, 3);

            //TODO write linq for purchase level check and to display weapons to user.
            #endregion
            #region Player object creation
            bool exit = false;

            
                //Player name
                Console.Write("Welcome to the dungeon, adventurer - What is your name?\n");
                string playerName = Console.ReadLine().Trim();
                Console.WriteLine();
                Console.Clear();
                //Race selection
                var dudes = Enum.GetValues<Race>().ToList();
                Console.WriteLine($"What would you like to be {playerName}?");
                foreach (Race dude in dudes)
                {
                    string display = dude.ToString().Replace('_', ' ');
                    Console.WriteLine($"{(int)dude + 1}) {dude}");
                }
                int chosenRace = int.Parse(Console.ReadLine()) - 1;

                Race playerRace = (Race)chosenRace;

                //TODO build weapon selection menu
                //Display a list of races and let them pick one, or assign one randomly.

                Player player = new Player(name: playerName, hitChance: 70, block: 5, maxLife: 40, characterRace: playerRace, equippedWeapon: sword);
                Console.Clear();
                Console.WriteLine();
            if (playerRace==Race.Hobit)
            {
                Console.WriteLine("All Hobitses must be named Sam.");
                player.Name = "Sam";
            }
                Console.WriteLine(player);
                Console.WriteLine();
                Console.Write("Press any key to enter the dungeon. ");
                Console.ReadLine();
                Console.Clear();
            #endregion
            #region Main Game Loop

            //Counter variable - used in the condition of the loop

            do
            {
                exit = false;
                //Generate a random room the player will enter
                Console.WriteLine(GetRoom());

                //Select a random monster to inhabit the room
                Monster monster = Monster.GetMonster();

                Console.WriteLine("\n In this room... " + monster.Name);
                //Create the gameplay menu loop

                #region Gameplay Menu Loop

                bool reload = false;

                do
                {


                    #region MENU

                    //Prompt the user
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");

                    //Capture the user's menu selection
                    ConsoleKey userChoice = Console.ReadKey(true).Key; //Capture the pressed key, hide the key from 
                                                                       //the console, and execute immediately

                    //Clear the console
                    Console.Clear();

                    //Use branching logic to act upon the user's selection
                    switch (userChoice)
                    {
                        case ConsoleKey.A:

                            //Combat
                            #region Possible Expansion - Racial/Weapon Bonus

                            //Possible Expansion: Give certain character races or characters with a certain weapon an advantage
                            //if (player.CharacterRace == Race.DarkElf)
                            //{
                            //    Combat.DoAttack(player, monster);
                            //}
                            #endregion

                            Combat.DoBattle(player, monster);
                            //Check if the monster is dead
                            if (monster.Life <= 0)
                            {

                                //Use green to indicate winning
                                Console.ForegroundColor = ConsoleColor.Green;
                                //Loot, experience, gold, whatever.
                                Random random = new Random();
                                int loot = 0;
                                if (monster.Rarity == "Common")
                                {
                                    loot = random.Next(1, 51);
                                }
                                else if (monster.Rarity == "Uncommon")
                                {
                                    loot = random.Next(41, 101);
                                }
                                else
                                {
                                    loot = random.Next(151, 251);
                                }
                                Console.WriteLine($"{monster.Name} drops {loot} coin");
                                //TODO add amount of gold dropped to wallet

                                //output the result
                                Console.WriteLine($"\nYou killed {monster.Name}!");

                                //Reset the color
                                Console.ResetColor();

                                //leave the inner loop
                                reload = true;

                                //update the score
                                score++;
                            }

                            break;


                        case ConsoleKey.R:

                            //Run Away - Attack of Opportunity

                            Console.WriteLine("Run Away!!!");

                            //Monster gets an "attack of opportunity"
                            Console.WriteLine(monster.Name + " attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();//for formatting

                            reload = true;
                            break;

                        case ConsoleKey.P:

                            //Player Stats

                            Console.WriteLine(player);

                            break;

                        case ConsoleKey.M:

                            //Monster Stats

                            Console.WriteLine(monster);

                            break;


                        case ConsoleKey.X:
                        case ConsoleKey.E:
                        case ConsoleKey.Escape:
                            //Exit

                            Console.WriteLine("Nobody likes a quitter...");

                            exit = true;

                            break;

                        default:

                            Console.WriteLine("Thou hast chosen an improper option. Triest thou again.");

                            break;
                    }


                    #region Check Player's Life Total

                    //Check player's life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude... you died! \a");
                        exit = true;
                    }

                    #endregion



                    #endregion



                } while (!reload && !exit);


                #endregion


            } while (!exit);//Keep looping as long as exit is false

            #endregion

            Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));

        }//end Main()

        private static string GetRoom()
        {
            string[] rooms = /*new string[9]*/
            {
                    "The room is dark and musty. It smells like darkness... and must.",
                    "You enter a fairy-chamber... Sorry. There aren't any faries in this game.",
                    "You arrive in a room filled with chairs and a ticket stub machine...DMV",
                    "You enter a quiet library... silence... nothing but silence....",
                    "You enter a loud library... that stinks... there's a quiet library somewhere, I'm sure.",
                    "As you enter the room, you realize you are standing on a platform surrounded by sharks",
                    "Oh my.... what is that smell? ...this dungeon reminds you of your room.",
                    "You enter a dark room and you hear a raspy voice...It's a Rolling Stones concert!",
                    "Oh no... the Oprah show...maybe you'll get a gift",
            };

            return rooms[new Random().Next(rooms.Length)];
        }
    }//end Class
}//end namespace



