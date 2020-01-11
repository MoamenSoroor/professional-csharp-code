using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProCSharpBook.OOPExamples;

namespace ProCSharpBook.CSharpBasics
{
    static class SwitchTraining
    {
        static SwitchTraining() { }

        public static void TestSwitches()
        {
            SwitchTraining.TestSwitch(10);
            SwitchTraining.TestSwitch(10.2341);
            SwitchTraining.TestSwitch("Moamen");
            SwitchTraining.TestSwitch(null);
        }

        public static void TestSwitch(object obj)
        {
            switch (obj)
            {

                case int i:
                    Console.WriteLine("integer {0}", i);
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
                    Console.WriteLine("sales person: {0}", s.FirstName);
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



    }

    static class IfTraining
    {
        static IfTraining() { }

        public static void TestIfStatement()
        {
            Random random = new Random();

            int randomNumber = random.Next(0,11);

            Console.WriteLine($"random number = {randomNumber}");

            // one statement if 

            Console.WriteLine("---------- if statement ----------");
            if (randomNumber > 5)
                Console.WriteLine("random number is greater than 5");


            Console.WriteLine("---------- if with block statement  ----------");
            if (randomNumber > 5)
            {
                Console.WriteLine("random number is greater than 5");
            }


            Console.WriteLine("---------- if else statement ----------");
            if (randomNumber > 5)
                Console.WriteLine("random number is greater than 5");
            else
                Console.WriteLine("random number is less than 5");


            Console.WriteLine("---------- if else statement ----------");
            if (randomNumber > 5)
            {
                Console.WriteLine("random number is greater than 5");
                Console.WriteLine($"and it's value is {randomNumber}");

            }
                
            else
            {
                Console.WriteLine("random number is greater than 5");
                Console.WriteLine($"and it's value is {randomNumber}");
            }
                

        }





    }

    static class LoopsTraining
    {
        public static void TestLoops()
        {

            // ----------------------- for Loop -----------------------
            Console.WriteLine("---------------------- for Loop  ----------------------");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"i = {i}");
            }

            // ----------------------- Foreach / in -----------------------
            Console.WriteLine("---------------------- Foreach / in ----------------------");
            int[] array = { 10, 20, 30, 40, 50, 60 };

            foreach (int item in array)
            {
                Console.WriteLine("array Element:" + item);
            }

            // ----------------------- while -----------------------
            Console.WriteLine("---------------------- while ----------------------");
            int counter = 0, end = 10;

            // loop from 0 to 9
            while(counter < end)
            {
                Console.WriteLine($"Counter = {counter}");
                counter++;
            }


            // ----------------------- do while -----------------------
            Console.WriteLine("---------------------- do while ----------------------");
            counter = 0;
            end = 10;

            // loop from 0 to 9
            do
            {
                Console.WriteLine($"Counter = {counter}");
                counter++;
            } while (counter < end);



        }

    }

}






    