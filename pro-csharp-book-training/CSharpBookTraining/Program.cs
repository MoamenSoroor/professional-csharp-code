using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpBook
{
    class Program
    {
        static void Main(string[] args)
        {
            CSharpBasics.BasicsTraining.TestBasics();
            CSharpBasics.LoopsTraining.TestLoops();
            CSharpBasics.SwitchTraining.TestSwitches();
            CSharpBasics.IfTraining.TestIfStatement();
            CSharpBasics.ArraysTraining.TestArrays();
            CSharpBasics.StringsTraining.TestStrings();
            



            CSharpValueTypes.EnumsTraining.TestEnums();
            CSharpValueTypes.StructuresTraining.TestStructures();
            CSharpValueTypes.TuplesTraining.TestTuples();
            CSharpValueTypes.NullablesTraining.TestNullables();

            ExceptionHandling.ExceptionHandlingTraining.TestExceptionHandling();


            OOPEncapsulation.OOPTraining.TestOOP();
            OOPInheritanceAndPlymorphism.OOPTraining.TestOOP();
            OOPInterfaces.OOPTraining.TestOOP();


            CSharpGenerics.GenericsTraining.Test();
            CSharpCollections.CollectionsTraining.TestCollections();



            Console.WriteLine("Press any key to continue . . .");
            Console.ReadLine();
        }

    }

}