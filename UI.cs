namespace Sudoku;

internal class MyUI
{

    private static string gameInfo_String = "";    

    /// Sets the game info string to the provided
    public static void GameInfo_Function(string info_String)
    {        
        // Set the game info string to the provided string
        gameInfo_String = info_String;
    }

    /// This function is a general interface that displays a menu and awaits user input
    public static bool UserInterface_Function(string menu_String, string firstOption_String, string secondOption_String, bool pointer_Bool, out bool output_Bool, out bool exit_Bool)
    {
        // Initialize outputs

        exit_Bool = false;

        output_Bool = false;

        // Clear console
        Console.Clear();

        // Display menu
        System.Console.WriteLine(menu_String);

        // Display pointer
        if (!pointer_Bool) System.Console.Write("->");

        System.Console.WriteLine(firstOption_String);

        if (pointer_Bool) System.Console.Write("->");

        System.Console.WriteLine(secondOption_String);

        // Await user input
        switch (Console.ReadKey(true).Key)
        {
            // If enter is pressed, clear console and return true

            case ConsoleKey.Enter:
                Console.Clear();
                return true;

            // If escape is pressed, set exit_Bool to true
            case ConsoleKey.Escape:            
                exit_Bool = true;
                break;

            // If up or down arrow is pressed, set output_Bool to true
            case ConsoleKey.UpArrow:
               output_Bool = true;
               break;

            case ConsoleKey.DownArrow:
                output_Bool = true;
                break;

            // If any other key is pressed, do nothing
            default:
                break;

        }

        // Return false
        return false;

    }

    /// This function is a general interface that displays a menu and awaits user input
    public static int UserInterface2_Function(string menu_String, string number_String, out int output_Int)
    {
        // Initialize outputs

        output_Int = 0;

        // Clear console
        Console.Clear();

        // Display menu
        System.Console.WriteLine(menu_String);

        System.Console.WriteLine("->"+number_String);

        // Await user input
        switch (Console.ReadKey(true).Key)
        {
            // If enter is pressed, clear console and return true

            case ConsoleKey.D:
                Console.Clear();
                output_Int = 4;
                break;

            case ConsoleKey.S:
                Console.Clear();
                output_Int = 3;
                break;

            case ConsoleKey.Enter:
                Console.Clear();
                return 1;

            // If escape is pressed, set exit_Bool to true
            case ConsoleKey.Escape:
                output_Int = 2;
                break;

            // If up or down arrow is pressed, set output_Bool to true
            case ConsoleKey.UpArrow:
               output_Int = 1;
               break;

            case ConsoleKey.DownArrow:
                output_Int = 0;
                break;

            // If any other key is pressed, do nothing
            default:
                break;

        }

        // Return false
        return 0;

    }

