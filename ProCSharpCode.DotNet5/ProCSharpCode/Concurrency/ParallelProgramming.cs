using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpCode.ProCSharpCode.Concurrency
{

    // introcuction
    // -----------------------------------------------------------------------------------
    //    Parallel programming in .NET can be achieved in a few different ways.There's
    // the lower level thread class, which gives you complete control of an actual
    // thread.With complete control also comes great responsibility.You'd have to write a
    // lot of code on your own to effectively introduce parallelism using the thread
    // class. Then we have the Task Parallel Library, which provides an abstract concept
    // of looking at an operation that shouldn't block. The Task should be the preferred
    // way of running operations where you don't want to block the current
    // context.With a Task, you don't have to care about if it's a new thread or if it's reusing
    // an existing thread.The Task can schedule work on a thread pool, which may or may
    // not spawn an actual thread.It may also reuse a pre‑existing thread.This means
    // that you don't have to use the lower‑level threading, and can instead rely on
    // the framework and the language to give you some help.The Task Parallel Library
    // also introduces helper classes to easier introduce parallelism in your code.
    // You've got a class called Parallel, which provides functionality for running a set of
    // operations across the available resources, but also ways to easily convert a
    // For and a ForEach loop into a parallel loop. When processing collections, you may
    // have encountered LINQ, and there's a very handy extension with the Task Parallel
    // Library which provides a way to write Parallel LINQ.All the parallel helpers
    // in the Task Parallel Library are built on top of the Task.When Microsoft
    // introduced and started building these features, they were commonly known as the Parallel
    // Extensions.Obviously, there are also other libraries out there that will allow
    // you to run background work and process data asynchronously.It's time to explore
    // the parallel portion of the Task Parallel Library.

    #region Parallel Class
    //    we're going to use the Parallel class. This introduces a few helpers that will
    //allow us to more easily approach this. Internally.it will, in fact, use the
    //task from the Task parallel library. It will also provide some configuration
    //capabilities to override some behavior. Out of the box, it will take care of
    //calculating the most efficient way of dividing the tasks it's given among the available
    //cores.This means distributing the work effectively across the different cores
    //that you have available on your system.If we simply spawn a lot of tasks using
    //Task.Run, not only will it not be as efficient as it could be, it will also
    //require us to write a lot more code than we have to.Instead of doing that, we can use
    //these methods available on the Parallel class.

    //We could use Parallel for, which is really the same as a normal for loop,
    //but it will run in parallel and be
    //configured to distribute the work according to the system it's running on.
    //
    //You could also use the parallel ForEach, which is a parallel version of the normal
    //ForEach loop.
    //
    //You've also got a method called Invoke
    //on the Parallel class. This takes a list of actions.These actions will be
    //distributed and executed in parallel.
    //
    //None of the methods on the parallel class will
    //guarantee that it's executing in parallel because it really depends on the system.
    //I've had a look at the internals of Parallel.Invoke, and depending on how many
    //actions you pass to it, it might execute them using a parallel for loop.This
    //just proves that it does some really heavy lifting and provide some great
    //functionality and optimizations which you shouldn't take lightly. Parallel.Invoke doesn't
    //return anything, and the actions you pass to it are distributed to run as
    //effectively as possible and run independent from each other.
    #endregion


    #region Important notes

    // Parallel methods :
    // if exception is thrown in one of the currently executing tasks, execution of the other
    // ones will not be stopped
    // 

    #endregion

    #region Parallel.Invoke

    public class ParallelInvokeMethod
    {
        // Test Method
        public static void Test()
        {
            ConcurrentBag<int> data = new ConcurrentBag<int>();
            Parallel.Invoke(
                () =>
                {
                    int result = Calculate();
                    data.Add(result);
                },
                () =>
                {
                    int result = Calculate();
                    data.Add(result);
                },
                () =>
                {
                    int result = Calculate();
                    data.Add(result);
                },
                () =>
                {
                    int result = Calculate();
                    data.Add(result);
                }

                );
        }


        // heavy operation
        static int Calculate(int max= 3000000)
        {
            return Enumerable.Range(2, 3000000).Count(n
                     => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
        }

    }




    #endregion


}
