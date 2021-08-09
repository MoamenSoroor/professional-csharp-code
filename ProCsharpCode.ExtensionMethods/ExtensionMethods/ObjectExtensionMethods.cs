using System;
using System.Linq;
using System.Text;

namespace ProCSharpCode.ExtensionMethods
{
    public static class ObjectExtensionMethods
    {
        public static string GetObjectInfo(this object obj)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("object info:");
            builder.AppendLine("------------");
            builder.AppendLine($@"obj.GetType().Name---------------: {obj.GetType().Name}");
            builder.AppendLine($@"obj.GetType().BaseType.Name------: {obj.GetType().BaseType.Name}");
            builder.AppendLine($@"obj.GetType().Namespace----------: {obj.GetType().Namespace}");
            builder.AppendLine($@"obj.GetType().Assembly.GetName()-: {obj.GetType().Assembly.GetName()}");
            builder.AppendLine();
            return builder.ToString();
        }

        /// <summary>
        /// alike in operator in python programming language, that checks if an item is exists in an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool In<T>(this T item, params T[] items)
        {
            if (items == null)
                throw new ArgumentNullException("items");

            return items.Contains(item);
        }

    }
}
