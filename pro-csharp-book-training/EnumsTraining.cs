using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_csharp_book_training
{

    // System.Enum is the class that is enums gain functionality from it.

    public static class EnumsTraining
    {
        public static void TestEnums()
        {
            EmpType emp1 = EmpType.Manager;
            Console.WriteLine(emp1);
            Console.WriteLine($"emp1.GetType() = {emp1.GetType()}");    //pro_csharp_book_training.EmpType
            Console.WriteLine($"emp1.GetTypeCode() = {emp1.GetTypeCode()}");    //Int32

            // Compare
            Console.WriteLine($"emp1.CompareTo(EmpType.Manager) = {emp1.CompareTo(EmpType.Manager)}"); // 0
            Console.WriteLine($"emp1.CompareTo(EmpType.SalesPersom) = {emp1.CompareTo(EmpType.SalesPersom)}"); // -1
            //Error:
            //Console.WriteLine($@"emp1.CompareTo(""Manager"") = {emp1.CompareTo("Manager")}");
            //Error:
            //Console.WriteLine($"emp1.CompareTo(0) = { emp1.CompareTo(0)}");

            // Equals : doesn't throw Exception in Type Mismatch
            Console.WriteLine($"emp1.Equals(EmpType.Manager) = {emp1.Equals(EmpType.Manager)}");        // True
            Console.WriteLine($"emp1.Equals(EmpType.SalesPersom) = {emp1.Equals(EmpType.SalesPersom)}"); // False
            Console.WriteLine($"emp1.Equals(1) = {emp1.Equals(1)}");    // False
            Console.WriteLine($@"emp1.Equals(""Managers"") = {emp1.Equals("Manager")}");    // False

            Console.WriteLine($"Enum.GetUnderlyingType(typeof(EmpType)) = {Enum.GetUnderlyingType(typeof(EmpType))} "); // Int32

            foreach (var item in Enum.GetValues(emp1.GetType()))
            {
                Console.WriteLine($"Name: {item} , Value: {(int)item}");
            }
            Console.WriteLine();

            Console.WriteLine("Enum.GetNames()");
            foreach (var item in Enum.GetNames(typeof(EmpType)))
            {
                Console.Write($"{item}");
            }
            Console.WriteLine();










        }
    }


    // enums default first constant is 0 , and the default storage is System.Int32
    public enum EmpType{
        Manager,
        SalesPersom,
        PTSalesPerson
    }

    public enum EmpType2
    {
        Manager = 100,
        SalesPersom,
        PTSalesPerson
    }

    public enum EmpType3
    {
        Manager = 10,
        SalesPersom = 19,
        PTSalesPerson = 6
    }

    public enum EmpType4 : short
    {
        Manager,
        SalesPersom,
        PTSalesPerson
    }


    enum Day { Sat, Sun, Mon, Tue, Wed, Thu, Fri };



}