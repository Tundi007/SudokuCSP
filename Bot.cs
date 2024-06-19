namespace Sudoku;

internal class Bot()
{

    public static int debug_Int = 0;

    public static int debugger_Int = 0;

    public static int modifier_Int = 0;

    private static MyCSP struct_MyCSP;

    public static void Bot_Function()
    {

        debug_Int = 0;

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

            string info_String = "";

            // if(modifier_Int == 1)
            //     index_Int = struct_MyCSP.tableMRV_2DInt.Cast<int>().ToList().IndexOf(minimumRange_Int);

            // if(modifier_Int == 2)
            //     index_Int = struct_MyCSP.tableLCV_2DInt.Cast<int>().ToList().IndexOf(leastConstraint_Int);

            if(minimumRange_Int < leastConstraint_Int)
                (info_String,index_Int) = ("[MRV]",struct_MyCSP.tableMRV_2DInt.Cast<int>().ToList().IndexOf(minimumRange_Int));
            else
                (info_String,index_Int) = ("[LCV]",struct_MyCSP.tableLCV_2DInt.Cast<int>().ToList().IndexOf(leastConstraint_Int));

            int rowIndex_Int = index_Int/9;

            int columnIndex_Int = index_Int%9;

            int[] indexRange_ArrayInt = struct_MyCSP.rangeBoard_2DInt[rowIndex_Int][columnIndex_Int].Clone() as int[];

            for (int i = 0; i < indexRange_ArrayInt.Length; i++)
            {
                                       
            
                if(debugger_Int == 0)
                {

                    Console.Clear();

                    MyUI.ShowMenu_Function(boardMap_2DInt, defaultMap_2DInt, rowIndex_Int, columnIndex_Int);

                    System.Console.WriteLine(info_String);

                    Thread.Sleep(100);

                }

                boardMap_2DInt[rowIndex_Int,columnIndex_Int] = indexRange_ArrayInt[i];                              
            
                if(debugger_Int == 0)
                {

                    Console.Clear();

                    MyUI.ShowMenu_Function(boardMap_2DInt, defaultMap_2DInt,rowIndex_Int,columnIndex_Int);

                    System.Console.WriteLine(info_String);

                    Thread.Sleep(100);

                }
                                
                if(CSP_Function() == 0)
                    return 0;                
            
                if(debugger_Int == 0)
                {

                    Console.Clear();

                    MyUI.ShowMenu_Function(boardMap_2DInt, defaultMap_2DInt, rowIndex_Int, columnIndex_Int);

                    System.Console.WriteLine("Back Tracking: [next value]");

                    Thread.Sleep(100);

                }else
                    debug_Int++;

            }
            
            if(debugger_Int == 0)
            {
             
                Console.Clear();

                MyUI.ShowMenu_Function(boardMap_2DInt, defaultMap_2DInt, rowIndex_Int, columnIndex_Int);

                System.Console.WriteLine("Back Tracking: [new branch]");

                Thread.Sleep(100);
                
            }else
                debug_Int++;

            return 1;

        }
            
        if(debugger_Int == 0)
        {

            MyUI.ShowMenu_Function(boardMap_2DInt,new int[9,9],-1,-1);

            Console.ReadKey();

        }
                
    }

}