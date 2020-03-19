using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace ProCSharpBook.ProcessesTraining
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


}
