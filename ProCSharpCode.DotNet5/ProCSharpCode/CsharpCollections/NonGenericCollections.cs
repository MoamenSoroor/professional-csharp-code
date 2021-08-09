using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpCode.CSharpCollections
{
    // Non-Generic Collections
    // =======================
    #region Nongeneric collections (System.Collections namespace)

    // The System.Collections Namespace
    // ================================
    // When the.NET platform was first released, programmers frequently used the nongeneric collection
    // classes found within the System.Collections namespace, which contains a set of classes used to manage
    // and organize large amounts of in-memory data.

    // Table 9-1 Useful Types of System.Collections
    //---------------------------------------------
    // System.Collections Class          Meaning in Life Key         Implemented Interfaces
    // ==============================================================================================================
    // ArrayList 
    // ---------
    // Represents a dynamically sized collection of objects listed in sequential order
    // -----------------------------------------------------------------------------------------------------
    // - Implemented Interfaces:
    //    IList, ICollection, IEnumerable, and ICloneable.
    // ==============================================================================================================
    // BitArray
    // --------
    // Manages a compact array of bit values, which are represented as Booleans, where  true indicates that 
    // the bit is on (1) and false indicates the bit is off(0).
    // -----------------------------------------------------------------------------------------------------
    // - Implemented Interfaces:
    //    ICollection, IEnumerable, and ICloneable
    //    
    // ==============================================================================================================
    // Hashtable
    // --------- 
    // Represents a collection of key-value pairs that are organized based on the hash code of the key.
    // -----------------------------------------------------------------------------------------------------
    // - Implemented Interfaces:
    //    IDictionary, ICollection, IEnumerable, and ICloneable
    //    
    //    
    // ==============================================================================================================
    // Queue 
    // -------- 
    // Represents a standard first-in, first-out (FIFO) collection of objects.
    // -----------------------------------------------------------------------------------------------------
    // - Implemented Interfaces:
    //    ICollection, IEnumerable,  and ICloneable
    //   
    // ==============================================================================================================
    // SortedList 
    // ---------- 
    // Represents a collection of key-value pairs that are sorted by the keys and are accessible
    // by key and by index
    // 
    // -----------------------------------------------------------------------------------------------------
    // - Implemented Interfaces:
    //    IDictionary, ICollection,IEnumerable, and ICloneable
    //    
    //    
    // ==============================================================================================================
    // Stack 
    // ------
    // A last-in, first-out (LIFO) stack providing push and pop(and peek) functionality.
    // -----------------------------------------------------------------------------------------------------
    // - Implemented Interfaces:
    //    ICollection, IEnumerable, and ICloneable
    //    

    // ============================================================================================================
    // Table 9-2. Key Interfaces Supported by Classes of System.Collections
    // --------------------------------------------------------------------
    // System.Collections Interface      Meaning in Life
    // ============================================================================================================
    // ICollection 
    // ---------------
    // Defines general characteristics (e.g., size, enumeration, and thread
    // safety) for all nongeneric collection types
    // ============================================================================================================
    // ICloneable 
    // ---------------
    // Allows the implementing object to return a copy of itself to the caller
    // ============================================================================================================
    // IDictionary
    // ---------------
    // Allows a nongeneric collection object to represent its contents using key-value pairs
    // ============================================================================================================
    // IEnumerable 
    // ---------------
    // Returns an object implementing the IEnumerator interface (see next table entry)
    // ============================================================================================================
    // IEnumerator 
    // ---------------
    // Enables foreach-style iteration of collection items
    // ============================================================================================================
    // IList 
    // ---------------
    // Provides behavior to add, remove, and index items in a sequential list of objects
    // ============================================================================================================

    // Working with ArrayList
    // ----------------------

    //public class ArrayList : IList, ICollection, IEnumerable, ICloneable
    //{
    //    public ArrayList();
    //    public ArrayList(int capacity);
    //    public ArrayList(ICollection c);

    //    public virtual object this[int index] { get; set; }

    //    public virtual bool IsSynchronized { get; }
    //    public virtual bool IsReadOnly { get; }
    //    public virtual bool IsFixedSize { get; }
    //    public virtual int Count { get; }
    //    public virtual int Capacity { get; set; }
    //    public virtual object SyncRoot { get; }

    //    public static ArrayList Adapter(IList list);
    //    public static IList FixedSize(IList list);
    //    public static ArrayList FixedSize(ArrayList list);
    //    public static IList ReadOnly(IList list);
    //    public static ArrayList ReadOnly(ArrayList list);
    //    public static ArrayList Repeat(object value, int count);
    //    public static ArrayList Synchronized(ArrayList list);
    //    public static IList Synchronized(IList list);
    //    public virtual int Add(object value);
    //    public virtual void AddRange(ICollection c);
    //    public virtual int BinarySearch(int index, int count, object value, IComparer comparer);
    //    public virtual int BinarySearch(object value);
    //    public virtual int BinarySearch(object value, IComparer comparer);
    //    public virtual void Clear();
    //    public virtual object Clone();
    //    public virtual bool Contains(object item);
    //    public virtual void CopyTo(int index, Array array, int arrayIndex, int count);
    //    public virtual void CopyTo(Array array);
    //    public virtual void CopyTo(Array array, int arrayIndex);
    //    public virtual IEnumerator GetEnumerator();
    //    public virtual IEnumerator GetEnumerator(int index, int count);
    //    public virtual ArrayList GetRange(int index, int count);
    //    public virtual int IndexOf(object value, int startIndex, int count);
    //    public virtual int IndexOf(object value, int startIndex);
    //    public virtual int IndexOf(object value);
    //    public virtual void Insert(int index, object value);
    //    public virtual void InsertRange(int index, ICollection c);
    //    public virtual int LastIndexOf(object value, int startIndex);
    //    public virtual int LastIndexOf(object value, int startIndex, int count);
    //    public virtual int LastIndexOf(object value);
    //    public virtual void Remove(object obj);
    //    public virtual void RemoveAt(int index);
    //    public virtual void RemoveRange(int index, int count);
    //    public virtual void Reverse(int index, int count);
    //    public virtual void Reverse();
    //    public virtual void SetRange(int index, ICollection c);
    //    public virtual void Sort(IComparer comparer);
    //    public virtual void Sort(int index, int count, IComparer comparer);
    //    public virtual void Sort();
    //    public virtual object[] ToArray();
    //    public virtual Array ToArray(Type type);
    //    public virtual void TrimToSize();
    //}





    // A Survey of System.Collections.Specialized Namespace
    // =====================================================
    // System.Collections is not the only.NET namespace that contains nongeneric collection classes.The
    // System.Collections.Specialized namespace defines a number of(pardon the redundancy) specialized
    // collection types.Table 9-3 documents some of the more useful types in this particular collection-centric
    // namespace, all of which are nongeneric.
    // Beyond these concrete class types, this namespace also contains many additional interfaces and
    // abstract base classes that you can use as a starting point for creating custom collection classes.While these
    // “specialized” types might be just what your projects require in some situations, I won’t comment on their
    // usage here. Again, in many cases, you will likely find that the System.Collections.Generic namespace
    // provides classes with similar functionality and additional benefits.
    // ■ Note there are two additional collection-centric namespaces (System.Collections.ObjectModel and
    // System.Collections.Concurrent) in the.net base class libraries. You will examine the former namespace
    // later in this chapter, after you are comfortable with the topic of generics.System.Collections.Concurrent
    // provides collection classes well-suited to a multithreaded environment (see Chapter 19 for information on
    // multithreading).

    // Table 9-3. Useful Classes of System.Collections.Specialized
    // ==============================================================================================
    // System.Collections.Specialized Type Meaning in Life
    // ==============================================================================================
    // HybridDictionary 
    // ------------------------------------------------------------
    // This class implements IDictionary by using a
    // ListDictionary while the collection is small and then
    // switching to a Hashtable when the collection gets large.
    // ==============================================================================================
    // ListDictionary
    // ------------------------------------------------------------
    // This class is useful when you need to manage a small
    // number of items(ten or so) that can change over time.This
    // class makes use of a singly linked list to maintain its data.
    // ==============================================================================================
    // StringCollection 
    // ------------------------------------------------------------
    // This class provides an optimal way to manage large
    // collections of string data.
    // ==============================================================================================
    // BitVector32 
    // ------------------------------------------------------------
    // This class provides a simple structure that stores Boolean
    // values and small integers in 32 bits of memory.

    // ■ Note: there are two additional collection-centric namespaces(System.Collections.ObjectModel and
    // System.Collections.Concurrent) in the.net base class libraries. You will examine the former namespace
    // later in this chapter, after you are comfortable with the topic of generics.System.Collections.Concurrent
    // provides collection classes well-suited to a multithreaded environment. 
    #endregion

    #region Working with the ArrayList Class

    // NOTE: Use Generic version of that collection is better (List<T>)

    class WorkingWithArrayList
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With ArrayList ");
            Console.WriteLine("".PadLeft(40, '='));

            ArrayList arList = new ArrayList();

            arList.AddRange(new[] { "Moamen", "Mohammed", "Gamal" });

            arList.Add("Soroor");

            Console.Write("List Items {");
            foreach (var item in arList)
            {
                Console.Write($" {item} ");
            }
            Console.WriteLine("}\n");


        }

    }

    #endregion

    #region Working with the Stack Class

    // NOTE: Use Generic version of that collection is better (Stack<T>)

    class WorkingWithStack
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Stack ");
            Console.WriteLine("".PadLeft(40, '='));

            Stack stack = new Stack();


            stack.Push(10);
            stack.Push("Moamen");

            var moamen  = stack.Pop();
            Console.WriteLine(moamen);

            Console.WriteLine(stack.Pop()); // 10
        }

    }

    #endregion

    #region Working with the Queue Class


    // NOTE: Use Generic version of that collection is better (Queue<T>)

    class WorkingWithQueue
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Queue ");
            Console.WriteLine("".PadLeft(40, '='));

            Queue queue = new Queue();

            queue.Enqueue("moamen");

            queue.Enqueue("mohammed");


            string moamen = queue.Dequeue() as string; // moamen
            string mohammed = queue.Dequeue() as string;    // mohammed


        }

    }

    #endregion

    #region Working with the SortedList Class

    // NOTE: Use Generic version of that collection is better ( SortedList<TKey, TValue>)


    class WorkingWithSortedList
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With SortedList ");
            Console.WriteLine("".PadLeft(40, '='));

            SortedList arList = new SortedList();


        }

    }

    #endregion

    #region Working with the Hashtable Class

    class WorkingWithHashtable
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Hashtable ");
            Console.WriteLine("".PadLeft(40, '='));

            Hashtable arList = new Hashtable();



        }

    }

    #endregion

    #region Working with the BitArray Class
    
    // NOTE that BitArray is Immutable
    // It is efficient to use it in encryption algorithms
    // and it also encapsulate the logic of the bit operations
    public class WorkingWithBitArray
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With BitArray ");
            Console.WriteLine("".PadLeft(40, '='));

            BitArray arr = new BitArray(64);
            arr = new BitArray(new[] {true, true, true, true }); // value of 15 
            arr = new BitArray(64); // length is 64 bit
            arr = new BitArray(8,true); // value of 255 , with array length 8 bit
            arr = new BitArray(new[] { 0x0F }); // Value of 15 one int in the array is with the length of 32 bit.

            // convert to array of bool
            List<bool> bools = arr.OfType<bool>().ToList();
            Console.WriteLine(string.Join(", ",bools));

            // convert to array of int , each integer represent bit
            List<int> ints = arr.OfType<bool>().Select(b => b ? 1 : 0).ToList();
            Console.WriteLine(string.Join("", ints));


            var arrOr = arr.Or(new BitArray(new[] { 0x0F }));
            var orResult = new int[1];
            arrOr.CopyTo(orResult,0);
            Console.WriteLine($"{arrOr[0]:x2}");

            var arrAnd = arr.And(new BitArray(new int[] { 0x0F }));
            var andResult = new int[1];
            arrAnd.CopyTo(orResult, 0);
            Console.WriteLine($"{arrAnd[0]:x2}");
        }




        public static BitArray ToBinary(int numeral)
        {
            return new BitArray(new[] { numeral });
        }

        public static int ToNumeral(BitArray binary)
        {
            if (binary == null)
                throw new ArgumentNullException("binary");
            if (binary.Length > 32)
                throw new ArgumentException("must be at most 32 bits long");

            var result = new int[1];
            binary.CopyTo(result, 0);
            return result[0];
        }


    }

    #endregion

}
