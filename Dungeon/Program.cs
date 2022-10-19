using DungeonLibrary;

namespace Dungeon 
{
    class Program
    {
        //svm > Tab > Tab creates a static void Main()
        static void Main(string[] args)
        {
            //Title & Introduction

            #region Title / Introduction

            Console.Title = "DUNGEON OF DOOM";

            Console.WriteLine("Your journey begins...\n");

            #endregion

            //Variable to Track Score

            int score = 0;

            //TODO Weapon Object Creation
            Weapon sword = new Weapon(8, "Long Sword", 10, WeaponType.Sword, false, 1);

            //TODO Player Object Creation
            Character test = new Character("Testy", 30,10,100);

            //TODO Create the main game loop

            #region Main Game Loop

            //Counter variable - used in the condition of the loop
            bool exit = false;

            do
            {
                //TODO Generate a random room the player will enter
                Console.WriteLine(GetRoom());

                //TODO Select a random monster to inhabit the room

                //Create the gameplay menu loop

                #region Gameplay Menu Loop

                bool reload = false;

                do
                {

                    //TODO Create the main gameplay menu
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

                            //TODO Combat

                            Console.WriteLine("Attack");

                            break;


                        case ConsoleKey.R:

                            //TODO Run Away - Attack of Opportunity

                            Console.WriteLine("Run Away");
                            reload = true;

                            break;

                        case ConsoleKey.P:

                            //TODO Player Stats

                            Console.WriteLine("Player Info");

                            break;

                        case ConsoleKey.M:

                            //TODO Monster Stats

                            Console.WriteLine("Monster Info");

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

                    //TODO Check player's life


                    #endregion



                    #endregion



                } while (!reload && !exit);


                #endregion


            } while (!exit); //Keep looping as long as exit is false


            #endregion


            //TODO Output the Final Score

            Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));



            //Added this line to preserve the Console.Title
            Console.ReadKey();

        }// end Main()
        private static string GetRoom()
        {
            //code
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
                "The room looks just like the room you are sitting in right now... or does it?",
            };

            return rooms[new Random().Next(rooms.Length)];
        }//end GetRoom()
    }//end Class
}//end namespace



