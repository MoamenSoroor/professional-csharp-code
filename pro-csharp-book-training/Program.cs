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

            //SwitchTraining.TestSwitch(10);
            //SwitchTraining.TestSwitch(10.2341);
            //SwitchTraining.TestSwitch("Moamen");
            //SwitchTraining.TestSwitch(null);

            //ArraysTraining.TestArrays();
            //StringsTraining.TestStrings();
            //EnumsTraining.TestEnums();
            //StructuresTraining.TestStructures();
            NullablesTraining.TestNullables();
            //TuplesTraining.TestTuples();



            Console.WriteLine("Press Any Key to Continue!");
            Console.ReadLine();
        }


        static class SwitchTraining
        {
            static SwitchTraining() { }

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







    }









}
