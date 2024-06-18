namespace Sudoku;

internal class GameBoard
{
    
    //check goal: gameBoard_2DArrayInt.Cast<int>().Any(number => number == 0)

    private static int[,]gameBoard_2DArrayInt = new int[9,9];

    private static int[,]defaultMap_2DArrayInt = new int[9,9];

    /// Resets the game board for a new match.
    public static void GameBoardReset_Function()
    {
        // Create a new game board with all elements set to zero
        gameBoard_2DArrayInt = new int[9,9];
        defaultMap_2DArrayInt = new int[9,9];
    }

    /// Returns the current state of the game board.

    public static void SetBoard_Function(int[,] board_2DArrayInt)
    {
        // Set the game board.
        gameBoard_2DArrayInt = board_2DArrayInt.Clone() as int[,];

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if(gameBoard_2DArrayInt[i,j] != 0)
                    defaultMap_2DArrayInt[i,j] = 1;
            }
        }

    }

    public static (int[,],int[,]) GameBoardStatus_Function()
    {
        // Returns the current state of the game board.
        return (gameBoard_2DArrayInt,defaultMap_2DArrayInt);
    }

    public static int CheckPlacement_Function(int playerRow_Int, int playerColumn_Int , int number_Int)
    {

        int localRow_Int = playerRow_Int - (playerRow_Int % 3);

        int localColumn_Int = playerColumn_Int - (playerColumn_Int % 3);

        if(defaultMap_2DArrayInt[playerRow_Int, playerColumn_Int] == 1)
            return 1;

        for (int index_Int = 0; index_Int < 9; index_Int++)
        {
            
            if(gameBoard_2DArrayInt[playerRow_Int, index_Int] == number_Int)
                return 2;

            if(gameBoard_2DArrayInt[index_Int, playerColumn_Int] == number_Int)
                return 3;
            
        }

        for (int squareRow_Int = localRow_Int; squareRow_Int < 3 + localRow_Int; squareRow_Int++)
        {

            for (int squareColumn_Int = localColumn_Int; squareColumn_Int < 3 + localColumn_Int; squareColumn_Int++)
            {

                if(gameBoard_2DArrayInt[squareRow_Int, squareColumn_Int] == number_Int)
                    return 4;
                
            }
            
        }

        return 0;

    }

}