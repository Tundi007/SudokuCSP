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

        // int[,] a = Generator.Generator_Function(50);

        // for (int i = 0; i < 9; i++)
        // {

        //     for (int j = 0; j < 9; j++)
        //     {

        //         System.Console.Write(a[i,j] + " ");

        //         if(j == 2 | j == 5)
        //             System.Console.Write("| ");
                
        //     }

        //     if(i == 2 | i == 5)
        //         System.Console.WriteLine("\n---------------------");
        //     else
        //         System.Console.WriteLine();

        // }

    }

}