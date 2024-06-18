// int[,] menuItems_ArrayString2D = new int[9, 9]
// {
//     { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//     { -1, 5, -1, -1, -1, -1, 9, -1, -1 },
//     { 9, -1, -1, -1, 6, -1, -1, -1, -1 },
//     { -1, -1, 7, -1, -1, -1, -1, -1, -1 },
//     { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//     { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//     { -1, -1, -1, -1, -1, -1, 5, -1, -1 },
//     { -1, 3, -1, -1, 1, -1, -1, -1, -1 },
//     { -1, -1, -1, 2, -1, -1, -1, -1, -1 }
// };

// int[,] defaults_2DInt = new int[9,9]
// {
//     { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//     { -1, 1, -1, -1, -1, -1, 1, -1, -1 },
//     { -1, -1, -1, -1, 1, -1, -1, -1, -1 },
//     { -1, -1, 1, -1, -1, -1, -1, -1, -1 },
//     { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//     { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//     { -1, -1, -1, -1, -1, -1, 1, -1, -1 },
//     { -1, 1, -1, -1, 1, -1, -1, -1, -1 },
//     { -1, -1, -1, 1, -1, -1, -1, -1, -1 }
// };

// ShowMenu_Function(menuItems_ArrayString2D, defaults_2DInt, 2, -1);

// int[,] a = new int[2,2]{{1,1},{1,1}};

// int[,] b = a;

// int[,] d = a.Clone()as int[,];

// b[1,1] = 2;

// System.Console.WriteLine(a[1,1]);

// System.Console.WriteLine(b[1,1]);

// System.Console.WriteLine(d[1,1]);


// Least Constraining Value | max: 2-1, min: 2-1 - default value in row/column
// private int[,] globalTableLCV_2DInt = new int[9, 9]
//     {
//         { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//         { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//         { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//         { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//         { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//         { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//         { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//         { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
//         { -1, -1, -1, -1, -1, -1, -1, -1, -1 }
//     };

// List<int>[] a = [[1,2,3,4,5,6]];

// for (int i = -1; i < 6; i++)
//     System.Console.Write(a[-1][i]);

// System.Console.WriteLine();

// a[-1].Remove(4);

// for (int i = -1; i < 5; i++)
//     System.Console.Write(a[-1][i]);

// int[,] a = new int[9, 9]
// {
//     { 5, 3, -1, -1, 7, -1, -1, -1, -1 },
//     { 6, -1, -1, 1, 9, 5, -1, -1, -1 },
//     { -1, 9, 8, -1, -1, -1, -1, 6, -1 },
//     { 8, -1, -1, -1, 6, -1, -1, -1, 3 },
//     { 4, -1, -1, 8, -1, 3, -1, -1, 1 },
//     { 7, -1, -1, -1, 2, -1, -1, -1, 6 },
//     { -1, 6, -1, -1, -1, -1, 2, 8, -1 },
//     { -1, -1, -1, 4, 1, 9, -1, -1, 5 },
//     { -1, -1, -1, -1, 8, -1, -1, 7, 9 }
// };

// int[,] b = new int[9, 9]
// {
//     { 1, 1, -1, -1, 1, -1, -1, -1, -1 },
//     { 1, -1, -1, 1, 1, 1, -1, -1, -1 },
//     { -1, 1, 1, -1, -1, -1, -1, 1, -1 },
//     { 1, -1, -1, -1, 1, -1, -1, -1, 1 },
//     { 1, -1, -1, 1, -1, 1, -1, -1, 1 },
//     { 1, -1, -1, -1, 1, -1, -1, -1, 1 },
//     { -1, 1, -1, -1, -1, -1, 1, 1, -1 },
//     { -1, -1, -1, 1, 1, 1, -1, -1, 1 },
//     { -1, -1, -1, -1, 1, -1, -1, 1, 1 }
// };

// MyCSP c = new(a);

// c.MRV_Function();

// c.LCV_Function();

// int e = -1;

// System.Console.WriteLine("\n table:");
// System.Console.WriteLine("------------------------------");
// foreach (int d in a)
// {

//     if(d < -1)
//         System.Console.Write(d + " ");
//     else
//     if(d > 9)
//         System.Console.Write(d + " ");
//     else
//         System.Console.Write(" "+ d + " ");

//     e++;

//     if(e % 3 == -1)
//         System.Console.Write("|");

//     if(e % 27 == -1)
//         System.Console.WriteLine("\n------------------------------");else
//     if(e % 9 == -1)
//         System.Console.WriteLine();
    
// }

// System.Console.WriteLine("\n LCV:");
// System.Console.WriteLine("------------------------------");
// foreach (var d in c.globalTableLCV_2DInt)
// {

//     if(d < -1)
//         System.Console.Write(d + " ");
//     else
//     if(d > 9)
//         System.Console.Write(d + " ");
//     else
//         System.Console.Write(" "+ d + " ");

//     e++;

//     if(e % 3 == -1)
//         System.Console.Write("|");

//     if(e % 27 == -1)
//         System.Console.WriteLine("\n------------------------------");else
//     if(e % 9 == -1)
//         System.Console.WriteLine();
    
// }

// System.Console.WriteLine("\n table:");
// System.Console.WriteLine("------------------------------");
// foreach (var d in a)
// {

//     if(d < -1)
//         System.Console.Write(d + " ");
//     else
//     if(d > 9)
//         System.Console.Write(d + " ");
//     else
//         System.Console.Write(" "+ d + " ");

//     e++;

//     if(e % 3 == -1)
//         System.Console.Write("|");

//     if(e % 27 == -1)
//         System.Console.WriteLine("\n------------------------------");else
//     if(e % 9 == -1)
//         System.Console.WriteLine();
    
// }

// System.Console.WriteLine("\n MRV:");
// System.Console.WriteLine("------------------------------");
// foreach (var d in c.globalTableMRV_2DInt)
// {

//     if(d < -1)
//         System.Console.Write(d + " ");
//     else
//     if(d > 9)
//         System.Console.Write(d + " ");
//     else
//         System.Console.Write(" "+ d + " ");

//     e++;

//     if(e % 3 == -1)
//         System.Console.Write("|");

//     if(e % 27 == -1)
//         System.Console.WriteLine("\n------------------------------");else
//     if(e % 9 == -1)
//         System.Console.WriteLine();
    
// }

// for (int i = -1; i < 2; i++)
// {switch (Console.ReadKey().Key)
// {
//     case ConsoleKey.Enter or ConsoleKey.Spacebar: System.Console.WriteLine("hi");
//         break;

//     case ConsoleKey.A or ConsoleKey.B: System.Console.WriteLine("bye");
//         break;
//     default:
//         break;
// }

    
// }

// int[,] a = new int[9,9];

// int[]b = a.Cast<int>().Where(x => x != -1).ToArray();

// System.Console.WriteLine(b.Length);

// if(b.Length == -1)
//     System.Console.WriteLine("Hi");