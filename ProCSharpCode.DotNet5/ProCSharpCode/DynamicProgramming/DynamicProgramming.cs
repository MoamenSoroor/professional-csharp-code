using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
// Create an alias to the Excel object model.
using Excel = Microsoft.Office.Interop.Excel;


#region Important Keys
// Interop Assemplies
// COM: Component Object Model
// RCW: Runtime Callable Wrapper proxy
// PIA: Primary Interop Assemblies

#endregion

namespace ProCSharpCode.DynamicProgramming
{
    class DynamicProgramming
    {

    }

    #region  NET 4.0 introduced dynamic keyword, Dynamic Language Runtime(DLR)
    // ------------------------ Introduction to Dynamic Programming -------------------------
    // NET 4.0 introduced a new keyword to the C# language, specifically, dynamic. This keyword allows you to
    // incorporate scripting-like behaviors into the strongly typed world of type safety, semicolons, and curly
    // brackets.Using this loose typing, you can greatly simplify some complex coding tasks and also gain the
    // ability to interoperate with a number of dynamic languages which are.NET savvy.
    // In this chapter, you will be introduced to the C# dynamic keyword and understand how loosely typed
    // calls are mapped to the correct in-memory object using ((((( the Dynamic Language Runtime(DLR) ))))). 
    // After you understand the services provided by the DLR, you will see examples of using dynamic 
    // types to streamline how you can perform late-bound method calls(via reflection services) and to 
    // easily communicate with legacy COM libraries.
    // -------------------------------------------------------------------------
    #endregion


    #region implicity typing - var keyword
    // ------------------------ implicity typing - var keyword -------------------------
    // var keyword, which allows you to define local variables in such a way
    // that the underlying date type is determined at compile time, based on the initial assignment(recall that this
    // is termed implicit typing). Once this initial assignment has been made, you have a strongly typed variable,
    // and any attempt to assign an incompatible value will result in a compiler error.


    // Using implicit typing simply for the sake of doing so is considered by some to be bad style (if you know
    // you need a List<int>, just declare a List<int>). However, as you saw in Chapter 12, implicit typing is useful
    // with LINQ, as many LINQ queries return enumerations of anonymous classes (via projections) that you
    // cannot directly declare in your C# code. However, even in such cases, the implicitly typed variable is, in fact,
    // strongly typed.

