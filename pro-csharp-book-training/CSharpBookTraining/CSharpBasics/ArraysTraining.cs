using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpBook.CSharpBasics
{
    public static class ArraysTraining
    {
        //        Understanding C# Arrays
        //As I would guess you are already aware, an array is a set of data items, accessed using a numerical index.
        //More specifically, an array is a set of contiguous data points of the same type (an array of ints, an array of
        //strings, an array of SportsCars, and so on). Declaring, filling, and accessing an array with C# are all quite
        //straightforward.

        //Note Do be aware that if you declare an array but do not explicitly fill each index, each item will be set to the
        //default value of the data type(e.g., an array of bools will be set to false or an array of ints will be set to 0)




        static ArraysTraining() { }

        public static void TestArrays()
        {
            int[] arrint = new int[4];
            arrint[0] = 10;
            arrint[1] = 20;
            arrint[2] = 30;
            arrint[3] = 40;


            //            C# Array Initialization Syntax
            //In addition to filling an array element by element, you are able to fill the items of an array using C# array
            //initialization syntax.To do so, specify each array item within the scope of curly brackets({ }). This syntax
            //can be helpful when you are creating an array of a known size and want to quickly specify the initial values.

            // Array initialization without new keyword and size.
            int[] arrint2 = { 10, 20, 30, 40 };
            // Array initialization with new keyword, and without Type and size.
            int[] arrint3 = new[] { 10, 20, 30, 40 };
            // Array initialization with new keyword and Type, and without size.
            int[] arrint4 = new int[] { 10, 20, 30, 40 };
            // Array initialization with new keyword and Type and size.
            int[] arrint5 = new int[5] { 10, 20, 30, 40, 50 };


            //            Implicitly Typed Local Arrays
            //Recall that the var keyword allows you to define a variable, whose underlying type is determined by the compiler.
            //In a similar vein, the var keyword can be used to define implicitly typed local arrays.
            //Using this technique, you can allocate a new array variable without specifying the type contained within 
            //the array itself(note you must use the new keyword when using this approach).

            var arrvar = new int[4];
            arrvar[0] = 10;
            arrvar[1] = 20;
            arrvar[2] = 30;
            arrvar[3] = 40;

            // Error:
            //var arrvar2 = { 10, 20, 30, 40 };
            var arrvar2 = new[] { 10, 20, 30, 40 };
            // Error:
            //var arrvar2 = new[4] { 10, 20, 30, 40 };

            var arrvar4 = new int[] { 10, 20, 30, 40 };
            var arrvar5 = new int[4] { 10, 20, 30, 40 };

            //            Of course, just as when you allocate an array using explicit C# syntax, the items in the array’s
            //initialization list must be of the same underlying type (e.g., all ints, all strings, or all SportsCars). Unlike
            //what you might be expecting, an implicitly typed local array does not default to System.Object; thus, the
            //following generates a compile-time error:
            // Error! Mixed types!
            //var d = new[] { 1, "one", 2, "two", false };

            // -----------------------------------------------------------------------------------------------

            #region Working with Multidimensional Arrays
            //            Working with Multidimensional Arrays
            //In addition to the single - dimension arrays you have seen thus far, C# also supports two varieties of
            //multidimensional arrays. The first of these is termed a rectangular array, which is simply an array of multiple
            //dimensions, where each row is of the same length. 

            // Rectangle 2D array (The same Length)
            int[,] rect1 = new int[2, 4];
            rect1[0, 0] = 10;
            rect1[0, 1] = 20;
            rect1[0, 2] = 30;
            rect1[0, 3] = 40;

            rect1[1, 0] = 50;
            rect1[1, 1] = 60;
            rect1[1, 2] = 70;
            rect1[1, 3] = 80;

            int[,] rect2 = new int[3, 4] { { 10, 20, 30, 40 }, { 50, 60, 70, 80 }, { 90, 91, 92, 93 } };
            // Error
            //int[,] rect3 = new int[2,] { { 10, 20, 30, 40 }, { 50, 60, 70, 80 } };
            int[,] rect4 = new int[,] { { 10, 20, 30, 40 }, { 50, 60, 70, 80 } };
            int[,] rect5 = new[,] { { 10, 20, 30, 40 }, { 50, 60, 70, 80 } };

            // read rect array
            int rows = rect2.GetLength(0);
            int cols = rect2.GetLength(1);

            int rowIndexWidth = rows.ToString().Length;
            int colIndexWidth = cols.ToString().Length;

            int rowWidth = "row".Length + rowIndexWidth;
            Console.Write(Repeate(" ", rowWidth) + "\t");
            for (int i = 0; i < rect2.GetLength(1); i++)
            {
                Console.Write($"col{i}\t");
            }
            Console.WriteLine();
            for (int i = 0; i < rect2.GetLength(0); i++)
            {
                Console.Write($"row{i}\t");
                for (int j = 0; j < rect2.GetLength(1); j++)
                {
                    Console.Write($"{rect2[i, j]}\t");
                }
                Console.WriteLine();
            }


            // Jagged 2D Array: have different dim lengths
            int[][] arr1 = new int[2][];

            int[][] arr2 = new int[2][] { new int[] { 10, 20, 30, 40, 90 }, new int[] { 50, 60, 70, 80 } };

            int[][] arr4 = new int[2][];
            arr4[0] = new int[] { 10, 20, 30, 40, 90 };
            arr4[1] = new int[] { 101, 201, 301, 401, 901 };

            int[][] arr5 = new int[2][];
            arr5[0] = new int[] { 10, 20, 30, 40, 90 };
            arr5[1] = new int[] { 101, 201, 301, 401, 901 };

            var arr6 = new int[2][] { new int[] { 10, 20, 30, 40, 50 }, new int[] { 60, 70, 80, 90 } };

            Console.WriteLine("arr6: ");
            for (int i = 0; i < arr6.GetLength(0); i++)
            {
                for (int j = 0; j < arr6[i].GetLength(0); j++)
                {
                    Console.Write($"{arr6[i][j]}\t");
                }
                Console.WriteLine();
            }

            var arr7 = new string[2][][];
            arr7[0] = new string[3][];
            arr7[1] = new string[4][];

            arr7[0][0] = new string[3];
            arr7[0][1] = new string[4];
            arr7[0][2] = new string[5];

            arr7[1][0] = new string[3];
            arr7[1][1] = new string[4];
            arr7[1][2] = new string[5];
            arr7[1][3] = new string[6];

            arr7[0][0][0] = "000";
            arr7[0][0][1] = "001";
            arr7[0][0][2] = "002";

            arr7[0][1][0] = "010";
            arr7[0][1][1] = "011";
            arr7[0][1][2] = "012";
            arr7[0][1][3] = "013";

            arr7[0][2][0] = "020";
            arr7[0][2][1] = "021";
            arr7[0][2][2] = "022";
            arr7[0][2][3] = "023";
            arr7[0][2][4] = "024";


            arr7[1][0][0] = "100";
            arr7[1][0][1] = "101";
            arr7[1][0][2] = "102";

            arr7[1][1][0] = "110";
            arr7[1][1][1] = "111";
            arr7[1][1][2] = "112";
            arr7[1][1][3] = "113";

            arr7[1][2][0] = "120";
            arr7[1][2][1] = "121";
            arr7[1][2][2] = "122";
            arr7[1][2][3] = "123";
            arr7[1][2][4] = "124";

            arr7[1][3][0] = "130";
            arr7[1][3][1] = "131";
            arr7[1][3][2] = "132";
            arr7[1][3][3] = "133";
            arr7[1][3][4] = "134";
            arr7[1][3][5] = "135";

            Console.WriteLine("arr7 : ");
            Console.WriteLine("[");
            for (int i = 0; i < arr7.GetLength(0); i++)
            {
                Console.WriteLine(" [");
                for (int j = 0; j < arr7[i].GetLength(0); j++)
                {
                    Console.Write("  [");
                    for (int k = 0; k < arr7[i][j].GetLength(0); k++)
                    {
                        Console.Write($"  {arr7[i][j][k]}  ");
                    }
                    Console.WriteLine("]");
                }
                Console.WriteLine(" ]");
            }
            Console.WriteLine("]");
            #endregion



            #region System.Array Class
            // ==============================> The System.Array Base Class <==============================
            // Every array you create gathers much of its functionality from the System.Array class. Using these common
            //members, you are able to operate on an array using a consistent object model.Table 4-1 gives a rundown of
            //some of the more interesting members (be sure to check the .NET Framework 4.7 SDK documentation for
            //full details).

            #region Basic Methods and Properties of Array Base Class
            //            
            //Let’s see some of these members in action.The following helper method makes use of the static
            //Reverse() and Clear() methods to pump out information about an array of string types to the console:


            //        Table 4 - 1.  Select Members of System.Array
            //Member of Array Class        Meaning in Life
            // ------------------------------------------------------------------------------------------
            // Length
            //      This property returns the number of items within the array.
            // Rank
            //      This property returns the number of dimensions of the current array.
            // Clear()
            //      This static method sets a range of elements in the array to empty values
            //      (0 for numbers, null for object references, false for Booleans).
            // CopyTo()
            //      This method is used to copy elements from the source array into the
            //      destination array.
            // Reverse()
            //      This static method reverses the contents of a one - dimensional array.
            // Sort()
            //      This static method sorts a one-dimensional array of intrinsic types. If the
            //      elements in the array implement the IComparer interface.
            // -------------------------------------------------------------------------------------------
            #endregion

            #region All Methods and Properties of Array Base Class

            //            Properties
            // =====================================================================================================
            //IsFixedSize
            //Gets a value indicating whether the Array has a fixed size.
            // -----------------------------------------------------------------------------------------------------
            //IsReadOnly
            //Gets a value indicating whether the Array is read - only.
            // -----------------------------------------------------------------------------------------------------
            //IsSynchronized
            //Gets a value indicating whether access to the Array is synchronized(thread safe).
            // -----------------------------------------------------------------------------------------------------
            //Length
            //Gets the total number of elements in all the dimensions of the Array.
            // -----------------------------------------------------------------------------------------------------
            //LongLength
            //Gets a 64 - bit integer that represents the total number of elements in all the dimensions of the Array.
            // -----------------------------------------------------------------------------------------------------
            //Rank
            //Gets the rank(number of dimensions) of the Array.For example, a one - dimensional array returns 1, a two-dimensional array returns 2, and so on.
            // -----------------------------------------------------------------------------------------------------
            //SyncRoot
            //Gets an object that can be used to synchronize access to the Array.
            // -----------------------------------------------------------------------------------------------------

            //            Methods
            // =====================================================================================================
            //AsReadOnly<T>(T[])
            //Returns a read - only wrapper for the specified array.

            //BinarySearch(Array, Int32, Int32, Object)
            //Searches a range of elements in a one - dimensional sorted array for a value, using the IComparable interface implemented by each element of the array and by the specified value.

            //BinarySearch(Array, Int32, Int32, Object, IComparer)
            //Searches a range of elements in a one-dimensional sorted array for a value, using the specified IComparer interface.

            //BinarySearch(Array, Object)
            //Searches an entire one-dimensional sorted array for a specific element, using the IComparable interface implemented by each element of the array and by the specified object.

            //BinarySearch(Array, Object, IComparer)
            //Searches an entire one-dimensional sorted array for a value using the specified IComparer interface.

            //BinarySearch<T>(T[], Int32, Int32, T)
            //Searches a range of elements in a one-dimensional sorted array for a value, using the IComparable<T> generic interface implemented by each element of the Array and by the specified value.

            //BinarySearch<T>(T[], Int32, Int32, T, IComparer<T>)
            //Searches a range of elements in a one-dimensional sorted array for a value, using the specified IComparer<T> generic interface.

            //BinarySearch<T>(T[], T)
            //Searches an entire one-dimensional sorted array for a specific element, using the IComparable<T> generic interface implemented by each element of the Array and by the specified object.

            //BinarySearch<T>(T[], T, IComparer<T>)
            //Searches an entire one-dimensional sorted array for a value using the specified IComparer<T> generic interface.

            //Clear(Array, Int32, Int32)
            //Sets a range of elements in an array to the default value of each element type.

            //Clone()
            //Creates a shallow copy of the Array.

            //ConstrainedCopy(Array, Int32, Array, Int32, Int32)
            //Copies a range of elements from an Array starting at the specified source index and pastes them to another Array starting at the specified destination index.Guarantees that all changes are undone if the copy does not succeed completely.

            //ConvertAll<TInput, TOutput>(TInput[], Converter<TInput, TOutput>)
            //Converts an array of one type to an array of another type.

            //Copy(Array, Array, Int32)
            //Copies a range of elements from an Array starting at the first element and pastes them into another Array starting at the first element.The length is specified as a 32-bit integer.

            //Copy(Array, Array, Int64)
            //Copies a range of elements from an Array starting at the first element and pastes them into another Array starting at the first element.The length is specified as a 64-bit integer.

            //Copy(Array, Int32, Array, Int32, Int32)
            //Copies a range of elements from an Array starting at the specified source index and pastes them to another Array starting at the specified destination index.The length and the indexes are specified as 32-bit integers.

            //Copy(Array, Int64, Array, Int64, Int64)
            //Copies a range of elements from an Array starting at the specified source index and pastes them to another Array starting at the specified destination index.The length and the indexes are specified as 64-bit integers.

            //CopyTo(Array, Int32)
            //Copies all the elements of the current one-dimensional array to the specified one-dimensional array starting at the specified destination array index.The index is specified as a 32-bit integer.

            //CopyTo(Array, Int64)
            //Copies all the elements of the current one-dimensional array to the specified one-dimensional array starting at the specified destination array index.The index is specified as a 64-bit integer.

            //CreateInstance(Type, Int32)
            //Creates a one-dimensional Array of the specified Type and length, with zero-based indexing.

            //CreateInstance(Type, Int32, Int32)
            //Creates a two-dimensional Array of the specified Type and dimension lengths, with zero-based indexing.

            //CreateInstance(Type, Int32, Int32, Int32)
            //Creates a three-dimensional Array of the specified Type and dimension lengths, with zero-based indexing.

            //CreateInstance(Type, Int32[])
            //Creates a multidimensional Array of the specified Type and dimension lengths, with zero-based indexing. The dimension lengths are specified in an array of 32-bit integers.

            //CreateInstance(Type, Int32[], Int32[])
            //Creates a multidimensional Array of the specified Type and dimension lengths, with the specified lower bounds.

            //CreateInstance(Type, Int64[])
            //Creates a multidimensional Array of the specified Type and dimension lengths, with zero-based indexing. The dimension lengths are specified in an array of 64-bit integers.

            //Empty<T>()
            //Returns an empty array.

            //Equals(Object)
            //Determines whether the specified object is equal to the current object.

            //(Inherited from Object)
            //Exists<T>(T[], Predicate<T>)
            //Determines whether the specified array contains elements that match the conditions defined by the specified predicate.

            //Find<T>(T[], Predicate<T>)
            //Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire Array.

            //FindAll<T>(T[], Predicate<T>)
            //Retrieves all the elements that match the conditions defined by the specified predicate.

            //FindIndex<T>(T[], Int32, Int32, Predicate<T>)
            //Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the Array that starts at the specified index and contains the specified number of elements.

            //FindIndex<T>(T[], Int32, Predicate<T>)
            //Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the Array that extends from the specified index to the last element.

            //FindIndex<T>(T[], Predicate<T>)
            //Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the entire Array.

            //FindLast<T>(T[], Predicate<T>)
            //Searches for an element that matches the conditions defined by the specified predicate, and returns the last occurrence within the entire Array.

            //FindLastIndex<T>(T[], Int32, Int32, Predicate<T>)
            //Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the range of elements in the Array that contains the specified number of elements and ends at the specified index.

            //FindLastIndex<T>(T[], Int32, Predicate<T>)
            //Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the range of elements in the Array that extends from the first element to the specified index.

            //FindLastIndex<T>(T[], Predicate<T>)
            //Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the entire Array.

            //ForEach<T>(T[], Action<T>)
            //Performs the specified action on each element of the specified array.

            //GetEnumerator()
            //Returns an IEnumerator for the Array.

            //GetHashCode()
            //Serves as the default hash function.

            //(Inherited from Object)
            //GetLength(Int32)
            //Gets a 32-bit integer that represents the number of elements in the specified dimension of the Array.

            //GetLongLength(Int32)
            //Gets a 64-bit integer that represents the number of elements in the specified dimension of the Array.

            //GetLowerBound(Int32)
            //Gets the index of the first element of the specified dimension in the array.

            //GetType()
            //Gets the Type of the current instance.

            //(Inherited from Object)
            //GetUpperBound(Int32)
            //Gets the index of the last element of the specified dimension in the array.

            //GetValue(Int32)
            //Gets the value at the specified position in the one-dimensional Array.The index is specified as a 32-bit integer.

            //GetValue(Int32, Int32)
            //Gets the value at the specified position in the two-dimensional Array. The indexes are specified as 32-bit integers.

            //GetValue(Int32, Int32, Int32)
            //Gets the value at the specified position in the three-dimensional Array. The indexes are specified as 32-bit integers.

            //GetValue(Int32[])
            //Gets the value at the specified position in the multidimensional Array.The indexes are specified as an array of 32-bit integers.

            //GetValue(Int64)
            //Gets the value at the specified position in the one-dimensional Array. The index is specified as a 64-bit integer.

            //GetValue(Int64, Int64)
            //Gets the value at the specified position in the two-dimensional Array. The indexes are specified as 64-bit integers.

            //GetValue(Int64, Int64, Int64)
            //Gets the value at the specified position in the three-dimensional Array. The indexes are specified as 64-bit integers.

            //GetValue(Int64[])
            //Gets the value at the specified position in the multidimensional Array.The indexes are specified as an array of 64-bit integers.

            //IndexOf(Array, Object)
            //Searches for the specified object and returns the index of its first occurrence in a one-dimensional array.

            //IndexOf(Array, Object, Int32)
            //Searches for the specified object in a range of elements of a one-dimensional array, and returns the index of its first occurrence. The range extends from a specified index to the end of the array.

            //IndexOf(Array, Object, Int32, Int32)
            //Searches for the specified object in a range of elements of a one-dimensional array, and returns the index of ifs first occurrence. The range extends from a specified index for a specified number of elements.

            //IndexOf<T>(T[], T)
            //Searches for the specified object and returns the index of its first occurrence in a one-dimensional array.

            //IndexOf<T>(T[], T, Int32)
            //Searches for the specified object in a range of elements of a one dimensional array, and returns the index of its first occurrence. The range extends from a specified index to the end of the array.

            //IndexOf<T>(T[], T, Int32, Int32)
            //Searches for the specified object in a range of elements of a one-dimensional array, and returns the index of its first occurrence. The range extends from a specified index for a specified number of elements.

            //Initialize()
            //Initializes every element of the value-type Array by calling the parameterless constructor of the value type.

            //LastIndexOf(Array, Object)
            //Searches for the specified object and returns the index of the last occurrence within the entire one-dimensional Array.

            //LastIndexOf(Array, Object, Int32)
            //Searches for the specified object and returns the index of the last occurrence within the range of elements in the one-dimensional Array that extends from the first element to the specified index.

            //LastIndexOf(Array, Object, Int32, Int32)
            //Searches for the specified object and returns the index of the last occurrence within the range of elements in the one-dimensional Array that contains the specified number of elements and ends at the specified index.

            //LastIndexOf<T>(T[], T)
            //Searches for the specified object and returns the index of the last occurrence within the entire Array.

            //LastIndexOf<T>(T[], T, Int32)
            //Searches for the specified object and returns the index of the last occurrence within the range of elements in the Array that extends from the first element to the specified index.

            //LastIndexOf<T>(T[], T, Int32, Int32)
            //Searches for the specified object and returns the index of the last occurrence within the range of elements in the Array that contains the specified number of elements and ends at the specified index.

            //MemberwiseClone()
            //Creates a shallow copy of the current Object.

            //(Inherited from Object)
            //Resize<T>(T[], Int32)
            //Changes the number of elements of a one-dimensional array to the specified new size.

            //Reverse(Array)
            //Reverses the sequence of the elements in the entire one-dimensional Array.

            //Reverse(Array, Int32, Int32)
            //Reverses the sequence of a subset of the elements in the one-dimensional Array.

            //SetValue(Object, Int32)
            //Sets a value to the element at the specified position in the one-dimensional Array.The index is specified as a 32-bit integer.

            //SetValue(Object, Int32, Int32)
            //Sets a value to the element at the specified position in the two-dimensional Array. The indexes are specified as 32-bit integers.

            //SetValue(Object, Int32, Int32, Int32)
            //Sets a value to the element at the specified position in the three-dimensional Array. The indexes are specified as 32-bit integers.

            //SetValue(Object, Int32[])
            //Sets a value to the element at the specified position in the multidimensional Array.The indexes are specified as an array of 32-bit integers.

            //SetValue(Object, Int64)
            //Sets a value to the element at the specified position in the one-dimensional Array. The index is specified as a 64-bit integer.

            //SetValue(Object, Int64, Int64)
            //Sets a value to the element at the specified position in the two-dimensional Array. The indexes are specified as 64-bit integers.

            //SetValue(Object, Int64, Int64, Int64)
            //Sets a value to the element at the specified position in the three-dimensional Array. The indexes are specified as 64-bit integers.

            //SetValue(Object, Int64[])
            //Sets a value to the element at the specified position in the multidimensional Array.The indexes are specified as an array of 64-bit integers.

            //Sort(Array)
            //Sorts the elements in an entire one-dimensional Array using the IComparable implementation of each element of the Array.

            //Sort(Array, Array)
            //Sorts a pair of one-dimensional Array objects(one contains the keys and the other contains the corresponding items) based on the keys in the first Array using the IComparable implementation of each key.

            //Sort(Array, Array, IComparer)
            //Sorts a pair of one-dimensional Array objects(one contains the keys and the other contains the corresponding items) based on the keys in the first Array using the specified IComparer.

            //Sort(Array, Array, Int32, Int32)
            //Sorts a range of elements in a pair of one-dimensional Array objects(one contains the keys and the other contains the corresponding items) based on the keys in the first Array using the IComparable implementation of each key.

            //Sort(Array, Array, Int32, Int32, IComparer)
            //Sorts a range of elements in a pair of one-dimensional Array objects(one contains the keys and the other contains the corresponding items) based on the keys in the first Array using the specified IComparer.

            //Sort(Array, IComparer)
            //Sorts the elements in a one-dimensional Array using the specified IComparer.

            //Sort(Array, Int32, Int32)
            //Sorts the elements in a range of elements in a one-dimensional Array using the IComparable implementation of each element of the Array.

            //Sort(Array, Int32, Int32, IComparer)
            //Sorts the elements in a range of elements in a one-dimensional Array using the specified IComparer.

            //Sort<T>(T[])
            //Sorts the elements in an entire Array using the IComparable<T> generic interface implementation of each element of the Array.

            //Sort<T>(T[], Comparison<T>)
            //Sorts the elements in an Array using the specified Comparison<T>.

            //Sort<T>(T[], IComparer<T>)
            //Sorts the elements in an Array using the specified IComparer<T> generic interface.

            //Sort<T>(T[], Int32, Int32)
            //Sorts the elements in a range of elements in an Array using the IComparable<T> generic interface implementation of each element of the Array.

            //Sort<T>(T[], Int32, Int32, IComparer<T>)
            //Sorts the elements in a range of elements in an Array using the specified IComparer<T> generic interface.

            //Sort<TKey, TValue>(TKey[], TValue[])
            // Sorts a pair of Array objects(one contains the keys and the other contains the corresponding items) based on the keys in the first Array using the IComparable<T> generic interface implementation of each key.

            //Sort<TKey, TValue>(TKey[], TValue[], IComparer<TKey>)
            // Sorts a pair of Array objects(one contains the keys and the other contains the corresponding items) based on the keys in the first Array using the specified IComparer<T> generic interface.

            //Sort<TKey, TValue>(TKey[], TValue[], Int32, Int32)
            // Sorts a range of elements in a pair of Array objects(one contains the keys and the other contains the corresponding items) based on the keys in the first Array using the IComparable<T> generic interface implementation of each key.

            //Sort<TKey, TValue>(TKey[], TValue[], Int32, Int32, IComparer<TKey>)
            // Sorts a range of elements in a pair of Array objects(one contains the keys and the other contains the corresponding items) based on the keys in the first Array using the specified IComparer<T> generic interface.

            //ToString()
            //Returns a string that represents the current object.

            //(Inherited from Object)
            //TrueForAll<T>(T[], Predicate<T>)
            //Determines whether every element in the array matches the conditions defined by the specified predicate. 
            #endregion

            // separator
            Console.WriteLine("Array Class Training".PadLeft(10, '=').PadRight(10, '='));

            int[] arr10 = { 10, 2, 3, 4, 5, 9, 5, 7, 33, 10, 12, 13, 14, 17, 2, 10, 20, 30, 33, 34, 100, 11, 45, 33, 34, 100 };

            // find number = 10 in array
            int num = Array.Find(arr10, Predicates.Find100);
            Console.WriteLine($"find num == 10 -> {num}");

            num = Array.FindLast(arr10, Predicates.Find100);
            Console.WriteLine($"find last num == 10 -> {num}");

            int[] numarr = Array.FindAll(arr10, Predicates.Find100);
            Console.WriteLine($"find all num == 10 -> ");
            ArrayPrint(numarr);

            // find all number more than 9 and less than 31
            numarr = Array.FindAll(arr10, p => p >= 10 && p <= 30);
            Console.WriteLine($"find all num == 10 -> ");
            ArrayPrint(numarr);
            #endregion





        }


        static void SystemArrayFunctionality()
        {
            Console.WriteLine("=> Working with System.Array.");
            // Initialize items at startup.
            string[] gothicBands = { "Tones on Tail", "Bauhaus", "Sisters of Mercy" };
            // Print out names in declared order.
            Console.WriteLine("-> Here is the array:");
            for (int i = 0; i < gothicBands.Length; i++)
            {
                // Print a name.
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine("\n");
            // Reverse them...
            Array.Reverse(gothicBands);
            Console.WriteLine("-> The reversed array");
        }


        public static string Repeate(string str, int count)
        {
            return new StringBuilder(str.Length * count).Insert(0, str, count).ToString();
        }

        public static int CountDigits(int number)
        {
            return number.ToString().Length;
        }

        public static void ArrayPass(int[] arr)
        {
            Console.WriteLine(arr);
        }

        public static int[] ArrayReturn()
        {
            //return new int [] { 10, 20, 30, 40, 50, 60 };
            return new[] { 10, 20, 30, 40, 50, 60 };
        }


        public static int[] ArrayReverse(int[] arr)
        {
            Array.Reverse(arr);
            return arr;
        }

        // find number == 100
        public static void ArrayPrint(int[] arr)
        {
            //Console.WriteLine(string.Join(" , ",arr));
            //Console.WriteLine(string.Concat(arr));

            Console.WriteLine();
            int count = 0;
            foreach (var item in arr)
            {
                Console.Write($"{item.ToString()} {((count++ == arr.Length - 1) ? ' ' : ',')} ");
            }
            Console.WriteLine();
        }

    }

    static class Predicates
    {
        static Predicates()
        {

        }

        public static bool Find100(int a)
        {
            return a == 10;
        }


    }

}