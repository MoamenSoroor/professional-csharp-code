using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using static System.Environment;

namespace ProCSharpBook.CSharpDelegates
{
    // .NET delegates are classes that have built-in support for multicasting and asynchronous method
    // invocation.
    // In essence, a delegate is a type-safe object that points to another method 
    //(or possibly a list of methods) in the application, which can be invoked at a later time. 
    // Specifically, a delegate maintains three important pieces of information:
    //•	 The address of the method on which it makes calls
    //•	 The parameters (if any) of this method
    //•	 The return type (if any) of this method

    // Note .net delegates can point to either static or instance methods.

    //    After a delegate object has been created and given the necessary information, it may dynamically
    //invoke the method(s) it points to at runtime. Every delegate in the.NET Framework (including your custom
    //delegates) is automatically endowed with the ability to call its methods synchronously or asynchronously.
    //This fact greatly simplifies programming tasks, given that you can call a method on a secondary thread of
    //execution without manually creating and managing a Thread object.

    //    When the C# compiler processes delegate types, it automatically generates a sealed class deriving from
    //System.MulticastDelegate.This class (in conjunction with its base class, System.Delegate) provides the
    //necessary infrastructure for the delegate to hold onto a list of methods to be invoked at a later time. 

    public delegate int BinaryOp0(int x, int y);


    // when you create BinaryOp0 delegate the compiler-generated BinaryOp0 class defines three public methods.Invoke()
    //is perhaps the key method, as it is used to invoke each method maintained by the delegate object in a
    //synchronous manner, meaning the caller must wait for the call to complete before continuing on its way.

    //    BeginInvoke() and EndInvoke() provide the ability to call the current method asynchronously on a
    //separate thread of execution.If you have a background in multithreading, you know that one of the most
    //common reasons developers create secondary threads of execution is to invoke methods that require time to
    //complete.Although the.NET base class libraries supply several namespaces devoted to multithreaded and
    //parallel programming, delegates provide this functionality out of the box.

    //    Now, how exactly does the compiler know how to define the Invoke(), BeginInvoke(), and
    //EndInvoke() methods? To understand the process, here is the crux of the compiler-generated BinaryOp0 class
    //type (bold italic marks the items specified by the defined delegate type):
    // -------------------------------------------------------------------------------
    // sealed class BinaryOp0 : System.MulticastDelegate
    //     {
    //         public int Invoke(int x, int y);
    //         public IAsyncResult BeginInvoke(int x, int y,
    //         AsyncCallback cb, object state);
    //         public int EndInvoke(IAsyncResult result);
    //     }
    // -------------------------------------------------------------------------------

    //    First, notice that the parameters and return type defined for the Invoke() method exactly match the
    //definition of the BinaryOp0 delegate. The initial parameters to BeginInvoke() members (two integers,
    //in this case) are also based on the BinaryOp0 delegate; however, BeginInvoke() will always provide two
    //final parameters(of type AsyncCallback and object) that are used to facilitate asynchronous method
    //invocations.Finally, the return type of EndInvoke() is identical to the original delegate declaration and will
    //always take as a sole parameter an object implementing the IAsyncResult interface.

    // Another Example
    public delegate string MyDelegate(bool a, bool b, bool c);

    //    This time, the compiler-generated class breaks down as follows:
    // -------------------------------------------------------------------------------
    //sealed class MyDelegate : System.MulticastDelegate
    //    {
    //        public string Invoke(bool a, bool b, bool c);
    //        public IAsyncResult BeginInvoke(bool a, bool b, bool c,
    //        AsyncCallback cb, object state);
    //        public string EndInvoke(IAsyncResult result);
    //    }
    // -------------------------------------------------------------------------------



    //    Delegates can also “point to” methods that contain any number of out or ref parameters(as well as
    //array parameters marked with the params keyword). For example, assume the following delegate type:

    public delegate string MyOtherDelegate(out bool a, ref bool b, int c);

    //    The signatures of the Invoke() and BeginInvoke() methods look as you would expect; however, check
    //out the following EndInvoke() method, which now includes the set of all out/ref arguments defined by the
    //delegate type:
    // -------------------------------------------------------------------------------
    //public sealed class MyOtherDelegate : System.MulticastDelegate
    //    {
    //        public string Invoke(out bool a, ref bool b, int c);
    //        public IAsyncResult BeginInvoke(out bool a, ref bool b, int c,
    //        AsyncCallback cb, object state);
    //        public string EndInvoke(out bool a, ref bool b, IAsyncResult result);
    //    }
    // -------------------------------------------------------------------------------


