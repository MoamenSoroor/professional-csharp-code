using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Linq;


namespace ProCSharpBook.CSharpBasics
{
    class MethodsBasics
    {
        public static void TestMethods()
        {
            TestMethodWithNoModifier();
            TestOutMethodParameterModifier();





        }


        #region Method Shape
        // The shape of method is like:
        // ------------------------------------------------------------
        // returnType MethodName(paramater list) { /* Implementation */ }

        // it can take any number of parameters and have ablock of code that make some 
        // and return with value or no value



        // a Method with No return type (void), and No parameter
        public static void Method()
        {
            /* Implementation */
        }

        // a Method with No return type (void), and with One parameter
        public static void Method1(int parameter1)
        {
            /* Implementation */
        }

        // a Method with No return type (void), and with 2 parameter
        public static void Method2(int parameter1, int parameter2)
        {
            /* Implementation */
        }


        // a Method with No return type (void), and No parameter
        public static int IntMethod()
        {
            /* Implementation */
            return 0;
        }

        // a Method with No return type (void), and with One parameter
        public static int IntMethod1(int parameter1)
        {
            /* Implementation */
            return 0;
        }

        // a Method with No return type (void), and with 2 parameter
        public static int IntMethod2(int parameter1, int parameter2)
        {
            /* Implementation */
            return 0;
        }


        #endregion


        #region syntactic sugar
        // ----------------------- syntactic sugar ---------------------------
        // syntactic sugar, meaning that the generated IL is no different.
        // It’s just another way to write the method. Some find it easier to read, 
        // and others don’t, so the choice is yours (or your team’s) 
        // which style you prefer.

        // Return Values and Expression Bodied Members (Syntactic Sugar)
        // -------------------------------------------------------------------
        // C# 6 introduced expression-bodied members that shorten the syntax for single-line methods.
        // C# 7 expanded this capability to include single-line constructors, finalizers, and get and set accessors
        // on properties and indexers.



        // normal shape
        public static int AddInts(int x, int y)
        {

            return x + y;
        }

        // Syntactic Sugar generate the same IL Instructions of the brevious method
        public static int AddInts2(int x, int y) => x + y;
        #endregion



        #region Method Parameter Modifiers - out - ref - params
        // The default manner in which a parameter is sent into a function is by value.Simply put, if you do not mark
        // an argument with a parameter modifier, a copy of the data is passed into the function. As explained later in
        // this chapter, exactly what is copied will depend on whether the parameter is a value type or a reference type


        // Table C# Parameter Modifiers
        // --------------------------------------------------------------------------------------------
        // Parameter Modifier       Meaning in Life
        // --------------------------------------------------------------------------------------------
        // (None) 
        // ------------------
        // If a parameter is not marked with a parameter modifier, it is assumed to be
        // passed by value, meaning the called method receives a copy of the original data.
        // out Output parameters must be assigned by the method being called and, therefore,
        // are passed by reference. If the called method fails to assign output parameters,
        // you are issued a compiler error.
        // --------------------------------------------------------------------------------------------
        // ref 
        // ------------------
        // The value is initially assigned by the caller and may be optionally modified by
        // the called method (as the data is also passed by reference). No compiler error is
        // generated if the called method fails to assign a ref parameter.
        // --------------------------------------------------------------------------------------------
        // out 
        // ------------------
        // The value may optionally assigned by the caller and, it must be assigned by
        // the called method (as the data is also passed by reference). compiler error is
        // generated if the called method fails to assign an out parameter
        // --------------------------------------------------------------------------------------------
        // params 
        // ------------------
        // This parameter modifier allows you to send in a variable number of arguments
        // as a single logical parameter.A method can have only a single params modifier,
        // and it must be the final parameter of the method. In reality, you might not need
        // to use the params modifier all too often; however, be aware that numerous
        // methods within the base class libraries do make use of this C# language feature



        #region None Modifiers

        // - You must initialize argument that will be passed by value (parameter with no value)
        //  - any changes to no modifier argument will not affect the outer state of it.


        // with value Types
        public static int AddMethodWithNoModifier(int x, int y)
        {
            // Caller will not see these changes
            // as you are modifying a copy of the
            // original data.

            x = 100;
            y = 200;
            Console.WriteLine($"Inside Method with None Modifier: x = {x}, y = {y}");
            return x + y;
        }

        // with reference Types
        public static string ConcatMethodWithNoModifier(string x, string y)
        {
            // Caller will not see these changes
            // as you are modifying a copy of the
            // original data.

            x = "Moamen";
            y = "Soroor";
            Console.WriteLine($"Inside Method with None Modifier: x = {x}, y = {y}");
            return x + y;
        }

        // with reference Types
        public static object MethodWithNoModifier(object obj1)
        {
            // Caller will not see these changes
            // as you are modifying a copy of the
            // original data.

            obj1 = " we change to text";
            Console.WriteLine($"Inside Method with None Modifier: object = {obj1.ToString()}");
            return obj1;
        }


