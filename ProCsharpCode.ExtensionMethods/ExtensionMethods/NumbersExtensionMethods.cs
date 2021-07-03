using System;
using System.Linq;

namespace ProCSharpCode.ExtensionMethods
{
    /// <summary>
    /// extension methods for primitive value types :  
    /// <list type="bullet">
    ///     <item>
    ///         <term> <see cref="System.Int16"/> </term>
    ///         <description>short type</description>
    ///     </item>
    ///     <item>
    ///         <term> <see cref="System.Int32"/> </term>
    ///         <description>Integer type</description>
    ///     </item>
    ///     <item>
    ///         <term> <see cref="System.Int64"/> </term>
    ///         <description>long type</description>
    ///     </item>
    ///     <item>
    ///         <term> <see cref="System.Double"/> </term>
    ///         <description>double type</description>
    ///     </item>
    ///     <item>
    ///         <term> <see cref="System.Decimal"/> </term>
    ///         <description>decimal type</description>
    ///     </item>
    ///     <item>
    ///         <term> <see cref="System.Single"/> </term>
    ///         <description>float type</description>
    ///     </item>
    /// </list> 
    /// </summary>
    public static class NumbersExtensionMethods
    {
        // This method allows any integer to reverse its digits.
        // For example, 56 would return 65.
        public static int ReverseDigits(this int input)
        {
            // Translate short shorto a string, and then
            // get all the characters.
            int sign = (input < 0 ? -1 : 1);
            char[] digits = input.ToString().ToCharArray().Where(c => char.IsNumber(c)).ToArray();
            // Now reverse items in the array.
            Array.Reverse(digits);
            // Put back into string.
            string newDigits = new string(digits);
            // Finally, return the modified string back as an short.
            return int.Parse(newDigits) * sign;

        }
        
        public static short ReverseDigits(this short input)
        {
            // Translate short shorto a string, and then
            // get all the characters.
            int sign = (input < 0 ? -1 : 1);
            char[] digits = input.ToString().ToCharArray().Where(c=> char.IsNumber(c)).ToArray();
            // Now reverse items in the array.
            Array.Reverse(digits);
            // Put back into string.
            string newDigits = new string(digits);
            // Finally, return the modified string back as an short.
            return (short)(short.Parse(newDigits) * sign);
        }


    }
}
