using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpBook.CSharpBasics
{

    // System.Enum is the class that is enums gain functionality from it.

    public static class EnumsTraining
    {
        public static void TestEnums()
        {
            #region enum instances methods

            
            EmpType emp1 = EmpType.Manager;
            // ------------------------<  obj.ToString()  >------------------------
            Console.WriteLine(emp1);
            Console.WriteLine($"emp1.ToString() = {emp1.ToString()}");

            // ------------------------<  obj.GetType()  >------------------------
            Console.WriteLine($"emp1.GetType() = {emp1.GetType()}");    //pro_csharp_book_training.EmpType

            // ------------------------<  obj.GetTypeCode()  >------------------------
            Console.WriteLine($"emp1.GetTypeCode() = {emp1.GetTypeCode()}");    //Int32

            // ------------------------<  obj.CompareTo(object target)  >------------------------
            // NOTE: target argument should be in the same type of enumeration
            Console.WriteLine($"emp1.CompareTo(EmpType.Manager) = {emp1.CompareTo(EmpType.Manager)}"); // 0
            Console.WriteLine($"emp1.CompareTo(EmpType.SalesPersom) = {emp1.CompareTo(EmpType.SalesPersom)}"); // -1
            //Error:passing string not EmptType
            //Console.WriteLine($@"emp1.CompareTo(""Manager"") = {emp1.CompareTo("Manager")}");
            //Error:passing int not EmptType
            //Console.WriteLine($"emp1.CompareTo(0) = { emp1.CompareTo(0)}");

            // ------------------------<  obj.Equals(object target)  >------------------------
            // Equals : it accepts underline storage or enum constant name,
            //          so it doesn't throw Exception in Type Mismatch
            Console.WriteLine($"emp1.Equals(EmpType.Manager) = {emp1.Equals(EmpType.Manager)}");        // True
            Console.WriteLine($"emp1.Equals(EmpType.SalesPersom) = {emp1.Equals(EmpType.SalesPersom)}"); // False
            Console.WriteLine($"emp1.Equals(1) = {emp1.Equals(1)}");    // False
            Console.WriteLine($@"emp1.Equals(""Managers"") = {emp1.Equals("Manager")}");    // False
            #endregion
            
            #region Get Type of enum
            // ------------------------<  System.Enum Class Functionality  >------------------------
            // -------------------------------------------------------------------------------------
            Console.WriteLine($"Enum.GetUnderlyingType(typeof(EmpType)) = {Enum.GetUnderlyingType(typeof(EmpType))} "); // Int32
            #endregion

            #region Array Enum.GetValues(Type enumtype);

            // ------------------------<   public static Array GetValues(Type enumType);  >------------------------
            Console.WriteLine("1- Array empItems = Enum.GetValues(typeof(EmpType))");
            Array empItems = Enum.GetValues(typeof(EmpType));
            foreach (EmpType item in empItems)
            {
                Console.WriteLine($"Name: {item} , Value: {(int)item}");
            }
            Console.WriteLine();


            // ------------------------<  public static Array GetValues(Type enumType);  >------------------------
            // The same as the last code but here we see some changes
            Console.WriteLine("2- Array empItems = Enum.GetValues(typeof(EmpType))");
            empItems = Enum.GetValues(typeof(EmpType));
            for (int i= 0; i < empItems.Length; i++)
            {
                Console.WriteLine("Name: {0} , Value: {0:D}", empItems.GetValue(i));
            }
            Console.WriteLine();

            // ------------------------<  public static Array GetValues(Type enumType);  >------------------------
            // The same as the last code but here we see some changes
            Console.WriteLine("3- Enum.GetValues(emp1.GetType())");
            foreach (EmpType item in Enum.GetValues(emp1.GetType()))
            {
                //Console.WriteLine($"Name: {item} , Value: {(int)item}");
                Console.WriteLine("Name: {0} , Value: {1}", item, (int)item);
            }
            Console.WriteLine();
            #endregion

            #region public static string[] GetNames(Type enumType)
            // ------------------------<  public static string[] GetNames(Type enumType);  >------------------------
            Console.WriteLine("Enum.GetNames()");
            foreach (string item in Enum.GetNames(typeof(EmpType)))
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();
            #endregion

            #region public static string GetName(Type enumType, object value);
            // ------------------------<  public static string GetName(Type enumType, object value);  >------------------------
            Console.WriteLine("Enum.GetName(typeof(EmpType),0) = {0}", Enum.GetName(typeof(EmpType),0));
            #endregion

            #region public static object Parse(Type enumType, string value);
            // ------------------------<  public static object Parse(Type enumType, string value);  >------------------------
            Console.WriteLine("public static object Parse(Type enumType, string value);");
            emp1 = EmpType.SalesPersom;
            Console.WriteLine(emp1.ToString());
            emp1 = (EmpType)Enum.Parse(typeof(EmpType), "Manager");
            Console.WriteLine(@"Enum.Parse(typeof(EmpType),""Manager"") = " + emp1);

            emp1 = (EmpType)Enum.Parse(typeof(EmpType), "2");
            Console.WriteLine(@"Enum.Parse(typeof(EmpType),""2"") = " + emp1);
            #endregion

            #region public static bool TryParse<TEnum>(string value, out TEnum result) where TEnum : struct;
            // -----<  public static bool TryParse<TEnum>(string value, out TEnum result) where TEnum : struct;  >------

            if (Enum.TryParse("PTSalesPerson", out EmpType emp2))
            {
                Console.WriteLine($"TryParse string (PTSalesPerson) Result:");
                WriteEnum(emp2);
            }
            else
                Console.WriteLine("Can't Parse string");

            if (Enum.TryParse("2", out emp2))
            {
                Console.WriteLine($"TryParse integer 2 Result:");
                WriteEnum(emp2);
            }
            else
                Console.WriteLine("Can't Parse integer");
            #endregion

            #region public static object ToObject(Type enumType, int value);
            // -----<  public static object ToObject(Type enumType, int value);  >------
            Console.WriteLine(new StringBuilder().Append('=',30));
            Console.WriteLine("public static object ToObject(Type enumType, int value);");
            // To convert integer any provided value type to enum
            EmpType emp3 = (EmpType)Enum.ToObject(typeof(EmpType), 2);
            WriteEnum(emp3);
            WriteEnumNameValuePair(emp3.GetType());
            #endregion

            #region public static bool IsDefined(Type enumType, object value);

            
            // -----<  public static bool IsDefined(Type enumType, object value);  >------
            Console.WriteLine();
            Console.WriteLine("public static bool IsDefined(Type enumType, object value);");
            Console.WriteLine($@"Enum.IsDefined(typeof(Day),""Sat"") = {Enum.IsDefined(typeof(Day),"Sat")}");
            Console.WriteLine($@"Enum.IsDefined(typeof(Day),""sat"") = {Enum.IsDefined(typeof(Day), "sat")}");
            Console.WriteLine($@"Enum.IsDefined(typeof(Day),""Moamen"") = {Enum.IsDefined(typeof(Day), "Moamen")}");
            Console.WriteLine();
            #endregion

            #region public static string Format(Type enumType, object value, string format);
            //-----<  public static string Format(Type enumType, object value, string format);  >------
            //  Format          Description
            //"G" or "g"        If value is equal to a named enumerated constant, 
            //                  the name of that constant is returned; otherwise, 
            //                  the decimal equivalent of value is returned.

            //                  For example, suppose the only enumerated constant is named Red, 
            //                  and its value is 1.If value is specified as 1, this format returns "Red".However,
            //                  if value is specified as 2, this format returns "2".
            ///////////////// there are another part here in Microsoft APIs about FlagsAttribute.

            // "X" or "x"       Represents value in hexadecimal format without a leading "0x".

            // "D" or "d"       Represents value in decimal form.

            // "F" or "f"       Behaves identically to "G" or "g", except that 
            //                  the FlagsAttribute is not required to be present on the Enum declaration.
            Console.WriteLine("------------------- General Format --------------------");
            Console.WriteLine($@"Enum.Format(Day, Day.Sat,""G"") = {Enum.Format(typeof(Day), Day.Sat, "G")}");
            Console.WriteLine($@"Enum.Format(Day, Day.Sun,""G"") = {Enum.Format(typeof(Day), Day.Sun, "G")}");
            Console.WriteLine($@"Enum.Format(Day, Day.Mon,""G"") = {Enum.Format(typeof(Day), Day.Mon, "G")}");

            Console.WriteLine("------------------- Decimal Format --------------------");
            Console.WriteLine($@"Enum.Format(Day, Day.Sat,""D"") = {Enum.Format(typeof(Day), Day.Sat, "D")}");
            Console.WriteLine($@"Enum.Format(Day, Day.Sun,""D"") = {Enum.Format(typeof(Day), Day.Sun, "D")}");
            Console.WriteLine($@"Enum.Format(Day, Day.Mon,""D"") = {Enum.Format(typeof(Day), Day.Mon, "D")}");

            Console.WriteLine("------------------- HexDecimal Format --------------------");
            Console.WriteLine($@"Enum.Format(Day, Day.Sat,""x"") = {Enum.Format(typeof(Day), Day.Sat, "x")}");
            Console.WriteLine($@"Enum.Format(Day, Day.Sun,""x"") = {Enum.Format(typeof(Day), Day.Sun, "x")}");
            Console.WriteLine($@"Enum.Format(Day, Day.Mon,""x"") = {Enum.Format(typeof(Day), Day.Mon, "x")}");
            #endregion

            // Test: public static void WriteEnumNameValuePair(Type enumType);
            WriteEnumNameValuePair(emp2.GetType());
            WriteEnumNameValuePair(typeof(Day));
        }


        public static void WriteEnum(Enum e)
        {
            Console.WriteLine();
            Console.WriteLine($"Write Info of Enum << {e.GetType()} >>");
            Console.WriteLine($"Enum Name-------------: {e}");
            Console.WriteLine($"Enum Value------------: {Convert.ToInt32(e)}");
            Console.WriteLine($"Enum Type-------------: {e.GetType()}");
            Console.WriteLine($"Enum Underlaying Type-: {e.GetTypeCode()}");
            Console.WriteLine();
        }

        public static void WriteEnumNameValuePair(Type enumType)
        {

            Array items = Enum.GetValues(enumType);
            Console.WriteLine();
            Console.WriteLine($"Name-Value Pair of Enum << {enumType.FullName} >>");
            foreach (var item in items)
            {
                Console.WriteLine($"Name: {item}, Value: {(int)item}");
            }
            Console.WriteLine();
        }


    }


    // enums default first constant is 0 , and the default storage is System.Int32
    public enum EmpType{
        Manager,        // = 0  UnderlayingType : Int32
        SalesPersom,    // = 1  UnderlayingType : Int32
        PTSalesPerson   // = 2  UnderlayingType : Int32
    }

    public enum EmpType2
    {
        Manager = 100,  // = 100  UnderlayingType : Int32
        SalesPersom,    // = 101  UnderlayingType : Int32
        PTSalesPerson   // = 102  UnderlayingType : Int32
    }

    public enum EmpType3
    {
        Manager = 10,       // = 10  UnderlayingType : Int32
        SalesPersom = 19,   // = 19  UnderlayingType : Int32
        PTSalesPerson = 6   // = 6  UnderlayingType : Int32
    }

    public enum EmpType4 : short
    {
        Manager,        // = 0  UnderlayingType : Int16
        SalesPersom,    // = 1  UnderlayingType : Int16
        PTSalesPerson   // = 2  UnderlayingType : Int16
    }


    enum Day { Sat, Sun, Mon, Tue, Wed, Thu, Fri };



}