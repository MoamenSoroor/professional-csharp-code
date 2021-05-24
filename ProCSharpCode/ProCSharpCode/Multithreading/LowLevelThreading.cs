using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProCSharpCode.MultiThreading
{
    

    #region Introduction
    // ------------------------ Introduction -------------------------
    // Most applications need to deal with more than one thing happening at a time(concurrency).
    // The most common concurrency scenarios are:
    // 
    // Writing a responsive user interface
    // In WPF, mobile, and Windows Forms applications, you must run timeconsuming tasks concurrently with the code that runs your user interface to
    // maintain responsiveness.
    // 
    // Allowing requests to process simultaneously
    // On a server, client requests can arrive concurrently and so must be handled in
    // parallel to maintain scalability. If you use ASP.NET, WCF, or Web Services,
    // the.NET Framework does this for you automatically. However, you still need
    // to be aware of shared state (for instance, the effect of using static variables for
    // caching).
    // 
    // Parallel programming
    // Code that performs intensive calculations can execute faster on multicore/
    // multiprocessor computers if the workload is divided between cores(Chapter 23 is dedicated to this).
    //
    // Speculative execution
    // On multicore machines, you can sometimes improve performance by predict‐
    // ing something that might need to be done, and then doing it ahead of time.
    // -------------------------------------------------------------------------
    #endregion

    #region Important Definitions
    // ------------------------ Important Definitions -------------------------
    //Threading
    //A thread is an execution path that can proceed independently of others.
    // 
    // -------------------------------------------------------------------------
    #endregion

    #region I/O-bound versus compute-bound
    // ------------------------ I/O-bound versus compute-bound -------------------------
    // I/O-Bound:
    // An operation that spends most of its time waiting for something to happen is called
    // I/O-bound—an example is downloading a web page or calling Console.ReadLine.
    //
    // Compute-Bound:
    // an operation that spends most of its time performing CPU-intensive work is called computebound.
    // -------------------------------------------------------------------------
    #endregion

    #region I/O-bound operations - synchronously And asynchronously waits
    // ------------------------ I/O-bound operations - synchronously And asynchronously waits -------------------------
    //An I/O-bound operation works in one of two ways: 
    //
    // - it either waits synchronously on the current thread until the operation 
    //      is complete(such as Console.ReadLine,Thread.Sleep, or Thread.Join)
    //
    // - or operates asynchronously, firing a callback when
    //      the operation finishes some time later.
    // 
    // -------------------------------------------------------------------------
    #endregion

    #region Blocking versus spinning
    // ------------------------ Blocking versus spinning -------------------------
    // I/O-bound operations that wait synchronously spend most of their time blocking a
    // thread.They may also “spin” in a loop periodically:
    // 
    //      while (DateTime.Now<nextStartTime)
    //      Thread.Sleep (100);
    // 
    // Leaving aside that there are better ways to do this (such as timers or signaling con‐
    // structs), another option is that a thread may spin continuously:
    // 
    //      while (DateTime.Now < nextStartTime);
    // 
    // In general, Spin is very wasteful on processor time
    // In effect, we’ve turned what should be an I/Obound operation into a compute-bound operation.
    // 
    // - spinning can be effective when you expect a condition to be satisfied soon
    //   (perhaps within a few microseconds), because it avoids the overhead and 
    //   latency of acontext switch.
    //   The .NET Framework provides special methods and classes to 
    //   assist—see “SpinLock and SpinWait”
    // 
    // - Second, blocking does not incur a zero cost. This is because
    //   each thread ties up around 1 MB of memory for as long as it
    //   lives and causes an ongoing administrative overhead for the
    //   CLR and operating system.For this reason, blocking can be
    //   troublesome in the context of heavily I/O-bound programs
    //   that need to handle hundreds or thousands of concurrent
    //   operations.
    //

    // -------------------------------------------------------------------------
    #endregion

    #region Create a Thread
    // ------------------------ Create a Thread -------------------------

    public class CreateThread
    {

        // Test Method
        public static void Test()
        {
            // Create a Thread
            Thread thread1 = new Thread(new ThreadStart(WriteY));
            thread1.Start();  // start thread execution


            // Write X
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("X");
            }

        }
        public static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("Y");
            }
        }




    }

    // --------------------------------------------------------------
    #endregion

    #region Sleep And Yield
    // ------------------------ Sleep And Yield -------------------------
    // Thread.Sleep pauses the current thread for a specified period:
    // --------------------------------------------------------------------
    //      Thread.Sleep(TimeSpan.FromHours (1));   // Sleep for 1 hour
    //      Thread.Sleep(500);  // Sleep for 500 milliseconds
    // --------------------------------------------------------------------
    // Note: 
    // - Thread.Sleep(0) relinquishes the thread’s current time slice immediately, voluntarily 
    //   handing over the CPU to other threads.
    // 
    // - Thread.Yield() does the same thing except that 
    //   it relinquishes only to threads running on the same processor.
    // 
    // Sleep(0) or Yield is occasionally useful in production code
    // for advanced performance tweaks.It’s also an excellent diag‐
    // nostic tool for helping to uncover thread safety issues: if
    // inserting Thread.Yield() anywhere in your code breaks the
    // program, you almost certainly have a bug.
    public class SleepAndYield
    {

        // Test Method
        public static void Test()
        {
            Console.WriteLine("Wait For a 3 Seconds...");
            // Thread.Sleep pauses the current thread for a specified period

            // with milliseconds
            Thread.Sleep(1000); // sleep for 1 second

            // with TimeSpan struct
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.Write("Mission Complete.");

        }

    }

    #endregion

    #region Join and Sleep
    // ------------------------ Join and Sleep -------------------------

    public class JoinAndSleep
    {

        // Test Method
        public static void Test()
        {
            Thread t = new Thread(new ThreadStart(GO));
            t.Start();
            t.Join();   // with join this thread will wait for t to end
            Console.WriteLine("t thread has ended");

        }

        public static void GO()
        {
            Console.WriteLine("Wait For a 3 Seconds...");
            // Thread.Sleep pauses the current thread for a specified period

            // with milliseconds
            Thread.Sleep(1000); // sleep for 1 second

            // with timeSpan struct
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.Write("Mission Complete.");
        }


    }

    #endregion

    #region Join With Timeout
    // ------------------------ Join With Timeout -------------------------
    // You can include a timeout when calling Join, either in milliseconds or as a
    // TimeSpan.It then returns true if the thread ended or false if it timed out.
    // 
    public class JoinWithTimeout
    {

        // Test Method
        public static void Test()
        {
            Thread t = new Thread(new ThreadStart(GO));

            // start thread execution
            t.Start();

            // It returns true if the thread ended or false if it timed out.
            bool isEnded = t.Join(1000); 
            Console.WriteLine(isEnded? "t thread has ended" : "t thread timed out");

        }

        public static void GO()
        {
            Console.WriteLine("Wait For a 3 Seconds...");
            // Thread.Sleep pauses the current thread for a specified period
            Thread.Sleep(1000); // sleep for 1 second
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.Write("Mission Complete.");
        }


    }

    #endregion

    #region Blocking, and ThreadState property, and IsAlive Property
    // ------------------------ Blocking -------------------------
    // While waiting on a Sleep or Join, a thread is blocked.
    // A thread is deemed blocked when its execution is paused for some reason, such as
    // when Sleeping or waiting for another to end via Join.

    // A blocked thread immediately yields its processor time slice, and 
    // from then on consumes no processor time until its blocking condition is satisfied.

    // You can test for a thread being blocked via its ThreadState property
    // also you can use IsAlive Property but, The ThreadState property provides 
    // more specific information than the IsAlive property.
    public class Blocking
    {
        // Test Method
        public static void Test()
        {
            Thread newThread = new Thread(() =>
            {
                Thread.Sleep(1000);
            });

            Console.WriteLine("------- Before Start --------");
            Console.WriteLine("ThreadState: {0}", newThread.ThreadState);
            Console.WriteLine("IsAlive    : {0}", newThread.IsAlive);

            newThread.Start();

            Console.WriteLine("------- After Start --------");
            Console.WriteLine("ThreadState: {0}", newThread.ThreadState);
            Console.WriteLine("IsAlive    : {0}", newThread.IsAlive);

            // Wait for newThread to start and go to sleep.
            Thread.Sleep(300);
            Console.WriteLine("------- maybe Sleep --------");
            Console.WriteLine("ThreadState: {0}", newThread.ThreadState);
            Console.WriteLine("IsAlive    : {0}", newThread.IsAlive);
            Console.WriteLine();

            // Wait for newThread to restart.
            Thread.Sleep(1000);
            Console.WriteLine("------- should be Stopped --------");
            Console.WriteLine("ThreadState: {0}", newThread.ThreadState);
            Console.WriteLine("IsAlive    : {0}", newThread.IsAlive);



        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Local Versus Shared State: Local State Case
    // ------------------------ Local Versus Shared State -------------------------
    // The CLR assigns each thread its own memory stack so that local variables are kept separate
    public class LocalState
    {
        // Test Method
        public static void Test()
        {
            new Thread(Go).Start();     // Call Go in a new Thread
            Go();                       // Call Go on Main Thread

        }

        // A separate copy of the cycles variable is created on each thread’s memory stack
        static void Go()
        {
            for (int cycle = 0; cycle < 5; cycle++)
            {
                Console.Write("?");

            }
        }

    }
    // -------------------------------------------------------------------------
    #endregion

    #region Local Versus Shared State: Instance Case 
    // ------------------------ Local Versus Shared State: Instance Case -------------------------
    // Threads share data if they have a common reference to the same object instance
    public class SharedState
    {
        bool done = false;
        // Test Method
        public static void Test()
        {
            SharedState shared = new SharedState();
            new Thread(shared.Go).Start();      // Call instance method Go in the new thread
            shared.Go();                        // Call the same instance method again with the same object

        }

        void Go()
        {
            if (!done)
            {
                done = true;
                Console.WriteLine("Done!");
            }
        }
    }
    // -------------------------------------------------------------------------
    #endregion

    #region Local Versus Shared State: Lamda Expression and Delegate Case
    // ------------------------ Local Versus Shared State: Lamda Expression and Delegate Case -------------------------
    // Local variables captured by a lambda expression or anonymous delegate are converted 
    // by the compiler into fields, and so can also be shared
    public class LambdaSharedState
    {

        // Test Method
        public static void Test()
        {
            bool done = false;
            ThreadStart action = () =>
            {
                if (!done) { done = true; Console.WriteLine("Done"); }
            };

            new Thread(action).Start();     // Call action delegate in the new thread
            action();                       // Call action delegate in the main thread


        }

    }
    // -------------------------------------------------------------------------
    #endregion

    #region Local Versus Shared State: Static Case 
    // ------------------------ Local Versus Shared State: Static Case -------------------------
    // Static fields offer another way to share data between threads:
    public class StaticSharedState
    {

        static bool done = false;
        // Test Method
        public static void Test()
        {
            new Thread(Go).Start();
            Go();

        }

        static void Go()
        {
            if (!done)
            {
                done = true;
                Console.WriteLine("Done!");
            }
        }

    }
    // -------------------------------------------------------------------------
    #endregion

    #region Lack Of Thread Safety In Shared State
    // ------------------------ Lack Of Thread Safety In Shared State -------------------------
    // The output is actually indeterminate: it’s possible(though unlikely) that
    // “Done” could be printed twice.
    public class LackOfThreadSafetyInSharedState
    {
        bool done = false;
        // Test Method
        public static void Test()
        {
            LackOfThreadSafetyInSharedState shared = new LackOfThreadSafetyInSharedState();
            new Thread(shared.Go).Start();      // Call instance method Go in the new thread
            shared.Go();                        // Call the same instance method again with the same object

        }

        void Go()
        {
            if (!done)
            {

                // The problem is that one thread can be evaluating the if statement right as the other
                // thread is executing the WriteLine statement—before it’s had a chance to set done to true.
                Console.WriteLine("Done!"); // print Done! before assign done to true
                done = true;
            }
        }
    }

    // We’ll see next how to fix our program
    // with locking; 

    // however it’s better to avoid shared state altogether where possible.

    // -------------------------------------------------------------------------
    #endregion

    #region Locking and Thread Safety
    // ------------------------ Locking and Thread Safety -------------------------
    // We can fix the previous example by obtaining an exclusive lock while reading and
    // writing to the shared field.C# provides the lock statement for just this purpose.

    public class ThreadSafe
    {
        static bool done = false;
        static readonly object locker = new object();

        // Test Method
        public static void Test()
        {
            done = false;
            new Thread(Go).Start();
            Go();

        }

        static void Go()
        {
            lock(locker)
            {
                if (!done) 
                {
                    Console.WriteLine("Done!");
                    done = true;
                }
            }
        }

    }
    // When two threads simultaneously contend a lock (which can be upon any
    // reference-type object, in this caone thread waits, or blocks, until these, locker), 
    // lock becomes available. In this case, it ensures only one thread can enter its code
    // block at a time, and “Done” will be printed just once.Code that’s protected in such
    // a manner—from indeterminacy in a multithreaded context—is called thread-safe

    // Note: Locking is not a silver bullet for thread safety—it’s easy to forget to lock around
    //       accessing a field, and locking can create problems of its own(such as deadlocking)
    // --------------------------------------------------------------
    #endregion

    #region Passing Data to a Thread via Lamda Expression
    // ------------------------ Passing Data to a Thread via Lamda Expression -------------------------
    // Sometimes you’ll want to pass arguments to the thread’s startup method.
    // The easiest way to do this is with a lambda expression that calls the 
    // method with the desired arguments:
    public class PassingDataToThread
    {
        // Test Method
        public static void Test()
        {
            // Using Lamda Expression
            new Thread(() => Print("Hello World!")).Start();

        }

        public static void Print(string message)
        {
            Console.WriteLine(message);
        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Passing Data to a Thread Start method via ParameterizedThreadStart Delegate
    // ------------------------  Passing Data to a Thread Start method via ParameterizedThreadStart Delegate -------------------------
    // Lambda expressions didn’t exist prior to C# 3.0. So you might also come across an
    // old-school technique, which is to pass an argument into Thread’s Start method

    
    public class PassingDataToStartMethod
    {
        // Test Method
        public static void Test()
        {
            ParameterizedThreadStart function = new ParameterizedThreadStart(Print);
            Thread thread1 = new Thread(function);  // or Simply use Method Group Conversion Syntax

            // Pass 
            thread1.Start("Hello From Start Method!");
        }

        public static void Print(object obj)
        {
            // We need to cast here
            string message = (string)obj;
            Console.WriteLine(message);
        }
    }

    // This works because Thread’s constructor is overloaded to accept either of two delegates:
    // public delegate void ThreadStart();
    // public delegate void ParameterizedThreadStart(object obj);
    // The limitation of ParameterizedThreadStart is that it accepts only one argument.
    // And because it’s of type object, it usually needs to be cast.
    // --------------------------------------------------------------
    #endregion

    #region Lambda expressions and captured variables
    // ------------------------ Lambda expressions and captured variables -------------------------
    // a lambda expression is the most convenient and powerful way to pass
    // data to a thread.However, you must be careful about accidentally 
    // modifying captured variables after starting the thread.     
    
    public class CapturedVariables
    {
        // Test Method
        public static void Test()
        {
            for (int i = 0; i < 10; i++)
                new Thread(() => Console.Write(i)).Start(); // The output is nondeterministic!


            // wait for a time until the previous threads finish
            Thread.Sleep(3000);
            Console.WriteLine();

            // The problem is that the i variable refers to the same memory location throughout
            // the loop’s lifetime. Therefore, each thread calls Console.Write on a variable whose
            // value may change as it is running!The solution is to use a temporary variable as
            // follows:

            for (int i = 0; i < 10; i++)
            {
                int temp = i;   // each lamda has it's own variable and i not captured
                new Thread(() => Console.Write(temp)).Start();

            }


        }

        public static void AnotherExample()
        {
            string txt = "t1";
            Thread thread1 = new Thread(() => Console.WriteLine(txt));


            txt = "t2";
            Thread thread2 = new Thread(() => Console.WriteLine(txt));

            // the both will print t2 not t1
            thread1.Start();
            thread2.Start();
        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Exception Handling
    // ------------------------ Exception Handling -------------------------
    // Any try/catch/finally blocks in effect when a thread is created are of no relevance
    // to the thread when it starts executing.

    public class ExceptionHandling
    {
        // Test Method
        public static void Test()
        {
            try
            {
                new Thread(Go).Start();
            }
            catch (Exception ex)
            {
                // We'll never get here!
                Console.WriteLine("Exception!");
            }

        }

        static void Go()    
        {
            throw null;     // Throws a NullReferenceException
        }
    }
    // The try/catch statement in this example is ineffective, and the newly created
    // thread will be encumbered with an unhandled NullReferenceException. This
    // behavior makes sense when you consider that each thread has an independent execution
    // path.

    // The Right Way to Handling Exception of a thread:
    // You need an exception handler on all thread entry methods in production applications
    // just as you do (usually at a higher level, in the execution stack) on your main thread

    // An unhandled exception causes the whole application to shut down. With
    // an ugly dialog box!
    public class CorrectExceptionHandling
    {
        // Test Method
        public static void Test()
        {
                new Thread(Go).Start();
        }

        static void Go()
        {
            try
            {
                throw null;     // Throws a NullReferenceException
            }
            catch (Exception ex)
            {
                // We'll never get here!
                Console.WriteLine("Exception!");
            }
            
        }
    }
    // --------------------------------------------------------------
    #endregion

    #region Foreground Versus Background Threads

    // ------------------------ Foreground Versus Background Threads -------------------------
    // Foreground threads keep the application alive for as long as any one of them is running, whereas
    // background threads do not.

    // Once all foreground threads finish, the application ends, and
    // any background threads still running abruptly terminate.

    // Note: A thread’s foreground/background status has no relation to its
    //       priority(allocation of execution time).
    public class BackgroundThread
    {
        // Test Method
        public static void Test()
        {
            Thread worker = new Thread(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("End of Worker Thread");
            });
            worker.IsBackground = true;
            worker.Start();
            Console.WriteLine("End of Main Thread");
        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Thread Priority
    // ------------------------ Thread Priority -------------------------
    //A thread’s Priority property determines how much execution time it gets relative
    //to other active threads in the operating system, on the following scale:
    //enum ThreadPriority { Lowest, BelowNormal, Normal, AboveNormal, Highest }

    // Elevating a thread’s priority should be done with care as it can starve other threads.

    // If you want a thread to have higher priority than threads in other processes, you must 
    // also elevate the process priority using the Process class in System.Diagnostics
    // 
    //      using (Process p = Process.GetCurrentProcess())
    //      p.PriorityClass = ProcessPriorityClass.High;
    // 
    // UseCase:
    // This can work well for non-UI processes that do minimal work and need low
    // latency(the ability to respond very quickly) in the work they do. 
    // With computehungry applications(particularly those with a user interface), elevating
    // process priority can starve other processes, slowing down the entire computer.
    // 
    // 


    class ThreadPriority
    {
        // Test
        public static void Test()
        {

        }

    }

    // -------------------------------------------------------------------------
    #endregion

    #region Signaling
    // ------------------------ Signaling -------------------------
    // Sometimes you need a thread to wait until receiving notification(s) from other
    // thread(s). This is called signaling.The simplest signaling construct is ManualReset
    // Event. Calling WaitOne on a ManualResetEvent blocks the current thread until
    // another thread “opens” the signal by calling Set.
    // 
    // After calling Set, the signal remains open; it may be closed again by calling Reset.
    public class Signaling
    {
        // Test Method
        public static void Test()
        {
            ManualResetEvent signal = new ManualResetEvent(false);

            new Thread( () =>
            {
                Thread.Sleep(3000);
                signal.Set();
                Console.WriteLine("Send Signal");
            }).Start();

            Console.WriteLine("Wait For Signal...");
            signal.WaitOne();
            signal.Dispose();
            Console.WriteLine("Got Signal");



        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Threading in Rich-Client Applications
    // ------------------------ Threading in Rich-Client Applications -------------------------

    // -------------------------------------------------------------------------
    #endregion

    #region Synchronization Contexts
    // ------------------------ Synchronization Contexts -------------------------

    // -------------------------------------------------------------------------
    #endregion

    #region The Thread Pool
    // ------------------------ The Thread Pool -------------------------
    // Whenever you start a thread, a few hundred microseconds are spent organizing
    // such things as a fresh local variable stack.The thread pool cuts this overhead by
    // having a pool of pre-created recyclable threads.Thread pooling is essential for efficient 
    // parallel programming and fine-grained concurrency; it allows short operations 
    // to run without being overwhelmed with the overhead of thread startup.

    // There are a few things to be wary of when using pooled threads:
    // • You cannot set the Name of a pooled thread, making debugging more difficult.
    // • Pooled threads are always background threads.
    // • Blocking pooled threads can degrade performance.

    // - You are free to change the priority of a pooled thread—it will 
    //   be restored to normal when released back to the pool

    // You can query if you’re currently executing on a pooled thread via the property
    // Thread.CurrentThread.IsThreadPoolThread.
    public class TheThreadPool
    {
        // Test Method
        public static void Test()
        {
            // Entering the thread pool
            Task.Run(() => Console.WriteLine("I am ThreadPool Thread!"));

            // As tasks didn’t exist prior to Framework 4.0, a common alternative is to call
            ThreadPool.QueueUserWorkItem(notused => Console.WriteLine("Hello From a ThreadPool!") );

        }


    }
    // The following use the thread pool implicitly:
    // • WCF, Remoting, ASP.NET, and ASMX Web Services application servers
    // • System.Timers.Timer and System.Threading.Timer
    // • The parallel programming constructs
    // • The(now redundant) BackgroundWorker class
    // • Asynchronous delegates(also now redundant)
    // --------------------------------------------------------------
    #endregion

    #region Hygiene in the thread pool
    // ------------------------ Hygiene in the thread pool -------------------------
    // The thread pool serves another function, which is to ensure that a temporary excess
    // of compute-bound work does not cause CPU oversubscription.Oversubscription is
    // the condition of there being more active threads than CPU cores, with the operating
    // system having to time-slice threads.Oversubscription hurts performance because
    // time-slicing requires expensive context switches and can invalidate the CPU caches
    // that have become essential in delivering performance to modern processors.
    // 
    // The CLR avoids oversubscription in the thread pool by queuing tasks and throttling
    // their startup. It begins by running as many concurrent tasks as there are hardware
    // cores, and then tunes the level of concurrency via a hill-climbing algorithm, continually 
    // adjusting the workload in a particular direction.If throughput improves, it
    // continues in the same direction (otherwise it reverses). This ensures that it always
    // tracks the optimal performance curve—even in the face of competing process activity 
    // on the computer.
    // 
    // The CLR’s strategy works best if two conditions are met:
    // • Work items are mostly short-running(<250ms, or ideally <100ms), so that the
    //   CLR has plenty of opportunities to measure and adjust.
    // • Jobs that spend most of their time blocked do not dominate the pool.
    // 
    // - For longer-running and blocked Operation, you should avoid use of a pooled thread.

    // Blocking is troublesome because it gives the CLR the false idea that it’s loading up
    // the CPU.The CLR is smart enough to detect and compensate(by injecting more
    // threads into the pool), although this can make the pool vulnerable to subsequent
    // oversubscription. It also may introduce latency, as the CLR throttles the rate at
    // which it injects new threads, particularly early in an application’s life(more so on
    // client operating systems where it favors lower resource consumption).
    // Maintaining good hygiene in the thread pool is particularly relevant when you want
    // to fully utilize the CPU
    // -------------------------------------------------------------------------
    #endregion







}
