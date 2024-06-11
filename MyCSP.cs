namespace Sudoku;

public readonly struct MyCSP(int[,] inputBoard_2DInt)
{

    private readonly int[,] board_2DInt = inputBoard_2DInt;

    public readonly int[][][] rangeBoard_2DInt = new int[9][][];

    public readonly int[,] tableMRV_2DInt
    {
        get
        {

            MRV_Function();
            
            return tableMRV_2DInt;
            
        }
        set
        { 
            
            tableMRV_2DInt = value; 

        }

    }

    public readonly int[][] tableLCV_2DInt
    {
        get
        {

            LCV_Function();
            
            return tableLCV_2DInt;
            
        }
        set
        {
            
            tableLCV_2DInt = value;

        }

    }

    private readonly void MRV_Function()
    {

        tableMRV_2DInt = new int[9,9];

        List<int>[] availableRowOptions_Int = [

            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9]

        ];

        List<int>[] availableColumnOptions_Int = [

            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9]

        ];

        List<int>[] availableSquareOptions_Int = [

            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9],
            [1,2,3,4,5,6,7,8,9]

        ];

        for (int index1_Int = 0; index1_Int < 9; index1_Int++)
        {

            for (int index2_Int = 0; index2_Int < 9; index2_Int++)
            {

                int square_Int = 0;

                if(index1_Int > 2)
                    square_Int += 3;
                
                if(index1_Int > 5)
                    square_Int += 3;

                square_Int += index2_Int/3;

                if(board_2DInt[index1_Int,index2_Int] != 0)
                {

                    if(board_2DInt[index1_Int,index2_Int] == 10)
                    {

                        tableMRV_2DInt[index1_Int,index2_Int] = 10;

                    }
                    else
                    {

                        tableMRV_2DInt[index1_Int,index2_Int] = -1;

                        availableRowOptions_Int[index1_Int].Remove(board_2DInt[index1_Int,index2_Int]);

                        availableColumnOptions_Int[index2_Int].Remove(board_2DInt[index1_Int,index2_Int]);

                        availableSquareOptions_Int[square_Int].Remove(board_2DInt[index1_Int,index2_Int]);

                    }

                }
                        
            }
            
        }

        for (int index1_Int = 0; index1_Int < 9; index1_Int++)
        {

            for (int index2_Int = 0; index2_Int < 9; index2_Int++)
            {

                int square_Int = 0;

                if(index1_Int > 2)
                    square_Int += 3;
                
                if(index1_Int > 5)
                    square_Int += 3;

                square_Int += index2_Int/3;

                if(tableMRV_2DInt[index1_Int,index2_Int] != -1)
                {
                    
                    rangeBoard_2DInt[index1_Int][index2_Int] =
                        availableRowOptions_Int[index1_Int].Where
                            (x => availableColumnOptions_Int[index2_Int].Any
                                (y => y == x) & availableSquareOptions_Int[square_Int].Any
                                    (z => z == x)).ToArray();

                    tableMRV_2DInt[index1_Int,index2_Int] =
                        rangeBoard_2DInt[index1_Int][index2_Int].Length;
                    
                }else
                    rangeBoard_2DInt[index1_Int][index2_Int] = [0];
                
            }
            
        }

    }

    private readonly void LCV_Function()
    {

        tableLCV_2DInt =
        [
            [ -1, -1, -1, -1, -1, -1, -1, -1, -1 ],
            [ -1, -1, -1, -1, -1, -1, -1, -1, -1 ],
            [ -1, -1, -1, -1, -1, -1, -1, -1, -1 ],
            [ -1, -1, -1, -1, -1, -1, -1, -1, -1 ],
            [ -1, -1, -1, -1, -1, -1, -1, -1, -1 ],
            [ -1, -1, -1, -1, -1, -1, -1, -1, -1 ],
            [ -1, -1, -1, -1, -1, -1, -1, -1, -1 ],
            [ -1, -1, -1, -1, -1, -1, -1, -1, -1 ],
            [ -1, -1, -1, -1, -1, -1, -1, -1, -1 ]
        ];

        
        int[][] array_2DInt = new int[9][];

        for (int index_Int = 0; index_Int < 9; index_Int++)
        {

            array_2DInt[index_Int] = new int[9];

            for (int index1_Int = 0; index1_Int < 9; index1_Int++)
            {

                array_2DInt[index_Int][index1_Int] = board_2DInt[index_Int,index1_Int];

            }

        }

        int[][] columnArray_2DInt = 
        [
            [array_2DInt[0][0], array_2DInt[1][0], array_2DInt[2][0], array_2DInt[3][0], array_2DInt[4][0], array_2DInt[5][0], array_2DInt[6][0], array_2DInt[7][0], array_2DInt[8][0]],
            [array_2DInt[0][1], array_2DInt[1][1], array_2DInt[2][1], array_2DInt[3][1], array_2DInt[4][1], array_2DInt[5][1], array_2DInt[6][1], array_2DInt[7][1], array_2DInt[8][1]],
            [array_2DInt[0][2], array_2DInt[1][2], array_2DInt[2][2], array_2DInt[3][2], array_2DInt[4][2], array_2DInt[5][2], array_2DInt[6][2], array_2DInt[7][2], array_2DInt[8][2]],
            [array_2DInt[0][3], array_2DInt[1][3], array_2DInt[2][3], array_2DInt[3][3], array_2DInt[4][3], array_2DInt[5][3], array_2DInt[6][3], array_2DInt[7][3], array_2DInt[8][3]],
            [array_2DInt[0][4], array_2DInt[1][4], array_2DInt[2][4], array_2DInt[3][4], array_2DInt[4][4], array_2DInt[5][4], array_2DInt[6][4], array_2DInt[7][4], array_2DInt[8][4]],
            [array_2DInt[0][5], array_2DInt[1][5], array_2DInt[2][5], array_2DInt[3][5], array_2DInt[4][5], array_2DInt[5][5], array_2DInt[6][5], array_2DInt[7][5], array_2DInt[8][5]],
            [array_2DInt[0][6], array_2DInt[1][6], array_2DInt[2][6], array_2DInt[3][6], array_2DInt[4][6], array_2DInt[5][6], array_2DInt[6][6], array_2DInt[7][6], array_2DInt[8][6]],
            [array_2DInt[0][7], array_2DInt[1][7], array_2DInt[2][7], array_2DInt[3][7], array_2DInt[4][7], array_2DInt[5][7], array_2DInt[6][7], array_2DInt[7][7], array_2DInt[8][7]],
            [array_2DInt[0][8], array_2DInt[1][8], array_2DInt[2][8], array_2DInt[3][8], array_2DInt[4][8], array_2DInt[5][8], array_2DInt[6][8], array_2DInt[7][8], array_2DInt[8][8]]
        ];

        int[][] sqareArray_2DInt = 
        [
            [array_2DInt[0][0], array_2DInt[0][1], array_2DInt[0][2], array_2DInt[1][0], array_2DInt[1][1], array_2DInt[1][2], array_2DInt[2][0], array_2DInt[2][1], array_2DInt[2][2]],
            [array_2DInt[0][3], array_2DInt[0][4], array_2DInt[0][5], array_2DInt[1][3], array_2DInt[1][4], array_2DInt[1][5], array_2DInt[2][3], array_2DInt[2][4], array_2DInt[2][5]],
            [array_2DInt[0][6], array_2DInt[0][7], array_2DInt[0][8], array_2DInt[1][6], array_2DInt[1][7], array_2DInt[1][8], array_2DInt[2][6], array_2DInt[2][7], array_2DInt[2][8]],
            [array_2DInt[3][0], array_2DInt[3][1], array_2DInt[3][2], array_2DInt[4][0], array_2DInt[4][1], array_2DInt[4][2], array_2DInt[5][0], array_2DInt[5][1], array_2DInt[5][2]],
            [array_2DInt[3][3], array_2DInt[3][4], array_2DInt[3][5], array_2DInt[4][3], array_2DInt[4][4], array_2DInt[4][5], array_2DInt[5][3], array_2DInt[5][4], array_2DInt[5][5]],
            [array_2DInt[3][6], array_2DInt[3][7], array_2DInt[3][8], array_2DInt[4][6], array_2DInt[4][7], array_2DInt[4][8], array_2DInt[5][6], array_2DInt[5][7], array_2DInt[5][8]],
            [array_2DInt[6][0], array_2DInt[6][1], array_2DInt[6][2], array_2DInt[7][0], array_2DInt[7][1], array_2DInt[7][2], array_2DInt[8][0], array_2DInt[8][1], array_2DInt[8][2]],
            [array_2DInt[6][3], array_2DInt[6][4], array_2DInt[6][5], array_2DInt[7][3], array_2DInt[7][4], array_2DInt[7][5], array_2DInt[8][3], array_2DInt[8][4], array_2DInt[8][5]],
            [array_2DInt[6][6], array_2DInt[6][7], array_2DInt[6][8], array_2DInt[7][6], array_2DInt[7][7], array_2DInt[7][8], array_2DInt[8][6], array_2DInt[8][7], array_2DInt[8][8]]
        ];

        for (int index1_Int = 0; index1_Int < 9; index1_Int++)
        {

            for (int index2_Int = 0; index2_Int < 9; index2_Int++)
            {

                if(board_2DInt[index1_Int,index2_Int] == 0)
                {

                    int square_Int = 0;

                    int localColumn_Int = -1;

                    int localRow_Int = -1;

                    if(index1_Int > 2)
                        square_Int += 3;
                    
                    if(index1_Int > 5)
                        square_Int += 3;

                    square_Int += index2_Int/3;

                    tableLCV_2DInt[index1_Int][index2_Int] = 0;

                    tableLCV_2DInt[index1_Int][index2_Int] += array_2DInt[index1_Int].Count(x => x ==0) - 1;

                    tableLCV_2DInt[index1_Int][index2_Int] += columnArray_2DInt[index2_Int].Count(x => x ==0) - 1;

                    switch (index1_Int)
                    {

                        case 0 or 3 or 6: localRow_Int = 0;
                            break;

                        case 1 or 4 or 7: localRow_Int = 1;
                            break;

                        case 2 or 5 or 8: localRow_Int = 2;
                            break;
                        
                        default: break;

                    }

                    switch (index2_Int)
                    {

                        case 0 or 3 or 6: localColumn_Int = 0;
                            break;

                        case 1 or 4 or 7: localColumn_Int = 1;
                            break;

                        case 2 or 5 or 8: localColumn_Int = 2;
                            break;
                        
                        default: break;

                    }

                    switch (localRow_Int,localColumn_Int)
                    {

                        case (0,0):
                        {

                            if(sqareArray_2DInt[square_Int][4] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][5] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][7] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][8] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                        }break;

                        case (1,0):
                        {

                            if(sqareArray_2DInt[square_Int][1] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][2] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][7] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][8] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                        }break;

                        case (2,0):
                        {

                            if(sqareArray_2DInt[square_Int][1] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][2] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][4] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][5] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                        }break;

                        case (0,1):
                        {

                            if(sqareArray_2DInt[square_Int][3] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][5] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][6] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][8] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                        }break;

                        case (1,1):
                        {

                            if(sqareArray_2DInt[square_Int][0] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][2] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][6] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][8] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                        }break;

                        case (2,1):
                        {

                            if(sqareArray_2DInt[square_Int][0] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][2] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][3] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][5] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                        }break;

                        case (0,2):
                        {

                            if(sqareArray_2DInt[square_Int][3] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][4] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][6] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][7] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                        }break;

                        case (1,2):
                        {

                            if(sqareArray_2DInt[square_Int][0] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][1] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][6] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][7] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                        }break;

                        case (2,2):
                        {

                            if(sqareArray_2DInt[square_Int][0] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][1] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][3] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                            if(sqareArray_2DInt[square_Int][4] == 0)
                                tableLCV_2DInt[index1_Int][index2_Int]++;

                        }break;
                        
                        default: break;
                    }
                    
                }
                        
            }
            
        }
        
    }

}