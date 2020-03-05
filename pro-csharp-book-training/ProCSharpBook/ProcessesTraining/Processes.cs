using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

                Console.WriteLine($" Process:[ ID:{theProc.Id},Name: {theProc.ProcessName} ]");
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




}
