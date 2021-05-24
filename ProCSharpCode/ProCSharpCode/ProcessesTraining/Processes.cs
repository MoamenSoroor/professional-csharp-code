using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Runtime.Remoting.Contexts;

namespace ProCSharpCode.ProcessesTraining
{
    #region Processes Manipulator



    class Processes
    {

        public static void Test()
        {
            Console.WriteLine("List All Running Processes: ");
            ListAllRunningProcesses();

            // Prompt user for a PID and print out the set of active threads.
            Console.WriteLine("***** Enter PID of process to investigate *****");
            Console.Write("PID: ");
            string pID = Console.ReadLine();
            int theProcID = int.Parse(pID);

            GetSpecificProcess(theProcID);
            EnumThreadsForPid(theProcID);
            EnumModsForPid(theProcID);
            StartAndKillProcess();
        }


        static void ListAllRunningProcesses()
        {
            var processes = from proc in Process.GetProcesses(".") orderby proc.Id select proc;

            Console.WriteLine(" PID        ProcessName");
            Console.WriteLine("********************************************");
            foreach (var item in processes)
            {
                Console.WriteLine($" {item.Id}   {item.ProcessName}");
            }
            Console.WriteLine("********************************************");
        }


        // If there is no process with the PID of 987, a runtime exception will be thrown.
        static void GetSpecificProcess(int id)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(id);

                Console.WriteLine($" Process:[ ID: {theProc.Id},Name: {theProc.ProcessName} ]");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void EnumThreadsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            // List out stats for each thread in the specified process.
            Console.WriteLine("Here are the threads used by: {0}", theProc.ProcessName);
            ProcessThreadCollection theThreads = theProc.Threads;

            foreach (ProcessThread pt in theThreads)
            {
                string info =
                    $"-> Thread ID: {pt.Id}\tStart Time: {pt.StartTime.ToShortTimeString()}\tPriority: {pt.PriorityLevel}";
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************\n");
        }

        static void EnumModsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Here are the loaded modules for: {0}", theProc.ProcessName);
            ProcessModuleCollection theMods = theProc.Modules;
            foreach (ProcessModule pm in theMods)
            {
                string info = $"-> Mod Name: {pm.ModuleName}";
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************\n");
        }

