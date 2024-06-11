namespace Sudoku;

internal class Game
{

    public static bool bot_Bool;

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
        while(!MyUI.UserInterface_Function("Select Game Mode:", "Player", "Bot",
            pointer_Bool, out bool valid_Bool, out bool exit_Bool))
        {
            // If exit is triggered, exit the game
            if (exit_Bool)
                PrematureExit_Function();
            // If valid input is triggered, toggle single player mode
            if (valid_Bool)
                (bot_Bool, pointer_Bool) = (!bot_Bool, !pointer_Bool);
        }

        pointer_Bool = false;

        bool difficulty_Int_Bool = false;

        int difficulty_Int = 20;

        // Bot configuration selection loop
        while (!MyUI.UserInterface_Function("Table Difficulty:", "Normal", "Scarce", pointer_Bool,
            out bool valid_Bool, out bool exit_Bool))
        {
            // If exit is triggered, exit the game
            if (exit_Bool)
                PrematureExit_Function();

            // If valid input is triggered, toggle bot configurations
            if (valid_Bool)
                (difficulty_Int_Bool, pointer_Bool) = (!difficulty_Int_Bool, !pointer_Bool);
        }

        if(difficulty_Int_Bool)
            difficulty_Int = 60;
            
        // Reset the game board
        GameBoard.GameBoardReset_Function();

        GameBoard.SetBoard_Function(Generator.Generator_Function(difficulty_Int));

    }

    /// The main game loop that handles the game logic.
    private static void Game_Function()
    {

        int[,] answer_2DInt = new int[9,9];

        if (bot_Bool)
            answer_2DInt = Bot.Bot_Function();
        else
            PlayerTurn_Function();

        if(answer_2DInt.Cast<int>().Sum() == 0)
            return;// couldnt solve

    }

    /// Handles the player's turn in the game loop.
    private static bool PlayerTurn_Function()
    {
        if (MyUI.GameInterface_Function() == 1)
            PrematureExit_Function();
            return false;
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