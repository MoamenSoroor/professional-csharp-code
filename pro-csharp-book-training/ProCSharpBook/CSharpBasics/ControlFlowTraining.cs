using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProCSharpBook.OOPExamples;

namespace ProCSharpBook.CSharpBasics
{
    class ControlFlowTraining
    {
        public static void TestControlFlow()
        {
            
            //CSharpBasics.IfTraining.TestIfStatement();
            CSharpBasics.SwitchTraining.TestSwitches();
            //CSharpBasics.LoopsTraining.TestLoops();
        }

    }


    // ==============================> Operators work with Conditional Expressions <==============================

    // ----------------------- Relational and type-testing -----------------------
    // x < y        Less Than Operator <
    // x > y        Greater Than Operator >
    // x <= y       Less Than Or Equal Operator >
    // x >= y       Greater Than Or Equal Operator >
    // is           is Operator
    // as	        as Operator

    // ----------------------- Equality -----------------------
    // x == y       Equality operator ==
    // x != y       Inequality operator !=

    // ----------------------- Boolean logical AND or bitwise logical AND -----------------------
    // x & y                    

    // ----------------------- Boolean logical XOR or bitwise logical XOR -----------------------
    // x ^ y                    

    // ----------------------- Boolean logical OR or bitwise logical OR -----------------------
    // x | y                    

    // ----------------------- Conditional AND -----------------------
    // x && y                   

    // ----------------------- Conditional OR -----------------------
    // x || y 
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
    static class SwitchTraining
    {
        static SwitchTraining() { }

        public static void TestSwitches()
        {
            // constant pattern
            SwitchTraining.TestSwitch1(10);
            SwitchTraining.TestSwitch1(20);
            SwitchTraining.TestSwitch1(30);
            SwitchTraining.TestSwitch1(40);
            

            SwitchTraining.TestSwitch2(10);
            SwitchTraining.TestSwitch2(10.2341);
            SwitchTraining.TestSwitch2("Moamen");
            SwitchTraining.TestSwitch2(null);


            SwitchTraining.TestSwitch3(10);
            SwitchTraining.TestSwitch3(20);
            SwitchTraining.TestSwitch3(10.2341);
            SwitchTraining.TestSwitch3("Moamen");
            SwitchTraining.TestSwitch3(null);

            SwitchTraining.TestSwitch4(10);
            SwitchTraining.TestSwitch4(10.2341);
            SwitchTraining.TestSwitch4("Moamen");
            SwitchTraining.TestSwitch4(null);

            SwitchTraining.TestSwitch5(10);
            SwitchTraining.TestSwitch5(10.2341);
            SwitchTraining.TestSwitch5("Moamen");
            SwitchTraining.TestSwitch5(null);

            SwitchTraining.TestSwitch6(new Manager("Moamen", "Soroor", 25));
            SwitchTraining.TestSwitch6(new Manager("Mohammed", "Gamal", 58));
            SwitchTraining.TestSwitch6(new Manager("Rahma", "Soroor", 28));





        }

        // This is a standard constant pattern switch statement
        public static void TestSwitch1(int number)
        {
            Console.WriteLine("------- Test Standard Constant Pattern Switch Statement--------");
            switch (number)
            {

                case 10:
                    Console.WriteLine("integer is 10");
                    break;
                case 20:
                    Console.WriteLine("integer is 20");
                    break;
                case 30:
                    Console.WriteLine("integer is 30");
                    break;
                default:
                    Console.WriteLine("integer is not 10 or 20 or 30");
                    break;
            }
        }

        // ==============================> Using Pattern Matching in Switch Statements<==============================
        // ----------------------------------------------------------------------------------------------------------
        // Prior to C# 7, match expressions in switch statements were limited to comparing a variable to constant
        // values, sometimes referred to as the constant pattern.In C# 7, switch statements can also employ the type
        // pattern, where case statements can evaluate the type of the variable being checked and case expressions are
        // no longer limited to constant values.The rule that each case statement must be terminated with a return or
        // break still applies; however, goto statements are not supported using the type pattern.

        // With the initial release of C# 7, there was a small glitch with pattern matching when pattern matching
        // using generic types.This has been resolved with C# 7.1

        // From C#7, This is new the pattern matching switch statement
        public static void TestSwitch2(object obj)
        {
            Console.WriteLine("------- Test New Pattern Matching Switch Statement --------");
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

        // ==============================> Value Matching with Pattern Matching <==============================

        // in addition to checking the type, the value of the converted type is also checked for a match
        public static void TestSwitch3(object obj)
        {
            Console.WriteLine("------- Test Value Matching with Pattern Matching --------");
            switch (obj)
            {
                case int i when i < 10 && i > 0:
                    Console.WriteLine("integer between 0 and 10 is  {0}", i);
                    break;
                case int i:
                    Console.WriteLine("integer not between 0 and 10 is {0}", i);
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


        // the order of the case statements is now significant.
        // ------------------------------------------------------------
        // With the constant pattern, each case statement had to be unique.With the type pattern, this is no
        // longer the case. 

        public static void TestSwitch4(object obj)
        {
            switch (obj)
            {
                case int i:
                    Console.WriteLine("integer not between 0 and 10 is {0}", i);
                    break;
                // This case will never be executed, compile error will be thrown

                //case int i when i < 10 && i > 0:
                //    Console.WriteLine("integer between 0 and 10 is  {0}", i);
                //    break;
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

        // ==============================> Discards With Switch Statement <==============================
        public static void TestSwitch5(object obj)
        {
            switch (obj)
            {

                case int i when i < 10 && i > 0:
                    Console.WriteLine("integer between 0 and 10 is  {0}", i);
                    break;
                case int i:
                    Console.WriteLine("integer not between 0 and 10 is {0}", i);
                    break;
                case double d:
                    Console.WriteLine("double {0}", d);
                    break;
                case string s:
                    Console.WriteLine("String {0}", s);
                    break;
                
                // var _ matches any object with any value, so if execution of switch reach here it will be executed.
                case var _:
                    Console.WriteLine(" var discard case ");
                    break;

                default:
                    Console.WriteLine("default");
                    break;
            }
        }


        // ==============================> Switch With Custom Object<==============================
        public static void TestSwitch6(Employee emp)
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
            while (counter < end)
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






    