        static void StartAndKillProcess()
        {
            Process ffProc = null;

            // Launch Google Chrome and go to facebook!
            try
            {
                ProcessStartInfo startInfo =
                    new ProcessStartInfo("chrome.exe", "www.facebook.com")
                    {
                        WindowStyle = ProcessWindowStyle.Maximized
                    };

                ffProc = Process.Start(startInfo);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("--> Hit enter to kill {0}...", ffProc.ProcessName);
            Console.ReadLine();

            // Kill the chrome.exe process.
            try
            {
                ffProc.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
    #endregion

    #region Interacting with the Default Application Domain
    // ------------------------ Interacting with the Default Application Domain -------------------------

    public class DefaultAppDomain
    {
        // Test Method
        public static void Test()
        {
            Console.WriteLine("***** Fun with the default app domain *****\n");
            InitDefaultAppDomain();
            DisplayDefaultAppDomainStats();
            ListAllAssembliesInAppDomain();
            Console.WriteLine("---------------------- end ---------------------- ");
        }



        #region Display stats of default app domain
        private static void DisplayDefaultAppDomainStats()
        {
            // Get access to the app domain for the current thread.

            AppDomain defaultAD = AppDomain.CurrentDomain;

            // Print out various stats about this domain.
            Console.WriteLine("Name of this domain: {0}", defaultAD.FriendlyName);
            Console.WriteLine("ID of domain in this process: {0}", defaultAD.Id);
            Console.WriteLine("Is this the default domain?: {0}", defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain: {0}", defaultAD.BaseDirectory);
        }
        #endregion

        #region List All Assemblies In AppDomain
        static void ListAllAssembliesInAppDomain()
        {
            // Get access to the app domain for the current thread.
            AppDomain defaultAD = AppDomain.CurrentDomain;

            var assemblies = from asm in defaultAD.GetAssemblies()
                             orderby asm.GetName().Name
                             select asm;
            Console.WriteLine("***** Here are the assemblies loaded in {0} *****\n", defaultAD.FriendlyName);
            foreach (Assembly item in assemblies)
            {
                Console.WriteLine($"Name----: {item.GetName().Name}");
                Console.WriteLine($"Version-: {item.GetName().Version}");
                Console.WriteLine();
            }

        }
        #endregion


        public static void InitDefaultAppDomain()
        {
            // This logic will print out the name of any assembly
            // loaded into the applicaion domain, after it has been
            // created. 
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.AssemblyLoad += (o, s) =>
            {
                Console.WriteLine("{0} has been loaded!", s.LoadedAssembly.GetName().Name);
            };
        }

        private static void DefaultAD_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("{0} has been loaded!", args.LoadedAssembly.GetName().Name);
        }
    }

    // --------------------------------------------------------------
    #endregion

    #region  Interacting with Custom AppDomains
    // ------------------------  Interacting with Custom AppDomains -------------------------

    public class CustomAppDomains
    {
        // Test Method
        public static void Test()
        {
            Console.WriteLine("***** Fun with Custom App Domains *****\n");

            // Show all loaded assemblies in default app domain.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.ProcessExit += (o, s) =>
            {
                Console.WriteLine("Default AD unloaded!");
            };

            ListAllAssembliesInAppDomain(defaultAD);

            MakeNewAppDomain();

        }

        #region Make new AD
        static void MakeNewAppDomain()
        {
            // Make a new AppDomain in the current process.
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");
            newAD.DomainUnload += (o, s) =>
            {
                Console.WriteLine("The second app domain has been unloaded!");
            };

            try
            {
                // Now load CarLibrary.dll into this new domain.
                newAD.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // List all assemblies. 
            ListAllAssembliesInAppDomain(newAD);

            // Now tear down this app domain.
            AppDomain.Unload(newAD);
        }
        #endregion

        #region List ASMS in AD
        static void ListAllAssembliesInAppDomain(AppDomain ad)
        {
            // Now get all loaded assemblies in the default app domain. 
            var loadedAssemblies = from a in ad.GetAssemblies()
                                   orderby a.GetName().Name
                                   select a;

            Console.WriteLine("***** Here are the assemblies loaded in {0} *****\n",
              ad.FriendlyName);
            foreach (var a in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", a.GetName().Name);
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
            }
        }
        #endregion

    }

    // --------------------------------------------------------------
    #endregion

    #region Understanding Object Context Boundaries
    // ------------------------ Understanding Object Context Boundaries -------------------------
    // In a nutshell, a.NET context provides a way for a single AppDomain to establish 
    // a “specific home” for a given object.
    //
    //
    // Using context, the CLR is able to ensure that objects that have special runtime requirements are
    // handled in an appropriate and consistent manner by intercepting method invocations into and out of a
    // given context.

    // For example, if you define a C# class type that requires automatic
    // thread safety(using the [Synchronization] attribute), the CLR will 
    // create a “synchronized context” during allocation.

    // Just as a process defines a default AppDomain, every application domain has a default context. This
    // default context(sometimes referred to as context 0, given that it is always the first context created within an
    // application domain) is used to group together.NET objects that have no specific or unique contextual needs.
    // As you might expect, a vast majority of .NET objects are loaded into context 0. If the CLR determines a newly
    // created object has special needs, a new context boundary is created within the hosting application domain.

    // Context-Agile and Context-Bound Types:
    // --------------------------------------
    // Context-Agile: 
    // .NET objects that do not demand any special contextual treatment are termed context-agile objects.These
    // objects can be accessed from anywhere within the hosting AppDomain without interfering with the
    // object’s runtime requirements.Building context-agile objects is easy, given that you simply do nothing
    // (specifically, you do not adorn the type with any contextual attributes and do not derive from the System.
    // ContextBoundObject base class). Here’s an example:
    // 
    // A context-agile object is loaded into context zero.
    class SportsCar0 { }
    // 
    // Context-Bound:
    // --------------
    // On the other hand, objects that do demand contextual allocation are termed context-bound objects, and
    // they must derive from the System.ContextBoundObject base class. 
    // 
    // In addition to deriving from System.ContextBoundObject, a context-sensitive type will also be adorned
    // by a special category of.NET attributes termed (not surprisingly) context attributes.All context attributes
    // derive from the ContextAttribute base class.

    // Defining a Context-Bound Object
    // -------------------------------
    // Assume that you want to define a class (SportsCarTS) that is automatically thread safe in nature.
    //  To do so, derive from ContextBoundObject and apply the[Synchronization] attribute as follows:

    [Synchronization] // inherited from ContextAttribute
    public class SportsCarTS0 : ContextBoundObject
    {
        public SportsCarTS0() { }
    }

    // Types that are attributed with the [Synchronization] attribute 
    // are loaded into a thread-safe context.
    // --------------------------------------------------------------
    #endregion

    #region Inspecting an Object’s Context
    // ------------------------ Inspecting an Object’s Context -------------------------

    class SportsCar 
    {
        public SportsCar()
        {
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in Context ID: {1}", this.ToString(), ctx.ContextID);

            foreach (IContextProperty property in ctx.ContextProperties)
            {
                Console.WriteLine(" Ctx Prop: {0}", property.Name);
            }
            Console.WriteLine();
        }
    
    }

    // SportsCarTS demands to be loaded in
    // a synchronization context.
    [Synchronization]
    public class SportsCarTS : ContextBoundObject
    {
        public SportsCarTS() 
        {
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in Context ID: {1}", this.ToString(), ctx.ContextID);

            foreach (IContextProperty property in ctx.ContextProperties)
            {
                Console.WriteLine(" Ctx Prop: {0}", property.Name);
            }
            Console.WriteLine();
        }
    }



    public class InspectingContexts
    {
        // Test Method
        public static void Test()
        {
            // Context-agile objects
            SportsCar car1 = new SportsCar();
            SportsCar car2 = new SportsCar();

            // Context-bound objects
            SportsCarTS carTS = new SportsCarTS();

        }


    }




    // --------------------------------------------------------------
    #endregion



    #region The new .Net Core and .Net 5 LoadContext

    // NOTE: Works ONly within .Net core or .Net 5

    // AssemblyLoadContext Class: https://docs.microsoft.com/en-us/dotnet/api/system.runtime.loader.assemblyloadcontext?view=net-5.0
    // The AssemblyLoadContext represents a load context.Conceptually, a load context creates a scope for 
    // loading, resolving, and potentially unloading a set of assemblies.

    // AssemblyLoadContext is an abstract class. The AssemblyLoadContext.Load(AssemblyName) method needs 
    // to be implemented to create a concrete class.

    // The AssemblyLoadContext exists primarily to provide assembly loading isolation.It allows multiple versions 
    // of the same assembly to be loaded within a single process.It replaces the isolation mechanisms 
    // provided by multiple AppDomain instances in the.NET Framework.

    //Note
    //AssemblyLoadContext does not provide any security features.All code has full permissions of the process.


    //  Application usage
    //  An application can create its own AssemblyLoadContext to create a custom solution for advanced scenarios.
    //  The customization focuses on defining dependency resolution mechanisms.
    
    //  The AssemblyLoadContext provides two extension points to implement managed assembly resolution:
    
    //  The AssemblyLoadContext.Load(AssemblyName) method provides the first chance for the AssemblyLoadContext 
    //  to resolve, load, and return the assembly. If the AssemblyLoadContext.Load(AssemblyName) method returns 
    //  null, the loader tries to load the assembly into the AssemblyLoadContext.Default.
    //  If the AssemblyLoadContext.Default is unable to resolve the assembly, the original AssemblyLoadContext 
    //  gets a second chance to resolve the assembly.The runtime raises the Resolving event.
    //  Additionally, the AssemblyLoadContext.LoadUnmanagedDll(String) virtual method allows customization 
    //  of the default unmanaged assembly resolution.The default implementation returns null, which causes 
    //  the runtime search to use its default search policy. The default search policy is sufficient 
    //  for most scenarios.


    class LoadContexts
    {
        static void LoadAdditionalAssembliesDifferentContexts()
        {
            //var path =
            //Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            //"ClassLibrary1.dll");
            //AssemblyLoadContext lc1 =
            //new AssemblyLoadContext("NewContext1", false);
            //var cl1 = lc1.LoadFromAssemblyPath(path);
            //var c1 = cl1.CreateInstance("ClassLibrary1.Car");
            //AssemblyLoadContext lc2 =
            //new AssemblyLoadContext("NewContext2", false);
            //var cl2 = lc2.LoadFromAssemblyPath(path);
            //var c2 = cl2.CreateInstance("ClassLibrary1.Car");
            //Console.WriteLine("*** Loading Additional Assemblies in Different Contexts ***");
            //Console.WriteLine($"Assembly1 Equals(Assembly2) {cl1.Equals(cl2)}");
            //Console.WriteLine($"Assembly1 == Assembly2 {cl1 == cl2}");
            //Console.WriteLine($"Class1.Equals(Class2) {c1.Equals(c2)}");
            //Console.WriteLine($"Class1 == Class2 {c1 == c2}");
        }

        //// output: 
        //*** Loading Additional Assemblies in Different Contexts ***
        //Assembly1 Equals(Assembly2) False
        //Assembly1 == Assembly2 False
        //Class1.Equals(Class2) False
        //Class1 == Class2 False
    }

    


    #endregion

}
