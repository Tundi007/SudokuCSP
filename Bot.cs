namespace Sudoku;

internal class Bot()
{

    private static MyCSP struct_MyCSP;

    public static void Bot_Function()
    {

        (int[,] boardMap_2DInt,int[,]defaultMap_2DInt) = GameBoard.GameBoardStatus_Function();

        struct_MyCSP = new(boardMap_2DInt);

        CSP_Function();

        int CSP_Function()
        {

            struct_MyCSP.Update_Function();

            if(struct_MyCSP.tableMRV_2DInt.Cast<int>().Any(x => x == 0))
                return 1;

            if(struct_MyCSP.tableMRV_2DInt.Cast<int>().All(x => x == 10))
                return 0;

            int minimumRange_Int = struct_MyCSP.tableMRV_2DInt.Cast<int>().Min();

            int leastConstraint_Int = struct_MyCSP.tableLCV_2DInt.Cast<int>().Where(x => x != -1).Min();

            int index_Int = -1;

            if(minimumRange_Int < leastConstraint_Int)
                index_Int = struct_MyCSP.tableMRV_2DInt.Cast<int>().ToList().IndexOf(minimumRange_Int);
            else
                index_Int = struct_MyCSP.tableLCV_2DInt.Cast<int>().ToList().IndexOf(leastConstraint_Int);

            int rowIndex_Int = index_Int/9;

            int columnIndex_Int = index_Int%9;

            int[] indexRange_ArrayInt = struct_MyCSP.rangeBoard_2DInt[rowIndex_Int][columnIndex_Int].Clone() as int[];

            for (int i = 0; i < indexRange_ArrayInt.Length; i++)
            {

                Console.Clear();

                MyUI.ShowMenu_Function(boardMap_2DInt, defaultMap_2DInt, rowIndex_Int, columnIndex_Int);

                Thread.Sleep(100);

                boardMap_2DInt[rowIndex_Int,columnIndex_Int] = indexRange_ArrayInt[i];

                Console.Clear();

                MyUI.ShowMenu_Function(boardMap_2DInt, defaultMap_2DInt,rowIndex_Int,columnIndex_Int);

                Thread.Sleep(100);
                
                if(CSP_Function() == 0)
                    return 0;                

                Console.Clear();

                MyUI.ShowMenu_Function(boardMap_2DInt, defaultMap_2DInt, rowIndex_Int, columnIndex_Int);

                System.Console.WriteLine("Back Tracking: [next value]");

                Console.ReadKey();

            }

            boardMap_2DInt[rowIndex_Int,columnIndex_Int] = 0; 

            Console.Clear();

            MyUI.ShowMenu_Function(boardMap_2DInt, defaultMap_2DInt, rowIndex_Int, columnIndex_Int);

            System.Console.WriteLine("Back Tracking: [new branch]");

            Console.ReadKey();

            return 1;

        }

        MyUI.ShowMenu_Function(boardMap_2DInt,new int[9,9],-1,-1);

        Console.ReadKey();
                
    }

}