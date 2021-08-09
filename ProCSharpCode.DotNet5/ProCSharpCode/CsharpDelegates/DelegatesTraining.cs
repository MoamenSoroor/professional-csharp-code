using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using static System.Environment;

namespace ProCSharpCode.CSharpDelegates
{
    #region Introduction to .Net Delegates

    // .NET delegates are classes that have built-in support for multicasting and asynchronous method
    // invocation.
    // In essence, a delegate is a type-safe object that points to another method 
    // (or possibly a list of methods) in the application, which can be invoked at a later time. 
    // Specifically, a delegate maintains three important pieces of information:
    // •  The address of the method on which it makes calls
    // •  The parameters (if any) of this method
    // •  The return type (if any) of this method

    // Note .net delegates can point to either static or instance methods.

    // After a delegate object has been created and given the necessary information, it may dynamically
    // invoke the method(s) it points to at runtime. Every delegate in the.NET Framework (including your custom
    // delegates) is automatically endowed with the ability to call its methods synchronously or asynchronously.
    // This fact greatly simplifies programming tasks, given that you can call a method on a secondary thread of
    // execution without manually creating and managing a Thread object. 
    #endregion

    #region The C# delegate keyword represents a sealed class deriving from System.MulticastDelegate

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
    //         public IAsyncResult BeginInvoke(int x, int y,AsyncCallback cb, object state);
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
    #endregion

    #region The System.MulticastDelegate and System.Delegate Base Classes

    // ------------------------ The System.MulticastDelegate and System.Delegate Base Classes -------------------------

    // So, when you build a type using the C# delegate keyword, you are indirectly declaring a class type that
    // derives from System.MulticastDelegate.This class provides descendants with access to a list that contains
    // the addresses of the methods maintained by the delegate object, as well as several additional methods
    // (and a few overloaded operators) to interact with the invocation list.Here are some select members of
    // System.MulticastDelegate:

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
    // --------------------- End of The System.MulticastDelegate and System.Delegate Base Classes ---------------------
    #endregion

    #region Simple Delegate Example - Outer Delegation
    // ------------------------ Simple Delegate Example -------------------------
    public delegate int BinaryOp(int x, int y);



    // Static Implementation of SimpleMath class Methods
    class SimpleMath
    {
        public static int Add(int x, int y) => x + y;
        public static int Sub(int x, int y) => x - y;
        public static int Mul(int x, int y) => x * y;
        public static int Div(int x, int y) => x / y;
        public static int Square(int x) => x * x;

    }

    // Instance Implementation of SimpleMath class Methods
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
            // C# does not require you to explicitly call Invoke() within your codebase. 
            // Because BinaryOp can point to methods that take two arguments,
            // the following code statement is also permissible:

            // Invoke Add() method indirectly using delegate object.
            Console.WriteLine($@"delegateAdd(20,10): {delegateAdd.Invoke(20, 10)}");

            // Invoke Sub() method indirectly using delegate object.
            Console.WriteLine($@"delegateSub(20,10): {delegateSub.Invoke(20, 10)}");

            // Invoke Mul() method indirectly using delegate object.
            Console.WriteLine($@"delegateMul(20,10): {delegateMul.Invoke(20, 10)}");

            // Invoke Div() method indirectly using delegate object.
            Console.WriteLine($@"delegateDiv(20,10): {delegateDiv.Invoke(20, 10)}");
            // ------------------------------------------------------------------

            // Recall that .NET delegates are type-safe.Therefore, if you attempt to create a delegate object 
            // pointing to a method that does not match the pattern, you receive a compile-time error.

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

    #region Callback by Interface - Simple Example
    // ------------------------ Callback by Interface - Simple Example -------------------------
    public interface IBinaryOperation
    {
        int BinaryOp(int x, int y);

    }

    class SimpleMath3
    {
        public int Add(int x, int y) => x + y;
        public int Sub(int x, int y) => x - y;
        public int Mul(int x, int y) => x * y;
        public int Div(int x, int y) => x / y;
        public int Square(int x) => x * x;

    }

    class InterfaceCallbacks
    {
        public static void Test()
        {
            SimpleMath3 math = new SimpleMath3();
            AddCallback obj = new AddCallback(math);

            Console.WriteLine($@"obj.BinaryOp(10, 20): {obj.BinaryOp(10, 20)}");
        }

        class AddCallback : IBinaryOperation
        {
            private SimpleMath3 simpleMath;
            public AddCallback(SimpleMath3 simpleMath)
            {
                this.simpleMath = simpleMath;
            }
            public int BinaryOp(int x, int y) => this.simpleMath.Add(x, y);
        }

    }

    // --------------------- Callback by Interface - Simple Example ---------------------
    #endregion

    #region Callback by Interface - More Complex Example
    // ------------------------ Interface Callback -------------------------

    public interface IOperationHandler
    {
        void Handle(string msg, int result);
    }

    class SimpleOperation
    {

        private IOperationHandler add;
        private IOperationHandler sub;

        public void RegisterAddHandler(IOperationHandler add)
        {
            this.add = add;
        }

        public void RegisterSubHandler(IOperationHandler sub)
        {
            this.sub = sub;
        }


        public int Add(int x, int y)
        {
            int result = x + y;
            add?.Handle("Message From Add Method", result);
            return result;
        }
        public int Sub(int x, int y)
        {
            int result = x + y;
            sub?.Handle("Message From Sub Method", result);
            return result;
        }
        public int Mul(int x, int y)
        {
            int result = x + y;
            return result;
        }
        public int Div(int x, int y)
        {
            int result = x + y;
            return result;
        }
        public int Square(int x) => x * x;

    }