    public class ImplicityTyping
    {
        // Test Method
        public static void Test()
        {
            // a is of type List<int>.
            var a = new List<int> { 90 };

            // This would be a compile-time error! : 
            //      Cannot implicitly convert type 'string' to 'System.Collections.Generic.List<int>' 

            try
            {
                //a = "Hello";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }

    // --------------------------------------------------------------
    #endregion


    #region Object Reference Variable
    // ------------------------ Object Reference Variable -------------------------
    //    System.Object is the topmost parent class in the.NET
    //Framework and can represent anything at all.Again, if you declare a variable of type object, you have a
    //strongly typed piece of data; however, what it points to in memory can differ based on your assignment of
    //the reference.To gain access to the members the object reference is pointing to in memory, you need to
    //perform an explicit cast.
    public class ObjectReferenceVariable
    {
        // Test Method
        public static void Test()
        {
            // Assume we have a class named Person.
            object o = new Person() { FirstName = "Mike", LastName = "Larson" };


            // Must cast object as Person to gain access
            // to the Person properties.
            Console.WriteLine("Person's first name is {0}", ((Person)o).FirstName);

            // assign object ref with another type (polymorphism)
            o = "Moamen Soroor";


            // but all of that is done at compile-time

        }


    }

    class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person() { }

    }


    // --------------------------------------------------------------
    #endregion


    #region The Role of the C# dynamic Keyword
    // ------------------------ The Role of the C# dynamic Keyword -------------------------
    // 
    // What makes a dynamic variable much(much) different from a variable declared implicitly or via a
    // System.Object reference is that it is not strongly typed.Said another way, dynamic data is not statically
    // typed.As far as the C# compiler is concerned, a data point declared with the dynamic keyword can be
    // assigned any initial value at all and can be reassigned to any new (and possibly unrelated) 
    // value during its lifetime.

    public class CSharpDynamicKeyword
    {



        // Test Method
        public static void Test()
        {
            PrintThreeStrings();
            ChangeDynamicDataType();
        }

        static void PrintThreeStrings()
        {
            var s1 = "Greetings";
            object s2 = "From";
            dynamic s3 = "Minneapolis";
            Console.WriteLine("s1 is of type: {0}", s1.GetType());
            Console.WriteLine("s2 is of type: {0}", s2.GetType());
            Console.WriteLine("s3 is of type: {0}", s3.GetType());
        }

        static void ChangeDynamicDataType()
        {
            // Declare a single dynamic data point
            // named "t".
            dynamic t = "Hello!";
            Console.WriteLine("t is of type: {0}", t.GetType());
            t = false;
            Console.WriteLine("t is of type: {0}", t.GetType());
            t = new List<int>();
            Console.WriteLine("t is of type: {0}", t.GetType());
        }

    }

    // --------------------------------------------------------------
    #endregion


    #region Calling Members on Dynamically Declared Data
    // ------------------------ Calling Members on Dynamically Declared Data -------------------------
    // the validity of the members you specify will not be checked by the compiler! Remember, 
    // unlike a variable defined as a System.Object, dynamic data is not statically typed.It is not until
    // runtime that you will know whether the dynamic data you invoked supports a specified
    // member, whether you passed in the correct parameters, whether you spelled the member correctly

    // Another obvious distinction between calling members on dynamic data and strongly typed data is that
    // when you apply the dot operator to a piece of dynamic data, you will not see the expected Visual Studio
    // IntelliSense.
    public class InvokeMembersOnDynamicData
    {
        // Test Method
        public static void Test()
        {
            dynamic textData1 = "Hello";
            Console.WriteLine(textData1.ToUpper());
            // You would expect compiler errors here!
            // But they compile just fine.
            //Console.WriteLine(textData1.toupper());
            //Console.WriteLine(textData1.Foo(10, "ee", DateTime.Now));

            // if you invoke this method from within Main(), you will get runtime errors similar to the 
            // following output:
            // Unhandled Exception: Microsoft.CSharp.RuntimeBinder.RuntimeBinderException:
            // 'string' does not contain a definition for 'toupper'

        }


    }

    // --------------------------------------------------------------
    #endregion

    #region The Role of the Microsoft.CSharp.dll Assembly, and Microsoft.CSharp.RuntimeBinder.RuntimeBinderException class
    // ------------------------ The Role of the Microsoft.CSharp.dll Assembly -------------------------
    // When you create a new Visual Studio C# project, you will automatically have a reference set to an assembly
    // named Microsoft.CSharp.dll(you can see this for yourself by looking in the References folder of
    // the Solution Explorer). This library is small and defines only a single namespace (Microsoft.CSharp.
    // RuntimeBinder) with two classes.

    // Microsoft.CSharp.RuntimeBinder.RuntimeBinderException: 
    // ------------------------------------------------------
    // As you can tell by their names, both of these classes are strongly typed exceptions.The most common
    // class, RuntimeBinderException, represents an error that will be thrown if you attempt to invoke a member
    // on a dynamic data type, which does not actually exist(as in the case of the toupper() and Foo() methods).
    // This same error will be raised if you specify the wrong parameter data to a member that does exist.

    // Because dynamic data is so volatile, whenever you are invoking members on a variable declared with
    // the C# dynamic keyword, you could wrap the calls within a proper try/catch block and handle the error in a
    // graceful manner

    class MicrosoftCSharpAssembly
    {
        public static void Test()
        {
            dynamic textData1 = "Hello";
            try
            {
                Console.WriteLine(textData1.ToUpper());
                Console.WriteLine(textData1.toupper()); // toupper() is wrong
                Console.WriteLine(textData1.Foo(10, "ee", DateTime.Now));
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Output:
            // HELLO
            // 'string' does not contain a definition for 'toupper'
        }

    }

    // Of course, the process of wrapping all dynamic method invocations in a try/catch block is rather
    // tedious.As long as you watch your spelling and parameter passing, this is not required. However, catching
    // exceptions is handy when you might not know in advance if a member will be present on the target type.

    // --------------------------------------------------------------
    #endregion


    #region The Scope of the dynamic Keyword
    // ------------------------ The Scope of the dynamic Keyword -------------------------

    // Recall that implicitly typed data(declared with the var keyword) is possible only for local variables in a
    // member scope.The var keyword can never be used as a return value, a parameter, or a member of a class/
    // structure.This is not the case with the dynamic keyword, however. Consider the following class definition :
    public class VeryDynamicClass
    {
        // A dynamic field.
        private static dynamic myDynamicField;
        // A dynamic property.
        public dynamic DynamicProperty { get; set; }
        // A dynamic return type and a dynamic parameter type.
        public dynamic DynamicMethod(dynamic dynamicParam)
        {
            // A dynamic local variable.
            dynamic dynamicLocalVar = "Local variable";
            int myInt = 10;
            if (dynamicParam is int)
            {
                return dynamicLocalVar;
            }
            else
            {
                return myInt;
            }
        }
    }

    // --------------------------------------------------------------
    #endregion


    #region Limitations of the dynamic Keyword: extension methods, anynomous methods, lambdas, and LINQ
    // ------------------------ Limitations of the dynamic Keyword -------------------------
    // do know that a dynamic data item cannot make use of lambda
    // expressions or C# anonymous methods when calling a method. 
    // you will need to work with the underlying delegate directly

    // dynamic a = GetDynamicObject();
    // // Error! Methods on dynamic data can't use lambdas!
    // a.Method(arg => Console.WriteLine(arg));

    // Another limitation is that a dynamic point of data cannot understand
    // any extension methods.  Unfortunately, this would also include any of the extension
    // methods that come from the LINQ APIs.

    // dynamic a = GetDynamicObject();
    // // Error! Dynamic data can't find the Select() extension method!
    // var data = from d in a select d;

    // --------------------------------------------------------------
    #endregion

    #region The Role of the Dynamic Language Runtime
    // ------------------------ The Role of the Dynamic Language Runtime -------------------------
    //Now that you better understand what “dynamic data” is all about, let’s learn how it is processed.Since the
    //release of.NET 4.0, the Common Language Runtime (CLR) was supplemented with a complementary
    //runtime environment named the Dynamic Language Runtime.
    // 
    //The concept of a “dynamic runtime” is
    //certainly not new. In fact, many programming languages such as JavaScript, LISP, Ruby, and Python have
    //used it for years.In a nutshell, a dynamic runtime allows a dynamic language the ability to discover types
    //completely at runtime with no compile-time checks.

    // If you have a background in strongly typed languages (including C#, without dynamic types), the notion
    // of such a runtime might seem undesirable.After all, you typically want to receive compile-time errors, not
    // runtime errors, wherever possible.

    // Nevertheless, dynamic languages/runtimes do provide some interesting
    //features, including the following:
    // 
    //      • An extremely flexible codebase.You can refactor code without making numerous
    //           changes to data types.
    //        
    //      • A simple way to interoperate with diverse object types built in different platforms
    //           and programming languages.
    //        
    //      • A way to add or remove members to a type, in memory, at runtime.

    // One role of the DLR is to enable various dynamic languages to run with the .NET runtime and give
    // them a way to interoperate with other.NET code.These languages live in a dynamic universe, where type
    // is discovered solely at runtime. And yet, these languages have access to the richness of the.NET base class
    // libraries. Even better, their codebases can interoperate with C# (or vice versa), thanks to the inclusion of the
    // dynamic keyword.
    // -------------------------------------------------------------------------
    #endregion

    #region The Role of Expression Trees
    // ------------------------ The Role of Expression Trees -------------------------

    // -------------------------------------------------------------------------
    #endregion

    #region The Role of the System.Dynamic Namespace
    // ------------------------ The Role of the System.Dynamic Namespace -------------------------

    // -------------------------------------------------------------------------
    #endregion

    #region Dynamic Runtime Lookup of Expression Trees
    // ------------------------ Dynamic Runtime Lookup of Expression Trees -------------------------

    // -------------------------------------------------------------------------
    #endregion




    #region Simplifying Late-Bound Calls Using Dynamic Types
    // ------------------------ Simplifying Late-Bound Calls Using Dynamic Types -------------------------
    // If you are building an application that makes heavy use of dynamic loading/late binding,
    // I am sure you can see how these code savings would add up over time.
    public class SimplifyingLateBoundCallsUsingDynamicTypes
    {
        // Test Method
        public static void Test()
        {
            CreateUsingLateBinding();
            InvokeMethodWithDynamicKeyword();
            AddWithReflection();
            AddWithDynamic();

        }

        private static void CreateUsingLateBinding()
        {
            try
            {
                Assembly asm = Assembly.Load("CarLibrary");
                // Get metadata for the Minivan type.
                Type miniVan = asm.GetType("CarLibrary.MiniVan");
                // Create the Minivan on the fly.
                object obj = Activator.CreateInstance(miniVan);
                // Get info for TurboBoost.
                MethodInfo mi = miniVan.GetMethod("TurboBoost");
                // Invoke method ("null" for no parameters).
                mi.Invoke(obj, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void InvokeMethodWithDynamicKeyword()
        {
            try
            {
                Assembly asm = Assembly.Load("CarLibrary");
                // Get metadata for the Minivan type.
                Type miniVan = asm.GetType("CarLibrary.MiniVan");
                // Create the Minivan on the fly and call method!
                dynamic obj = Activator.CreateInstance(miniVan);
                obj.TurboBoost();

                // By declaring the obj variable using the dynamic keyword, the heavy lifting of reflection is done on your
                // behalf, courtesy of the DRL.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void AddWithReflection()
        {
            Assembly asm = Assembly.Load("MathLibrary");
            try
            {
                // Get metadata for the SimpleMath type.
                Type math = asm.GetType("MathLibrary.SimpleMath");
                // Create a SimpleMath on the fly.
                object obj = Activator.CreateInstance(math);
                // Get info for Add.
                MethodInfo mi = math.GetMethod("Add");
                // Invoke method (with parameters).
                object[] args = { 10, 70 };
                Console.WriteLine("Result is: {0}", mi.Invoke(obj, args));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void AddWithDynamic()
        {
            Assembly asm = Assembly.Load("MathLibrary");
            try
            {
                // Get metadata for the SimpleMath type.
                Type math = asm.GetType("MathLibrary.SimpleMath");
                // Create a SimpleMath on the fly.
                dynamic obj = Activator.CreateInstance(math);
                // Note how easily we can now call Add().
                Console.WriteLine("Result is: {0}", obj.Add(10, 70));
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

    // --------------------------------------------------------------
    #endregion



    #region COM Interop Using C# Dynamic Data
    // ------------------------ COM Interop Using C# Dynamic Data -------------------------

    public class COMInteropUsingDynamic
    {
        // Test Method
        public static void Test()
        {

            List<Car> carsInStock = new List<Car>
            {
                new Car {Color="Green", Make="VW", PetName="Mary"},
                new Car {Color="Red", Make="Saab", PetName="Mel"},
                new Car {Color="Black", Make="Ford", PetName="Hank"},
                new Car {Color="Yellow", Make="BMW", PetName="Davie"}
            };

            ExportToExcel(carsInStock);

        }

        static void ExportToExcel(List<Car> carsInStock)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();

            // Go ahead and make Excel visible on the computer.
            excelApp.Visible = true;

            Excel._Worksheet worksheet = excelApp.ActiveSheet;

            worksheet.Cells[1, "A"] = "Make";
            worksheet.Cells[1, "B"] = "Color";
            worksheet.Cells[1, "C"] = "Pet Name";

            // Now, map all data in List<Car> to the cells of the spreadsheet.
            int row = 1;
            foreach (Car c in carsInStock)
            {
                row++;
                worksheet.Cells[row, "A"] = c.Make;
                worksheet.Cells[row, "B"] = c.Color;
                worksheet.Cells[row, "C"] = c.PetName;
            }

            // Give our table data a nice look and feel.
            worksheet.Range["A1"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);

            // Save the file, quit Excel, and display message to user.
            worksheet.SaveAs($@"{Environment.CurrentDirectory}\Inventory.xlsx");
            excelApp.Quit();
            Console.WriteLine("The Inventory.xslx file has been saved to your app folder");

        }


        // if you doesn't make Embedded Interop Types
        static void ExportToExcelManual(List<Car> carsInStock)
        {
            Excel.Application excelApp = new Excel.Application();
            // Must mark missing params!
            excelApp.Workbooks.Add(Type.Missing);
            // Must cast Object as _Worksheet!
            Excel._Worksheet workSheet = (Excel._Worksheet)excelApp.ActiveSheet;
            // Must cast each Object as Range object then call low-level Value2 property!
            ((Excel.Range)excelApp.Cells[1, "A"]).Value2 = "Make";
            ((Excel.Range)excelApp.Cells[1, "B"]).Value2 = "Color";
            ((Excel.Range)excelApp.Cells[1, "C"]).Value2 = "Pet Name";
            int row = 1;
            foreach (Car c in carsInStock)
            {
                row++;
                // Must cast each Object as Range and call low-level Value2 prop!
                ((Excel.Range)workSheet.Cells[row, "A"]).Value2 = c.Make;
                ((Excel.Range)workSheet.Cells[row, "B"]).Value2 = c.Color;
                ((Excel.Range)workSheet.Cells[row, "C"]).Value2 = c.PetName;
            }
            // Must call get_Range method and then specify all missing args!
            excelApp.get_Range("A1", Type.Missing).AutoFormat(
            Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2,
            Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing);
            // Must specify all missing optional args!
            workSheet.SaveAs($@"{Environment.CurrentDirectory}\InventoryManual.xlsx",
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            Console.WriteLine("The InventoryManual.xslx file has been saved to your app folder");
        }
    }

    public class Car
    {
        public string Make { get; set; }
        public string Color { get; set; }
        public string PetName { get; set; }
    }



    // --------------------------------------------------------------
    #endregion



}
