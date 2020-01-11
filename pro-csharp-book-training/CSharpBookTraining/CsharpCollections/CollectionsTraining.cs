using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpCollections
{
    // ==============================> Chapter 9: Collections and Generics <==============================
    // ===================================================================================================

    // Any application you create with the.NET platform will need to contend with the issue of 
    // maintaining and manipulating a set of data points in memory.

    // When the.NET platform was first released, programmers frequently used the classes of the System.
    // Collections namespace to store and interact with bits of data used within an application.In.NET 2.0, the
    // C# programming language was enhanced to support a feature termed generics; and with this change, a new
    // namespace was introduced in the base class libraries : System.Collections.Generic.

    // The Motivation for Collection Classes:
    // ======================================
    // - The most primitive container you could use to hold application data is undoubtedly the array.
    // - C# arrays allow you to define a set of identically typed items (including an array of System.
    //   Objects, which essentially represents an array of any type of data) of a fixed upper limit.

    // - While basic arrays can be useful to manage small amounts of fixed-size data, there are many other times
    // where you require a more flexible data structure, such as a dynamically growing and shrinking container or
    // a container that can hold objects that meet only a specific criteria(e.g., only objects deriving from a specific
    // base class or only objects implementing a particular interface).

    // To help overcome the limitations of a simple array, the.NET base class libraries ship with a number
    // of namespaces containing collection classes.Unlike a simple C# array, collection classes are built to
    // dynamically resize themselves on the fly as you insert or remove items.

    // a collection class can belong to one of two broad categories:
    //•	 Nongeneric collections (primarily found in the System.Collections namespace)
    //•	 Generic collections(primarily found in the System.Collections.Generic
    //   namespace)

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




    class WorkingWithArrayList
    {

        public static void Test()
        {
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


    // Boxing and Unboxing
    // =========================================================================================================
    // you will seldom need to store a local value type in a local object variable,
    // as shown here.However, it turns out that the boxing/unboxing process is quite helpful because it allows you
    // to assume everything can be treated as a System.Object, while the CLR takes care of the memory-related
    // details on your behalf.

    // Although you pass in Value Type directly into methods requiring an object, the runtime automatically 
    // boxes the stack-based data on your behalf.Later, if you want to retrieve a Value Type from methods, 
    // you must unbox the heap-allocated object into a stack-allocated integer using a casting operation.
    // 

    class BoxingAndUnboxing
    {
        public static void Test()
        {
            int val1 = 10;

            // Boxing Operation : stack to heap memory transfer
            object obj1 = val1;
            TestBoxing(val1);

            // Unboxing Operation : heap to stack memory transfer
            int val2 = (int)obj1;
            val2 = (int)TestUnboxing();




        }

        // Boxing Operation when passing type value argument to the method
        public static void TestBoxing(object obj1)
        {
            if (obj1 is ValueType)
                Console.WriteLine($"Boxed Value");
        }

        // unboxing Operation when returning type value from method
        public static object TestUnboxing()
        {
            int val = new Random().Next(100);
            return val;
        }

    }


    // The Problems of Nongeneric Collections
    // ==================================================================================
    // ==================================================================================
    // 1- The Issue of Performance
    // 2- The Issue of Type Safety

    // 1- The Issue of Performance
    // ==================================================================================
    // Boxing and unboxing are convenient from a programmer’s viewpoint, but this simplified approach to
    // stack/heap memory transfer comes with the baggage of performance issues (in both speed of execution and
    // code size) and a lack of type safety. To understand the performance issues, ponder these steps that must
    // occur to box and unbox a simple integer:

    // 1. A new object must be allocated on the managed heap.

    // 2. The value of the stack-based data must be transferred into that memory location.

    // 3. When unboxed, the value stored on the heap-based object must be transferred
    //    back to the stack.

    // 4. The now unused object on the heap will (eventually) be garbage collected.

    // you could certainly feel the impact if an ArrayList contained thousands of integers that your
    // program manipulates on a somewhat regular basis.


    // 2- The Issue of Type Safety
    // ==================================================================================
    // Recall that you must unbox your data into the same data type it was declared as before boxing. 
    // in a non-generic world: the fact that a majority of the classes of System.Collections can typically hold 
    // anything whatsoever because their members are prototyped to operate on System.Objects.


    // In some cases, you will require an extremely flexible container that can hold literally anything,
    // However, most of the time you desire a type-safe container that can operate only on a particular type
    // of data point.For example, you might need a container that can hold only database connections, bitmaps, or
    // IPointy-compatible objects.

    class TestTypeSafety
    {
        public static void Test()
        {
            // if we assume we will use non generic Collections to store integers
            Stack aStack = new Stack(4);

            aStack.Push(10);
            aStack.Push(20);
            aStack.Push(30);

            // pass by wrong a string
            //aStack.Push("Moamen");

            // pop Items
            for (int i = 0; i < aStack.Count; i++)
            {
                // if type of pop value is not integer, Error will be thrown due to type mismatch
                // so, non generic collections is not type safe
                Console.WriteLine($"Stack int Items: {(int)aStack.Pop()}");
            }


        }



    }

    // Create Custom Types To solve the Issue of Type Safety
    // =====================================================
    // Prior to generics, the only way you could address this issue of type safety was to create a custom
    // (strongly typed) collection class manually. and delegate the System.Collections to desired type.

    // With these types defined, you are now assured of type safety, given that the C#
    // compiler will be able to determine any attempt to insert an incompatible data type.

    // the Problem with this approach is:
    //
    //  - this approach leaves you in a position where you must create an(almost identical) custom collection
    //    for each unique data type you want to contain.
    //
    //  - a custom collection class does nothing to solve the issue of boxing/unboxing penalties.

    class IntStack : IEnumerable
    {
        private Stack aStack;

        public IntStack()
        {
            aStack = new Stack();
        }
        public IntStack(int initialCapacity)
        {
            aStack = new Stack(initialCapacity);
        }
        public IntStack(ICollection col)
        {
            aStack = new Stack(col);
        }

        public int Count 
        {
            get
            {
                return aStack.Count;
            }
        }
        public void Clear()
        {
            aStack.Clear();
        }
        public object Clone()
        {
            return aStack.Clone();
        }
        public bool Contains(int obj)
        {
            return aStack.Contains(obj);
        }

        public IEnumerator GetEnumerator()
        {
            return aStack.GetEnumerator();
        }

        public int Peek()
        {
            return (int)aStack.Peek();
        }
        public int Pop()
        {
            return (int)aStack.Pop();
        }
        public void Push(int obj)
        {
            aStack.Push(obj);
        }




    }

    class TestCustomCollectionsType
    {
        public static void Test()
        {
            IntStack intStack = new IntStack();

            intStack.Push(10);
            intStack.Push(20);
            intStack.Push(30);
            intStack.Push(40);

            // Error, Can't convert from String to int, we solve the issue of type safety. 
            //intStack.Push("String Value");

            for (int i = 0; i < intStack.Count; i++)
            {
                Console.WriteLine($"Poped Stack Item: {intStack.Pop()}");
            }
        }

    }




    #region A First Look at Generic Collections
    // A First Look at Generic Collections
    // =====================================================================================================
    // When you use generic collection classes, you rectify all the previous issues, including boxing/unboxing
    // penalties and a lack of type safety.Also, the need to build a custom (generic) collection class becomes quite
    // rare.Rather than having to build unique classes that can contain people, cars, and integers, you can use a
    // generic collection class and specify the type of type.

    class Person
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Person(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public Person() : this(0, string.Empty) { }

        public override string ToString()
        {
            return $"Person [ ID:{ID}, Name:{Name} ]";
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj?.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }

    class FirstLookAtGenericCollections
    {
        public static void Test()
        {

            // The First list of Person and wee don't need to make custom class for type safety, 
            // and it guarantees good performance.

            List<Person> empsList = new List<Person>();

            // you can add only Person objects and their Drived types
            empsList.Add(new Person(10, "Mohammed"));
            empsList.Add(new Person(20, "Ahmed"));
            empsList.Add(new Person(30, "Kamal"));
            empsList.Add(new Person(40, "Moamen"));
            empsList.Add(new Person(50, "Waleed"));

            // you can get Persons without cast
            foreach (var item in empsList)
            {
                Console.WriteLine($"List<int> Item: {item}");
            }


            // =====================================================================
            // The Second List

            List<int> intsList = new List<int>();

            intsList.AddRange(new[] { 10, 20, 30, 40, 50, 60 });

            foreach (var item in intsList)
            {
                Console.WriteLine($"List<int> Item: {item}");
            }

            intsList.Add(70);

            foreach (var item in intsList)
            {
                Console.WriteLine($"List<int> Item: {item}");
            }




        }

    }

    // The first List<T> object can contain only Person objects.Therefore, you do not need to perform a
    // cast when plucking the items from the container, which makes this approach more type-safe.The second
    // List<T> can contain only integers, all of which are allocated on the stack; in other words, there is no hidden
    // boxing or unboxing as you found with the nongeneric ArrayList.

    // Here is a short list of the benefits generic containers provide over their nongeneric counterparts:

    // • Generics provide better performance because they do not result in boxing or
    //   unboxing penalties when storing value types.

    // • Generics are type safe because they can contain only the type of type you specify.

    // • Generics greatly reduce the need to build custom collection types because you
    //   specify the “type of type” when creating the generic container. 
    #endregion


    // The Role of Generic Type Parameters

    //    When you see a generic item listed in the.NET Framework documentation or the Visual Studio Object
    //Browser, you will notice a pair of angled brackets with a letter or other token sandwiched within.Figure 9-1
    //shows the Visual Studio Object Browser displaying a number of generic items located within the
    //System.Collections.Generic namespace, including the highlighted List<T> class.

    //    Formally speaking, you call these tokens type parameters; however, in more user-friendly terms, you can
    //simply call them placeholders.You can read the symbol<T> as "of T." Thus, you can read IEnumerable<T>
    //"as IEnumerable of T" or, to say it another way, "IEnumerable of type T".


    //    Note the name of a type parameter(placeholder) is irrelevant, and it is up to the developer who created
    //the generic item.however, typically T is used to represent types, TKey or K is used for keys, and TValue or V is
    //used for values.


    // Specifying Type Parameters for Generic Classes/Structures
    // =================================================================================================
    //    After you specify the type parameter of a generic item, it cannot be
    //changed(remember, generics are all about type safety). When you specify a type parameter for a generic
    //class or structure, all occurrences of the placeholder(s) are now replaced with your supplied value.

    //when you create a generic List<T> variable, the compiler does not literally create a new
    //implementation of the List<T> class. Rather, it will address only the members of the generic type you
    //actually invoke.

    // Specifying Type Parameters for Generic Members
    // =================================================================================================
    //    It is fine for a nongeneric class or structure to support generic properties.In these cases, you would also
    //need to specify the placeholder value at the time you invoke the method.For example, System.Array
    //supports a several generic methods. Specifically, the nongeneric static Sort() method now has a generic
    //counterpart named Sort<T>(). 

    class TypeParameterForGenericMembers
    {
        public static void Test()
        {

            int[] intsArray = { 60, 30, 10, 70, 50, 40 };

            Console.WriteLine("int array: ");
            foreach (var item in intsArray)
            {
                Console.Write($" {item} ");
            }
            Console.WriteLine();

            Array.Sort<int>(intsArray);

            Console.WriteLine("sorted array: ");
            foreach (var item in intsArray)
            {
                Console.Write($" {item} ");
            }
            Console.WriteLine();

        }

    }


    // Specifying Type Parameters for Generic Interfaces
    // =================================================================================================
    //    It is common to implement generic interfaces when you build classes or structures that need to support
    //various framework behaviors(e.g., cloning, sorting, and enumeration).
    //you learned about a number of nongeneric interfaces, such as IComparable, IEnumerable, IEnumerator, and IComparer.

    // you Note That: the code required several runtime checks and casting operations because the parameter was
    // a general System.Object.

    // public interface IComparable
    // {
    //     int CompareTo(T other);
    // }

    // Now assume you use the generic counterpart of  interfaces.

    // public interface IComparable<in T>
    // {
    //     int CompareTo(T other);
    // }

    class Person2 : Person, IComparable<Person2>
    {
        public Person2()
        {
        }

        public Person2(int iD, string name) : base(iD, name)
        {
        }



        public int CompareTo(Person2 other)
        {
            return this.ID.CompareTo(other.ID);
        }

    }

    class TypeParameterForGenericInterfaces
    {
        public static void Test()
        {
            List<Person2> people = new List<Person2>();

            people.Add(new Person2(70,"Ahmed"));
            people.Add(new Person2(30,"Mohammed"));
            people.Add(new Person2(10,"Waleed"));
            people.Add(new Person2(40,"Kamal"));
            people.Add(new Person2(30,"Sara"));


            Console.WriteLine("Before sort");
            foreach (var item in people)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            people.Sort();

            Console.WriteLine("After Sort");
            foreach (var item in people)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

    }


    // ==============================> The System.Collections.Generic Namespace <==============================
    // ========================================================================================================

    // Note: Some generic Interfaces are drived from the non generic 

    // Core generic interfaces you’ll encounter when working with the generic collection classes.
    // Table 9-4. Key Interfaces Supported by Classes of System.Collections.Generic

    // --------------------------------------------------------------------------
    // System.Collections.Generic Interface         Meaning in Life
    // ==========================================================================
    // ICollection<T> 
    // --------------
    // Defines general characteristics (e.g., size, enumeration,
    // and thread safety) for all generic collection types
    // ==========================================================================
    // IComparer<T> 
    // --------------
    // Defines a way to compare to objects
    // ==========================================================================
    // IDictionary<TKey, TValue>  
    // --------------
    // Allows a generic collection object to represent its contents
    // using key-value pairs
    // ==========================================================================
    // IEnumerable<T>  
    // --------------
    // Returns the IEnumerator<T> interface for a given object
    // ==========================================================================
    // IEnumerator<T>  
    // --------------
    // Enables foreach-style iteration over a generic collection
    // ==========================================================================
    // IList<T>  
    // --------------
    // Provides behavior to add, remove, and index items in a
    // sequential list of objects
    // ==========================================================================
    // ISet<T>  
    // --------------
    // Provides the base interface for the abstraction of sets
    // ==========================================================================

    // The System.Collections.Generic namespace also defines several classes that implement many of
    // these key interfaces.Table 9-5 describes some commonly used classes of this namespace, the interfaces they
    // implement, and their basic functionality.

    // Table 9-5. Classes of System.Collections.Generic
    // Generic Class                Supported Key Interfaces        Meaning in Life
    // =============================================================================================
    // Dictionary<TKey,TValue>
    // -----------------------
    // ICollection<T>, IDictionary<TKey,TValue>, IEnumerable<T>
    // ---------------------------------------------------------------------------------------------
    // This represents a generic collection of keys and values.
    // =============================================================================================
    // LinkedList<T> 
    // -----------------------
    // ICollection<T>, IEnumerable<T> This represents a doubly linked list.
    // List<T> ICollection<T>, IEnumerable<T>, IList<T>
    // ---------------------------------------------------------------------------------------------
    // This is a dynamically resizable sequential list of items.
    // =============================================================================================
    // Queue<T> 
    // -----------------------
    // ICollection (Not a typo! This is the nongeneric collection interface), IEnumerable<T>
    // ---------------------------------------------------------------------------------------------
    // This is a generic implementation of a first-in, first-out list.
    // =============================================================================================
    // SortedDictionary<TKey, TValue>
    // -----------------------
    // ICollection<T>, IDictionary<TKey, TValue>, IEnumerable<T>
    // ---------------------------------------------------------------------------------------------
    // This is a generic implementation of a sorted set of key-value pairs.
    // =============================================================================================
    // SortedSet<T> 
    // -----------------------
    // ICollection<T>, IEnumerable<T>,ISet<T>
    // ---------------------------------------------------------------------------------------------
    // This represents a collection of  objects that is maintained in sorted order with no duplication.
    // =============================================================================================
    // Stack<T> 
    // -----------------------
    // ICollection (Not a typo! This is the nongeneric collection interface), IEnumerable<T>
    // ---------------------------------------------------------------------------------------------
    // This is a generic implementation of a last-in, first-out list.
    // =============================================================================================

    // The System.Collections.Generic namespace also defines many auxiliary classes and structures 
    // that work in conjunction with a specific container.

    // Assemblies that has System.Collections.Generic Namespace:
    // ---------------------------------------------------------
    // 1- mscorelib.dll
    // ---------------------------------------------------------
    // 2- System.Core.dll
    // ---------------------------------------------------------
    // 3- System.dll
    // ---------------------------------------------------------
    // 4- System.ServiceModel.dll
    // ---------------------------------------------------------

    // Understanding Collection Initialization Syntax
    // ================================================================================================
    //    allow me to illustrate a C# language feature (first introduced in .NET 3.5) that simplifies the way
    // you populate generic(and nongeneric) collection containers with data.
    //    
    // This C# language feature makes it possible to populate many containers(such as ArrayList or List<T>) with items 
    // by using syntax similar to what you use to populate a basic array.

    // ■ Note: You can apply collection initialization syntax only to classes that support an Add() method, which is
    // formalized by the ICollection<T>/ICollection interfaces

    class CollectionInitializationSyntax
    {
        public static void Test()
        {
            // Init a standard array.
            int[] myArrayOfInts = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Init an ArrayList with numerical data.
            ArrayList myList = new ArrayList { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Init a generic List<> of ints.
            List<int> myGenericList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            List<Person> personsList = new List<Person> 
            { 
                new Person(10,"Ahmed"),
                new Person(20,"Ali"),
                new Person(30,"Kamal"),
                new Person(40,"Shady"),
                new Person(50,"Mohammed")
            };

            foreach (var item in personsList)
            {
                Console.WriteLine($"Person List Item: {item}");
            }
        }

    }

    class CollectionsTraining
    {

        public static void TestCollections()
        {
            
            //WorkingWithArrayList.Test();
            //BoxingAndUnboxing.Test();
            //TestTypeSafety.Test();
            //TestCustomCollectionsType.Test();
            //TypeParameterForGenericMembers.Test();
            //TypeParameterForGenericInterfaces.Test();

            CollectionInitializationSyntax.Test();




        }

    }

}