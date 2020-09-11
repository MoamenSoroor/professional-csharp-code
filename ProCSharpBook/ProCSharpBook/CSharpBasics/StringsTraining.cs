using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace ProCSharpBook.CSharpBasics
{
    public static class StringsTraining
    {
        static StringsTraining() { }

        public static void TestStrings()
        {
            #region Declaring and Initializing Strings
            // Declaring and Initializing Strings
            // You can declare and initialize strings in various ways, as shown in the following example:

            // Declare without initializing.
            string message1;

            // Initialize to null.
            string message2 = null;


            // Initialize as an empty string.
            // Use the Empty constant instead of the literal "".
            string message3 = System.String.Empty;

            //Initialize with a regular string literal.
            string oldPath = "c:\\Program Files\\Microsoft Visual Studio 8.0";

            // Initialize with a verbatim string literal.
            string newPath = @"c:\Program Files\Microsoft Visual Studio 9.0";

            // Use System.String if you prefer.
            System.String greeting = "Hello World!";

            // In local variables (i.e. within a method body)
            // you can use implicit typing.
            var temp = "I'm still a strongly-typed System.String!";

            // Use a const string to prevent 'message4' from
            // being used to store another string value.
            const string message4 = "You can't get rid of me!";

            // Use the String constructor only when creating
            // a string from a char*, char[], or sbyte*. See
            // System.String documentation for details.
            char[] letters = { 'A', 'B', 'C' };
            string alphabet = new string(letters);

            #endregion

            #region String Escape Sequence
            //            String Escape Sequences
            //-------------------------------------------------------------------------------------------------------------------
            //  Escape sequence     Character name         Unicode encoding
            //-------------------------------------------------------------------------------------------------------------------
            //  \'      Single quote	                    0x0027
            //  \"      Double quote	                    0x0022
            //  \\      Backslash                           0x005C
            //  \0      Null                                0x0000
            //  \a      Alert                               0x0007
            //  \b      Backspace                           0x0008
            //  \f      Form feed                           0x000C
            //  \n      New line                            0x000A
            //  \r      Carriage return                     0x000D
            //  \t      Horizontal tab                      0x0009
            //  \v      Vertical tab                        0x000B
            //  \u      Unicode escape sequence(UTF-16)	    \uHHHH(range: 0000 - FFFF; example: \u00E7 = "ç")
            //  \U      Unicode escape sequence(UTF-32)	    \U00HHHHHH(range: 000000 - 10FFFF; example: \U0001F47D = "👽")
            //  \x      Unicode escape sequence similar to "\u"
            //          except with variable length	\xH[H][H][H](range: 0 - FFFF; example: \x00E7 or \x0E7 or \xE7 = "ç")
            //-------------------------------------------------------------------------------------------------------------------

            Console.WriteLine("Single quote-----------------------: \'");
            Console.WriteLine("Double quote-----------------------: \"");
            Console.WriteLine("Backslash--------------------------: \\");
            Console.WriteLine("Null-------------------------------: \0");
            Console.WriteLine("Alert------------------------------: \a");
            Console.WriteLine("Backspace--------------------------: \b");
            Console.WriteLine("Form feed--------------------------: \f");
            Console.WriteLine("New line---------------------------: \n");
            Console.WriteLine("Carriage return--------------------: \r");
            Console.WriteLine("Horizontal tab---------------------: \t");
            Console.WriteLine("Vertical tab-----------------------: \v");
            Console.WriteLine("Unicode escape sequence(UTF-16)----: \u00E7");
            Console.WriteLine("Unicode escape sequence(UTF-32)----: \U000000E7");
            Console.WriteLine("Unicode escape sequence(UTF-32)----: \U0001F47D");
            Console.WriteLine("Variable Length UES(UTF-16)--------: \xE");
            // When using the \x escape sequence and specifying less than 4 hex digits, 
            // if the characters that immediately follow the escape sequence are valid hex digits (i.e. 0-9, A-F, and a-f),
            // they will be interpreted as being part of the escape sequence.

            #endregion

            #region Regular and Verbatim String Literals
            // Regular String Literal
            string columns = "Column 1\tColumn 2\tColumn 3";
            //Output: Column 1        Column 2        Column 3

            string rows = "Row 1\r\nRow 2\r\nRow 3";
            /* Output:
              Row 1
              Row 2
              Row 3
            */

            string title = "\"The \u00C6olean Harp\", by Samuel Taylor Coleridge";
            //Output: "The Æolean Harp", by Samuel Taylor Coleridge


            //---------------< Verbatim String Literal >--------------------
            //--------------------------------------------------------------------------------------

            //---------------< Escape characters are considered a character in string  >--------------------
            string filePath = @"C:\Users\scoleridge\Documents\";
            //Output: C:\Users\scoleridge\Documents\

            //---------------< initialize multiline strings  >--------------------
            string text = @"My pensive SARA ! thy soft cheek reclined
    Thus on mine arm, most soothing sweet it is
    To sit beside our Cot,...";
            /* Output:
            My pensive SARA ! thy soft cheek reclined
               Thus on mine arm, most soothing sweet it is
               To sit beside our Cot,... 
            */

            //---------------< to add double quote prefix it with another one  >--------------------
            string quote = @"Her name was ""Sara.""";
            //Output: Her name was "Sara."

            #endregion

            #region String Interpolation
            //            The curly bracket syntax illustrated within this chapter({ 0}, { 1}, and so on) has existed within the .NET
            //platform since version 1.0.Starting with the release of C# 6, C# programmers can use an alternative syntax to
            //build string literals that contain placeholders for variables.Formally, this is called string interpolation.While
            //the output of the operation is identical to traditional string formatting syntax, this new approach allows you
            //to directly embed the variables themselves, rather than tacking them on as a comma - delimited list


            // Some local variables we will plug into our larger string
            int age1 = 4;
            string name1 = "Soren";
            // Using curly bracket syntax.
            string greeting2 = string.Format("Hello {0} you are {1} years old.", name1, age1);
            // Using string interpolation
            string greeting3 = $"Hello {name1} you are {age1} years old.";



            // Another Example
            string fname = "Moamen";
            string lname = "Soroor";
            int age = 24;

            Console.WriteLine($"first name: {fname}; last name: {lname}; age: {age}");

            int radius = 10;
            const double pi = Math.PI;
            Console.WriteLine($"Area of Circle with Radius {radius}is {radius * radius * pi}");

            Console.WriteLine($" Sin(90) = {Math.Sin(90)}");
            Console.WriteLine($" Cos(90) = {Math.Cos(90)}");

            // Nested String inerpolation:
            TestGreaterOrEquals(10, 11);
            TestGreaterOrEquals(10, 9);
            TestGreaterOrEquals(10, 10);

            TestRelation(10, 11);
            TestRelation(10, 9);
            TestRelation(10, 10);


            #endregion

            #region string class static Methods and Properties
            // public static readonly String Empty;
            // public static int Compare(String strA, String strB, bool ignoreCase);
            // public static int Compare(String strA, int indexA, String strB, int indexB, int length, StringComparison comparisonType);
            // public static int Compare(String strA, int indexA, String strB, int indexB, int length, CultureInfo culture, CompareOptions options);
            // public static int Compare(String strA, int indexA, String strB, int indexB, int length, bool ignoreCase, CultureInfo culture);
            // public static int Compare(String strA, int indexA, String strB, int indexB, int length, bool ignoreCase);
            // public static int Compare(String strA, int indexA, String strB, int indexB, int length);
            // public static int Compare(String strA, String strB, bool ignoreCase, CultureInfo culture);
            // public static int Compare(String strA, String strB, CultureInfo culture, CompareOptions options);
            // public static int Compare(String strA, String strB, StringComparison comparisonType);
            // public static int Compare(String strA, String strB);
            // public static int CompareOrdinal(String strA, int indexA, String strB, int indexB, int length);
            // public static int CompareOrdinal(String strA, String strB);
            // public static String Concat(String str0, String str1);
            // public static String Concat(String str0, String str1, String str2);
            // public static String Concat(object arg0);
            // public static String Concat(String str0, String str1, String str2, String str3);
            // public static String Concat(object arg0, object arg1);
            // public static String Concat(params String[] values);
            // public static String Concat(object arg0, object arg1, object arg2, object arg3);
            // public static String Concat(params object[] args);
            // public static String Concat<T>(IEnumerable<T> values);
            // public static String Concat(IEnumerable<String> values);
            // public static String Concat(object arg0, object arg1, object arg2);
            // public static String Copy(String str);
            // public static bool Equals(String a, String b);
            // public static bool Equals(String a, String b, StringComparison comparisonType);
            // public static String Format(String format, object arg0);
            // public static String Format(String format, object arg0, object arg1, object arg2);
            // public static String Format(String format, params object[] args);
            // public static String Format(String format, object arg0, object arg1);
            // public static String Format(IFormatProvider provider, String format, object arg0, object arg1, object arg2);
            // public static String Format(IFormatProvider provider, String format, params object[] args);
            // public static String Format(IFormatProvider provider, String format, object arg0, object arg1);
            // public static String Format(IFormatProvider provider, String format, object arg0);
            // public static String Intern(String str);
            // public static String IsInterned(String str);
            // public static bool IsNullOrEmpty(String value);
            // public static bool IsNullOrWhiteSpace(String value);
            // public static String Join<T>(String separator, IEnumerable<T> values);
            // public static String Join(String separator, IEnumerable<String> values);
            // public static String Join(String separator, String[] value, int startIndex, int count);
            // public static String Join(String separator, params String[] value);
            // public static String Join(String separator, params object[] values);
            // ======================================================================================================================

            Logger.Title("public static int Compare(String strA, String strB)");
            Console.WriteLine($"{string.Compare("Moamen", "Soroor")}");
            Console.WriteLine($"{string.Compare("Moamen", "Moamen")}");
            Console.WriteLine($"{string.Compare("MOAMEN", "moamen",false)}");
            Console.WriteLine($"{string.Compare("MOAMEN", "moamen",true)}");
            Console.WriteLine($"{string.Compare("MOAMEN", "moamen", StringComparison.Ordinal)}");
            Console.WriteLine($"{string.Compare("MOAMEN", "moamen",StringComparison.OrdinalIgnoreCase)}");

            Logger.Title("public static bool Equals(String a, String b)");
            Console.WriteLine($"{string.Equals("Moamen", "Soroor")}");
            Console.WriteLine($"{string.Equals("Moamen", "Moamen")}");
            Console.WriteLine($"{string.Equals("MOAMEN", "moamen", StringComparison.Ordinal)}");
            Console.WriteLine($"{string.Equals("MOAMEN", "moamen", StringComparison.OrdinalIgnoreCase)}");

            Logger.Title("public static String Join<T>(String separator, IEnumerable<T> values);");
            Console.WriteLine($"{string.Join(",",new[] { 10, 20, 30, 40})}");
            Console.WriteLine($"{string.Join(", ",new[] { 10, 20, 30, 40})}");
            Console.WriteLine($"{string.Join(", ", "0123456789".ToCharArray())}");

            Logger.Title("public static String Join(String separator, params object[] values)");
            Console.WriteLine($"{string.Join(", ", 10,20,30,40,50,60,70)}");
            Console.WriteLine($"{string.Join(", ", 10, 20, 30, 40, 50, 60, 70)}");
            Console.WriteLine($"{string.Join(", ", 10, "Moamen", 20, "Mohammed", 30, "Gamal", 40, "Soroor")}");



            Logger.Title("public static String Join(String separator, String[] value, int startIndex, int count)");
            var strArray = new[] { "A", "B", "C", "D", "E", "F", "G" };
            Console.WriteLine($"{string.Join(", ", strArray,3,3)}");

            Logger.Title("public static String Concat(params String[] values); ");
            Console.WriteLine($"{string.Concat("Moamen","Mohammed", "Gamal" , "Soroor")}");
            Console.WriteLine($"{string.Concat(10,20,30,40,50,60)}");
            Console.WriteLine($"{string.Concat(10, true,"Hello", Math.PI)}");




            #endregion

            #region string class methods and properties
            string str = "Moamen Soroor";
            //           "0123456789012"   
            Console.WriteLine($"str = {str}");
            Console.WriteLine($"str.Length = {str.Length}");

            Console.WriteLine($@"str.Contains(""men"") = {str.Contains("men")}");
            Console.WriteLine($@"str.Contains(""Sor"") = {str.Contains("Sor")}");

            Console.WriteLine($"str.Replace('o','X') = {str.Replace('o','X')}");
            Console.WriteLine($@"str.Replace(""Sor"", ""Tor"") = {str.Replace("Sor","Tor")}");

            Console.WriteLine($"str.Remove(3) = {str.Remove(3)}");
            Console.WriteLine($@"str.Remove(3,6) = {str.Remove(3,6)}");

            Console.WriteLine($"str.ToLower() = {str.ToLower()}");
            Console.WriteLine($"str.ToUpper() = {str.ToUpper()}");

            Console.WriteLine($"str.Substring(7) = {str.Substring(7)}");
            Console.WriteLine($"str.Substring(3,3) = {str.Substring(3,3)}");

            Console.WriteLine($"str.IndexOf('M') = {str.IndexOf('M')}");
            Console.WriteLine($"str.IndexOf('m') = {str.IndexOf('m')}");
            Console.WriteLine($"str.IndexOf('o') = {str.IndexOf('o')}");
            Console.WriteLine($"str.IndexOf('r') = {str.IndexOf('r')}");
            Console.WriteLine($@"str.IndexOf(""Sor"") = {str.IndexOf("Sor")}");

            Console.WriteLine($"str.LastIndexOf('o') = {str.LastIndexOf('o')}");
            Console.WriteLine($"str.LastIndexOf('r') = {str.LastIndexOf('r')}");
            Console.WriteLine($"str.LastIndexOf('r') = {str.LastIndexOf('r')}");
            Console.WriteLine($@"str.LastIndexOf(""men"") = { str.LastIndexOf("men")}");

            Logger.Title("public int IndexOfAny(char[] anyOf, int startIndex, int count)");
            Console.WriteLine($"str.IndexOf('r') = {str.IndexOfAny(new [] {'S','e','r'})}"); ;
            Console.WriteLine($@"str.IndexOfAny(""ser"".ToCharArray()) = {str.IndexOfAny("ser".ToCharArray())}");
            Console.WriteLine($@"str.IndexOfAny(""ser"".ToCharArray(),7) = {str.IndexOfAny("ser".ToCharArray(),7)}");
            Console.WriteLine($@"str.IndexOfAny(""ser"".ToCharArray(),7,3) = {str.IndexOfAny("ser".ToCharArray(),7,3)}");

            Logger.Title("public int LastIndexOfAny(char[] anyOf, int startIndex, int count)");
            Console.WriteLine($@"str.LastIndexOfAny(""ser"".ToCharArray()) = {str.LastIndexOfAny("ser".ToCharArray())}");


            // the CompareTo method perform culture - sensitive and case-sensitive comparison
            // Better approach is to use string.Compare Static Method.
            Console.WriteLine($@"str.CompareTo(""Moamen Soroor"") = {str.CompareTo("Moamen Soroor")}");
            Console.WriteLine($@"str.CompareTo(""moamen soroor"") = {str.CompareTo("moamen soroor")}");

            Console.WriteLine($@"str.Equals(""Moamen Soroor"") = {str.Equals("Moamen Soroor")}");
            Console.WriteLine($@"str.Equals(""moamen soroor"") = {str.Equals("moamen soroor")}");

            Console.WriteLine($@"str.Equals(""Moamen Soroor"") = {str.Equals("Moamen Soroor",StringComparison.Ordinal)}");
            Console.WriteLine($@"str.Equals(""moamen soroor"") = {str.Equals("moamen soroor", StringComparison.OrdinalIgnoreCase)}");


            Logger.Title("Insert Method");
            Console.WriteLine($@"str.Insert(0, ""Mr. "") = {str.Insert(0,"Mr. ")}");
            Console.WriteLine($@"str.Insert(str.IndexOf("" ""),"" Mohammed"") = {str.Insert(str.IndexOf(" ")," Mohammed")}");

            // public String[] Split(params char[] separator);
            // public String[] Split(char[] separator, int count);
            // public String[] Split(char[] separator, StringSplitOptions options);
            // public String[] Split(char[] separator, int count, StringSplitOptions options);
            // public String[] Split(String[] separator, StringSplitOptions options);
            // public String[] Split(String[] separator, int count, StringSplitOptions options);
            Logger.Title("Split Method");

            string[] arr = "a, b, c , d , e , f".Split(',');
            Console.WriteLine(string.Join("",arr));

            arr = "go abc went abc gone abc".Split(new[] { "abc" } ,StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(string.Join("", arr));





            Console.WriteLine();
            #endregion

            #region String Literal Can use string class methods and properties
            Console.WriteLine();
            Console.WriteLine("".PadLeft(20,'=').PadRight(20,'='));
            Console.WriteLine("".Length);
            Console.WriteLine();

            #endregion

            

            // Make repeated string
            Console.WriteLine(RepeatStringWithLoop("Moamen ", 10));
            Console.WriteLine(RepeatStringWithLoopAndStringBuilder("Moamen ", 10));
            Console.WriteLine(RepeatStringWithStringBuilderAndInsert("Moamen ", 10));
            Console.WriteLine(RepeatStringWithPadLeftAndReplace("Moamen ", 10));
            Console.WriteLine(RepeatStringWithStringConstructorAndReplace("Moamen ", 10));


        }

        #region Nested String Interpolation Test Methods
        // for test nested interpolation
        public static void TestGreaterOrEquals(int point, int value)
        {
            Console.WriteLine($"Your Data {value} is {(value >= point ? $"Geater than or Equals {point}." : $"Smaller than {point}.")}");
        }

        // for test nested interpolation
        public static void TestRelation(int point, int value)
        {
            Console.WriteLine($"Your Data {value} is {(value > point ? $"Geater than {point}." : value == point ? $"Equal to {point}" : $"Smaller than {point}")}");
        }

        #endregion

        #region Repeate String with different ways
        // repeate String with for loop
        // // Not Efficient as each loop iteration a new string object is create
        public static string RepeatStringWithLoop(string str, int count)
        {
            string result = str;
            for (int i = 0; i < count - 1; i++)
            {
                result += str;
            }
            return result;
        }

        // better approach is to use StringBuilder with for loop and append method
        public static string RepeatStringWithLoopAndStringBuilder(string str, int count)
        {
            StringBuilder builder = new StringBuilder(str.Length * count);
            for (int i = 0; i < count; i++)
            {
                builder.Append(str);
            }
            return builder.ToString();
        }

        // The Best Approach
        public static string RepeatStringWithStringBuilderAndInsert(string str, int count)
        {
            return new StringBuilder(str.Length * count).Insert(0, str, count).ToString();
        }

        // Not Efficient
        public static string RepeatStringWithPadLeftAndReplace(string str, int count)
        {
            return "".PadLeft(count,'X').Replace("X", str);
        }

        // Not Efficient
        public static string RepeatStringWithStringConstructorAndReplace(string str, int count)
        {
            return new string('X',count).Replace("X", str);
        }

        #endregion

    }


    public class Logger
    {
        public static int Count { get; set; } = 40;
        public static string PaddingString { get; set; } = "=";

        public static void Title(string str, int? count = null, string paddingString = null)
        {
            Console.WriteLine();
            Console.WriteLine(str);
            Sep(count ?? str.Length, paddingString);
        }

        public static void Sep(int? count = null, string paddingString = null)
        {
            Console.WriteLine(RepeatString(paddingString ?? PaddingString, count ?? Count));
        }

        public static string RepeatString(string str, int count)
        {
            return new StringBuilder(str.Length * count).Insert(0, str, count).ToString();
        }


    }
}