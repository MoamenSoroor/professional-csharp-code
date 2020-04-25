using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


using static System.Environment;

namespace ProCSharpBook.SystemIO
{
    #region Count Character in Directories and Files
    // ------------------------ Count Character in Directories and Files -------------------------

    public class CountCharactersProblem
    {
        public static void Test()
        {
            string path = @"D:\Moamen\Projects\C#-Projects\pro-csharp-book-training\ProCSharpBook\ProCSharpBook";
            DirectoryCharacterCount(path, "*.cs");

        }

        public static void DirectoryCharacterCount(string path, string filter)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            Console.WriteLine($@"Directory: {dir.FullName}");
            Console.WriteLine($@"Counting Chars...");
            
            Console.WriteLine();
            Console.WriteLine($@"Full Directory Character Count is {CountChararacters(dir, filter)}");
            Console.WriteLine("-------------------------------------------------------------");
            

        }

        public static void ReportDirectoryCharacterCount(string path, string filter)
        {

            DirectoryInfo dir = new DirectoryInfo(path);
            Console.WriteLine($@"Directory: {dir.FullName}");
            Console.WriteLine($@"Counting Chars...");

            Console.WriteLine();
            Console.WriteLine($@"Full Directory Character Count is {CountChararacters(dir, filter)}");
            Console.WriteLine("-------------------------------------------------------------");


        }

        public static long CountChararacters(DirectoryInfo directory, string filter)
        {
            // get all files in directory recursively
            FileInfo[] files = directory.GetFiles(filter, SearchOption.AllDirectories);

            // Count character in each file 
            var query = from file in files.AsParallel().WithDegreeOfParallelism(4) select CountCharacters(file);

            return query.Sum();

        }

        public static long CountCharacters(FileInfo file)
        {
            try
            {
                // Count character in each file 
                using (StreamReader reader = new StreamReader(file.OpenRead()))
                {
                    long count = reader.ReadToEnd().LongCount();
                    Console.WriteLine($@"File: {file.FullName} has {count} Character");
                    return count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception With File {0}: {1}", file.FullName, ex.Message);
                return 0;
            }

        }
    }

    // --------------------------------------------------------------
    #endregion

}