    class InterfaceCallbacks2
    {
        public static void Test()
        {
            SimpleOperation math = new SimpleOperation();

            Console.WriteLine($@"math.Add(10, 20): {math.Add(10, 20)}");
            Console.WriteLine($@"math.Sub(10, 20): {math.Sub(10, 20)}");



            AddHandler addHandler = new AddHandler();
            SubHandler subHandler = new SubHandler();

            math.RegisterAddHandler(addHandler);
            math.RegisterSubHandler(subHandler);

            Console.WriteLine($@"math.Add(10, 20): {math.Add(10, 20)}");
            Console.WriteLine($@"math.Sub(10, 20): {math.Sub(10, 20)}");

        }

        class AddHandler : IOperationHandler
        {
            public void Handle(string msg, int result)
            {
                Console.WriteLine();
                Console.WriteLine("Handling Add Operation Event:-");
                Console.WriteLine($@"{msg}: {result}");
                Console.WriteLine("".PadLeft(40, '-'));
            }
        }

        class SubHandler : IOperationHandler
        {
            public void Handle(string msg, int result)
            {
                Console.WriteLine();
                Console.WriteLine("Handling Sub Operation Event:-");
                Console.WriteLine($@"{msg}: {result}");
                Console.WriteLine("".PadLeft(40, '-'));
            }
        }

    }

    // --------------------- End of Callback by Interface - More Complex Example ---------------------
    #endregion

    #region Sending Object State Notifications Using Delegates
    // ------------------------ Sending Object State Notifications Using Delegates -------------------------
    class Car
    {


        public Car()
        {

        }

        public Car(string petName, int maxSpeed, int currentSpeed)
        {
            PetName = petName;
            MaxSpeed = maxSpeed;
            CurrentSpeed = currentSpeed;
        }

        public string PetName { get; set; } = "Car Name";
        public int MaxSpeed { get; set; } = 100;
        public int CurrentSpeed { get; set; } = 0;

        private bool carIsDead = false;

        // 1) Define a delegate type.
        public delegate void CarEngineHandler(string msgForCaller);

        // 2) Define a member variable of this delegate.
        private CarEngineHandler listOfHandlers;

        // 3) Add registration function for the caller.
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            // For one Target
            //listOfHandlers = methodToCall;

            // For Multible Targets (Multicasting)
            listOfHandlers += methodToCall;
        }

