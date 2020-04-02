using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ProCSharpBook.CSharpBasics
{
    // Some Important Notes about  Nullable Types:
    // ----------------------------------------------------------------------------------------------------------
    // Value types can never be assigned the value of null, 

    // All Types drived from ValueType class can never be assigned to the value of null,
    //      as that is used to establish an empty object reference.
    //      and in many cases - like working with databases - we need null besides the range the type has.

    // A nullable type can represent all the values of its underlying type, plus the value null.

    // To define a nullable variable type, the question mark symbol (?) is suffixed to 
    //      the underlying data type. Do note that this syntax is legal only when applied to value types.
    //      If you attempt to create a nullable reference type (including strings), 
    //      you are issued a compile-time error. 


    // you are able to programmatically discover whether the nullable variable indeed has been 
    //      assigned a null value using the HasValue property or the != operator
    // The ? suffix notation is a shorthand for creating an 
    //  instance of the generic System.Nullable<T> structure type. 

    class NullablesTraining
    {
        public static void TestNullables()
        {

            #region Fun with Nullable Types
            // Define some local nullable variables.
            int? nullableInt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            char? nullableChar = 'a';
            int?[] arrayOfNullableInts = new int?[10];
            // Error! Strings are reference types!
            // string? s = "oops";

            // Get Nullable value
            if (nullableInt.HasValue)
                Console.WriteLine($"nullable int is {nullableInt.Value}");
            else
                Console.WriteLine($"nullable int is equal to null");

            bool? mybool = true;
            WriteNullableBoolInfo(mybool);
            mybool = false;
            WriteNullableBoolInfo(mybool);
            mybool = null;
            WriteNullableBoolInfo(mybool);


            // the ? suffix notation is a shorthand for creating an 
            //  instance of the generic System.Nullable<T> structure type. 

            // Define some local nullable types using Nullable<T>.
            Nullable<int> nullableInt1 = 10;
            Nullable<double> nullableDouble1 = 3.14;
            Nullable<bool> nullableBool1 = null;
            Nullable<char> nullableChar1 = 'a';
            Nullable<int>[] arrayOfNullableInts1 = new Nullable<int>[10];


            // some tests
            Console.WriteLine("=============== Nullable Tests ===============");
            NullableTester tester = new NullableTester();
            Console.WriteLine("test if result = 20 is " + tester.GetIntNullable1());
            Console.WriteLine("test if result = 20 is " + tester.GetIntNullable2());
            Console.WriteLine("test if result = 20 is " + tester.GetIntNullable3());

            int? np1 = 20;
            tester.PassIntNullable(np1);
            tester.PassIntNullable(10);
            tester.PassIntNullable(11);
            Console.WriteLine("=============================================");
            #endregion

            #region Simple Example used for next 2 topics
            Console.WriteLine("***** Fun with Nullable Data *****\n");
            DatabaseReader dr = new DatabaseReader();
            // Get int from "database".
            int? i = dr.GetIntFromDatabase();
            if (i.HasValue)
                Console.WriteLine("Value of 'i' is: {0}", i.Value);
            else
                Console.WriteLine("Value of 'i' is undefined.");
            // Get bool from "database".
            bool? b = dr.GetBoolFromDatabase();
            if (b != null)
                Console.WriteLine("Value of 'b' is: {0}", b.Value);
            else
                Console.WriteLine("Value of 'b' is undefined.");
            #endregion

            #region The Null Coalescing ?? Operator
            // The Null Coalescing Operator
            //---------------------------------------------------------------
            // Any variable that might have a null value (i.e., a reference-type variable
            //      or a nullable value-type variable) can make use of the C# ?? operator.

            // If the value from GetIntFromDatabase() is null,
            // assign local variable to 100.
            int myData = dr.GetIntFromDatabase() ?? 100;
            Console.WriteLine("Value of myData: {0}", myData);

            // Long-hand notation not using ?? syntax.
            int? moreData = dr.GetIntFromDatabase();
            if (!moreData.HasValue)
                moreData = 100;
            Console.WriteLine("Value of moreData: {0}", moreData);
            #endregion

            #region The Null Conditional ? Operator

            // The Null Conditional Operator
            // -----------------------------------------------------------------
            // When you are writing software, it is common to check incoming parameters, 
            //      which are values returned from type members(methods, properties, indexers), 
            //      against the value null.For example, let’s assume you have a method that takes 
            //      a string array as a single parameter. To be safe, you might want to test for null before
            //      proceeding.In that way, you will not get a runtime error if the array is empty.

            Console.WriteLine("=============== The Null Conditional Operator ===============");

            Console.WriteLine(">>>>>> Print array length with Exception handling");
            ArrayLength0(new[] { 10, 20, 30 });
            ArrayLength0(null);

            Console.WriteLine(">>>>>> Print array length with if null checking");
            ArrayLength1(new [] { 10, 20, 30 });
            ArrayLength1(null);

            // using null conditional operator ? to prevent NullReferenceException and print instead empty space:
            //      System.NullReferenceException: Object reference not set to an instance of an object.
            Console.WriteLine(">>>>>> Print array length with Null Conditional Operator");
            ArrayLength2(new[] { 10, 20, 30 });
            ArrayLength2(null);

            // using null conditional operator ? with null coalescing operator ?? 
            //      that prints instead equivalent value.
            Console.WriteLine(">>>>>> Print array length with Null Conditional Operator and Null Colascing Operator");
            ArrayLength3(new[] { 10, 20, 30 });
            ArrayLength3(null);

            Console.WriteLine("============================================================");
            #endregion

        }

        #region The ? operator test methods

        // prevening NullReferenceException with Exception handling: bad idea
        static void ArrayLength0(int[] args)
        {
            // We should check for null before accessing the array data!
            try
            {
                Console.WriteLine($"You sent me {args.Length} arguments.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void ArrayLength1(int[] args)
        {
            // We should check for null before accessing the array data!
            if (args != null)
            {
                Console.WriteLine($"You sent me {args.Length} arguments.");
            }
        }

        static void ArrayLength2(int[] args)
        {
            // We should check for null before accessing the array data!
            Console.WriteLine($"You sent me {args?.Length} arguments.");

        }

        static void ArrayLength3(int[] args)
        {
            // We should check for null before accessing the array data!
            Console.WriteLine($"You sent me {args?.Length ?? -1} arguments.");

        }

        #endregion


        public static void WriteNullableBoolInfo(bool? mybool)
        {
            Console.WriteLine();
            Console.WriteLine($"mybool = {mybool}");
            Console.WriteLine($"mybool.HasValue = {mybool.HasValue}");
            string result = mybool.HasValue ? $"{mybool.Value}" : $"null";
            Console.WriteLine($"mybool.Value = {result}");
            Console.WriteLine($"mybool.GetValueOrDefault() = {mybool.GetValueOrDefault()}");
            Console.WriteLine($"mybool.GetValueOrDefault(false) = {mybool.GetValueOrDefault(false)}");
            Console.WriteLine($"mybool.ToString() = {mybool.ToString()}");
        }

        public static void WriteNullableIntegerInfo(int? myint)
        {
            Console.WriteLine();
            Console.WriteLine($"mybool = {myint}");
            Console.WriteLine($"mybool.HasValue = {myint.HasValue}");
            // Note Here Nested String interpolation
            Console.WriteLine($"mybool.Value = {(myint.HasValue ? $"{myint.Value}" : $"null")}");
            Console.WriteLine($"mybool.GetValueOrDefault() = {myint.GetValueOrDefault()}");
            Console.WriteLine($"mybool.GetValueOrDefault(false) = {myint.GetValueOrDefault(0)}");
            Console.WriteLine($"mybool.ToString() = {myint.ToString()}");
        }


    }
    class NullableTester
    {
        private int? nullableField;
        public int? NullableAutoProp { get; set; }

        public void PassIntNullable(int? np)
        {
            // note here: np.HasValue
            if(np.HasValue)
                Console.WriteLine($"You Passed nullable int = {np}");
            else
                Console.WriteLine($"You Passed null");
        }

        public void PassDoubleNullable(int? np)
        {
            // note here: np != null
            if (np != null)
                Console.WriteLine($"You Passed nullable double = {np}");
            else
                Console.WriteLine($"You Passed null");
        }

        public int? GetIntNullable1()
        {
            int? nbi = 20;
            return nbi;
        }
        public int? GetIntNullable2()
        {
            return 20;
        }
        public int? GetIntNullable3()
        {
            return new int?(20);
        }



    }
    class DatabaseReader
    {
        // Nullable data field.
        public int? numericValue = null;
        public bool? boolValue = true;
        // Note the nullable return type.
        public int? GetIntFromDatabase()
        { return numericValue; }
        // Note the nullable return type.
        public bool? GetBoolFromDatabase()
        { return boolValue; }
    }


}