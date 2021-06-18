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
        public static List<string> FilterFileLines(string filePath, params string []filter)
        {
            var data = File.ReadAllLines(filePath).Where(l =>  filter.Any(f=> l.Contains(f))).ToList();
            return data;
        }


        public static void FilterFileLines(string sourceFilePath,string destinationFilePath, params string[] filter)
        {
            var data = File.ReadAllLines(sourceFilePath).Where(l => filter.Any(f => l.Contains(f))).ToList();
            File.WriteAllLines(destinationFilePath, data);

        }
    }
}
