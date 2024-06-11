namespace Sudoku;

internal class Bot
{

    private static bool botUpgrade_Bool = false;

    /// Returns the coordinates of the best move for the bot to make.
    public static int[,] Bot_Function()
    {

        //first solve each small square.
        //then fix each row that has duplicates.
        // then fix each column that has duplicates.
        //all of this should happen while only changing inside the small square.

        (int[,]defaultMap_2DInt, int[,] main_2DInt) = GameBoard.GameBoardStatus_Function();

        int[,] boardMap_2DInt = main_2DInt.Clone() as int[,];

        MyCSP struct_MyCSP = new(boardMap_2DInt);

        if(CSP_Function(boardMap_2DInt.Clone() as int[,]))
            return boardMap_2DInt;
        else
            return new int[9,9];

        bool CSP_Function(int[,] backupMap_2DInt)
        {

            int[,] tempMap_2DInt = boardMap_2DInt.Clone() as int[,];

            int index_Int = struct_MyCSP.tableMRV_2DInt.Cast<int>().ToList().IndexOf(struct_MyCSP.tableMRV_2DInt.Cast<int>().Where(x => x != 10).Max());

            int backtrackIndex_Int = -1;

            while((backtrackIndex_Int = struct_MyCSP.tableMRV_2DInt.Cast<int>().ToList().IndexOf(10)) != -1)
            {

                int backtrackRow_Int = backtrackIndex_Int / 9;

                int backtrackcolumn_Int = backtrackIndex_Int % 9;

                boardMap_2DInt[backtrackIndex_Int,backtrackcolumn_Int] = 0;

            }

            int row_Int = index_Int / 9;

            int column_Int = index_Int % 9;

            boardMap_2DInt[row_Int,column_Int] = struct_MyCSP.rangeBoard_2DInt[row_Int][column_Int][0];

            if(struct_MyCSP.tableMRV_2DInt.Cast<int>().Max() == -1)
                return true;

            if(struct_MyCSP.tableMRV_2DInt.Cast<int>().Max() == 0)
                return false;

            if(!CSP_Function(boardMap_2DInt.Clone() as int[,]))
            {

                boardMap_2DInt[row_Int,column_Int] = 10;
            
                CSP_Function(tempMap_2DInt.Clone() as int[,]);
            
            }

            return true;

        }
        
    }

}