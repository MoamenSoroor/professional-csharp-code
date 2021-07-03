using System;
using System.Collections;
using System.Collections.Generic;

namespace ProCSharpCode.ExtensionMethods
{
    /// <summary>
    /// extension methods of IEnumerable and IEnumerable&lt;T&gt;
    /// 
    /// </summary>
    public static class IEnumerableExtensionMethods
    {

        // System.Collections.IEnumerable Inteface
        public static void PrintDataAndBeep(this IEnumerable iterator)
        {
            foreach (var item in iterator)
            {
                Console.WriteLine(item);
                Console.Beep();
            }
        }


        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException("action passed to ForEach can't be null.");

            if(sequence is List<T> list)
            {
                list.ForEach(action);
                return;
            }

            foreach (var item in sequence)
            {
                action(item);
            }
        }


        public static void TestForEach()
        {
            IEnumerable<string> strs = new List<string>()
            {
                "hello","world"
            };

            strs.ForEach(s => Console.WriteLine(s));
        }

        public static void ReflectOverLinq<T>(this IEnumerable<T> resultSet, string queryType = "Query Expression")
        {
            Console.WriteLine($"========= Info about your query using {queryType} =========");
            Console.WriteLine($@"resultSet Type------: {resultSet.GetType().Name}");
            Console.WriteLine($@"resultSet Assembly--: {resultSet.GetType().Assembly.GetName().Name}");
            Console.WriteLine("".Padding(30, "-"));
            Console.WriteLine();
        }


        /// <summary>
        /// Extension Method of The Generic IEnumerable Interface to Execute Linq Queries With for each and print result to Console
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resultSet"></param>
        /// <param name="title">Header name to print it to console</param>
        public static void Execute<T>(this IEnumerable<T> resultSet, string title = "")
        {
            // Print out the results.
            Console.WriteLine($"Execute {title} Query".Padding());
            foreach (T item in resultSet)
            {
                if (item != null)
                    Console.WriteLine($@"Item: {item}");
            }
            Console.WriteLine("".Padding(30, "-"));
            Console.WriteLine();
        }
    }
}
