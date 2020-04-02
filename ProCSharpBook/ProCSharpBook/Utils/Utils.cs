using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpBook.Utils
{
	static class CollectionUtils
	{
        public static void PrintList(IEnumerable list, string title = "Print List")
        {
            if (list == null)
                return;
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine("".PadLeft(title.Length < 50 ? 50 : title.Length, '-'));

            int counter = 0;
            foreach (var item in list)
            {
                Console.WriteLine($"Item[{counter++}] = {item}");
            }
            Console.WriteLine();
        }
        public static void PrintListLine(IEnumerable list, string title = "Print List")
        {
            if (list == null)
                return;
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
        
        public static void PrintSet(IEnumerable list, string title = "Print Set")
        {
            if (list == null)
                return;
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine("".PadLeft(title.Length < 50 ? 50 : title.Length, '-'));

            int counter = 0;
            foreach (var item in list)
            {
                Console.WriteLine($"Item {counter++} = {item}");
            }
            Console.WriteLine();
        }
        public static void PrintSetLine(IEnumerable list, string title = "Print Set")
        {
            PrintListLine(list, title);
        }
        public static void PrintSetInfo<T>(ISet<T> set)
        {
            if (set == null)
                return;
            if (set is SortedSet<T> s)
            {
                Console.WriteLine("SortedSet Info: ");
                Console.WriteLine("".PadLeft(40,'-'));
                Console.WriteLine($"sortedSet.Count---: {s.Count}");
                Console.WriteLine($"sortedSet.Min-----: {s.Min}");
                Console.WriteLine($"sortedSet.Max-----: {s.Max}");
                Console.WriteLine($"sortedSet.Comparer: {s.Comparer}");
            }

            else if (set is HashSet<T> hs)
            {
                Console.WriteLine($"hashSet.Count---: {hs.Count}");
                Console.WriteLine($"hashSet.Comparer: {hs.Comparer}");
            }
            else
                return;
        }


        public static void PrintDictionary<TK, TV>(IDictionary<TK, TV> dict, string title = "Print Dictionary:")
        {
            if (dict == null)
                return;
            Console.WriteLine();
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