        // Removing Targets from a Delegate’s Invocation List
        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }

        // remember to send engine-related messages to any subscribed listener
        // 4) Implement the Accelerate() method to invoke the delegate's
        // invocation list under the correct circumstances.
        public void Accelerate(int delta)
        {
            // If this car is "dead," send dead message.
            if (carIsDead)
            {
                if (listOfHandlers != null)
                    listOfHandlers("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                // Is this car "almost dead"?
                if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null)
                {
                    listOfHandlers("Careful buddy! Gonna blow!");
                }
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }


    }

    class SendingObjectStateWithDelegates
    {
        public static void Test()
        {
            Console.WriteLine("***** Delegates as event enablers *****\n");
            // First, make a Car object.
            Car c1 = new Car("SlugBug", 100, 10);
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            // This time, hold onto the delegate object,
            // so we can unregister later.
            Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEvent2);
            c1.RegisterWithCarEngine(handler2);
            // Speed up (this will trigger the events).
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            // Unregister from the second handler.
            c1.UnRegisterWithCarEngine(handler2);
            // We won't see the "uppercase" message anymore!
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);


        }



        // This is the target for incoming events.
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("***********************************\n");
        }

        // This is the target for incoming events.
        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("=> {0}", msg.ToUpper());
        }

    }

    // --------------------- End of Sending Object State Notifications Using Delegates ---------------------
    #endregion

    #region Method Group Conversion Syntax
    // ------------------------ Method Group Conversion Syntax -------------------------
    // Method Group Conversion Syntax
    // As a simplification, C# provides a shortcut termed method group conversion. This feature allows you
    // to supply a direct method name, rather than a delegate object, when calling methods that take delegates as
    // arguments.
    class MethodGroupConversionSyntax
    {

        public static void Test()
        {
            Console.WriteLine("***** Method Group Conversion *****\n");
            Car c1 = new Car();
            // Register the simple method name.
            c1.RegisterWithCarEngine(CallMeHere);
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            // Unregister the simple method name.
            c1.UnRegisterWithCarEngine(CallMeHere);
            // No more notifications!
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

        }
        static void CallMeHere(string msg)
        {
            Console.WriteLine("=> Message from Car: {0}", msg);
        }
    }

    // Notice that you are not directly allocating the associated delegate object but rather simply specifying a
    // method that matches the delegate’s expected signature (a method returning void and taking a single string,
    // in this case). Understand that the C# compiler is still ensuring type safety. Thus, if the CallMeHere() method
    // did not take a string and return void, you would be issued a compiler error.
    // --------------------- End of Method Group Conversion Syntax ---------------------
    #endregion

    #region Understanding Generic Delegates
    // ------------------------ Understanding Generic Delegates -------------------------

    public delegate void MyGenericDelegate<T>(T arg);

    class GenericDelegates
    {

        public static void Test()
        {
            // Register targets.
            // Create an instance of MyGenericDelegate<T>
            // with string as the type parameter.
            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            strTarget("Message to StringTarget");

            // Create an instance of MyGenericDelegate<T>
            // with int as the type parameter.
            MyGenericDelegate<int> intTarget = new MyGenericDelegate<int>(IntTarget);
            intTarget(10);

            // Create an instance of MyGenericDelegate<T> Points to Generic Method
            // ------------------------------------------------------------------------------------
            // with int as the type parameter.
            MyGenericDelegate<int> genericIntTarget = new MyGenericDelegate<int>(GenericTarget);
            genericIntTarget(10);

            // with string as the type parameter.
            MyGenericDelegate<string> genericStringTarget = new MyGenericDelegate<string>(GenericTarget);
            genericStringTarget("String  Generic Target");


        }

        static void StringTarget(string arg)
        {
            Console.WriteLine("arg in uppercase is: {0}", arg.ToUpper());
        }
        static void IntTarget(int arg)
        {
            Console.WriteLine("++arg is: {0}", ++arg);
        }

        static void GenericTarget<T>(T arg)
        {
            Console.WriteLine($"Generic Target: {arg}");
        }

    }

    // --------------------- End of Understanding Generic Delegates ---------------------
    #endregion

    #region The Generic Action<> and Func<> Delegates
    // ------------------------ The Generic Action<> and Func<> Delegates -------------------------

    // you have seen that when you want to use delegates to enable callbacks in
    // your applications, you typically follow the steps shown here:
    // 1. Define a custom delegate that matches the format of the method being
    //      pointed to.
    // 2. Create an instance of your custom delegate, passing in a method name as a
    //      constructor argument.
    // 3. Invoke the method indirectly, via a call to Invoke() on the delegate object.

    // When you take this approach, you typically end up with a number of custom delegates that might never
    // be used beyond the current task at hand (e.g., MyGenericDelegate<T>, CarEngineHandler, and so forth).
    // While it may certainly be the case that you do indeed need to have a custom, uniquely named delegate type
    // for your project, other times the exact name of the delegate type is irrelevant.In many cases, you simply want
    // “some delegate” that takes a set of arguments and possibly has a return value other than void. In these cases,
    // you can use the framework’s built-in Action<> and Func<> delegate types.
    // The generic Action<> delegate is defined in the System namespaces of the mscorlib.dll and
    // System.Core.dll assemblies. You can use this generic delegate to “point to” a method that takes up to
    // 16 arguments (that ought to be enough!) and returns void. Now recall, because Action<> is a generic
    // delegate, you will need to specify the underlying types of each parameter as well.

    //    As you can see, using the Action<> delegate saves you the bother of defining a custom delegate type.
    //However, recall that the Action<> delegate type can point only to methods that take a void return value.
    //If you want to point to a method that does have a return value (and don’t want to bother writing the custom
    //delegate yourself), you can use Func<>.
    //The generic Func<> delegate can point to methods that (like Action<>) take up to 16 parameters and a
    //custom return value.

    //    Note many important.net APIs make considerable use of Action<> and Func<> delegates, including the
    //parallel programming framework and linQ(among others).

    class ActionAndFuncDelegates
    {
        public static void Test()
        {
            Action<string, ConsoleColor, int> Message = new Action<string, ConsoleColor, int>(DisplayMessage);
            Message("Hello With Action Delegate!!", ConsoleColor.Red, 10);

            Func<int, int, string> AddFunc = new Func<int, int, string>(Add);
            AddFunc(10, 20);

            // Simplify with Method Group Conversion Syntax

            Action<string, ConsoleColor, int> Message2 = DisplayMessage;
            Message2("Hello With Action Delegate!!", ConsoleColor.Red, 10);

            Func<int, int, string> AddFunc2 = Add;
            AddFunc(10, 20);


        }

        // This is a target for the Action<string, ConsoleColor, int> delegate.
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Set color of console text.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;
            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }
            // Restore color.
            Console.ForegroundColor = previous;
        }

        // This is a target for the Func<int,int,string> delegate.
        public static string Add(int x, int y) => (x + y).ToString();

    }

    // --------------------- End of The Generic Action<> and Func<> Delegates ---------------------
    #endregion

    #region The Problem With Class's public Delegate Member Variables
    // ------------------------ The Problem With Class's public Delegate Member Variables -------------------------
    //    Delegates are fairly interesting constructs in that they enable objects in memory to engage in a two-way
    //conversation.However, working with delegates in the raw can entail the creation of some boilerplate
    //code (defining the delegate, declaring necessary member variables, and creating custom registration and
    //unregistration methods to preserve encapsulation, etc.).
    //Moreover, when you use delegates in the raw as your application’s callback mechanism, if you do
    //not define a class’s delegate member variables as private, the caller will have direct access to the delegate
    //objects.In this case, the caller could reassign the variable to a new delegate object (effectively deleting the
    //current list of functions to call), and, worse yet, the caller would be able to directly invoke the delegate’s
    //invocation list.

    //Exposing public delegate members breaks encapsulation, which not only can lead to code that is hard
    //to maintain (and debug) but could also open your application to possible security risks! 


    public class Car2
    {
        public delegate void CarEngineHandler(string msgForCaller);
        // Now a public member!
        public CarEngineHandler listOfHandlers;
        // Just fire out the Exploded notification.
        public void Accelerate(int delta)
        {
            if (listOfHandlers != null)
                listOfHandlers("Sorry, this car is dead...");
        }
    }

    class ProblemWithPublicDelegateVariable
    {
        //        Notice that you no longer have private delegate member variables encapsulated with custom
        //registration methods.Because these members are indeed public, the caller can directly access the
        //listOfHandlers member variable and reassign this type to new CarEngineHandler objects and invoke the
        //delegate whenever it so chooses.
        public static void Test()
        {
            Console.WriteLine("***** Agh! No Encapsulation! *****\n");
            // Make a Car.
            Car2 myCar = new Car2();
            // We have direct access to the delegate!
            myCar.listOfHandlers = new Car2.CarEngineHandler(CallWhenExploded);
            myCar.Accelerate(10);
            // We can now assign to a whole new object...
            // confusing at best.
            myCar.listOfHandlers = new Car2.CarEngineHandler(CallHereToo);
            myCar.Accelerate(10);
            // The caller can also directly invoke the delegate!
            myCar.listOfHandlers.Invoke("hee, hee, hee...");
            Console.ReadLine();
        }
        static void CallWhenExploded(string msg)
        { Console.WriteLine(msg); }
        static void CallHereToo(string msg)
        { Console.WriteLine(msg); }
    }

    // --------------------- End of The Problem With Class's public Delegate Member Variables ---------------------
    #endregion

    #region The C# event Keyword
    // ------------------------ The C# event Keyword -------------------------

    //    As a shortcut, so you don’t have to build custom methods to add or remove methods to a delegate’s
    //invocation list, C# provides the event keyword. When the compiler processes the event keyword, you are
    //automatically provided with registration and unregistration methods, as well as any necessary member
    //variables for your delegate types.These delegate member variables are always declared private, and,
    //therefore, they are not directly exposed from the object firing the event. To be sure, the event keyword can
    //be used to simplify how a custom class sends out notifications to external objects.
    //Defining an event is a two-step process. First, you need to define a delegate type (or reuse an existing
    //one) that will hold the list of methods to be called when the event is fired. Next, you declare an event
    //(using the C# event keyword) in terms of the related delegate type.
    class Car3
    {


        public Car3()
        {

        }

        public Car3(string petName, int maxSpeed, int currentSpeed)
        {
            PetName = petName;
            MaxSpeed = maxSpeed;
            CurrentSpeed = currentSpeed;
        }

        public string PetName { get; set; } = "Car Name";
        public int MaxSpeed { get; set; } = 100;
        public int CurrentSpeed { get; set; } = 0;

        private bool carIsDead = false;

        // This delegate works in conjunction with the
        // Car's events.
        public delegate void CarEngineHandler(string msg);

        // This car can send these events.
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;
        //With this, you have configured the car to send two custom events without having to define custom
        //registration functions or declare delegate member variables. You will see the usage of this new automobile in
        //just a moment, but first let’s check the event architecture in a bit more detail.



        public void Accelerate(int delta)
        {
            // If the car is dead, fire Exploded event.
            if (carIsDead)
            {
                if (Exploded != null)
                    Exploded("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                // Almost dead?
                if (10 == MaxSpeed - CurrentSpeed && AboutToBlow != null)
                {
                    AboutToBlow("Careful buddy! Gonna blow!");
                }
                // Still OK!
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }

        // Cleaning Up Event Invocation Using the C# 6.0 Null-Conditional Operator 
        // Instead of null checking
        public void Accelerate2(int delta)
        {
            // If the car is dead, fire Exploded event.
            if (carIsDead)
            {
                // Using the C# 6.0 Null-Conditional Operator Instead of null checking
                Exploded?.Invoke("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                // Almost dead?
                if (10 == MaxSpeed - CurrentSpeed)
                {
                    // Using the C# 6.0 Null-Conditional Operator Instead of null checking
                    AboutToBlow?.Invoke("Careful buddy! Gonna blow!");
                }
                // Still OK!
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }

    }

    class TestEventKeyword
    {
        public static void Test()
        {
            Console.WriteLine("***** Test Event Keyword *****\n");
            Car3 c1 = new Car3("SlugBug", 100, 10);
            // Register event handlers.
            c1.AboutToBlow += new Car3.CarEngineHandler(CarIsAlmostDoomed);
            c1.AboutToBlow += new Car3.CarEngineHandler(CarAboutToBlow);
            Car3.CarEngineHandler d = new Car3.CarEngineHandler(CarExploded);
            c1.Exploded += d;
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            // Remove CarExploded method
            // from invocation list.
            c1.Exploded -= d;
            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

        }

        // To even further simplify event registration, you can use method group conversion.
        public static void Test2()
        {
            Console.WriteLine("***** Test Event Keyword *****\n");
            Car3 c1 = new Car3("SlugBug", 100, 10);
            // Register event handlers.
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;
            c1.Exploded += CarExploded;
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            // Remove CarExploded method
            // from invocation list.
            c1.Exploded -= CarExploded;
            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            Console.ReadLine();
        }

        public static void CarAboutToBlow(string msg)
        { Console.WriteLine(msg); }
        public static void CarIsAlmostDoomed(string msg)
        { Console.WriteLine("=> Critical Message from Car: {0}", msg); }
        public static void CarExploded(string msg)
        { Console.WriteLine(msg); }
    }

    //     Events Under the Hood
    // =======================================================================================
    // When the compiler processes the C# event keyword, it generates two hidden methods, one having an
    // add_ prefix and the other having a remove_ prefix.Each prefix is followed by the name of the C# event.
    // For example, the Exploded event results in two hidden methods named add_Exploded() and remove_
    // Exploded(). If you were to check out the CIL instructions behind add_AboutToBlow(), you would find a call
    // to the Delegate.Combine() method. Consider the partial CIL code:
    // ---------------------------------------------------------------------------------------
    // .method public hidebysig specialname instance void
    // add_AboutToBlow(class CarEvents.Car/CarEngineHandler 'value') cil managed
    //     {
    // ...
    // call class [mscorlib]
    //     System.Delegate
    // [mscorlib] System.Delegate::Combine(
    // class [mscorlib] System.Delegate, class [mscorlib] System.Delegate)
    // ...
    // }
    // ---------------------------------------------------------------------------------------

    // As you would expect, remove_AboutToBlow() will call Delegate.Remove() on your behalf.
    // ---------------------------------------------------------------------------------------
    // .method public hidebysig specialname instance void
    // remove_AboutToBlow(class CarEvents.Car/CarEngineHandler 'value')
    // cil managed
    // {
    // ...
    // call class [mscorlib]
    // System.Delegate
    // [mscorlib] System.Delegate::Remove(
    // class [mscorlib] System.Delegate, class [mscorlib] System.Delegate)
    // ...
    // }
    // ---------------------------------------------------------------------------------------

    // Finally, the CIL code representing the event itself makes use of the.addon and.removeon directives to
    // map the names of the correct add_XXX() and remove_XXX() methods to invoke.
    // ---------------------------------------------------------------------------------------
    // .event CarEvents.Car/EngineHandler AboutToBlow
    // {
    // .addon instance void CarEvents.Car::add_AboutToBlow
    // (class CarEvents.Car/CarEngineHandler)
    // .removeon instance void CarEvents.Car::remove_AboutToBlow
    // (class CarEvents.Car/CarEngineHandler)
    // }
    // ---------------------------------------------------------------------------------------
    // Now that you understand how to build a class that can send C# events (and are aware that events are
    // little more than a typing time-saver), the next big question is how to listen to the incoming events on the
    // caller’s side.

    // --------------------- End of The C# event Keyword ---------------------
    #endregion

    #region The C# event Keyword Example
    // ------------------------ The C# event Keyword Example -------------------------
    public class Employee
    {
        public delegate void SalaryHandler(string message);

        // Note  That The event Like 'Employee.SalaryIncreased' can only appear on the left hand side of += or -= 
        // except when used from within the type 'Employee'

        public event SalaryHandler SalaryIncreased;

        public event SalaryHandler SalaryDecreased;

        public Employee(int iD, string name, double salary)
        {
            ID = iD;
            Name = name;
            Salary = salary;
        }

        public Employee() : this(0, "", 0.0) { }

        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; private set; }



        public void UpdateSalary(double newSalary)
        {
            Console.WriteLine();
            Console.WriteLine($"Salary Updated:{newSalary}");
            if (newSalary > Salary)
            {
                SalaryIncreased?.Invoke($"Salary Increased From {Salary } to {newSalary } With {newSalary - Salary }");

                // Update Salary
                Salary = newSalary;

            }

            else if (newSalary < Salary)
            {
                if (SalaryDecreased != null)
                    SalaryDecreased($"Salary Decreased From {Salary } to {newSalary } With {Salary - newSalary }");

                // Update Salary
                Salary = newSalary;

            }
            else
                return;


        }

        public void SalaryIncreasedEventInfo()
        {

            Console.WriteLine();
            Console.WriteLine("Salary Increased Event Info:-");
            Console.WriteLine("".PadLeft(40, '-'));
            if (SalaryIncreased == null)
            {
                Console.WriteLine($@"SalaryIncreased == null, as Has No Handlers");
                Console.WriteLine();
                return;
            }
            foreach (var item in SalaryIncreased.GetInvocationList())
            {
                Console.WriteLine();
                Console.WriteLine($"Item: {item}");
                Console.WriteLine($@"item.Method: {item.Method}");
                Console.WriteLine($@"item.Target: {item.Target}");
            }
            Console.WriteLine();

        }

        public void SalaryDecreasedEventInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Salary Decreased Event Info:-");
            Console.WriteLine("".PadLeft(40, '-'));
            if (SalaryDecreased == null)
            {
                Console.WriteLine($@"SalaryDecreased == null, as Has No Handlers");
                Console.WriteLine();
                return;
            }
            foreach (var item in SalaryDecreased.GetInvocationList())
            {
                Console.WriteLine();
                Console.WriteLine($"Item: {item}");
                Console.WriteLine($@"item.Method: {item.Method}");
                Console.WriteLine($@"item.Target: {item.Target}");
            }
            Console.WriteLine();
        }



        public override string ToString()
        {
            //return base.ToString();
            return $"Employee[ID:{ID}, Name:{Name}, Salary:{Salary}]";
        }

        public override bool Equals(object obj)
        {
            //return base.Equals(obj);
            return this.ToString().Equals(obj?.ToString());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }



    public class TestEventKeywordExample
    {
        public static void Test()
        {
            Console.WriteLine("***** The C# event Keyword *****\n");
            Employee emp1 = new Employee(10, "Moamen", 4000.0);
            Console.WriteLine(emp1);

            // Register Handlers For SalaryIncreased and SalaryDecreased Events
            emp1.SalaryIncreased += new Employee.SalaryHandler(Emp1_SalaryIncreased); // Use the Full Delegate Syntax
            emp1.SalaryDecreased += Emp1_SalaryDecreased;   // Use Method Group Conversion
            emp1.SalaryIncreasedEventInfo();
            emp1.SalaryDecreasedEventInfo();
            emp1.UpdateSalary(5000);
            emp1.UpdateSalary(4500);

            // Unregister Handlers For SalaryIncreased Event
            emp1.SalaryIncreased -= Emp1_SalaryIncreased;
            emp1.UpdateSalary(5000);
            emp1.UpdateSalary(4500);

            // Unregister Handlers For SalaryDecreased Event
            emp1.SalaryDecreased -= Emp1_SalaryDecreased;
            emp1.UpdateSalary(5000);
            emp1.UpdateSalary(4500);

            emp1.SalaryIncreasedEventInfo();
            emp1.SalaryDecreasedEventInfo();
        }


        private static void Emp1_SalaryIncreased(string message)
        {
            Console.WriteLine();
            Console.WriteLine("Salary Increased Handler Static Method");
            Console.WriteLine($@"message: {message}");

        }
        private static void Emp1_SalaryDecreased(string message)
        {
            Console.WriteLine();
            Console.WriteLine("Salary Decreased Handler Static Method");
            Console.WriteLine($@"message: {message}");
        }
    }
    // --------------------- End of The C# event Keyword Example ---------------------
    #endregion

    #region Creating Custom Event Arguments - EventArgs Base Class
    // ------------------------ Creating Custom Event Arguments -------------------------
    //    Truth be told, there is one final enhancement you could make to the current iteration of the Car class that
    //mirrors Microsoft’s recommended event pattern.As you begin to explore the events sent by a given type in
    //the base class libraries, you will find that the first parameter of the underlying delegate is a System.Object,
    //while the second parameter is a descendant of System.EventArgs.
    //The System.Object argument represents a reference to the object that sent the event (such as the Car),
    //while the second parameter represents information regarding the event at hand.The System.EventArgs
    //base class represents an event that is not sending any custom information.
    // -------------------------------------------------------------------------------
    // public class EventArgs
    // {
    //     public static readonly EventArgs Empty;
    //     public EventArgs();
    // }
    // -------------------------------------------------------------------------------
    //For simple events, you can pass an instance of EventArgs directly.However, when you want to pass
    //along custom data, you should build a suitable class deriving from EventArgs.For this example, assume you
    //have a class named CarEventArgs, which maintains a string representing the message sent to the receiver.
    public class CustomCarEventArgs : EventArgs
    {
        public readonly string msg;
        public CustomCarEventArgs(string message)
        {
            msg = message;
        }
    }

    class Car4
    {
        public Car4() { }
        public Car4(string petName, int maxSpeed, int currentSpeed)
        {
            PetName = petName;
            MaxSpeed = maxSpeed;
            CurrentSpeed = currentSpeed;
        }

        public string PetName { get; set; } = "Car Name";
        public int MaxSpeed { get; set; } = 100;
        public int CurrentSpeed { get; set; } = 0;

        private bool carIsDead = false;

        // This delegate works in conjunction with the
        // Car's events.
        public delegate void CarEngineHandler(object sender, CustomCarEventArgs e);

        // This car can send these events.
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;
        
        public void Accelerate(int delta)
        {
            // If the car is dead, fire Exploded event.
            if (carIsDead)
            {
                // Using the C# 6.0 Null-Conditional Operator Instead of null checking
                Exploded?.Invoke(this, new CustomCarEventArgs("Sorry, this car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;
                // Almost dead?
                if (10 == MaxSpeed - CurrentSpeed)
                {
                    // Using the C# 6.0 Null-Conditional Operator Instead of null checking
                    AboutToBlow?.Invoke(this, new CustomCarEventArgs("Careful buddy! Gonna blow!"));
                }
                // Still OK!
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }

        public void Reset()
        {
            this.CurrentSpeed = 0;
            this.carIsDead = false;
            Console.WriteLine("=====> Buy new Car After the Exploded One :D ");
        }


    }

    class TestCustomEventArgs
    {
        public static void Test()
        {
            Console.WriteLine("***** Test Custom EventArgs with Events *****\n");
            Car4 c1 = new Car4("SlugBug", 100, 10);
            // Register event handlers.
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;
            c1.Exploded += CarExploded;
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            // Remove CarExploded method
            // from invocation list.
            c1.Exploded -= CarExploded;

            c1.Reset();
            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

        }

        public static void CarAboutToBlow(object sender, CustomCarEventArgs e)
        { 
            // Just to be safe, perform a
            // runtime check before casting.
            if (sender is Car4 c)
            {
                Console.WriteLine("Critical Message from {0}: {1}", c.PetName, e.msg);
            }
        }
        public static void CarIsAlmostDoomed(object sender, CustomCarEventArgs e)
        {
            // Just to be safe, perform a
            // runtime check before casting.
            if (sender is Car4 c)
            {
                Console.WriteLine("=> Critical Message from {0}: {1}", c.PetName, e.msg);
            }
        }
        public static void CarExploded(object sender, CustomCarEventArgs e)
        {
            if (sender is Car4 c)
                Console.WriteLine("{0} says: {1}", sender, e.msg);
        }
    }


    // --------------------- End of Creating Custom Event Arguments ---------------------
    #endregion

    #region The Generic EventHandler<T> Delegate
    // ------------------------ The Generic EventHandler<T> Delegate -------------------------
    //    Given that so many custom delegates take an object as the first parameter and an EventArgs descendant as
    // the second, you could further streamline the previous example by using the generic EventHandler<T> type,
    // where T is your custom EventArgs type. Consider the following update to the Car type (notice how you no
    // longer need to define a custom delegate type at all):

    // EventHandler<TEventArgs> Delegate
    // ----------------------------------
    //
    // Summary:
    //     Represents the method that will handle an event when the event provides data.
    //
    // Parameters:
    //   sender:
    //     The source of the event.
    //
    //   e:
    //     An object that contains the event data.
    //
    // Type parameters:
    //   TEventArgs:
    //     The type of the event data generated by the event.
    // ---------------------------------------------------------------------------
    // public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
    // ---------------------------------------------------------------------------
    public class CarEventArgs : EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message)
        {
            msg = message;
        }
    }

    class Car5
    {
        public Car5() { }
        public Car5(string petName, int maxSpeed, int currentSpeed)
        {
            PetName = petName;
            MaxSpeed = maxSpeed;
            CurrentSpeed = currentSpeed;
        }

        public string PetName { get; set; } = "Car Name";
        public int MaxSpeed { get; set; } = 100;
        public int CurrentSpeed { get; set; } = 0;

        private bool carIsDead = false;

        // Now No Need to Define Custom Delegate, as we will use EventHandler<TEventArgs> delegate
        //public delegate void EventHandler<CarEventArgs2>(object sender, CarEventArgs2 e);

        // This car can send these events.
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

        public void Accelerate(int delta)
        {
            // If the car is dead, fire Exploded event.
            if (carIsDead)
            {
                // Using the C# 6.0 Null-Conditional Operator Instead of null checking
                Exploded?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;
                // Almost dead?
                if (10 == MaxSpeed - CurrentSpeed)
                {
                    // Using the C# 6.0 Null-Conditional Operator Instead of null checking
                    AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Gonna blow!"));
                }
                // Still OK!
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }

        public void Reset()
        {
            this.CurrentSpeed = 0;
            this.carIsDead = false;
            Console.WriteLine("=====> Buy new Car After the Exploded One :D ");
        }


    }

    class TestGenericEventHandlerDelegate
    {
        public static void Test()
        {
            Console.WriteLine("***** Test Custom EventArgs with Events *****\n");
            Car5 c1 = new Car5("SlugBug", 100, 10);
            // Register event handlers.
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;
            
            // Long Delegate object Syntax if you like to use it(without method group syntax)
            EventHandler<CarEventArgs> d = new EventHandler<CarEventArgs>(CarExploded);
            c1.Exploded += d;

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            // Remove CarExploded method
            // from invocation list.
            c1.Exploded -= d;

            c1.Reset();
            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

        }

        public static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            // Just to be safe, perform a
            // runtime check before casting.
            if (sender is Car5 c)
            {
                Console.WriteLine("Critical Message from {0}: {1}", c.PetName, e.msg);
            }
        }
        public static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        {
            // Just to be safe, perform a
            // runtime check before casting.
            if (sender is Car5 c)
            {
                Console.WriteLine("=> Critical Message from {0}: {1}", c.PetName, e.msg);
            }
        }
        public static void CarExploded(object sender, CarEventArgs e)
        {
            if (sender is Car5 c)
                Console.WriteLine("{0} says: {1}", sender, e.msg);
        }
    }


    // --------------------- End of The Generic EventHandler<T> Delegate ---------------------
    #endregion

    #region Understanding C# Anonymous Methods
    // ------------------------ Understanding C# Anonymous Methods -------------------------
    //    As you have seen, when a caller wants to listen to incoming events, it must define a custom method in a class
    //(or structure) that matches the signature of the associated delegate.

    // -------------------------------------------------------------------------
    // class MyClass
    // {
    //     static void MyMethod()
    //     {
    //         SomeType t = new SomeType();
    //         // Assume "SomeDelegate" can point to methods taking no
    //         // args and returning void.
    //         t.SomeEvent += new SomeDelegate(MyEventHandler);
    //     }
    //     // Typically only called by the SomeDelegate object.
    //     public static void MyEventHandler()
    //     {
    //         // Do something when event is fired.
    //     }
    // }
    // -------------------------------------------------------------------------

    //    it is possible to associate an event directly to a block of code statements at the
    // time of event registration.Formally, such code is termed an anonymous method.

    //    The basic syntax of an anonymous method matches the following pseudocode:
    // -------------------------------------------------------------------------
    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         SomeType t = new SomeType();
    //         t.SomeEvent += delegate (optionallySpecifiedDelegateArgs)
    //         { /* statements */ };
    //     }
    // }
    // --------------------------------------------------------------------------------------
    //    Note the final curly bracket of an anonymous method must be terminated by a semicolon. if you fail to do
    //so, you are issued a compilation error

    //    you are not required to receive the incoming arguments sent by a specific event.
    //However, if you want to make use of the possible incoming arguments, you will need to specify the
    //parameters prototyped by the delegate type (as shown in the second handling of the AboutToBlow and
    //Exploded events)

    //    Accessing Local Variables
    // -----------------------------------------------------------------------------------
    //Anonymous methods are interesting in that they are able to access the local variables of the method that
    //defines them.Formally speaking, such variables are termed outer variables of the anonymous method.A few
    //important points about the interaction between an anonymous method scope and the scope of the defining
    //method should be mentioned.
    // ------------------------------------------------------------------------------------------
    //•	 An anonymous method cannot access ref or out parameters of the defining method.

    //•	 An anonymous method cannot have a local variable with the same name as a local
    //      variable in the outer method.

    //•	 An anonymous method can access instance variables (or static variables, as
    //      appropriate) in the outer class scope.

    //•	 An anonymous method can declare local variables with the same name as outer
    //      class member variables(the local variables have a distinct scope and hide the outer
    //      class member variables)
    // ------------------------------------------------------------------------------------------
    class TestAnonymousMethods
    {
        public static void Test()
        {
            Console.WriteLine("***** Anonymous Methods *****\n");
            Car5 c1 = new Car5("SlugBug", 100, 10);
            // Register event handlers as anonymous methods.
            c1.AboutToBlow += delegate  // you are not required to receive the incoming arguments sent by a specific event
            {
                Console.WriteLine("Eek! Going too fast!");
            }; // Note the semicolon

            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine("Message from Car: {0}", e.msg);
            };

            c1.Exploded += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine("Fatal Message from Car: {0}", e.msg);
            };


            // This will eventually trigger the events.
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            //Console.ReadLine();
        }

        public static void Test2()
        {
            Car5 c1 = new Car5("Toyota", 100, 10);

            c1.AboutToBlow += delegate
            {
                Console.WriteLine(NewLine + "AboutToBlow EventHandler<CarEventrgs> Delegate Anonymous Method");
                Console.WriteLine("Car is About To Blow" + NewLine);
            };

            c1.AboutToBlow += delegate(object sender, CarEventArgs e) 
            {
                Console.WriteLine(NewLine + "=>AboutToBlow2 EventHandler<CarEventrgs> Delegate Anonymous Method");
                Console.WriteLine($"Message from Car: {e.msg}{NewLine}");
            };

            c1.Exploded += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine(NewLine + "Exploded EventHandler<CarEventrgs> Delegate Anonymous Method");
                Console.WriteLine($"Fatal Message from Car: {e.msg}{NewLine}");
            };

            // This will eventually trigger the events.
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            

        }

        // Accessing Local Variables
        public static void Test3()
        {
            Console.WriteLine("***** Anonymous Methods *****\n");
            int aboutToBlowCounter = 0;
            // Make a car as usual.
            Car5 c1 = new Car5("SlugBug", 100, 10);
            // Register event handlers as anonymous methods.
            c1.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("Eek! Going too fast!");
            };
            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                aboutToBlowCounter++;
                Console.WriteLine("Critical Message from Car: {0}", e.msg);
            };
            // This will eventually trigger the events.
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            Console.WriteLine("AboutToBlow event was fired {0} times.",
            aboutToBlowCounter);
        }

    }



    // --------------------- End of Understanding C# Anonymous Methods ---------------------
    #endregion

    #region Understanding Lambda Expressions
    // ------------------------ Understanding Lambda Expressions -------------------------
    // To conclude your look at the .NET event architecture, you will examine C# lambda expressions. As just
    // explained, C# supports the ability to handle events “inline” by assigning a block of code statements directly
    // to an event using anonymous methods, rather than building a stand-alone method to be called by the
    // underlying delegate. Lambda expressions are nothing more than a concise way to author anonymous
    // methods and ultimately simplify how you work with the.NET delegate type.

    // first understand that lambda expressions can be used anywhere you would have used  
    // an anonymous method or a strongly typed delegate (typically with far fewer keystrokes).
    // Under the hood, the C# compiler translates the expression into a standard anonymous method making use
    // of the Predicate<T> delegate type (which can be verified using ildasm.exe or reflector.exe).

    //  a lambda expression can be understood as follows:
    //  ArgumentsToProcess => StatementsToProcessThem
    // -----------------------------------------------------------------
    // // This lambda expression...
    // List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);
    // -----------------------------------------------------------------
    // is compiled into the following approximate C# code:
    // -----------------------------------------------------------------
    // // ...becomes this anonymous method.
    // List<int> evenNumbers = list.FindAll(delegate (int i)
    // {
    //     return (i % 2) == 0;
    // });
    // -----------------------------------------------------------------


    class TestLambdaExpressions
    {
        public static void Test()
        {
            Console.WriteLine("***** Fun with Lambdas *****\n");
            TraditionalDelegateSyntax();
            AnonymousMethodSyntax();
            LambdaExpressionSyntax();
            LambdaExpressionSyntaxWithMultipleStatements();
            LambdaExpressionWithMultipleParameters();
            LambdaExpressionWithZeroParameters();
        }

        static void TraditionalDelegateSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Call FindAll() using traditional delegate syntax.
            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);
            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        // Target for the Predicate<> delegate.
        static bool IsEvenNumber(int i)
        {
            // Is it an even number?
            return (i % 2) == 0;
        }

        static void AnonymousMethodSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Now, use an anonymous method.
            List<int> evenNumbers = list.FindAll(delegate (int i)
            { return (i % 2) == 0; });
            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        static void LambdaExpressionSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Now, use a C# lambda expression.
            // ------------------------------------------------------------------------------

            // The parameters of a lambda expression can be explicitly or implicitly typed.

            // implicitly typed Parameters. 
            //List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);
            //List<int> evenNumbers = list.FindAll((i) => (i % 2) == 0);

            // Explicitly typed Parameters. 
            //List<int> evenNumbers = list.FindAll((int i) => (i % 2) == 0);
            List<int> evenNumbers = list.FindAll((int i) => ((i % 2) == 0));


            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        static void LambdaExpressionSyntaxWithMultipleStatements()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Now process each argument within a group of
            // code statements.
            List<int> evenNumbers = list.FindAll((i) =>
            {
                Console.WriteLine("value of i is currently: {0}", i);
                bool isEven = ((i % 2) == 0);
                return isEven;
            });
            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        static void LambdaExpressionWithMultipleParameters()
        {
            // Register with delegate as a lambda expression.
            SimpleMath4 m = new SimpleMath4();
            m.SetMathHandler((msg, result) =>
            { Console.WriteLine("Message: {0}, Result: {1}", msg, result); });
            // This will execute the lambda expression.
            m.Add(10, 10);
        }

        static void LambdaExpressionWithZeroParameters()
        {
            // Register with delegate as a lambda expression.
            SimpleMath5 m = new SimpleMath5();

            // Handle No Parameter Delegate with no parameter lambda Expression
            m.SetMathHandler(() => Console.WriteLine("Message from zero parameter handler!! "));
            // This will execute the lambda expression.
            m.Add(10, 10);
        }

    }

    // Lambda Expression With Multiple Parameters
    public class SimpleMath4
    {
        public delegate void MathMessage(string msg, int result);
        private MathMessage mmDelegate;
        public void SetMathHandler(MathMessage target)
        { mmDelegate = target; }
        public void Add(int x, int y)
        {
            mmDelegate?.Invoke("Adding has completed!", x + y);
        }
    }

    // Lambda Expression With Zero Parameters
    public class SimpleMath5
    {
        public delegate void SimpleMathDelegate();
        private SimpleMathDelegate mmDelegate;
        public void SetMathHandler(SimpleMathDelegate target)
        { mmDelegate = target; }
        public void Add(int x, int y)
        {
            mmDelegate?.Invoke();
        }
    }

    // --------------------- End of Understanding Lambda Expressions ---------------------
    #endregion

    #region Lambdas and Expression-Bodied Members
    // ------------------------ Lambdas and Expression-Bodied Members -------------------------
    // Now that you understand lambda expressions and how they work, it should be much clearer how
    // expression-bodied members work under the covers.As mentioned in Chapter 4, as of C# 6, it is permissible
    // to use the => operator to simplify some (but not all) member implementations.Specifically, if you have a
    // method or property (in addition to a custom operator or conversion routine; see Chapter 11) that consists of
    // exactly a single line of code in the implementation, you are not required to define a scope via curly bracket.
    // You can instead leverage the lambda operator and write an expression-bodied member. In C# 7, you can
    // also use this syntax for class constructors, finalizers(covered in Chapter 13), and get and set accessors on
    // property members.

    // always remember a lambda expression can be broken down to
    // the following simple equation:
    // ---------------------------------------------------------------------------
    // ArgumentsToProcess => StatementsToProcessThem
    //
    // ---------------------------------------------------------------------------
    // Or, if using the => operator to implement a single-line type member, it would be like this:
    // ---------------------------------------------------------------------------
    // TypeMember => SingleCodeStatement
    // ---------------------------------------------------------------------------

    // It is worth pointing out that the LINQ programming model also makes substantial use of lambda
    // expressions to help simplify your coding efforts.You will examine LINQ beginning in Chapter 12

    // --------------------- End of Lambdas and Expression-Bodied Members ---------------------
    #endregion


    public class DelegateTraining
    {
        public static void Test()
        {
            //TestSimpleDelegate.Test();
            //SendingObjectStateWithDelegates.Test();
            //InterfaceCallbacks.Test();
            //InterfaceCallbacks2.Test();
            //MethodGroupConversionSyntax.Test();
            //GenericDelegates.Test();
            //ActionAndFuncDelegates.Test();
            //ProblemWithPublicDelegateVariable.Test();
            //TestEventKeyword.Test();
            //TestEventKeywordExample.Test();
            //TestCustomEventArgs.Test();
            //TestGenericEventHandlerDelegate.Test();
            // TestAnonymousMethods.Test();
            // TestAnonymousMethods.Test2();
            // TestAnonymousMethods.Test3();
            TestLambdaExpressions.Test();


        }

    }



}