using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_csharp_book_training
{
    class Program
    {
        static void Main(string[] args)
        {

            //TestSwitch(10);
            //TestSwitch(10.2341);
            //TestSwitch("Moamen");
            //TestSwitch(null);

            TestArrays();

            Console.WriteLine("Press Any Key to Continue!");
            Console.ReadLine();
        }



        public static void TestSwitch(object obj)
        {
            switch (obj)
            {

                case int i:
                    Console.WriteLine("integer {0}",i);
                    break;
                case double d:
                    Console.WriteLine("double {0}", d);
                    break;
                case string s:
                    Console.WriteLine("String {0}", s);
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }
        }

        public static void TestSwitch2(Employee emp)
        {
            switch (emp)
            {

                case Manager m when m.Age >= 30:
                    Console.WriteLine($"Manager: {m.FirstName} {m.LastName} is old");
                    break;
                case Manager m:
                    Console.WriteLine($"Manager: age= {m.Age} is new");
                    break;
                case PTSalesPerson _:
                    Console.WriteLine("");
                    break;
                case SalesPerson s:
                    Console.WriteLine("sales person: {0}",s.FirstName);
                    break;
                case null:
                    Console.WriteLine("null");
                    break;
                /*                
                    case var _:
                    Console.WriteLine(" var discard case");
                    break;
                */
                default:
                    Console.WriteLine("default");
                    break;
            }
        }

        public static void TestArrays()
        {
            int[] arrint = new int[4];
            arrint[0] = 10;
            arrint[1] = 20;
            arrint[2] = 30;
            arrint[3] = 40;

            int[] arrint2 = { 10, 20, 30, 40 };
            int[] arrint3 = new [] { 10, 20, 30, 40 };
            int[] arrint4 = new int [] { 10, 20, 30, 40 };
            int[] arrint5 = new int [5] { 10, 20, 30, 40, 50 };

            var arrvar = new int[4];
            arrvar[0] = 10;
            arrvar[1] = 20;
            arrvar[2] = 30;
            arrvar[3] = 40;

            // Error:
            // var arrvar2 = { 10, 20, 30, 40 };
            var arrvar2 = new [] { 10,20,30,40};
            // Error:
            // var arrvar2 = new[4] { 10, 20, 30, 40 };
            var arrvar4 = new int[] { 10,20,30,40};
            var arrvar5 = new int[4] { 10,20,30,40};

            // Rectangle 2D array
            int[,] rect1 = new int[2, 4];
            int[,] rect2 = new int[2, 4] { { 10, 20, 30, 40 }, { 50, 60, 70, 80 } };
            // Error
            //int[,] rect3 = new int[2,] { { 10, 20, 30, 40 }, { 50, 60, 70, 80 } };
            int[,] rect4 = new int[,] { { 10, 20, 30, 40 }, { 50, 60, 70, 80 } };
            int[,] rect5 = new [,] { { 10, 20, 30, 40 }, { 50, 60, 70, 80 } };

            // read rect array
            for (int i = 0; i < rect2.Rank; i++)
            {
                Console.WriteLine($"rect dim {i}");
                for (int j = 0; j < rect2.GetLength(i); j++)
                {
                    Console.WriteLine($"rectangle array[{i} , {j}] = {rect2[i, j]}");
                }
            }

            // Jagged 2D Array
            int[][] arr1 = new int[2][];

            int[][] arr2 = new int[2][] { new int [] { 10, 20, 30, 40, 90 }, new int [] { 50, 60, 70, 80 } };

            int[][] arr4 = new int[2][];
            arr4[0] = new int[] { 10, 20, 30, 40, 90 };
            arr4[1] = new int[] { 101, 201, 301, 401, 901 };

            int[][] arr5 = new int[2][];
            arr5[0] = new int[] { 10, 20, 30, 40, 90 };
            arr5[1] = new int[] { 101, 201, 301, 401, 901 };




        }
    }









}
