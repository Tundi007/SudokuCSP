namespace Sudoku;

internal class Game
{

    public static bool bot_Bool = true;

    /// Load function is responsible for setting up the game rules and starting the game.
    public static void Load_Function()
    {

        bot_Bool = true;

        // If the game is being started for the first time, display a loading screen.
        if (Program.initialStart_Bool)
        {
            string loading_String = "[                    ]";
            bool loading_Bool = true;

            // Loop through the loading animation.
            for (int loading_Int = 2; loading_Int < 23; loading_Int++)
            {
                Console.Clear();            
                System.Console.Write("Loading");
                System.Console.Write(loading_String);

                if (loading_Int == 22) System.Console.WriteLine("100%");
                else System.Console.WriteLine((int)((double)loading_Int / 23 * 100) + "%");

                loading_String = loading_String[..(loading_Int - 1)] + "-" + loading_String[(loading_Int)..];

                if (loading_Int == 4) Thread.Sleep(100);

                if (loading_Bool)
                {
                    if (loading_Int % 1 == 0) Thread.Sleep(1);
                    if (loading_Int % 3 == 0) Thread.Sleep(30);
                    if (loading_Int % 5 == 0) Thread.Sleep(200);
                    if (loading_Int % 6 == 0) Thread.Sleep(100);
                    if (loading_Int % 7 == 0) Thread.Sleep(50);
                    if (loading_Int % 10 == 0)
                    {
                        Thread.Sleep(200);
                        loading_Bool = false;
                    }
                }
                else Thread.Sleep(5);
            }

            Thread.Sleep(200);
        }

        Console.Clear();
        
        // Select the game mode.
        GameMode_Function();

        // Start the game.
        Game_Function();
    }

    /// Function that handles the game mode selection menu.
    private static void GameMode_Function()
    {
        // Initialize variables
        bool pointer_Bool = false;
        // Game mode selection loop
        while(!MyUI.UserInterface_Function("Select Game Mode:", "Bot", "Player",
            pointer_Bool, out bool valid_Bool, out bool exit_Bool))
        {
            // If exit is triggered, exit the game
            if (exit_Bool)
                PrematureExit_Function();
            // If valid input is triggered, toggle single player mode
            if (valid_Bool)
                (bot_Bool, pointer_Bool) = (!bot_Bool, !pointer_Bool);
        }

        int difficulty_Int = 40;

        // Bot configuration selection loop
        while (MyUI.UserInterface2_Function("Table Difficulty:", difficulty_Int.ToString(), out int return_Int) == 0)
        {

            if (return_Int == 4)
            {

                Console.Clear();

                Debugger_Function();

                PrematureExit_Function();

            }

            // If exit is triggered, exit the game
            if (return_Int == 2)
                PrematureExit_Function();

            if (return_Int == 3)
            {

                Console.Clear();

                difficulty_Int = -1;

                GameBoard.sampleBoard_Function();

                break;

            }

            // If valid input is triggered, toggle bot configurations
            
            if (return_Int == 1 & difficulty_Int < 75)
                difficulty_Int+=5;
            else
            if(return_Int == 0 & difficulty_Int > 5)
                difficulty_Int-=5;
                
        }

        if(difficulty_Int != -1)
        {
            
            // Reset the game board
            GameBoard.GameBoardReset_Function();

            GameBoard.SetBoard_Function(Generator.Generator_Function(difficulty_Int));

        }

    }

    /// The main game
    private static void Game_Function()
    {

        int[,] answer_2DInt = new int[9,9];

        if (bot_Bool)
            Bot.Bot_Function();
        else
            PlayerTurn_Function();

    }

    /// Handles the player's turn in the game loop.
    private static bool PlayerTurn_Function()
    {
        if (MyUI.GameInterface_Function() == 1)
            PrematureExit_Function();
            return false;
    }

    private static void Debugger_Function()
    {

        Console.Clear();

        Bot.debugger_Int = 1;

        int bug_Int = 0;

        Bot.modifier_Int = 1;
            
        for (int j = 0; j < 1000; j++)
        {

            GameBoard.GameBoardReset_Function();            

            GameBoard.SetBoard_Function(Generator.Generator_Function(55));

            Bot.Bot_Function();

            bug_Int += Bot.debug_Int;

        }

        System.Console.WriteLine($"Average (MRV == 1): {(double)bug_Int/1000}");

        Bot.modifier_Int = 2;

        bug_Int = 0;
            
        for (int j = 0; j < 1000; j++)
        {

            GameBoard.GameBoardReset_Function();            

            GameBoard.SetBoard_Function(Generator.Generator_Function(55));

            Bot.Bot_Function();

            bug_Int += Bot.debug_Int;

        }

        System.Console.WriteLine($"Average (MRV == 0.5): {(double)bug_Int/1000}");   

        Console.ReadKey();

    }

    /// Function to check if the player wants to rematch.
    public static bool Rematch_Function()
    {
        // Initialize option_Bool to true and pointer_Bool to false
        bool option_Bool = true;
        bool pointer_Bool = false;

        // Loop until the player selects an option or exits the function
        while(!MyUI.UserInterface_Function("Rematch? (Use Up/Down Arrow Keys, Escape To Exit)", "Yes", "No", pointer_Bool, out bool valid_Bool, out bool exit_Bool))
        {
            // If the player has exited the function, call the PrematureExit_Function
            if (exit_Bool)
                PrematureExit_Function();

            // If the player has selected a valid option, toggle the option_Bool and pointer_Bool
            if (valid_Bool)
                (option_Bool, pointer_Bool) = (!option_Bool, !pointer_Bool);
        }

        // Return the value of option_Bool
        return option_Bool;
    }

    /// Function to handle a premature exit from the game.
    private static void PrematureExit_Function()
    {
        // Clear the console
        Console.Clear();

        // Display a message
        System.Console.WriteLine("Have A Nice Day!");

        // Wait for 300 milliseconds
        Thread.Sleep(300);

        // Terminate the program
        Environment.Exit(0);
    }

}