    /// This function is a general interface that displays a game menu and awaits user input
    public static int GameInterface_Function()
    {

        //could implement undo button
        
        // Initialize variables
        bool finish_Bool = false;
        string error_String = "";
        int menuPointerColumn_Int = 0;
        int menuPointerRow_Int = 0;
        (int[,] menuItems_ArrayString2D, int[,]defaults_2DArrayInt) = GameBoard.GameBoardStatus_Function();
        int[,] original_2DArrayInt = menuItems_ArrayString2D.Clone() as int[,];

        // Create hint string
        string hint_String =
            $"Use \"Arrow Keys\" To Navigate, \"Number Keys\" To Place Numbers, \"Backspace\" To Remove,\n\"R\": Reset To Original Board, \"Escape\": Main Menu";

        // Display game menu
        while (true)
        {

            if(finish_Bool = !menuItems_ArrayString2D.Cast<int>().Any(number => number == 0))
            {

                gameInfo_String = "You Won! Press \"R\" To Rematch Or \"Escape\" To Exit";

                hint_String = "Press Any Key To Continue";

            }
            Console.Clear();          
            System.Console.WriteLine(gameInfo_String);
            ShowMenu_Function(menuItems_ArrayString2D, defaults_2DArrayInt, menuPointerRow_Int, menuPointerColumn_Int);
            if(!string.IsNullOrWhiteSpace(error_String))
                System.Console.WriteLine(error_String);
            error_String = "";
            System.Console.WriteLine(hint_String);
            if(finish_Bool)
            {
                
                Console.ReadKey(true);

                return 0;
                
            }

            // Await user input
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                {
                    if(menuPointerColumn_Int < 1) break;
                    menuPointerColumn_Int--;
                }break;

                case ConsoleKey.RightArrow:
                {
                    if (menuPointerColumn_Int > 7) break;
                    menuPointerColumn_Int++;
                }break;

                case ConsoleKey.UpArrow:
                {
                    if(menuPointerRow_Int < 1) break;
                    menuPointerRow_Int--;
                }break;

                case ConsoleKey.DownArrow:
                {
                    if (menuPointerRow_Int > 7) break;
                    menuPointerRow_Int++;
                }break;

                case ConsoleKey.Backspace:
                {
                    if(defaults_2DArrayInt[menuPointerRow_Int,menuPointerColumn_Int] == 0)
                        menuItems_ArrayString2D[menuPointerRow_Int,menuPointerColumn_Int] = 0;
                    else
                        error_String = "Can't Delete Default Value!";
                }break;

                case ConsoleKey.Escape:
                {
                    bool pointer_Bool = false;
                    bool mainMenu_Bool = false;
                    // Display confirmation for exiting to main menu
                    while (!MyUI.UserInterface_Function($"All Progress Will Be Lost\nProceed?", "No", "Yes", pointer_Bool, out bool valid_Bool, out bool exit_Bool))
                    {            
                        if(exit_Bool)
                            return 1;
                        if(valid_Bool)
                            (mainMenu_Bool,pointer_Bool) =
                                (!mainMenu_Bool,!pointer_Bool);
                    }

                    if(mainMenu_Bool)
                        return 0;
                }break;

                case ConsoleKey.R:
                {
                    bool pointer_Bool = false;
                    bool reset_Bool = false;
                    // Display confirmation for exiting to main menu
                    while (!MyUI.UserInterface_Function($"Reset To Original Board?", "No", "Yes", pointer_Bool, out bool valid_Bool, out bool exit_Bool))
                    {            
                        if(exit_Bool)
                            return 1;
                        if(valid_Bool)
                            (reset_Bool,pointer_Bool) =
                                (!reset_Bool,!pointer_Bool);
                    }
                    if(reset_Bool)
                        menuItems_ArrayString2D = original_2DArrayInt.Clone() as int[,];
                }break;

                case ConsoleKey.D1:
                {

                    switch (GameBoard.CheckPlacement_Function(menuPointerRow_Int, menuPointerColumn_Int , 1))
                    {
                        case 0:
                            menuItems_ArrayString2D[menuPointerRow_Int,menuPointerColumn_Int] = 1;
                            break;

                        case 1:
                            error_String = "Invalid place! Can't Change A Default Value!";
                            break;

                        case 2:
                            error_String = "Invalid Number! Duplicate Number In Row!";
                            break;

                        case 3:
                            error_String = "Invalid Number! Duplicate Number In Column!";
                            break;

                        case 4:
                            error_String = "Invalid Number! Duplicate Number In Local Square!";
                            break;
                        
                        default:
                            break;
                    }
                        

                }break;

                case ConsoleKey.D2:
                {

                    switch (GameBoard.CheckPlacement_Function(menuPointerRow_Int, menuPointerColumn_Int , 2))
                    {
                        case 0:
                            menuItems_ArrayString2D[menuPointerRow_Int,menuPointerColumn_Int] = 2;
                            break;

                        case 1:
                            error_String = "Invalid place! Can't Change A Default Value!";
                            break;

                        case 2:
                            error_String = "Invalid Number! Duplicate Number In Row!";
                            break;

                        case 3:
                            error_String = "Invalid Number! Duplicate Number In Column!";
                            break;

                        case 4:
                            error_String = "Invalid Number! Duplicate Number In Local Square!";
                            break;
                        
                        default:
                            break;
                    }
                        

                }break;

                case ConsoleKey.D3:
                {

                    switch (GameBoard.CheckPlacement_Function(menuPointerRow_Int, menuPointerColumn_Int , 3))
                    {
                        case 0:
                            menuItems_ArrayString2D[menuPointerRow_Int,menuPointerColumn_Int] = 3;
                            break;

                        case 1:
                            error_String = "Invalid place! Can't Change A Default Value!";
                            break;

                        case 2:
                            error_String = "Invalid Number! Duplicate Number In Row!";
                            break;

                        case 3:
                            error_String = "Invalid Number! Duplicate Number In Column!";
                            break;

                        case 4:
                            error_String = "Invalid Number! Duplicate Number In Local Square!";
                            break;
                        
                        default:
                            break;
                    }
                        

                }break;

                case ConsoleKey.D4:
                {

                    switch (GameBoard.CheckPlacement_Function(menuPointerRow_Int, menuPointerColumn_Int , 4))
                    {
                        case 0:
                            menuItems_ArrayString2D[menuPointerRow_Int,menuPointerColumn_Int] = 4;
                            break;

                        case 1:
                            error_String = "Invalid place! Can't Change A Default Value!";
                            break;

                        case 2:
                            error_String = "Invalid Number! Duplicate Number In Row!";
                            break;

                        case 3:
                            error_String = "Invalid Number! Duplicate Number In Column!";
                            break;

                        case 4:
                            error_String = "Invalid Number! Duplicate Number In Local Square!";
                            break;
                        
                        default:
                            break;
                    }
                        

                }break;

                case ConsoleKey.D5:
                {

                    switch (GameBoard.CheckPlacement_Function(menuPointerRow_Int, menuPointerColumn_Int , 5))
                    {
                        case 0:
                            menuItems_ArrayString2D[menuPointerRow_Int,menuPointerColumn_Int] = 5;
                            break;

                        case 1:
                            error_String = "Invalid place! Can't Change A Default Value!";
                            break;

                        case 2:
                            error_String = "Invalid Number! Duplicate Number In Row!";
                            break;

                        case 3:
                            error_String = "Invalid Number! Duplicate Number In Column!";
                            break;

                        case 4:
                            error_String = "Invalid Number! Duplicate Number In Local Square!";
                            break;
                        
                        default:
                            break;
                    }
                        

                }break;

                case ConsoleKey.D6:
                {

                    switch (GameBoard.CheckPlacement_Function(menuPointerRow_Int, menuPointerColumn_Int , 6))
                    {
                        case 0:
                            menuItems_ArrayString2D[menuPointerRow_Int,menuPointerColumn_Int] = 6;
                            break;

                        case 1:
                            error_String = "Invalid place! Can't Change A Default Value!";
                            break;

                        case 2:
                            error_String = "Invalid Number! Duplicate Number In Row!";
                            break;

                        case 3:
                            error_String = "Invalid Number! Duplicate Number In Column!";
                            break;

                        case 4:
                            error_String = "Invalid Number! Duplicate Number In Local Square!";
                            break;
                        
                        default:
                            break;
                    }
                        

                }break;

                case ConsoleKey.D7:
                {

                    switch (GameBoard.CheckPlacement_Function(menuPointerRow_Int, menuPointerColumn_Int , 7))
                    {
                        case 0:
                            menuItems_ArrayString2D[menuPointerRow_Int,menuPointerColumn_Int] = 7;
                            break;

                        case 1:
                            error_String = "Invalid place! Can't Change A Default Value!";
                            break;

                        case 2:
                            error_String = "Invalid Number! Duplicate Number In Row!";
                            break;

                        case 3:
                            error_String = "Invalid Number! Duplicate Number In Column!";
                            break;

                        case 4:
                            error_String = "Invalid Number! Duplicate Number In Local Square!";
                            break;
                        
                        default:
                            break;
                    }
                        

                }break;

                case ConsoleKey.D8:
                {

                    switch (GameBoard.CheckPlacement_Function(menuPointerRow_Int, menuPointerColumn_Int , 8))
                    {
                        case 0:
                            menuItems_ArrayString2D[menuPointerRow_Int,menuPointerColumn_Int] = 8;
                            break;

                        case 1:
                            error_String = "Invalid place! Can't Change A Default Value!";
                            break;

                        case 2:
                            error_String = "Invalid Number! Duplicate Number In Row!";
                            break;

                        case 3:
                            error_String = "Invalid Number! Duplicate Number In Column!";
                            break;

                        case 4:
                            error_String = "Invalid Number! Duplicate Number In Local Square!";
                            break;
                        
                        default:
                            break;
                    }
                        

                }break;

                case ConsoleKey.D9:
                {

                    switch (GameBoard.CheckPlacement_Function(menuPointerRow_Int, menuPointerColumn_Int , 9))
                    {
                        case 0:
                            menuItems_ArrayString2D[menuPointerRow_Int,menuPointerColumn_Int] = 9;
                            break;

                        case 1:
                            error_String = "Invalid place! Can't Change A Default Value!";
                            break;

                        case 2:
                            error_String = "Invalid Number! Duplicate Number In Row!";
                            break;

                        case 3:
                            error_String = "Invalid Number! Duplicate Number In Column!";
                            break;

                        case 4:
                            error_String = "Invalid Number! Duplicate Number In Local Square!";
                            break;
                        
                        default:
                            break;
                    }
                        

                }break;

                default:
                    error_String = "Undefined Input";
                    break;

            }

        }

    }

    /// Displays a menu given a 2D array of menu items and the coordinates of the pointer
    public static void ShowMenu_Function(int[,] menuItems_ArrayString2D, int[,] defaults_2DArrayInt, int menuPointerRow_Int, int menuPointerColumn_Int)
    {
        // Print each row of the menu
        System.Console.WriteLine();
        for (int rowNumber_Int = 0; rowNumber_Int < 9 ; rowNumber_Int++)
        {
            // Print each column of the row
            for (int columnNumber_Int = 0; columnNumber_Int < 9; columnNumber_Int++)
            {
                // If the current cell is the menu pointer
                if(rowNumber_Int == menuPointerRow_Int && columnNumber_Int == menuPointerColumn_Int)
                {
                    // Print the appropriate symbol
                    if(menuItems_ArrayString2D[rowNumber_Int,columnNumber_Int] == 0)
                        System.Console.Write("[-]");
                    else if(defaults_2DArrayInt[rowNumber_Int,columnNumber_Int] == 1)
                        System.Console.Write($"!{menuItems_ArrayString2D[rowNumber_Int,columnNumber_Int]}!");
                    else
                        System.Console.Write($"[{menuItems_ArrayString2D[rowNumber_Int,columnNumber_Int]}]");
                }
                else
                {
                    // Print the appropriate symbol
                    if (menuItems_ArrayString2D[rowNumber_Int,columnNumber_Int] == 0)
                        System.Console.Write(" - ");
                    else if(defaults_2DArrayInt[rowNumber_Int,columnNumber_Int] == 1)
                        System.Console.Write($"<{menuItems_ArrayString2D[rowNumber_Int,columnNumber_Int]}>");
                    else
                        System.Console.Write($" {menuItems_ArrayString2D[rowNumber_Int,columnNumber_Int]} ");
                }
                if(columnNumber_Int == 2 | columnNumber_Int == 5 )
                    System.Console.Write(" | ");

            }

            if(rowNumber_Int == 2 | rowNumber_Int == 5 )
                System.Console.Write("\n---------------------------------");

            System.Console.WriteLine();
        }
    }

}