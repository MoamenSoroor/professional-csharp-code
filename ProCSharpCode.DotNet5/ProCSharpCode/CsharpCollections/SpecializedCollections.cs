using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpCode.CSharpCollections
{
    // ================================================
    // The System.Collections.Specialized Namespace
    // ================================================
    // Requires System.Collections.Specialized;
    #region Working with the HybridDictionary Class
    class WorkingWithHybridDictionary
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With HybridDictionary ");
            Console.WriteLine("".PadLeft(40, '='));

            HybridDictionary arList = new HybridDictionary();



        }

    }

    #endregion

    // Requires System.Collections.Specialized;
    #region Working with the ListDictionary Class
    // Requires System.Collections.Specialized
    class WorkingWithListDictionary
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With ListDictionary ");
            Console.WriteLine("".PadLeft(40, '='));

            ListDictionary arList = new ListDictionary();



        }

    }

    #endregion

    // Requires System.Collections.Specialized;
    #region Working with the StringCollection Class
    // Requires System.Collections.Specialized
    class WorkingWithStringCollection
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With StringCollection ");
            Console.WriteLine("".PadLeft(40, '='));

            StringCollection arList = new StringCollection();



        }

    }

    #endregion

    // Requires System.Collections.Specialized;
    #region Working with the BitVector32 Class
    // Requires System.Collections.Specialized
    class WorkingWithBitVector32
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With BitVector32 ");
            Console.WriteLine("".PadLeft(40, '='));

            BitVector32 arList = new BitVector32(0b0000_1111); // value of 15

            // get integer value that represnt the bitVector
            int value = arList.Data;
            Console.WriteLine(value);


            // get the most small bit
            Console.WriteLine(arList[0]); // 1



            

        }

    }

    #endregion
}