    //    To summarize, a C# delegate type definition results in a sealed class with three compiler-generated
    //methods whose parameter and return types are based on the delegate’s declaration. The following
    //pseudocode approximates the basic pattern:

    // -------------------------------------------------------------------------------
    //// This is only pseudo-code!
    //public sealed class DelegateName : System.MulticastDelegate
    //    {
    //        public delegateReturnValue Invoke(allDelegateInputRefAndOutParams);
    //        public IAsyncResult BeginInvoke(allDelegateInputRefAndOutParams,
    //        AsyncCallback cb, object state);
    //        public delegateReturnValue EndInvoke(allDelegateRefAndOutParams,
    //        IAsyncResult result);
    //    }
    // -------------------------------------------------------------------------------

    //    The System.MulticastDelegate and System.Delegate Base Classes
    //So, when you build a type using the C# delegate keyword, you are indirectly declaring a class type that
    //derives from System.MulticastDelegate.This class provides descendants with access to a list that contains
    //the addresses of the methods maintained by the delegate object, as well as several additional methods
    //(and a few overloaded operators) to interact with the invocation list.Here are some select members of
    //System.MulticastDelegate:

    // -------------------------------------------------------------------------------
    //public abstract class MulticastDelegate : Delegate
    //    {
    //        // Returns the list of methods "pointed to."
    //        public sealed override Delegate[] GetInvocationList();
    //        // Overloaded operators.
    //        public static bool operator ==(MulticastDelegate d1, MulticastDelegate d2);
    //        public static bool operator !=(MulticastDelegate d1, MulticastDelegate d2);
    //        // Used internally to manage the list of methods maintained by the delegate.
    //        private IntPtr _invocationCount;
    //        private object _invocationList;
    //    }
    // -------------------------------------------------------------------------------

    //    System.MulticastDelegate obtains additional functionality from its parent class, System.Delegate.
    //    Here is a partial snapshot of the class definition :

    //public abstract class Delegate : ICloneable, ISerializable
    //    {
    //        // Methods to interact with the list of functions.
    //        public static Delegate Combine(params Delegate[] delegates);
    //        public static Delegate Combine(Delegate a, Delegate b);
    //        public static Delegate Remove(Delegate source, Delegate value);
    //        public static Delegate RemoveAll(Delegate source, Delegate value);
    //        // Overloaded operators.
    //        public static bool operator ==(Delegate d1, Delegate d2);
    //        public static bool operator !=(Delegate d1, Delegate d2);
    //        // Properties that expose the delegate target.
    //        public MethodInfo Method { get; }
    //        public object Target { get; }
    //    }
    // -------------------------------------------------------------------------------

    //    Now, understand that you can never directly derive from these base classes in your code(it is a
    //    compiler error to do so). Nevertheless, when you use the delegate keyword, you have indirectly created a
    //class that “is-a” MulticastDelegate.Table 10-1 documents the core members common to all delegate types.Chapter 10 ■ Delegates, events, anD lambDa expressions

    //      Table 10 - 1.Select Members of System.MulticastDelegate / System.Delegate
    // -------------------------------------------------------------------------------
    //  Member      Meaning in Life
    // ===============================================================================
    //  Method 
    // This property returns a System.Reflection.MethodInfo object that represents
    //          details of a static method maintained by the delegate.
    // -------------------------------------------------------------------------------
    // Target 
    // If the method to be called is defined at the object level(rather than a static
    //      method), Target returns an object that represents the method maintained by
    //      the delegate.If the value returned from Target equals null, the method to be
    //      called is a static member.
    // -------------------------------------------------------------------------------
    // Combine() 
    // This static method adds a method to the list maintained by the delegate.In
    //  C#, you trigger this method using the overloaded += operator as a shorthand notation.
    // -------------------------------------------------------------------------------
    // GetInvocationList() 
    // This method returns an array of System.Delegate objects, each representing a
    //            particular method that may be invoked.
    // -------------------------------------------------------------------------------
    // Remove() RemoveAll() 
    // These static methods remove a method(or all methods) from the delegate’s
    //      invocation list.In C#, the Remove() method can be called indirectly using the
    //      overloaded -= operator.
    // ===============================================================================


    #region Simple Delegate Example
    // ------------------------ Simple Delegate Example -------------------------
    public delegate int BinaryOp(int x, int y);
    class SimpleMath
    {
        public static int Add(int x, int y) => x + y;
        public static int Sub(int x, int y) => x - y;
        public static int Mul(int x, int y) => x * y;
        public static int Div(int x, int y) => x / y;
        public static int Square(int x) => x * x;

    }

