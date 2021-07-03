using System;
using System.Text;

namespace ProCSharpCode.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static string Repeat(this string str, int count)
        {
            return new StringBuilder(str.Length * count).Insert(0, str, count).ToString();
        }

        public static string Reverse(this string str)
        {
            var arr = str.ToCharArray();
            Array.Reverse(arr);
            return string.Concat(arr);
        }

        public static string Padding(this string str, int count = 10, string padding = "=")
        {
            string space = str.Length == 0 ? "" : " ";
            StringBuilder builder = new StringBuilder(str.Length * count + padding.Length * count * 2);
            builder.Insert(0, padding, count).Append($"{space}{str}{space}").Insert(builder.Length, padding, count);
            return builder.ToString();

        }
    }
}
