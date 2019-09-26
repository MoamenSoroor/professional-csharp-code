using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_csharp_book_training
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
            //  Escape  sequence Character name         Unicode encoding
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


        }

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


    }
}