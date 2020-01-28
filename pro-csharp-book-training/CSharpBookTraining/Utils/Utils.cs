using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpBook.Utils
{
	static class CollectionUtils
	{
        public static void PrintList<T>(IEnumerable<T> list, string title = "Print List:")
        {
            Console.WriteLine(title);
            Console.WriteLine("".PadLeft(title.Length < 50 ? 50 : title.Length, '-'));

            int counter = 0;
            foreach (var item in list)
            {
                Console.WriteLine($"Item[{counter++}] = {item}");
            }
            Console.WriteLine();
        }
        public static void PrintListLine<T>(IEnumerable<T> list, string title = "Print List:")
        {

            StringBuilder builder = new StringBuilder();
            builder.Append($"{title}: {{");
            foreach (var item in list)
            {
                builder.Append($" {item},");
            }
            builder.Append(" }");
            builder.Replace(", }", " }");

            Console.WriteLine();
            Console.WriteLine(builder.ToString());
            Console.WriteLine("".PadLeft(title.Length < 50 ? 50 : title.Length, '-'));
        }
        public static void PrintSet<T>(IEnumerable<T> list, string title = "Print Set:")
        {
            Console.WriteLine(title);
            Console.WriteLine("".PadLeft(title.Length < 50 ? 50 : title.Length, '-'));

            int counter = 0;
            foreach (var item in list)
            {
                Console.WriteLine($"Item {counter++} = {item}");
            }
            Console.WriteLine();
        }

        public static void PrintSetLine<T>(IEnumerable<T> list, string title = "Print Set:")
        {
            PrintListLine(list, title);
        }

        public static void PrintDictionary<TK, TV>(IDictionary<TK, TV> dict, string title = "Print Dictionary:")
        {
            Console.WriteLine(title);
            Console.WriteLine("".PadLeft(title.Length < 50 ? 50 : title.Length, '-'));

            foreach (KeyValuePair<TK, TV> item in dict)
            {
                Console.WriteLine($"Item[{item.Key}] = {item.Value}");
            }
            Console.WriteLine();
        }

    }


}