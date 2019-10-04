using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBookTraining
{
    public static class ArraysTraining
    {
        static ArraysTraining() { }

        public static void TestArrays()
        {
            int[] arrint = new int[4];
            arrint[0] = 10;
            arrint[1] = 20;
            arrint[2] = 30;
            arrint[3] = 40;

            int[] arrint2 = { 10, 20, 30, 40 };
            int[] arrint3 = new[] { 10, 20, 30, 40 };
            int[] arrint4 = new int[] { 10, 20, 30, 40 };
            int[] arrint5 = new int[5] { 10, 20, 30, 40, 50 };

            var arrvar = new int[4];
            arrvar[0] = 10;
            arrvar[1] = 20;
            arrvar[2] = 30;
            arrvar[3] = 40;

            // Error:
            // var arrvar2 = { 10, 20, 30, 40 };
            var arrvar2 = new[] { 10, 20, 30, 40 };
            // Error:
            // var arrvar2 = new[4] { 10, 20, 30, 40 };
            var arrvar4 = new int[] { 10, 20, 30, 40 };
            var arrvar5 = new int[4] { 10, 20, 30, 40 };

            // Rectangle 2D array
            int[,] rect1 = new int[2, 4];
            rect1[0, 0] = 10;
            rect1[0, 1] = 20;
            rect1[0, 2] = 30;
            rect1[0, 3] = 40;

            rect1[1, 0] = 50;
            rect1[1, 1] = 60;
            rect1[1, 2] = 70;
            rect1[1, 3] = 80;

            int[,] rect2 = new int[3, 4] { { 10, 20, 30, 40 }, { 50, 60, 70, 80 }, { 90, 91, 92, 93 } };
            // Error
            //int[,] rect3 = new int[2,] { { 10, 20, 30, 40 }, { 50, 60, 70, 80 } };
            int[,] rect4 = new int[,] { { 10, 20, 30, 40 }, { 50, 60, 70, 80 } };
            int[,] rect5 = new[,] { { 10, 20, 30, 40 }, { 50, 60, 70, 80 } };

            // read rect array
            int rows = rect2.GetLength(0);
            int cols = rect2.GetLength(1);

            int rowIndexWidth = rows.ToString().Length;
            int colIndexWidth = cols.ToString().Length;

            int rowWidth = "row".Length + rowIndexWidth;
            Console.Write(Repeate(" ", rowWidth) + "\t");
            for (int i = 0; i < rect2.GetLength(1); i++)
            {
                Console.Write($"col{i}\t");
            }
            Console.WriteLine();
            for (int i = 0; i < rect2.GetLength(0); i++)
            {
                Console.Write($"row{i}\t");
                for (int j = 0; j < rect2.GetLength(1); j++)
                {
                    Console.Write($"{rect2[i, j]}\t");
                }
                Console.WriteLine();
            }


            // Jagged 2D Array: have different dim lengths
            int[][] arr1 = new int[2][];

            int[][] arr2 = new int[2][] { new int[] { 10, 20, 30, 40, 90 }, new int[] { 50, 60, 70, 80 } };

            int[][] arr4 = new int[2][];
            arr4[0] = new int[] { 10, 20, 30, 40, 90 };
            arr4[1] = new int[] { 101, 201, 301, 401, 901 };

            int[][] arr5 = new int[2][];
            arr5[0] = new int[] { 10, 20, 30, 40, 90 };
            arr5[1] = new int[] { 101, 201, 301, 401, 901 };

            var arr6 = new int[2][] { new int[] { 10, 20, 30, 40, 50 }, new int[] { 60, 70, 80, 90 } };

            Console.WriteLine("arr6: ");
            for (int i = 0; i < arr6.GetLength(0); i++)
            {
                for (int j = 0; j < arr6[i].GetLength(0); j++)
                {
                    Console.Write($"{arr6[i][j]}\t");
                }
                Console.WriteLine();
            }

            var arr7 = new string[2][][];
            arr7[0] = new string[3][];
            arr7[1] = new string[4][];

            arr7[0][0] = new string[3];
            arr7[0][1] = new string[4];
            arr7[0][2] = new string[5];

            arr7[1][0] = new string[3];
            arr7[1][1] = new string[4];
            arr7[1][2] = new string[5];
            arr7[1][3] = new string[6];

            arr7[0][0][0] = "000";
            arr7[0][0][1] = "001";
            arr7[0][0][2] = "002";

            arr7[0][1][0] = "010";
            arr7[0][1][1] = "011";
            arr7[0][1][2] = "012";
            arr7[0][1][3] = "013";

            arr7[0][2][0] = "020";
            arr7[0][2][1] = "021";
            arr7[0][2][2] = "022";
            arr7[0][2][3] = "023";
            arr7[0][2][4] = "024";


            arr7[1][0][0] = "100";
            arr7[1][0][1] = "101";
            arr7[1][0][2] = "102";

            arr7[1][1][0] = "110";
            arr7[1][1][1] = "111";
            arr7[1][1][2] = "112";
            arr7[1][1][3] = "113";

            arr7[1][2][0] = "120";
            arr7[1][2][1] = "121";
            arr7[1][2][2] = "122";
            arr7[1][2][3] = "123";
            arr7[1][2][4] = "124";

            arr7[1][3][0] = "130";
            arr7[1][3][1] = "131";
            arr7[1][3][2] = "132";
            arr7[1][3][3] = "133";
            arr7[1][3][4] = "134";
            arr7[1][3][5] = "135";

            Console.WriteLine("arr7 : ");
            Console.WriteLine("[");
            for (int i = 0; i < arr7.GetLength(0); i++)
            {
                Console.WriteLine(" [");
                for (int j = 0; j < arr7[i].GetLength(0); j++)
                {
                    Console.Write("  [");
                    for (int k = 0; k < arr7[i][j].GetLength(0); k++)
                    {
                        Console.Write($"  {arr7[i][j][k]}  ");
                    }
                    Console.WriteLine("]");
                }
                Console.WriteLine(" ]");
            }
            Console.WriteLine("]");

            // separator
            Console.WriteLine("Array Class Training".PadLeft(10,'=').PadRight(10,'='));

            int[] arr10 = { 10, 2, 3, 4, 5, 9, 5, 7, 33, 10, 12, 13, 14, 17 , 2, 10, 20, 30, 33, 34, 100, 11, 45, 33, 34, 100};

            // find number = 10 in array
            int num = Array.Find(arr10, Predicates.Find100);
            Console.WriteLine($"find num == 10 -> {num}");

            num = Array.FindLast(arr10, Predicates.Find100);
            Console.WriteLine($"find last num == 10 -> {num}");

            int [] numarr = Array.FindAll(arr10, Predicates.Find100);
            Console.WriteLine($"find all num == 10 -> ");
            ArrayPrint(numarr);

            // find all number more than 9 and less than 31
            numarr = Array.FindAll(arr10, p => p >= 10 && p <= 30 );
            Console.WriteLine($"find all num == 10 -> ");
            ArrayPrint(numarr);

            



        }

        public static string Repeate(string str, int count)
        {
            return new StringBuilder(str.Length * count).Insert(0, str, count).ToString();
        }

        public static int CountDigits(int number)
        {
            return number.ToString().Length;
        }

        public static void ArrayPass(int[] arr)
        {
            Console.WriteLine(arr);
        }

        public static int[] ArrayReturn()
        {
            //return new int [] { 10, 20, 30, 40, 50, 60 };
            return new[] { 10, 20, 30, 40, 50, 60 };
        }


        public static int[] ArrayReverse(int [] arr)
        {
            Array.Reverse(arr);
            return arr;
        }

        // find number == 100
        public static void ArrayPrint(int[] arr)
        {
            //Console.WriteLine(string.Join(" , ",arr));
            //Console.WriteLine(string.Concat(arr));

            Console.WriteLine();
            int count = 0;
            foreach (var item in arr)
            {
                Console.Write($"{item.ToString()} {((count++ == arr.Length - 1)? ' ' : ',')} ");
            }
            Console.WriteLine();
        }

    }

    static class Predicates
    {
        static Predicates()
        {

        }

        public static bool Find100(int a)
        {
            return a == 10;
        }


    }

}