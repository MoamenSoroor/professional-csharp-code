using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpBook.ExtensionMethods
{

    #region Understanding Extension Methods
    // ------------------------ Understanding Extension Methods -------------------------
    //NET 3.5 introduced the concept of extension methods, which allow you to add new methods or properties
    //to a class or structure, without modifying the original type in any direct manner.So, where might this be
    //helpful? Consider the following possibilities.
    //First, say you have a given class that is in production.It becomes clear over time that this class should
    //support a handful of new members.If you modify the current class definition directly, you risk the possibility
    //of breaking backward compatibility with older codebases making use of it, as they might not have been
    //compiled with the latest and greatest class definition. One way to ensure backward compatibility is to create
    //a new derived class from the existing parent; however, now you have two classes to maintain.As we all know,
    //code maintenance is the least glamorous part of a software engineer’s job description.
    //Now consider this situation.Let’s say you have a structure (or maybe a sealed class) and want to add
    //new members so that it behaves polymorphically in your system.Since structures and sealed classes cannot
    //be extended, your only choice is to add the members to the type, once again risking backward compatibility!
    //Using extension methods, you are able to modify types without subclassing and without modifying the
    //type directly.The catch is that the new functionality is offered to a type only if the extension methods have
    //been referenced for use in your current project.

    //    Defining Extension Methods
    // ====================================================================
    //When you define extension methods, the first restriction is that they must be defined within a static class
    //therefore, each extension method must be declared with the static keyword.The second
    //point is that all extension methods are marked as such by using the this keyword as a modifier on the first
    //(and only the first) parameter of the method in question. The “this qualified” parameter represents the item
    //being extended.

    // ---------------<<< Note >>>-------------------
    //understand that a given extension method can have multiple parameters, but only the first parameter
    //can be qualified with this. the additional parameters would be treated as normal incoming parameters for use
    //by the method
    // -----------------------------------------------

    //    Importing Extension Methods
    // ====================================================================
    //When you define a class containing extension methods, it will no doubt be defined within a.NET
    //namespace.If this namespace is different from the namespace using the extension methods, you will need
    //to make use of the expected C# using keyword. When you do, your code file has access to all extension
    //methods for the type being extended.This is important to remember because if you do not explicitly import
    //the correct namespace, the extension methods are not available for that C# code file.

    //    Extending Types Implementing Specific Interfaces
    // ====================================================================
    //At this point, you have seen how to extend classes (and, indirectly, structures that follow the same syntax)
    //with new functionality via extension methods.It is also possible to define an extension method that can only
    //extend a class or structure that implements the correct interface. 

    // Benefits of that Language Feature
    // ====================================================================
    // Remember that this particular language feature can be useful whenever you want to extend
    // the functionality of a type but do not want to subclass
    // (or cannot subclass if the type is sealed), for the purposes of polymorphism.As you will see later in the text,
    // extension methods play a key role for LINQ APIs.


    // Important points for the use of extension methods
    // ====================================================================
    // - An extension method must be defined in a top-level static class.
    // - An extension method with the same name and signature as an instance method will not be called.
    // - Extension methods cannot be used to override existing methods.
    // - The concept of extension methods cannot be applied to fields, properties or events.
    // - Overuse of extension methods is not a good style of programming.

    // ---------------------------------------------------------------------------
    #endregion

    static class MyExtensions
    {
        public static string Repeat(this string str, int count)
        {
            return new StringBuilder(str.Length * count).Insert(0, str, count).ToString();
        }

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

        // This method allows any integer to reverse its digits.
        // For example, 56 would return 65.
        public static int ReverseDigits(this int integer)
        {
            // Translate int into a string, and then
            // get all the characters.
            char[] digits = integer.ToString().ToCharArray();
            // Now reverse items in the array.
            Array.Reverse(digits);
            // Put back into string.
            string newDigits = new string(digits);
            // Finally, return the modified string back as an int.
            return int.Parse(newDigits);

        }

        // With Custom and .Net Interfaces

        // System.Collections.IEnumerable Inteface
        public static void PrintDataAndBeep(this IEnumerable iterator)
        {
            foreach (var item in iterator)
            {
                Console.WriteLine(item);
                Console.Beep();
            }
        }

    }

    static class MyExtensionMethods
    {
        public static void Test()
        {
            Console.WriteLine("********* Invoking Extension Methods *********\n");

            string str1 = "Moamen";
            // use string Extension Method with strings only, 
            // and if you try another type you will face Compiler Error
            Console.WriteLine($@"str1.Repeat(3): {str1.Repeat(3)}");
            Console.WriteLine($@"str1.Repeat(4): {str1.Repeat(4)}");
            Console.WriteLine($@"str1.Repeat(5): {str1.Repeat(5)}");


            Console.WriteLine($@"""Hello"".Repeat(3): {"Hello".Repeat(3)}");

            int num = 12345;
            // use int Extension Method with ints only, 
            // and if you try another type you will face Compiler Error
            Console.WriteLine($@"num.ReverseDigits(): {num.ReverseDigits()}");

            // use object Extension Method with strings and ints,...etc any type;
            Console.WriteLine($@"str1.GetObjectInfo(): {str1.GetObjectInfo()}");
            Console.WriteLine($@"num.GetObjectInfo(): {num.GetObjectInfo()}");


            Console.WriteLine("***** Extending Interface Compatible Types *****\n");
            // System.Array implements IEnumerable!
            string[] data = { "Wow", "this", "is", "sort", "of", "annoying",
                                "but", "in", "a", "weird", "way", "fun!"};
            data.PrintDataAndBeep();
            Console.WriteLine();
            // List<T> implements IEnumerable!
            List<int> myInts = new List<int>() { 10, 15, 20 };
            myInts.PrintDataAndBeep();
            

        }

    }

    


}
