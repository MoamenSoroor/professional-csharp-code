using System;
using System.Linq;
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

        public static string CustomPadding(this string str, int count = 10, string padding = "=")
        {
            string space = str.Length == 0 ? "" : " ";
            StringBuilder builder = new StringBuilder(str.Length * count + padding.Length * count * 2);
            builder.Insert(0, padding, count).Append($"{space}{str}{space}").Insert(builder.Length, padding, count);
            return builder.ToString();

        }

        public static string Padding(this string str, int count, string padding = " ")
        {
            StringBuilder builder = new StringBuilder(str.Length * count + padding.Length * count * 2);
            builder.Insert(0, padding, count).Append(str).Insert(builder.Length, padding, count);
            return builder.ToString();

        }

        public static string[] SplitAt(this string str, params int[] indices)
        {
            #region old implementation wrong in wasting the memory

            //if (str == null)
            //    throw new ArgumentNullException("string can't be null");

            //var ordered = indices
            //    .Select(ind =>
            //        ind > str.Length - 1 ? throw new IndexOutOfRangeException("one of indices is out of range") : ind)
            //    .OrderBy(ind => ind)
            //    .Prepend(0)
            //    .Append(str.Length)
            //    .ToArray();

            //var preparedIndices = ordered.Take(ordered.Length-1).Select((o, i) =>
            //{
            //    var prepared = ordered.Skip(i).Take(2).ToArray();
            //    return new { Next = prepared?[1]??prepared[0] , Previous = prepared[0] };
            //}).ToList();

            ////preparedIndices.RemoveAt(preparedIndices.Count - 1);

            //return preparedIndices.Select(o => str.Substring(o.Previous,o.Next - o.Previous) ).ToArray();

            ////arr.Append(str.Length).Select((a,i)=> string.Concat(str.Skip(i ==0 ?0:arr[i-1] ).Take(a- (i == 0 ? 0 : arr[i - 1]))) ).ToList()

            #endregion


            if (str == null)
                throw new ArgumentNullException("string can't be null");

            var ordered = indices
                .Select(ind =>
                    ind > str.Length - 1 ? throw new IndexOutOfRangeException("one of indices is out of range") : ind)
                .OrderBy(ind => ind)
                .Prepend(0)
                .Append(str.Length);
            var preparedIndices = ordered.SkipLast(1).Select((o, i) =>
            {
                var prepared = ordered.Skip(i).Take(2);
                return new { Next = prepared.Last(), Previous = prepared.First() };
            });

            return preparedIndices.Select(o => str.Substring(o.Previous, o.Next - o.Previous)).ToArray();
        }
        
        public static string[] SplitEvery(this string str, int count)
        {
            if (str == null)
                throw new ArgumentNullException("string can't be null");

            if (count <= 0) throw new ArgumentException("count can't be less than 1");
            //if (count == 1) return str.ToCharArray().Select(c => $"{c}").ToArray();

            int max = str.Length / count;
            int appendCount = str.Length % count;
            var result = new string[max + (appendCount == 0 ? 0 : 1)];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = str.Substring(i * count, ((appendCount != 0 && i == result.Length - 1) ? appendCount : count));
            }

            return result;
        }




    }
}
