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

        public static string FormatWithLine(string txt, int lineLength = 80)
        {
            var NL = Environment.NewLine; // new line
            var text = txt.Replace(NL, " ");

            StringBuilder builder = new StringBuilder(text.Length);
            builder.Append(text);

            var indexes = Enumerable.Range(1, text.Length / lineLength - 1)
                .Select(v=> v*lineLength).ToList();

            Console.WriteLine(string.Join(", ", indexes));
            indexes = indexes.Select(index => text.LastIndexOf(' ', index)).ToList();
            Console.WriteLine(string.Join(", ",indexes));

            var strs = indexes.Select((a, i) =>
            {
                if(i == 0)
                    return text.Substring(0, a);
                else
                    return text.Substring(indexes[i-1], a - indexes[i - 1]);
            }).ToList();

            //var textArr = indexes.SelectMany(i=> text.)
            //indexes.Select((x,i) => builder.Insert(x+i*NL.Length, NL)).Count();
            //return builder.ToString();
            return string.Join(NL, strs);
        }

        static  void TestFormat()
        {
            var data = "hello form moamen mohammed gamal, hello world , happy day, good morning" +
                " hello moamen , hello ahmed, gamal samil , alex, cairo ahmed gamal samir waleed mohammed";


            var result = FormatWithLine(data, 12);
            Console.WriteLine(result);
        }



    }
}
