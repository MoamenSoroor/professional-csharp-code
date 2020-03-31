using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProCSharpBook.Multithreading
{

    #region Principles of Asynchrony
    // ------------------------ Principles of Asynchrony -------------------------

    // Synchronous Versus Asynchronous Operations
    // ------------------------------------------
    // A synchronous operation does its work before returning to the caller.
    //
    // An asynchronous operation does(most or all of) its work after returning to the
    // caller.
    // 
    // Asynchronous methods are less common, and initiate concurrency, because 
    // work continues in parallel to the caller.Asynchronous methods typically return 
    // quickly (or immediately) to the caller; hence they are also called nonblocking methods.
    // 
    // Most of the asynchronous methods that we’ve seen so far can be described as
    // general-purpose methods:
    // • Thread.Start
    // • Task.Run
    // • Methods that attach continuations to tasks


    public class AsynchronousProgramming
    {
        // Test Method
        public static void Test()
        {
            for (int i = 0; i < 10; i++)
            {
                int temp = i;   // to avoid capturing
                var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
                awaiter.OnCompleted(() => 
                        Console.WriteLine(awaiter.GetResult() + " primes between... " 
                        + (temp * 1000000) + " and " + ((temp + 1) * 1000000 - 1)));

            }
            Console.WriteLine("Done");

        }
        static Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() =>
                ParallelEnumerable.Range(start, count).Count(n =>
                    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }

    }

    // --------------------------------------------------------------
    #endregion

    #region Asynchronous Functions
    // ------------------------ Asynchronous Functions -------------------------
    // Awaiting
    // --------
    // The await keyword simplifies the attaching of continuations.Starting with a basic
    // scenario, the compiler expands:
    // 
    //  var result = await expression;
    //  statement(s);
    // 
    //  into something functionally similar to:
    // 
    //  var awaiter = expression.GetAwaiter();
    //  awaiter.OnCompleted(() =>
    //  {
    //      var result = awaiter.GetResult();
    //      statement(s);
    //  });
    //
    // 
    // The async modifier tells the compiler to treat await as a keyword rather than an
    // identifier should an ambiguity arise within that method(this ensures that code
    // written prior to C# 5 that might use await as an identifier will still compile without
    // error). The async modifier can be applied only to methods(and lambda expres‐
    // sions) that return void or(as we’ll see later) a Task or Task<TResult>.

    // The async modifier is similar to the unsafe modifier in that it
    // has no effect on a method’s signature or public metadata; it
    // affects only what happens inside the method.For this reason,
    // it makes no sense to use async in an interface. However it is
    // legal, for instance, to introduce async when overriding a nonasync 
    // virtual method, as long as you keep the signature the same.

    // awaitable object 
    // ===============================================================
    // any object with a GetAwaiter method that returns an awaitable object
    // (implementing INotifyCompletion.OnCompleted and with an appropriately 
    // typed GetResult method and a bool IsCompleted property)
    // -------------------------------------------------------------------

    public class AsynchronousFunctions
    {
        // Test Method
        // async is applied only to void , Task, and Task<TResult>
        public static async void Test()
        {

            int result = await GetPrimesCountAsync(2, 1000_000);
            Console.WriteLine("result: " + result);
        }

        static Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() =>
           ParallelEnumerable.Range(start, count).Count(n =>
         Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }


    }

    // --------------------------------------------------------------
    #endregion


    #region Awaiting a nongeneric task
    // ------------------------ Awaiting a nongeneric task -------------------------

    public class AwaitingNongenericTask
    {
        // Test Method
        public static async void Test()
        {
            await Task.Delay(3000);
            Console.WriteLine("Three Seconds Passed!");

        }

        public static async void Test2()
        {
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(2000);
                Console.WriteLine($"{i}- Three Seconds Passed!");
            }
            Console.WriteLine("Done!");
            

        }

        public static void CallTest2()
        {
            Test2();
            Console.WriteLine("Second Done!");


        }

        public static void Test3()
        {
            for (int i = 0; i < 5; i++)
            {
                Task.Delay(2000).GetAwaiter().OnCompleted(
                    ()=>Console.WriteLine($"{i}- Three Seconds Passed!"));

                
            }
            Console.WriteLine("Done!");


        }
    }

    // --------------------------------------------------------------
    #endregion

    #region Building Asynchronous Functions
    // ------------------------ Building Asynchronous Functions -------------------------

    public class BuildingAsyncFunctions
    {
        // Test Method
        public static void Test()
        {


        }


    }

    // --------------------------------------------------------------
    #endregion


}


