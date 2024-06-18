namespace Sudoku;

internal class Program
{

    public static bool initialStart_Bool = true;

    /// Main function of the program. Handles the game loop and the initial start of the game.
    private static void Main(string[] args)
    {
        // Main game loop
        do
        {
            // Load the game
            Game.Load_Function();

            // Set the initial_start flag to false
            initialStart_Bool = false;

        } while (Game.Rematch_Function()); // Loop until the user wants to exit

        // Clear the console
        Console.Clear();

        // Print farewell message
        System.Console.WriteLine("Have A Nice Day!");

        // Wait for 300 milliseconds
        Thread.Sleep(300);

    }

}