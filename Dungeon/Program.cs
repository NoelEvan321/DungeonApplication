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

            //TODO Player Object Creation


            //TODO Create the main game loop

            #region Main Game Loop

            //Counter variable - used in the condition of the loop
            bool exit = false;

            do
            {
                //TODO Generate a random room the player will enter

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

        }
    }
}