        public static void TestMethodWithNoModifier()
        {
            Console.WriteLine(" ---- Test Method With No Modifier with ValueType ---- ");
            int x = 50, y = 60;
            Console.WriteLine($"Before Method with None Modifier: x = {x}, y = {y}");
            Console.WriteLine($"Return Value: {AddMethodWithNoModifier(x, y)}");
            Console.WriteLine($"After Method with None Modifier: x = {x}, y = {y}");
            Console.WriteLine("=======================================================");

            Console.WriteLine(" ---- Test Method With No Modifier with Reference Type ---- ");
            string x2 = "Mohammed", y2 = "Gamal";
            Console.WriteLine($"Before Method with None Modifier: x = {x2}, y = {y2}");
            Console.WriteLine($"Return Value: {ConcatMethodWithNoModifier(x2, y2)}");
            Console.WriteLine($"After Method with None Modifier: x = {x2}, y = {y2}");
            Console.WriteLine("=======================================================");

            Console.WriteLine(" ---- Test Method With No Modifier with Reference Type : object example ---- ");
            object obj1 = new[] { 10, 20, 30, 40 };
            Console.WriteLine($"Before Method with None Modifier: object type = {obj1.ToString()}");
            Console.WriteLine($"Return Value: {MethodWithNoModifier(obj1)}");
            Console.WriteLine($"After Method with None Modifier: object type = {obj1.ToString()}");
            Console.WriteLine("=======================================================");

        }


        #endregion

        #region out Modifiers

        // out 
        // ------------------
        // The value may optionally assigned by the caller and, it must be assigned by
        // the called method (as the data is also passed by reference). compiler error is
        // generated if the called method fails to assign an out parameter

        // with value Types
        public static int AddMethodWithOutModifier(out int x, out int y)
        {
            x = 100;
            y = 200;
            Console.WriteLine($"Inside Method with Out Modifier: x = {x}, y = {y}");
            return x + y;
        }

        // with reference Types
        public static string ConcatMethodWithOutModifier(out string x, out string y)
        {
            x = "Moamen";
            y = "Soroor";
            Console.WriteLine($"Inside Method with Out Modifier: x = {x}, y = {y}");
            return x + y;
        }

        // with reference Types
        public static object MethodWithOutModifier(out object obj1)
        {
            // Caller will not see these changes
            // as you are modifying a copy of the
            // original data.

            obj1 = " we change to string";
            Console.WriteLine($"Inside Method with Out Modifier: object = {obj1.ToString()}");
            return obj1;
        }




        public static void TestOutMethodParameterModifier()
        {
            Console.WriteLine(" ---- Test Method With Out Modifier with ValueType ---- ");
            int x = 50, y = 60;
            Console.WriteLine($"Before Method with Out Modifier: x = {x}, y = {y}");
            Console.WriteLine($"Return Value: {AddMethodWithOutModifier(out x, out y)}");
            Console.WriteLine($"After Method with Out Modifier: x = {x}, y = {y}");
            Console.WriteLine("=======================================================");

            Console.WriteLine(" ---- Test Method With Out Modifier with Reference Type ---- ");
            string x2 = "Mohammed", y2 = "Gamal";
            Console.WriteLine($"Before Method with Out Modifier: x = {x2}, y = {y2}");
            Console.WriteLine($"Return Value: {ConcatMethodWithOutModifier(out x2, out y2)}");
            Console.WriteLine($"After Method with Out Modifier: x = {x2}, y = {y2}");
            Console.WriteLine("=======================================================");


            Console.WriteLine(" ---- Test Method With Out Modifier with Reference Type : object example ---- ");
            object obj1 = new[] { 10, 20, 30, 40 };
            Console.WriteLine($"Before Method with Out Modifier: object type = {obj1.ToString()}");
            Console.WriteLine($"Return Value: {MethodWithOutModifier(out obj1)}");
            Console.WriteLine($"After Method with Out Modifier: object type = {obj1.ToString()}");
            Console.WriteLine("=======================================================");


            Console.WriteLine(" ---- Test Method With Out Modifier with Uninitialized Reference Type : object example ---- ");
            object obj2;
            Console.WriteLine($"Before Method with Out Modifier: object type = NULL");
            Console.WriteLine($"Return Value: {MethodWithOutModifier(out obj2)}");
            Console.WriteLine($"After Method with Out Modifier: object type = {obj2.ToString()}");
            Console.WriteLine("=======================================================");


        }



        #endregion


        #region ref Modifiers



        #endregion

        #region params Modifiers



        #endregion



        #endregion


        #region Discards with out Method Parameter

        // Discards 
        // ------------------------------------------------------------
        // are temporary, dummy variables that are intentionally unused.They are unassigned, don’t have
        // a value, and might not even allocate any memory.This can provide a performance benefit but, at the least,
        // can make your code more readable. Discards can be used with out parameters, with tuples, with pattern
        // matching), or even as stand-alone variables.


        #endregion

    }

}