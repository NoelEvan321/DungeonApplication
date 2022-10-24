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

            Console.WriteLine("He sings DoomDoomDoomDoomDoom\n");

            #endregion

            #region Possible Expansion - Levels of Play - Block 5

            //Possible Expansion: 
            //TODO Define levels of play
            //int[] levels = { 5, 12, 20, 30, 45 };//Use with experience property in Character
            //inherited down to Player and Monster, to scale levelling.

            #endregion


            //Variable to Track Score

            int score = 0;

            //Weapon Object Creation
            Weapon sword = new Weapon(8, "Long Sword", 10, false, WeaponType.Sword, 1);
            //TODO add more weapon instances? Could do this in the weapon class and add a GetWeapon().
            #region Possible Expansion
            //Create a list of weapons, and either give the player a random weapon, let them pick a weapon, 
            //or let them pick a WeaponType, and give them a weapon based off of that type.
            #endregion

            #region Player object creation
            #region Possible Expansion - Player Customization - Block 5

            //Possible Expansion: 
            //Allow player to define chatacter name
            //Console.Write("Enter your name: ");
            //string userName = Console.ReadLine();
            //Console.Clear();
            //Console.WriteLine("Welcome, {0}! Your journey begins...", userName);
            //Console.ReadKey();
            //Console.Clear();

            //Display a list of races and let them pick one, or assign one randomly.
            #endregion

            Player player = new Player(name: "Leeroy Jenkins", hitChance: 70, block: 5, maxLife: 40, characterRace: Race.Hobitses, equippedWeapon: sword);//TODO update player creation with console readlines? Do in Main Game Loop.
            #endregion

            #region Main Game Loop

            //Counter variable - used in the condition of the loop
            bool exit = false;

            do
            {
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
                                //Loot, experience, gold, whatever.

                                //Use green to indicate winning
                                Console.ForegroundColor = ConsoleColor.Green;

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


            } while (!exit); //Keep looping as long as exit is false


            #endregion

            Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));

        }//end Main()

        private static string GetRoom()
        {
            string[] rooms = /*new string[5]*/
            {
                    "The room is dark and musty with the smell of lost souls.",
                    "You enter a pretty pink powder room and instantly get glitter on you.",
                    "You arrive in a room filled with chairs and a ticket stub machine...DMV",
                    "You enter a quiet library... silence... nothing but silence....",
                    "As you enter the room, you realize you are standing on a platform surrounded by sharks",
                    "Oh my.... what is that smell? You appear to be standing in a compost pile",
                    "You enter a dark room and all you can hear is hair band music blaring.... This is going to be bad!",
                    "Oh no.... the worst of them all... Oprah's bedroom....",
                    "The room looks just like the room you are sitting in right now... or does it?"
            };//TODO generate a new list of room descriptions

            return rooms[new Random().Next(rooms.Length)];
        }
    }//end Class
}//end namespace



