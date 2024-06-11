namespace Sudoku;

public class Generator
{
    private static int[,] mat = new int[9,9];
    private static int SRN; // square root of 9
    private static int missing_Int; // No. Of missing digits

    // Constructor
    public static int[,] Generator_Function(int number_Int)
    {

        mat = new int[9,9];
        
        missing_Int = number_Int;

        double SRNd = Math.Sqrt(9);

        SRN = (int)SRNd;

        FillValues();

        return mat;

    }

    // Sudoku Generator
    private static void FillValues()
    {
        // Fill the diagonal of SRN x SRN matrices
        FillDiagonal();

        // Fill remaining blocks
        FillRemaining(0, SRN);

        // Remove Randomly missing_Int digits to make game
        RemoveKDigits();

    }

    // Fill the diagonal SRN number of SRN x SRN matrices
    private static void FillDiagonal()
    {

        for (int i = 0; i<9; i+=SRN)

            // for diagonal box, start coordinates->i==j
            FillBox(i, i);
    }

    // Returns false if given 3 x 3 block contains num.
    private static bool UnUsedInBox(int rowStart, int colStart, int num)
    {
        for (int i = 0; i<SRN; i++)
            for (int j = 0; j<SRN; j++)
                if (mat[rowStart+i,colStart+j]==num)
                    return false;

        return true;
    }

    // Fill a 3 x 3 matrix.
    private static void FillBox(int row,int col)
    {
        int num;
        for (int i=0; i<SRN; i++)
        {
            for (int j=0; j<SRN; j++)
            {
                do
                {
                    num = RandomGenerator(9);
                }
                while (!UnUsedInBox(row, col, num));

                mat[row+i,col+j] = num;
            }
        }
    }

    // Random generator
    private static int RandomGenerator(int num)
    {
        Random rand = new Random();
        return (int) Math.Floor((double)(rand.NextDouble()*num+1));
    }

    private static bool CheckIfSafe(int i,int j,int num)
    {
        return UnUsedInRow(i, num) &&
                unUsedInCol(j, num) &&
                UnUsedInBox(i-i%SRN, j-j%SRN, num);
    }

    private static bool UnUsedInRow(int i,int num)
    {
        for (int j = 0; j<9; j++)
           if (mat[i,j] == num)
                return false;
        return true;
    }

    private static bool unUsedInCol(int j,int num)
    {
        for (int i = 0; i<9; i++)
            if (mat[i,j] == num)
                return false;
        return true;
    }

    private static bool FillRemaining(int i, int j)
    {
        if (j>=9 && i<9-1)
        {
            i++;
            j = 0;
        }
        if (i>=9 && j>=9)
            return true;

        if (i < SRN)
        {
            if (j < SRN)
                j = SRN;
        }
        else if (i < 9-SRN)
        {
            if (j==(int)(i/SRN)*SRN)
                j +=  SRN;
        }
        else
        {
            if (j == 9-SRN)
            {
                i++;
                j = 0;
                if (i>=9)
                    return true;
            }
        }

        for (int num = 1; num<=9; num++)
        {
            if (CheckIfSafe(i, j, num))
            {
                mat[i,j] = num;
                if (FillRemaining(i, j+1))
                    return true;

                mat[i,j] = 0;
            }
        }
        return false;
    }

    private static void RemoveKDigits()
    {
        int count = missing_Int;
        while (count != 0)
        {
            int cellId = RandomGenerator(9*9)-1;

            int i = cellId/9;
            int j = cellId%9;

            if (mat[i,j] != 0)
            {
                count--;
                mat[i,j] = 0;
            }
            
        }

    }

}
// This code is contributed by rrrtnx.
// This code is modified by Susobhan Akhuli