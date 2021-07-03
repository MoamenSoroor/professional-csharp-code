using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProCSharpCode
{
    class Scripts
    {
        public static List<string> FilterFileLines(string filePath, params string[] filter)
        {
            var data = File.ReadAllLines(filePath).Where(l => filter.Any(f => l.Contains(f))).ToList();
            return data;
        }


        public static void FilterFileLines(string sourceFilePath, string destinationFilePath, params string[] filter)
        {
            var data = File.ReadAllLines(sourceFilePath).Where(l => filter.Any(f => l.Contains(f))).ToList();
            File.WriteAllLines(destinationFilePath, data);

        }

        public static string GenerateRandomString(int length)
        {
            Random rand = new Random();
            return string.Concat(Enumerable.Repeat((char)rand.Next('A', 'Z'), length));
        }


        public static string GenerateRandomStringWithRandomChar(int length)
        {

            Random rand = new Random();
            return string.Concat(Enumerable.Range(0, length).Select(n2 => (char)rand.Next('A', 'Z')));

        }




    }
}