    class SimpleMath2
    {
        public int Add(int x, int y) => x + y;
        public int Sub(int x, int y) => x - y;
        public int Mul(int x, int y) => x * y;
        public int Div(int x, int y) => x / y;
        public int Square(int x) => x * x;
    }
    class TestSimpleDelegate
    {
        public static void Test()
        {
            Console.WriteLine("***** Simple Delegate Example *****\n");
            // Create a BinaryOp delegate object that
            // "points to" SimpleMath.Add().
            Console.WriteLine($@"====== Delegates Points To Static Methods ====== ");
            BinaryOp delegateAdd = new BinaryOp(SimpleMath.Add);
            DisplayDelegateInfo(delegateAdd);
            BinaryOp delegateSub = new BinaryOp(SimpleMath.Sub);
            DisplayDelegateInfo(delegateSub);
            BinaryOp delegateMul = new BinaryOp(SimpleMath.Mul);
            DisplayDelegateInfo(delegateMul);
            BinaryOp delegateDiv = new BinaryOp(SimpleMath.Div);
            DisplayDelegateInfo(delegateDiv);

            // Invoke Add() method indirectly using delegate object.
            Console.WriteLine($@"delegateAdd(20,10): {delegateAdd(20, 10)}");

            // Invoke Sub() method indirectly using delegate object.
            Console.WriteLine($@"delegateSub(20,10): {delegateSub(20, 10)}");

            // Invoke Mul() method indirectly using delegate object.
            Console.WriteLine($@"delegateMul(20,10): {delegateMul(20, 10)}");

            // Invoke Div() method indirectly using delegate object.
            Console.WriteLine($@"delegateDiv(20,10): {delegateDiv(20, 10)}");

            // ------------------------------------------------------------------
            // using Invoke() Method
            // C# does not require you to explicitly call Invoke() within your codebase. Because BinaryOp can point to
            // methods that take two arguments, the following code statement is also permissible:

            // Invoke Add() method indirectly using delegate object.
            Console.WriteLine($@"delegateAdd(20,10): {delegateAdd.Invoke(20, 10)}");

            // Invoke Sub() method indirectly using delegate object.
            Console.WriteLine($@"delegateSub(20,10): {delegateSub.Invoke(20, 10)}");

            // Invoke Mul() method indirectly using delegate object.
            Console.WriteLine($@"delegateMul(20,10): {delegateMul.Invoke(20, 10)}");

            // Invoke Div() method indirectly using delegate object.
            Console.WriteLine($@"delegateDiv(20,10): {delegateDiv.Invoke(20, 10)}");
            // ------------------------------------------------------------------

            // Recall that .NET delegates are type-safe.Therefore, if you attempt to create a delegate object pointing
            // to a method that does not match the pattern, you receive a compile-time error.

            // Compiler error! Method does not match delegate pattern!
            //BinaryOp delegateSquare = new BinaryOp(SimpleMath.Square);

            // ===================================================================================================
            // Create Delegate Points to Non Static Method
            Console.WriteLine($@"====== Delegates Points To Non-Static Methods ====== ");
            SimpleMath2 simpleMath2 = new SimpleMath2();
            BinaryOp delegateAdd2 = new BinaryOp(simpleMath2.Add);
            // Invoke Add() method indirectly using delegate object.
            Console.WriteLine($@"delegateAdd2(20,10): {delegateAdd2(20, 10)}");

            DisplayDelegateInfo(delegateAdd2);
        }

        public static void DisplayDelegateInfo(Delegate delobj)
        {
            foreach (Delegate d in delobj.GetInvocationList())
            {
                Console.WriteLine($@" ----------------- Display Delegate Info ---------------------");

                // Gets the method represented by the delegate.
                // Returns:
                //     A System.Reflection.MethodInfo describing the method represented by the delegate.
                Console.WriteLine($@"d.Method: {d.Method}");

                // Gets the class instance on which the current delegate invokes the instance method.
                // Returns:
                //     The object on which the current delegate invokes the instance method, if the
                //     delegate represents an instance method; null if the delegate represents a static
                //     method.
                Console.WriteLine($@"d.Target: {d.Target}");

                Console.WriteLine("===================================================================");

            }

        }


    }
    // --------------------- End of Simple Delegate Example ---------------------
    #endregion


    public class DelegateTraining
    {
        public static void Test()
        {
            TestSimpleDelegate.Test();
        }

    }



}