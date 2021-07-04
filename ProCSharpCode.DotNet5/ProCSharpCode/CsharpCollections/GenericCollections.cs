using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using static System.Environment;
using static ProCSharpCode.Utils.CollectionUtils;
using System.Collections.Immutable;

namespace ProCSharpCode.CSharpCollections
{
    #region Introduction to Collections and Generics

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
    #endregion

    #region Boxing and Unboxing
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
    #endregion

    #region The Problems of Nongeneric Collections

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
    #endregion


    // Generic Collections
    // ===================
    #region A First Look at Generic Collections
    // A First Look at Generic Collections
    // =====================================================================================================
    // When you use generic collection classes, you rectify all the previous issues, including boxing/unboxing
    // penalties and a lack of type safety.Also, the need to build a custom (generic) collection class becomes quite
    // rare.Rather than having to build unique classes that can contain people, cars, and integers, you can use a
    // generic collection class and specify the type of type.

    class Person0
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }


        public Person0(int iD, string name) : this(iD, name, 0)
        {

        }

        public Person0() : this(0, string.Empty, 0) { }

        public Person0(int iD, string name, int age)
        {
            ID = iD;
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Person0 [ ID:{ID}, Name:{Name}, Age:{Age} ]";
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj?.ToString();
        }


        // It is Important to override GetHashCode() With Equals 
        // To Work with Value-Based Semantic in Dictionary
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

            List<Person0> empsList = new List<Person0>();

            // you can add only Person objects and their Drived types
            empsList.Add(new Person0(10, "Mohammed"));
            empsList.Add(new Person0(20, "Ahmed"));
            empsList.Add(new Person0(30, "Kamal"));
            empsList.Add(new Person0(40, "Moamen"));
            empsList.Add(new Person0(50, "Waleed"));

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
    //   unboxing penalties when storing ValueTypes.

    // • Generics are type safe because they can contain only the type of type you specify.

    // • Generics greatly reduce the need to build custom collection types because you
    //   specify the “type of type” when creating the generic container. 
    #endregion

    #region The Role of Generic Type Parameters

    // The Role of Generic Type Parameters
    // ----------------------------------------------------------------------------------------
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
    // After you specify the type parameter of a generic item, it cannot be  changed(remember, 
    // generics are all  about type safety). When you specify a type parameter for a generic   
    // class or structure, all occurrences of the placeholder(s) are now replaced with your 
    // supplied value.

    // when you create a generic List<T> variable, the compiler does not literally create a new
    // implementation of the List<T> class. Rather, it will address only the members of the generic type you
    // actually invoke.

    // Specifying Type Parameters for Generic Members
    // =================================================================================================
    // It is fine for a nongeneric class or structure to support generic properties.In these cases, you would also
    // need to specify the placeholder value at the time you invoke the method.For example, System.Array
    // supports a several generic methods. Specifically, the nongeneric static Sort() method now has a generic
    // counterpart named Sort<T>(). 

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

            // Generic Sort<>() Method
            Array.Sort<int>(intsArray);

            Console.WriteLine("sorted array: ");
            foreach (var item in intsArray)
            {
                Console.Write($" {item} ");
            }
            Console.WriteLine();

        }

    }
    #endregion

    #region Specifying Type Parameters for Generic Interfaces

    // Specifying Type Parameters for Generic Interfaces
    // =================================================================================================
    //    It is common to implement generic interfaces when you build classes or structures that need to support
    // various framework behaviors(e.g., cloning, sorting, and enumeration).
    // you learned about a number of nongeneric interfaces, such as IComparable, IEnumerable, IEnumerator, and IComparer.

    // you Note That: the code required several runtime checks and casting operations because the parameter was
    // a general System.Object.

    // Defines a generalized type-specific comparison method that a value type or class
    // implements to order or sort its instances.
    // public interface IComparable
    // {
    //     int CompareTo(object obj);
    // }

    // Now assume you use the generic counterpart of  interfaces.

    // public interface IComparable<in T>
    // {
    //     int CompareTo(T other);
    // }

    class Person : Person0, IComparable<Person>
    {

        public Person()
        {
        }

        public Person(int iD, string name) : base(iD, name)
        {
        }

        public Person(int iD, string name, int age) : base(iD, name, age)
        {
        }

        // overrides to work with value-based semantic
        public override string ToString()
        {
            return $"Person [ ID:{ID}, Name:{Name}, Age:{Age} ]";
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj?.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        // Default Sorting is by ID : ASc
        public int CompareTo(Person other)
        {
            return this.ID.CompareTo(other.ID);
        }

        // Strong-associated Property
        public static IComparer<Person> IDAscendingSort { get => (IComparer<Person>)new PersonIDAscendingSort(); }
        public static IComparer<Person> IDDescendingSort { get => (IComparer<Person>)new PersonIDDescendingSort(); }
        public static IComparer<Person> NameAscendingSort { get => (IComparer<Person>)new PersonNameAscendingSort(); }
        public static IComparer<Person> NameDescendingSort { get => (IComparer<Person>)new PersonNameDescendingSort(); }
        public static IComparer<Person> NameAscendingSortIgnoreCase { get => (IComparer<Person>)new PersonNameAscendingSortIgnoreCase(); }
        public static IComparer<Person> NameDescendingSortIgnoreCase { get => (IComparer<Person>)new PersonNameDescendingSortIgnoreCase(); }
        public static IComparer<Person> AgeAscendingSort { get => (IComparer<Person>)new PersonAgeAscendingSort(); }
        public static IComparer<Person> AgeDescendingSort { get => (IComparer<Person>)new PersonAgeDescendingSort(); }
        public static IEqualityComparer<Person> IDEquality { get => (IEqualityComparer<Person>)new PersonIDEquality(); }
        public static IEqualityComparer<Person> NameEquality { get => (IEqualityComparer<Person>)new PersonNameEquality(); }
        public static IEqualityComparer<Person> AgeEquality { get => (IEqualityComparer<Person>)new PersonAgeEquality(); }


        // Beginning of nested classes to sort Person by ID, and by Name.
        private class PersonIDAscendingSort : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.ID.CompareTo(y.ID);
            }
        }
        private class PersonIDDescendingSort : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return y.ID.CompareTo(x.ID);
            }
        }
        private class PersonNameAscendingSort : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            }
        }
        private class PersonNameDescendingSort : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return string.Compare(y.Name, x.Name, StringComparison.Ordinal);
            }
        }
        private class PersonNameAscendingSortIgnoreCase : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
            }
        }
        private class PersonNameDescendingSortIgnoreCase : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return string.Compare(y.Name, x.Name, StringComparison.OrdinalIgnoreCase);
            }
        }

        private class PersonAgeAscendingSort : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.Age.CompareTo(y.Age);
            }
        }
        private class PersonAgeDescendingSort : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return y.Age.CompareTo(x.Age);
            }
        }


        private class PersonIDEquality : IEqualityComparer<Person>
        {
            public bool Equals(Person x, Person y)
            {
                return x.ID.Equals(y.ID);
            }

            public int GetHashCode(Person obj)
            {
                return obj.ID.GetHashCode();
            }
        }

        private class PersonNameEquality : IEqualityComparer<Person>
        {
            public bool Equals(Person x, Person y)
            {
                return x.Name.Equals(y.Name);
            }

            public int GetHashCode(Person obj)
            {
                return obj.Name.GetHashCode();
            }
        }

        private class PersonAgeEquality : IEqualityComparer<Person>
        {
            public bool Equals(Person x, Person y)
            {
                return x.Age.Equals(y.Age);
            }

            public int GetHashCode(Person obj)
            {
                return obj.Age.GetHashCode();
            }
        }

        
    }

    class TypeParameterForGenericInterfaces
    {
        public static void Test()
        {
            List<Person0> people = new List<Person0>();

            people.Add(new Person0(70, "Ahmed"));
            people.Add(new Person0(30, "Mohammed"));
            people.Add(new Person0(10, "Waleed"));
            people.Add(new Person0(40, "Kamal"));
            people.Add(new Person0(30, "Sara"));


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
    #endregion

    #region The System.Collections.Generic Namespace
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
    // =============================================================================================
    // List<T> 
    // -----------------------
    // ICollection<T>, IEnumerable<T>, IList<T>
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
    // This represents a collection of  objects that is maintained in sorted order with no duplication
    // =============================================================================================
    // HashSet<T>
    // -----------------------
    // ICollection<T>, IEnumerable<T>, IEnumerable, ISerializable, IDeserializationCallback, ISet<T>, IReadOnlyCollection<T>
    // ---------------------------------------------------------------------------------------------
    //  Represents a set of values.
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
    #endregion

    #region Understanding Collection Initialization Syntax

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

            List<Person0> personsList = new List<Person0>
            {
                new Person0(10,"Ahmed"),
                new Person0(20,"Ali"),
                new Person0(30,"Kamal"),
                new Person0(40,"Shady"),
                new Person0(50,"Mohammed")
            };

            foreach (var item in personsList)
            {
                Console.WriteLine($"Person List Item: {item}");
            }
        }

    }
    #endregion

    #region Working with the List<T> Class

    //    The List<T> class is bound to be your most frequently used type in the System.Collections.Generic
    //namespace because it allows you to resize the contents of the container dynamically.

    class WorkingWithGenericList
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Generic List");
            Console.WriteLine("".PadLeft(40, '='));

            // Create List Object
            List<int> alist0 = new List<int>();
            // Create List Object With initial Capacity = 10
            List<int> alist1 = new List<int>(10);

            // use object initialization sytax
            List<int> alist2 = new List<int>() { 10, 20, 30, 40, 50, 60 };
            List<int> alist3 = new List<int>(6) { 10, 20, 30, 40, 50, 60 };
            List<int> alist4 = new List<int> { 10, 20, 30, 40, 50, 60 };

            // Count Property
            Console.WriteLine($"alist4.Count = {alist4.Count}");

            // Capacity Property
            Console.WriteLine($"alist4.Capacity = {alist4.Capacity}");

            // Index [] Operator
            Console.WriteLine($"alist4[0] : {alist4[0]}");
            Console.WriteLine($"alist4[1] : {alist4[1]}");
            Console.WriteLine($"alist4[2] : {alist4[2]}");
            Console.WriteLine($"alist4[3] : {alist4[3]}");
            Console.WriteLine($"alist4[4] : {alist4[4]}");
            Console.WriteLine($"alist4[5] : {alist4[5]}");
            Console.WriteLine();

            // Add To List Method : public void Add(T item);
            PrintList(alist4, "Add() Method List Before Add Three Items:");
            alist4.Add(70);
            alist4.Add(80);
            alist4.Add(90);
            // print list
            PrintList(alist4, "Add() Method List After Add Three Items:");

            // Add Range to List Method : public void AddRange(IEnumerable<T> collection);
            PrintList(alist4, "AddRange() Method List Before AddRange:");

            // add array
            alist4.AddRange(new[] { 100, 200, 300 });

            // add another list
            alist4.AddRange(new List<int> { 400, 500, 600, 700 });

            // print list
            PrintList(alist4, "AddRange() Method List After AddRange:");

            // public void Clear();
            Console.WriteLine("Clear All List Items");
            alist4.Clear();

            // add new members
            alist4.AddRange(new[] { 100, 50, 70, 60, 90, 30, 40, 20, 10, 80 });

            // public void Insert(int index, T item);
            alist4.Insert(0, 99);
            alist4.Insert(3, 69);

            // public void InsertRange(int index, IEnumerable<T> collection);

            alist4.InsertRange(0, new[] { 91, 92, 93, 94, 95 });

            alist4.InsertRange(alist4.Count - 1, new List<int> { 81, 82, 83, 84 });

            PrintList(alist4, "List After Insert Many Items:");

            // public bool Remove(T item);
            // public int RemoveAll(Predicate<T> match);
            // public void RemoveAt(int index);
            // public void RemoveRange(int index, int count);

            alist4.Remove(84);
            alist4.RemoveAt(0);
            alist4.RemoveRange(0, 3);
            alist4.RemoveAll(x => x % 10 != 0);

            PrintList(alist4, "List After Remove Many Items:");


            // public void Reverse(int index, int count);
            // public void Reverse();

            // Reverse Range of the list

            alist4.Reverse(2, 5);
            PrintList(alist4, "List After Reverse Items from 2 to 7 :");

            alist4.Reverse();
            PrintList(alist4, "List After Reverse All Items:");

            // public T[] ToArray();

            int[] arr = alist4.ToArray();

            PrintList(arr, "Array From List:");


            // public void CopyTo(T[] array, int arrayIndex);
            // public void CopyTo(int index, T[] array, int arrayIndex, int count);
            // public void CopyTo(T[] array);
            // Summary:
            //     Copies the entire System.Collections.Generic.List`1 to a compatible one-dimensional
            //     array, starting at the beginning of the target array.

            int[] array = new int[alist4.Count];
            alist4.CopyTo(array);
            PrintList(array, "Array Copied From List:");


            int[] array2 = new int[alist4.Count + 4];

            array2[0] = 1;
            array2[1] = 2;
            PrintList(array2, "Array Before Copy from List:");
            alist4.CopyTo(array2, 2);
            PrintList(array2, "Array After Copy from List:");


            Array.Clear(array2, 0, array2.Length);

            alist4.CopyTo(2, array2, 1, 5);
            PrintList(array2, "Array After Clear it and Copy from List From specific Index with Count:");

            // public List<T> GetRange(int index, int count);
            // Creates a shallow copy of a range of elements in the source System.Collections.Generic.List`1.

            List<int> myRange = alist4.GetRange(0, 5);
            PrintList(myRange, "Get another list from the old one with Range from 0 to 4:");


            // public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter);
            //     Converts the elements in the current System.Collections.Generic.List`1 to another
            //     type, and returns a list containing the converted elements.

            List<double> doubleList = alist4.ConvertAll(new Converter<int, double>(x => (double)x));

            PrintList(doubleList, "A new List With new Type Parameter From the alist4:");


            alist4.Clear();
            alist4.AddRange(new[] { 100, 50, 70, 100, 60, 90, 30, 40, 20, 10, 80, 90, 40 });
            PrintList(alist4, "My New List:");

            // public int IndexOf(T item, int index, int count);
            // public int IndexOf(T item, int index);
            // public int IndexOf(T item);
            //     Searches for the specified object and returns the zero-based index of the first
            //     occurrence within the entire System.Collections.Generic.List`1.

            Console.WriteLine($"alist4.IndexOf(50) : {alist4.IndexOf(50)}");
            Console.WriteLine($"alist4.IndexOf(50) : {alist4.IndexOf(60)}");
            Console.WriteLine($"alist4.IndexOf(50) : {alist4.IndexOf(101)}");

            // public int IndexOf(T item, int index);
            // Start Search from Specific index to The End
            Console.WriteLine($"alist4.IndexOf(20,2) : {alist4.IndexOf(20, 2)}");
            Console.WriteLine($"alist4.IndexOf(20,3) : {alist4.IndexOf(20, 3)}");


            // public int IndexOf(T item, int index, int count);
            // Search In Range from Index to index + count
            Console.WriteLine($"alist4.IndexOf(20,2,3) : {alist4.IndexOf(20, 2, 3)}");
            Console.WriteLine($"alist4.IndexOf(20,5,3) : {alist4.IndexOf(20, 5, 3)}");

            // public int LastIndexOf(T item);
            // public int LastIndexOf(T item, int index);
            // public int LastIndexOf(T item, int index, int count);
            //     Searches for the specified object and returns the zero-based index of the last
            //     occurrence within the entire System.Collections.Generic.List`1.
            Console.WriteLine($"alist4.LastIndexOf(100) : {alist4.LastIndexOf(100)}");
            Console.WriteLine($"alist4.LastIndexOf(90) : {alist4.LastIndexOf(90)}");
            Console.WriteLine($"alist4.LastIndexOf(40) : {alist4.LastIndexOf(40)}");
            Console.WriteLine($"alist4.LastIndexOf(101) : {alist4.LastIndexOf(101)}");


            // public bool Contains(T item);
            Console.WriteLine($"alist4.Contains(50) : {alist4.Contains(50)}");
            Console.WriteLine($"alist4.Contains(60) : {alist4.Contains(60)}");
            Console.WriteLine($"alist4.Contains(101) : {alist4.Contains(101)}");


            // public bool Exists(Predicate<T> match);

            // Check if number 50 Exists
            Console.WriteLine($"alist4.Exists(x=> x == 50) : {alist4.Exists(x => x == 50)}");

            // Check if number 60 Exists
            Console.WriteLine($"alist4.Exists(x=> x == 60) : {alist4.Exists(x => x == 60)}");

            // Check if number 101 Exists
            Console.WriteLine($"alist4.Exists(x=> x == 101) : {alist4.Exists(x => x == 101)}");

            // Check if any Odd Number Exists in the list
            Console.WriteLine($"alist4.Exists(x=> x % 2 != 0) : {alist4.Exists(x => x % 2 != 0)}");

            // Check if any number Less Than 0 and more than 100 exists in the list
            Console.WriteLine($"alist4.Exists(x=> x > 100 && x < 0) : {alist4.Exists(x => x > 100 && x < 0)}");

            // Check if All Array Exists in the list
            Console.WriteLine($"alist4.Exists(x=> x > 100 && x < 0) : {alist4.Exists(x => x > 100 && x < 0)}");


            // Check if all array elements Exists in the list
            int[] arr2 = { 10, 20, 101 };
            bool[] exists = { false, false, false };
            bool Exists(int x)
            {
                for (int i = 0; i < arr2.Length; i++)
                {
                    if (arr2[i] == x)
                    {
                        exists[i] = true;
                    }
                }
                return !Array.Exists(exists, p => p == false);
            }
            Console.WriteLine($"alist4.Exists(Exists) : {alist4.Exists(Exists)}");


            // public T Find(Predicate<T> match);
            // Returns:
            //     The first element that matches the conditions defined by the specified predicate,
            //     if found; otherwise, the default value for type T.

            // Find Number 40 in the list
            Console.WriteLine($"alist4.Find(x=> x == 40) : {alist4.Find(x => x == 40)}");
            // Find Number 100 in the list
            Console.WriteLine($"alist4.Find(x=> x == 100) : {alist4.Find(x => x == 100)}");
            // Find Number 101 in the list
            Console.WriteLine($"alist4.Find(x=> x == 101) : {alist4.Find(x => x == 101)}");


            // Find Number More Than 20 and Less Than 40
            Console.WriteLine($"alist4.Find(x=> x > 20 && x < 40) : {alist4.Find(x => x > 20 && x < 40)}");

            // Find Odd Number
            Console.WriteLine($"alist4.Find(x=> x % 2 != 0) : {alist4.Find(x => x % 2 != 0)}");


            // public List<T> FindAll(Predicate<T> match);
            // public T FindLast(Predicate<T> match);


            // public int FindIndex(Predicate<T> match);

            // Find Index of Number that More Than 20 and Less Than 60
            Console.WriteLine($"alist4.FindIndex(x => x > 20 && x < 60) : {alist4.FindIndex(x => x > 20 && x < 60)}");

            // public int FindIndex(int startIndex, Predicate<T> match);
            // public int FindIndex(int startIndex, int count, Predicate<T> match);

            // public int FindLastIndex(Predicate<T> match);
            // Find LastIndex of Number that More Than 20 and Less Than 60
            Console.WriteLine($"alist4.FindLastIndex(x => x > 20 && x < 60) : {alist4.FindLastIndex(x => x > 20 && x < 60)}");

            // public int FindLastIndex(int startIndex, Predicate<T> match);
            // public int FindLastIndex(int startIndex, int count, Predicate<T> match);

            // public bool TrueForAll(Predicate<T> match);

            // Check if All List Items is >= 0 or <= 100
            Console.WriteLine($"alist4.TrueForAll(x => x >= 0 && x <= 100) : {alist4.TrueForAll(x => x >= 0 && x <= 100)}");

            // Check if All List Items is Even
            Console.WriteLine($"alist4.TrueForAll(x => x % 2 == 0) : {alist4.TrueForAll(x => x % 2 == 0)}");

            // Check if All List Items is Dividable on 10 
            Console.WriteLine($"alist4.TrueForAll(x => x % 2 == 0) : {alist4.TrueForAll(x => x % 2 == 0)}");

            // Check if All List Items is From Specific Numbers

            int[] array3 = new int[] { 10, 20, 30 };
            List<int> intList = new List<int> { 10, 20, 30, 20, 30, 10, 10, 20, 30, 10, 20 };

            bool Check(int x)
            {
                foreach (var item in array3)
                {
                    if (item == x)
                        return true;
                }
                return false;
            }


            Console.WriteLine($"intList.TrueForAll(Check) : {intList.TrueForAll(Check)}");





            Console.WriteLine("========================= Sorting =========================");
            Console.WriteLine("".PadLeft(60, '='));

            #region Sort List Elements Using Default Comparer
            // -------------------------- Sort List Elements Using Default Comparer --------------------------
            List<Person> alist5 = new List<Person>
            {
                new Person(104,"Moamen"),
                new Person(103,"Mohammed"),
                new Person(107,"Kamal"),
                new Person(101,"Mostafa"),
                new Person(102,"Ali"),
                new Person(106,"Waleed"),
                new Person(105,"Helmy")
            };

            PrintList(alist5, "Unsorted List:");

            // sort Ascending by ID 
            alist5.Sort();

            PrintList(alist5, "Ascending Sorted List By ID:");

            #endregion

            #region Sort List Descending by ID
            // -------------------------- Sort List Descending by ID --------------------------
            List<Person> alist6 = new List<Person>
            {
                new Person(104,"Moamen"),
                new Person(103,"Mohammed"),
                new Person(107,"Kamal"),
                new Person(101,"Mostafa"),
                new Person(102,"Ali"),
                new Person(106,"Waleed"),
                new Person(105,"Helmy")
            };

            PrintList(alist6, "Unsorted List:");

            // sort Descending by ID 
            alist6.Sort(Person.IDDescendingSort);

            PrintList(alist6, "Descending Sorted List By ID:");

            #endregion

            #region Sort List Ascending by Name
            // -------------------------- Sort List Ascending by Name --------------------------
            List<Person> alist7 = new List<Person>
            {
                new Person(104,"Moamen"),
                new Person(103,"mohammed"),
                new Person(107,"Kamal"),
                new Person(108,"Kareem"),
                new Person(101,"Mostafa"),
                new Person(102,"Ali"),
                new Person(106,"Waleed"),
                new Person(105,"Helmy")
            };

            PrintList(alist7, "Unsorted List:");

            // sort Descending by ID 
            alist7.Sort(Person.NameAscendingSort);

            PrintList(alist7, "Ascending Sorted List By Name:");
            #endregion

            #region Sort List Ascending by Name Ignore Case
            // -------------------------- Sort List Ascending by Name Igone Case --------------------------
            List<Person> alist8 = new List<Person>
            {
                new Person(104,"Moamen"),
                new Person(103,"mohammed"),
                new Person(107,"Kamal"),
                new Person(108,"Kareem"),
                new Person(101,"Mostafa"),
                new Person(102,"Ali"),
                new Person(106,"Waleed"),
                new Person(105,"Helmy")
            };

            PrintList(alist8, "Unsorted List:");

            // sort Descending by ID 
            alist8.Sort(Person.NameAscendingSortIgnoreCase);

            PrintList(alist8, "Ascending Sorted List By Name Igone Case:");
            #endregion

            #region Sort List Descending by Name
            // -------------------------- Sort List Descending by Name --------------------------
            List<Person> alist9 = new List<Person>
            {
                new Person(104,"Moamen"),
                new Person(103,"mohammed"),
                new Person(107,"Kamal"),
                new Person(108,"Kareem"),
                new Person(101,"Mostafa"),
                new Person(102,"Ali"),
                new Person(106,"Waleed"),
                new Person(105,"Helmy")
            };

            PrintList(alist9, "Unsorted List:");

            // sort Descending by ID 
            alist9.Sort(Person.NameDescendingSort);

            PrintList(alist9, "Descending Sorted List By Name:");
            #endregion

            #region Sort List Descending by Name Ignore Case
            // -------------------------- Sort List Descending by Name Igone Case --------------------------
            List<Person> alist10 = new List<Person>
            {
                new Person(104,"Moamen"),
                new Person(103,"mohammed"),
                new Person(107,"Kamal"),
                new Person(108,"Kareem"),
                new Person(101,"Mostafa"),
                new Person(102,"Ali"),
                new Person(106,"Waleed"),
                new Person(105,"Helmy")
            };

            PrintList(alist10, "Unsorted List:");

            // sort Descending by ID 
            alist10.Sort(Person.NameDescendingSortIgnoreCase);

            PrintList(alist10, "Descending Sorted List By Name Igone Case:");
            Console.WriteLine();
            #endregion

            #region Binary Search On a List
            // -------------------------- Binary Search On a List --------------------------
            // public int BinarySearch(T item);
            // public int BinarySearch(T item, IComparer<T> comparer);
            // public int BinarySearch(int index, int count, T item, IComparer<T> comparer);

            // Returns:
            //     The zero-based index of item in the sorted System.Collections.Generic.List`1,
            //     if item is found; otherwise, a negative number that is the bitwise complement
            //     of the index of the next element that is larger than item or, if there is no
            //     larger element, the bitwise complement of System.Collections.Generic.List`1.Count.

            List<Person> alist13 = new List<Person>
            {
                new Person(104,"Moamen"),
                new Person(103,"mohammed"),
                new Person(107,"Kamal"),
                new Person(108,"Kareem"),
                new Person(101,"Mostafa"),
                new Person(102,"Ali"),
                new Person(106,"Waleed"),
                new Person(105,"Helmy")
            };


            // Default Sort
            alist13.Sort();
            PrintList(alist13, "Sorted List:");

            Console.WriteLine($@"alist13.BinarySearch(new Person(103,"""")) : {alist13.BinarySearch(new Person(103, ""))}");

            // Search by using different Sort type Comparer
            Console.WriteLine($@"alist13.BinarySearch(new Person(-1,""Moamen""), Person.NameAscendingSort) : {alist13.BinarySearch(new Person(-1, "Moamen"), Person.NameAscendingSort)}");


            #endregion

            #region Find Person With Specific ID or Name or Char of Name
            // -------------------------- Sort List Descending by Name Igone Case --------------------------
            List<Person> alist11 = new List<Person>
            {
                new Person(104,"Moamen"),
                new Person(103,"mohammed"),
                new Person(107,"Kamal"),
                new Person(108,"Kareem"),
                new Person(101,"Mostafa"),
                new Person(102,"Ali"),
                new Person(106,"Waleed"),
                new Person(105,"Helmy")
            };

            PrintList(alist11, "My Person List:");

            // Find Person Whose ID 101
            Console.WriteLine($"alist4.Find(pr=> pr.ID == 101) : {alist11.Find(pr => pr.ID == 101)}");
            // Find Person Whose ID 120: it returns null default of Person Object
            Console.WriteLine($"alist4.Find(pr=> pr.ID == 101) : {alist11.Find(pr => pr.ID == 120) ?? new Person(-1, "None")}");

            // Find Person Whose Name is Mohammed
            Console.WriteLine($@"alist4.Find(pr=> pr.Name == ""Mohammed"") : {alist11.Find(pr => pr.Name == "Mohammed") ?? new Person(-1, "None")}");

            // Find Person Whose Name is Mohammed but Ignore Case
            Console.WriteLine($@"alist4.Find(pr=> pr.Name == ""Mohammed"") : {alist11.Find(pr => pr.Name.Equals("Mohammed", StringComparison.OrdinalIgnoreCase))}");


            // Find Last Person Whose Name Starts With 'M'
            Console.WriteLine($@"alist4.FindLast(pr=> pr.Name[0]=='M') : {alist11.FindLast(pr => pr.Name[0] == 'M')}");


            // Find All Person Whose Name Starts With Char M or m
            List<Person> listOfM = alist11.FindAll(pr => pr.Name[0] == 'M' || pr.Name[0] == 'm');
            PrintList(listOfM, $"{NewLine}alist4.Find(pr=> pr.Name[0] == 'M' || pr.Name[0] == 'm') :");



            #endregion

            #region Find Person Index With Specific ID or Name or Char of Name
            // -------------------------- Sort List Descending by Name Igone Case --------------------------
            List<Person> alist12 = new List<Person>
            {
                new Person(104,"Moamen"),
                new Person(103,"mohammed"),
                new Person(107,"Kamal"),
                new Person(108,"Kareem"),
                new Person(101,"Mostafa"),
                new Person(102,"Ali"),
                new Person(106,"Waleed"),
                new Person(105,"Helmy")
            };

            PrintList(alist12, "My Person List To Find Specific Index:");





            #endregion
        }

    }

    #endregion

    #region Working with the LinkedList<T> Class

    class WorkingWithGenericLinkedList
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Generic LinkedList");
            Console.WriteLine("".PadLeft(40, '='));

            LinkedList<int> list0 = new LinkedList<int>(new[] { 10, 20, 30 });

            LinkedList<int> list = new LinkedList<int>();
            
            list.AddLast(20);
            list.AddLast(30);
            list.AddLast(40);
            list.AddLast(50);

            list.AddFirst(10);

            PrintList(list,"print linked list after add first and add before: ");


            Console.WriteLine( "First  :" + list.First.Value);
            Console.WriteLine( "Last   :" + list.Last.Value);
            Console.WriteLine( "Count  :" + list.Count);


            list.AddAfter(list.Find(20),25);
            list.AddBefore(list.Find(20),15);

            PrintList(list, "print linked list after add two nodes after and before node has value 20 : ");

            list.RemoveFirst();
            PrintList(list, "print linked list after remove first : ");

            list.RemoveLast();
            PrintList(list, "print linked list after remove last : ");

            Console.WriteLine(list.Remove(20));

            list.Clear();
            PrintList(list, "print linked list after clear : ");

            list.AddLast(10);
            list.AddLast(20); // first 20
            list.AddLast(30);
            list.AddLast(20); // last 20
            list.AddLast(50);


            LinkedListNode<int> nodeLast20 = list.FindLast(20);
            LinkedListNode<int> nodeFirst20 = list.Find(20);


            Console.WriteLine("find last value of 20: " + nodeLast20.Value);
            Console.WriteLine("find (find first) value of 20: " + nodeFirst20.Value);

            // use LinkedListNode
            LinkedListNode<int> firstNode = list.First;
            Console.WriteLine("First Node Value: " + firstNode.Value);


            Console.WriteLine("Next To First Node: " + firstNode.Next.Value);
            Console.WriteLine("Next Next To First Node: " + firstNode.Next.Next.Value);


            // use LinkedListNode
            LinkedListNode<int> lastNode = list.Last;
            Console.WriteLine("Last Node Value: " + lastNode.Value);
            Console.WriteLine("Previous To Last Node: " + lastNode.Previous.Value);
            Console.WriteLine("Previous Previous To Last Node: " + lastNode.Previous.Previous.Value);







        }

    }


    #endregion

    #region Working with the Stack<T> Class
    // The Stack<T> class represents a collection that maintains items using a last-in, first-out manner.
    // As you might expect, Stack<T> defines members named Push() and Pop() to place items onto 
    // or remove items from the stack.
    class WorkingWithGenericStack
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Generic Stack");
            Console.WriteLine("".PadLeft(40, '='));

            Stack<Person> stackOfPersons = new Stack<Person>();

            // Push Items To Stack
            stackOfPersons.Push(new Person(104, "Moamen"));
            stackOfPersons.Push(new Person(103, "Mohammed"));
            stackOfPersons.Push(new Person(107, "Kamal"));


            Console.WriteLine("First person is: {0}", stackOfPersons.Peek());
            Console.WriteLine("Popped off {0}", stackOfPersons.Pop());
            Console.WriteLine("\nFirst person is: {0}", stackOfPersons.Peek());
            Console.WriteLine("Popped off {0}", stackOfPersons.Pop());
            Console.WriteLine("\nFirst person item is: {0}", stackOfPersons.Peek());
            Console.WriteLine("Popped off {0}", stackOfPersons.Pop());

            try
            {
                Console.WriteLine("\nFirst person item is: {0}", stackOfPersons.Peek());
                Console.WriteLine("Popped off {0}", stackOfPersons.Pop());
            }
            catch (InvalidOperationException ex)
            {
                //Console.WriteLine("Pop From Empty Stack!!");
                Console.WriteLine("Error! {0}", ex.Message);
            }



        }

    }


    #endregion

    #region Working with the Queue<T> Class
    // Working with the Queue<T> Class
    // Queues are containers that ensure items are accessed in a first-in, first-out manner.Sadly, we humans
    // are subject to queues all day long: lines at the bank, lines at the movie theater, and lines at the morning
    // coffeehouse. When you need to model a scenario in which items are handled on a first-come, first- served
    // basis, you will find the Queue<T> class fits the bill.In addition to the functionality provided by the supported
    // interfaces, Queue defines the key members shown in Table 9-6.

    // Table 9-6. Members of the Queue<T> Type
    // Select Member of Queue<T>            Meaning in Life
    // ===========================================================================
    // Dequeue()    Removes and returns the object at the beginning of the Queue<T>
    // ---------------------------------------------------------------------------
    // Enqueue()    Adds an object to the end of the Queue<T>
    // ---------------------------------------------------------------------------
    // Peek()       Returns the object at the beginning of the Queue<T> without removing it
    // ---------------------------------------------------------------------------
    class WorkingWithGenericQueue
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Generic Queue");
            Console.WriteLine("".PadLeft(40, '='));

            // Make a Q with three people.
            Queue<Person> peopleQ = new Queue<Person>();
            peopleQ.Enqueue(new Person(104, "Moamen"));
            peopleQ.Enqueue(new Person(103, "Mohammed"));
            peopleQ.Enqueue(new Person(107, "Kamal"));
            // Peek at first person in Q.
            Console.WriteLine("{0} is first in line!", peopleQ.Peek().Name);
            // Remove each person from Q.
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            // Try to de-Q again?
            try
            {
                GetCoffee(peopleQ.Dequeue());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error! {0}", e.Message);
            }
        }

        static void GetCoffee(Person p)
        {
            Console.WriteLine("{0} got coffee!", p.Name);
        }

    }
    #endregion

    #region Working with the HashSet<T> Class
    // The SortedSet<T> class is useful because it automatically ensures that the items in the set are sorted when
    // you insert or remove items.However, you do need to inform the SortedSet<T> class exactly how you
    // want it to sort the objects, by passing in as a constructor argument an object that implements the generic
    // IComparer<T> interface.
    class WorkingWithGenericHashSet
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Generic HashSet");
            Console.WriteLine("".PadLeft(40, '='));

            // HashSet Constructors
            HashSet<int> intset1 = new HashSet<int>();

            // public HashSet(IEnumerable<T> collection);
            // From Array
            HashSet<int> intset2 = new HashSet<int>(new[] { 10, 20, 30, 40, 50 });

            // public HashSet(IEnumerable<T> collection);
            // From List<>
            HashSet<int> intset3 = new HashSet<int>(new List<int> { 10, 20, 30, 40, 50 });

            // public HashSet(IEnumerable<T> collection);
            // From Another HashSet
            HashSet<int> intset4 = new HashSet<int>(intset2);

            // Make HashSet Depends on Hashing and Equality of Person Class, 
            // that doesn't allows To Repeate Persons with the same GetHashCode()
            HashSet<Person> people1 = new HashSet<Person>();
            // Add new Entries
            Console.WriteLine(@"Add Person(100, ""Moamen"", 25):{0}", people1.Add(new Person(100, "Moamen", 25))); // true
            Console.WriteLine(@"Add Person(100, ""Moamen"", 25):{0}", people1.Add(new Person(100, "Moamen", 25)));  // false
            Console.WriteLine(@"Add Person(200, ""Moamen"", 25):{0}", people1.Add(new Person(200, "Moamen", 25)));  // true
            Console.WriteLine(@"Add Person(100, ""Kamal"", 25):{0}", people1.Add(new  Person(100, "Kamal", 25)));   // true
            Console.WriteLine(@"Add Person(100, ""Moamen"", 30):{0}", people1.Add(new Person(100, "Moamen", 30)));  // true
            Console.WriteLine(@"Add Person(300, ""Mohammed"", 59):{0}", people1.Add(new Person(300, "Mohammed", 59)));  // true
            PrintSet(people1, "Default Constructor with Default Equality");


            // public HashSet(IEqualityComparer<T> comparer);
            // --------------------------------------------------------------------
            // Make HashSet Depends on Hashing and Equality of Age, 
            // that doesn't allows To Repeate Persons with the same Age
            HashSet<Person> people2 = new HashSet<Person>(Person.AgeEquality);
            Console.WriteLine(@"Add Person(100, ""Moamen"", 25):{0}", people2.Add(new Person(100, "Moamen", 25))); // true
            Console.WriteLine(@"Add Person(100, ""Moamen"", 25):{0}", people2.Add(new Person(100, "Moamen", 25)));  // false
            Console.WriteLine(@"Add Person(200, ""Moamen"", 25):{0}", people2.Add(new Person(200, "Moamen", 25)));  // true
            Console.WriteLine(@"Add Person(100, ""Kamal"", 25):{0}", people2.Add(new Person(100, "Kamal", 25)));   // true
            Console.WriteLine(@"Add Person(100, ""Moamen"", 30):{0}", people2.Add(new Person(100, "Moamen", 30)));  // true
            Console.WriteLine(@"Add Person(300, ""Mohammed"", 59):{0}", people2.Add(new Person(300, "Mohammed", 59)));  // true
            PrintSet(people2, "IEqualityComparer<T> Constructor with AgeEquality");


            // Make HashSet Depends on Hashing and Equality of Name, 
            // that doesn't allows To Repeate Persons with the same Name
            HashSet<Person> people3 = new HashSet<Person>(Person.NameEquality);
            Console.WriteLine(@"Add Person(100, ""Moamen"", 25):{0}", people3.Add(new Person(100, "Moamen", 25))); // true
            Console.WriteLine(@"Add Person(100, ""Moamen"", 25):{0}", people3.Add(new Person(100, "Moamen", 25)));  // false
            Console.WriteLine(@"Add Person(200, ""Moamen"", 25):{0}", people3.Add(new Person(200, "Moamen", 25)));  // true
            Console.WriteLine(@"Add Person(100, ""Kamal"", 25):{0}", people3.Add(new Person(100, "Kamal", 25)));   // true
            Console.WriteLine(@"Add Person(100, ""Moamen"", 30):{0}", people3.Add(new Person(100, "Moamen", 30)));  // true
            Console.WriteLine(@"Add Person(300, ""Mohammed"", 59):{0}", people3.Add(new Person(300, "Mohammed", 59)));  // true
            PrintSet(people3, "IEqualityComparer<T> Constructor with NameEquality");

            // Make HashSet Depends on Hashing and Equality of ID, 
            // that doesn't allows To Repeate Persons with the same ID
            HashSet<Person> people4 = new HashSet<Person>(Person.IDEquality);
            Console.WriteLine(@"Add Person(100, ""Moamen"", 25):{0}", people4.Add(new Person(100, "Moamen", 25))); // true
            Console.WriteLine(@"Add Person(100, ""Moamen"", 25):{0}", people4.Add(new Person(100, "Moamen", 25)));  // false
            Console.WriteLine(@"Add Person(200, ""Moamen"", 25):{0}", people4.Add(new Person(200, "Moamen", 25)));  // true
            Console.WriteLine(@"Add Person(100, ""Kamal"", 25):{0}", people4.Add(new Person(100, "Kamal", 25)));   // true
            Console.WriteLine(@"Add Person(100, ""Moamen"", 30):{0}", people4.Add(new Person(100, "Moamen", 30)));  // true
            Console.WriteLine(@"Add Person(300, ""Mohammed"", 59):{0}", people4.Add(new Person(300, "Mohammed", 59)));  // true
            PrintSet(people4, "IEqualityComparer<T> Constructor with IDEquality");



            // Create Object of HashSet With Default Constructor
            HashSet<Person> setOfPeople = new HashSet<Person>()
            {
                // use of Object init Syntax as HashSet<t> has Add() Function
                new Person(104,"Moamen",25),
                new Person(103,"Mohammed",27),
                new Person(107,"Kamal",24),
                new Person(101,"Mostafa",23),
                new Person(102,"Ali",30),
                new Person(106,"Waleed",15),
                new Person(107,"Helmy",31),
                new Person(120,"Samy",35),
                new Person(122,"Malek",41)
            };

            PrintSet(setOfPeople, "Print HashSet Items:");

            // Count Property
            Console.WriteLine($"setOfPeople.Count = {setOfPeople.Count}");
            Console.WriteLine();

            // public bool Add(T item);
            // Add 3 new Entries
            Console.WriteLine(@"Add Person(108, ""Shady"", 25):{0}", setOfPeople.Add(new Person(108, "Shady", 25)));
            Console.WriteLine(@"Add Person(109, ""Gamal"", 59):{0}", setOfPeople.Add(new Person(109, "Gamal", 59)));
            Console.WriteLine(@"Add Person(110, ""Ahmed"", 41):{0}", setOfPeople.Add(new Person(110, "Ahmed", 41)));
            // Print After Add Three Entries to HashSet
            PrintSet(setOfPeople, "HashSet After Add 3 Items:");

            // NOTE: that if you add entry that is exist's before in the set, it will not be added
            // Add the Same Last 3 Entries
            Console.WriteLine(@"Add Person(108, ""Shady"", 25):{0}", setOfPeople.Add(new Person(108, "Shady", 25)));
            Console.WriteLine(@"Add Person(109, ""Gamal"", 59):{0}", setOfPeople.Add(new Person(109, "Gamal", 59)));
            Console.WriteLine(@"Add Person(110, ""Ahmed"", 41):{0}", setOfPeople.Add(new Person(110, "Ahmed", 41)));
            // Print After Add Three Entries to HashSet
            PrintSet(setOfPeople, "HashSet After Add The Same 3 Items:");


            // public bool Contains(T item);
            Console.WriteLine(@"Contains Person(109, ""Gamal"", 59) = {0}", setOfPeople.Contains(new Person(109, "Gamal", 59)));
            Console.WriteLine(@"Contains Person(108, ""Shady"", 25) = {0}", setOfPeople.Contains(new Person(108, "Shady", 25)));
            // False Cases
            Console.WriteLine(@"Contains Person(-1, ""Shady"", 25) = {0}", setOfPeople.Contains(new Person(-1, "Shady", 25)));
            Console.WriteLine(@"Contains Person(108, ""Kemo"", 25) = {0}", setOfPeople.Contains(new Person(108, "Kemo", 25)));
            Console.WriteLine(@"Contains Person(108, ""Shady"", 10) = {0}", setOfPeople.Contains(new Person(108, "Shady", 10)));

            // public bool Remove(T item);
            Console.WriteLine(@"Remove Person(108, ""Shady"", 25):{0}", setOfPeople.Remove(new Person(108, "Shady", 25)));
            Console.WriteLine(@"Remove Person(109, ""Gamal"", 59):{0}", setOfPeople.Remove(new Person(109, "Gamal", 59)));
            Console.WriteLine(@"Remove Person(110, ""Ahmed"", 41):{0}", setOfPeople.Remove(new Person(110, "Ahmed", 41)));
            // Print After Remove 3 Entries to HashSet
            PrintSet(setOfPeople, "HashSet After Remove 3 Items:");

            // public int RemoveWhere(Predicate<T> match);
            // Remove Persons Where more than 29 and less than 41
            int removed = setOfPeople.RemoveWhere(x => x.Age >= 30 && x.Age <= 40);
            Console.WriteLine($"Remove {removed} Items From the HashSet");
            // Print After Remove 3 Entries to HashSet
            PrintSet(setOfPeople, "HashSet After Remove Persons Where more than 29 and less than 41:");

            // public void Clear();
            Console.WriteLine("Clear All Items in the Hashset...");
            setOfPeople.Clear();
            PrintSet(setOfPeople, "HashSet After Clear() Method Call:");
            Console.WriteLine("----------------------------------------------------------------");

            // ==================================================================================
            HashSet<int> integers = new HashSet<int>() { 10, 20, 30 };

            PrintSetLine(integers, "Set Of Integers");

            integers.UnionWith(new[] { 10, 20, 30, 40, 50, 60 });
            PrintSetLine(integers, "After UnionWith(new[] { 10, 20, 30, 40, 50, 60 })");


            integers = new HashSet<int>() { 10, 20, 30 };
            integers.ExceptWith(new[] { 20, 30, 40, 50, 60, 70});
            PrintSetLine(integers, "After ExceptWith(new[] { 20, 30, 40, 50, 60 })");



            // public void SymmetricExceptWith(IEnumerable<T> other);
            // Summary:
            //     Modifies the current System.Collections.Generic.HashSet`1 object to contain only
            //     elements that are present either in that object or in the specified collection,
            //     but not both.
            integers = new HashSet<int>() { 10, 20, 30 };
            integers.SymmetricExceptWith(new[] { 30, 40, 50 });
            PrintSetLine(integers, "After SymmetricExceptWith(new[] { 30, 40, 50 })");

            //public void IntersectWith(IEnumerable<T> other);
            integers = new HashSet<int>() { 10, 20, 30 };
            integers.IntersectWith(new[] { 20, 30, 40, 50, 60 });
            PrintSetLine(integers, "After IntersectWith(new[] { 20, 30, 40, 50, 60 })");



            // public bool SetEquals(IEnumerable<T> other);
            integers = new HashSet<int>() { 10, 20, 30 };

            bool result = integers.SetEquals(new[] { 10, 20, 30 });
            Console.WriteLine($@"SetEquals(new[] {{ 10,20, 30 }}) : {result}"); // true

            result = integers.SetEquals(new[] { 10, 20, 30, 10, 20, 30 });
            Console.WriteLine($@"SetEquals(new[] {{ 10,20, 30, 10, 20, 30 }}) : {result}"); // true

            result = integers.SetEquals(new[] { 10, 20, 30, 40, 50 });
            Console.WriteLine($@"SetEquals(new[] {{ 10, 20, 30, 40, 50 }}) : {result}");    // false


            //public bool IsProperSubsetOf(IEnumerable<T> other);
            integers = new HashSet<int>() { 10, 20, 30 };

            PrintSetLine(integers, "My HashSet");

            result = integers.IsProperSubsetOf(new[] { 10, 20, 30, 40, 50 });
            Console.WriteLine($@"IsProperSubsetOf(new[] {{ 10, 20, 30, 40, 50 }}) : {result}");     //true

            result = integers.IsProperSubsetOf(new[] { 10, 20, 30 });
            Console.WriteLine($@"IsProperSubsetOf(new[] {{ 10, 20, 30 }}) : {result}");     // false

            result = integers.IsProperSubsetOf(new[] { 10, 40, 50 });
            Console.WriteLine($@"IsProperSubsetOf(new[] {{ 10, 40, 50 }}) : {result}");     // false

            result = integers.IsProperSubsetOf(new[] { 40, 50 });
            Console.WriteLine($@"IsProperSubsetOf(new[] {{  40, 50 }}) : {result}");        // false


            //public bool IsProperSupersetOf(IEnumerable<T> other);
            integers = new HashSet<int>() { 10, 20, 30 };

            PrintSetLine(integers, "My HashSet");

            result = integers.IsProperSupersetOf(new[] { 10, 20, 30, 40, 50 });
            Console.WriteLine($@"IsProperSupersetOf(new[] {{ 10, 20, 30, 40, 50 }}) : {result}");   // false
            
            result = integers.IsProperSupersetOf(new[] { 10, 20, 30 });
            Console.WriteLine($@"IsProperSupersetOf(new[] {{ 10, 20, 30 }}) : {result}"); // false

            result = integers.IsProperSupersetOf(new[] { 10, 20 });
            Console.WriteLine($@"IsProperSupersetOf(new[] {{ 10, 20 }}) : {result}");   // true

            result = integers.IsProperSupersetOf(new[] { 10, 40, 50 });
            Console.WriteLine($@"IsProperSupersetOf(new[] {{ 10, 40, 50 }}) : {result}");   // false


            //public bool IsSubsetOf(IEnumerable<T> other);
            integers = new HashSet<int>() { 10, 20, 30 };

            PrintSetLine(integers, "My HashSet");

            result = integers.IsSubsetOf(new[] { 10, 20, 30, 40, 50 });
            Console.WriteLine($@"IsSubsetOf(new[] {{ 10, 20, 30, 40, 50 }}) : {result}");   // true

            result = integers.IsSubsetOf(new[] { 10, 20, 30 });
            Console.WriteLine($@"IsSubsetOf(new[] {{ 10, 20, 30 }}) : {result}");   // true

            result = integers.IsSubsetOf(new[] { 10, 40, 50 });
            Console.WriteLine($@"IsSubsetOf(new[] {{ 10, 40, 50 }}) : {result}");   // false

            result = integers.IsSubsetOf(new[] { 40, 50 });
            Console.WriteLine($@"IsSubsetOf(new[] {{  40, 50 }}) : {result}");  // false


            //public bool IsSupersetOf(IEnumerable<T> other);
            integers = new HashSet<int>() { 10, 20, 30 };

            PrintSetLine(integers, "My HashSet");

            result = integers.IsSupersetOf(new[] { 10, 20, 30, 40, 50 });
            Console.WriteLine($@"IsSupersetOf(new[] {{ 10, 20, 30, 40, 50 }}) : {result}");   // false

            result = integers.IsSupersetOf(new[] { 10, 20, 30 });
            Console.WriteLine($@"IsSupersetOf(new[] {{ 10, 20, 30 }}) : {result}"); // true

            result = integers.IsSupersetOf(new[] { 10, 20 });
            Console.WriteLine($@"IsSupersetOf(new[] {{ 10, 20 }}) : {result}");   // true

            result = integers.IsSupersetOf(new[] { 10, 40, 50 });
            Console.WriteLine($@"IsSupersetOf(new[] {{ 10, 40, 50 }}) : {result}");   // false

            //public bool Overlaps(IEnumerable<T> other);
            //public bool Overlaps(IEnumerable<T> other);
            integers = new HashSet<int>() { 10, 20, 30 };

            PrintSetLine(integers, "My HashSet");

            result = integers.Overlaps(new[] { 10, 20, 30, 40, 50 });
            Console.WriteLine($@"Overlaps(new[] {{ 10, 20, 30, 40, 50 }}) : {result}");   // true

            result = integers.Overlaps(new[] { 10, 20, 30 });
            Console.WriteLine($@"Overlaps(new[] {{ 10, 20, 30 }}) : {result}"); // true

            result = integers.Overlaps(new[] { 10, 20 });
            Console.WriteLine($@"Overlaps(new[] {{ 10, 20 }}) : {result}");   // true

            result = integers.Overlaps(new[] { 10, 40, 50 });
            Console.WriteLine($@"Overlaps(new[] {{ 10, 40, 50 }}) : {result}");   // tue

            result = integers.Overlaps(new[] { 40, 50 });
            Console.WriteLine($@"Overlaps(new[] {{ 40, 50 }}) : {result}");   // false

            // public void CopyTo(T[] array, int arrayIndex);
            // public void CopyTo(T[] array, int arrayIndex, int count);
            // public void CopyTo(T[] array);

            integers = new HashSet<int>() { 10, 20, 30 };
            int [] arr1 = new int[integers.Count];
            PrintSetLine(integers, "My HashSet");
            integers.CopyTo(arr1);
            PrintListLine(arr1, "My Copied Array");

        }


        public static void TestHashSetWithString()
        {

            //IntersectWith removes the elements that are not in both sets. We can
            //extract all of the vowels from our set of characters as follows:
            var letters = new HashSet<char>("the quick brown fox");
            letters.IntersectWith("aeiou");
            foreach (char c in letters) Console.Write(c); // euio


            //ExceptWith removes the specified elements from the source set.
            // Here, we strip all vowels from the set:
            letters = new HashSet<char>("the quick brown fox");
            letters.ExceptWith("aeiou");
            foreach (char c in letters) Console.Write(c); // th qckbrwnfx


        }


    }

    #endregion

    #region Working with the SortedSet<T> Class
    // The SortedSet<T> class is useful because it automatically ensures that the items in the set are sorted when
    // you insert or remove items.However, you do need to inform the SortedSet<T> class exactly how you
    // want it to sort the objects, by passing in as a constructor argument an object that implements the generic
    // IComparer<T> interface.
    class WorkingWithGenericSortedSet
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Generic SortedSet");
            Console.WriteLine("".PadLeft(40, '='));

            
            // Create Object of Sorted Set With Constructor With IComparer<> 
            SortedSet<Person> setOfPeople = new SortedSet<Person>(Person.AgeAscendingSort)
            {
                // use of Object init Syntax as SortedSet<t> has Add() Function
                new Person(104,"Moamen",25),
                new Person(103,"Mohammed",27),
                new Person(107,"Kamal",24),
                new Person(101,"Mostafa",23),
                new Person(102,"Ali",30),
                new Person(106,"Waleed",15),
                new Person(105,"Helmy",15) // will not be added as age exists before
            };

            // Note the items are sorted by age!
            PrintSet(setOfPeople, "Print SortedSet Items depends on Age:");
            Console.WriteLine($"setOfPeople.Count---: {setOfPeople.Count}");
            Console.WriteLine($"setOfPeople.Min-----: {setOfPeople.Min}");
            Console.WriteLine($"setOfPeople.Max-----: {setOfPeople.Max}");
            Console.WriteLine($"setOfPeople.Comparer: {setOfPeople.Comparer}");


            // Add a few new people, with various ages.
            setOfPeople.Add(new Person(110, "Gamal", 12));
            setOfPeople.Add(new Person(112, "Ahmed", 40));
            // will not be added as age is exists before
            setOfPeople.Add(new Person(113, "Kemo", 40));


            // Note Still sorted by age!
            PrintSet(setOfPeople, "Sorted Set After Add 3 Items:");
            PrintSetInfo(setOfPeople);

            // -----------------------------------------------------------------------------------------
            // Create Object of Sorted Set With Constructor With IComparer<> 
            SortedSet<Person> sortedPeopleWithID = new SortedSet<Person>(Person.IDAscendingSort)
            {
                // use of Object init Syntax as SortedSet<t> has Add() Function
                new Person(104,"Moamen",25),
                new Person(103,"Mohammed",27),
                new Person(107,"Kamal",24),
                new Person(101,"Mostafa",23),
                new Person(102,"Ali",30),
                new Person(106,"Waleed",15),
                new Person(106,"Helmy",31) // will not be added because of ID was exists before in the list
            };

            // Note the items are sorted by ID!
            PrintSet(sortedPeopleWithID, "Print Set Items:");
            PrintSetInfo(sortedPeopleWithID);

            // Add a few new people, with various ID.
            sortedPeopleWithID.Add(new Person(110, "Gamal", 12));
            sortedPeopleWithID.Add(new Person(112, "Ahmed", 40));
            // repeated ID will not be added
            sortedPeopleWithID.Add(new Person(112, "Kemo", 41));

            // Note Still sorted by ID!
            PrintSet(sortedPeopleWithID, "Sorted Set After Add Two Items:");
            PrintSetInfo(sortedPeopleWithID);




            // ==================================================================================
            SortedSet<int> integers = new SortedSet<int>() { 10, 20, 30 };

            PrintSetLine(integers, "Set Of Integers");

            integers.UnionWith(new[] { 10, 20, 30, 40, 50, 60 });
            PrintSetLine(integers, "After UnionWith(new[] { 10, 20, 30, 40, 50, 60 })");


            integers = new SortedSet<int>() { 10, 20, 30 };
            integers.ExceptWith(new[] { 20, 30, 40, 50, 60, 70 });
            PrintSetLine(integers, "After ExceptWith(new[] { 20, 30, 40, 50, 60, 70 })");



            // public void SymmetricExceptWith(IEnumerable<T> other);
            // Summary:
            //     Modifies the current System.Collections.Generic.SortedSet`1 object to contain only
            //     elements that are present either in that object or in the specified collection,
            //     but not both.
            integers = new SortedSet<int>() { 10, 20, 30 };
            integers.SymmetricExceptWith(new[] { 30, 40, 50 });
            PrintSetLine(integers, "After SymmetricExceptWith(new[] { 30, 40, 50 })");

            //public void IntersectWith(IEnumerable<T> other);
            integers = new SortedSet<int>() { 10, 20, 30};
            integers.IntersectWith(new[] { 20, 30, 40, 50, 60 });
            PrintSetLine(integers, "After IntersectWith(new[] { 20, 30, 40, 50, 60 })");



            // public bool SetEquals(IEnumerable<T> other);
            integers = new SortedSet<int>() { 10, 20, 30 };

            bool result = integers.SetEquals(new[] { 10, 20, 30 });
            Console.WriteLine($@"SetEquals(new[] {{ 10,20, 30 }}) : {result}"); // true

            result = integers.SetEquals(new[] { 10, 20, 30, 10, 20, 30 });
            Console.WriteLine($@"SetEquals(new[] {{ 10,20, 30, 10, 20, 30 }}) : {result}"); // true

            result = integers.SetEquals(new[] { 10, 20, 30, 40, 50 });
            Console.WriteLine($@"SetEquals(new[] {{ 10, 20, 30, 40, 50 }}) : {result}");    // false


            //public bool IsProperSubsetOf(IEnumerable<T> other);
            integers = new SortedSet<int>() { 10, 20, 30 };

            PrintSetLine(integers, "My SortedSet");

            result = integers.IsProperSubsetOf(new[] { 10, 20, 30, 40, 50 });
            Console.WriteLine($@"IsProperSubsetOf(new[] {{ 10, 20, 30, 40, 50 }}) : {result}");     //true

            result = integers.IsProperSubsetOf(new[] { 10, 20, 30 });
            Console.WriteLine($@"IsProperSubsetOf(new[] {{ 10, 20, 30 }}) : {result}");     // false

            result = integers.IsProperSubsetOf(new[] { 10, 40, 50 });
            Console.WriteLine($@"IsProperSubsetOf(new[] {{ 10, 40, 50 }}) : {result}");     // false

            result = integers.IsProperSubsetOf(new[] { 40, 50 });
            Console.WriteLine($@"IsProperSubsetOf(new[] {{  40, 50 }}) : {result}");        // false


            //public bool IsProperSupersetOf(IEnumerable<T> other);
            integers = new SortedSet<int>() { 10, 20, 30 };

            PrintSetLine(integers, "My SortedSet");

            result = integers.IsProperSupersetOf(new[] { 10, 20, 30, 40, 50 });
            Console.WriteLine($@"IsProperSupersetOf(new[] {{ 10, 20, 30, 40, 50 }}) : {result}");   // false

            result = integers.IsProperSupersetOf(new[] { 10, 20, 30 });
            Console.WriteLine($@"IsProperSupersetOf(new[] {{ 10, 20, 30 }}) : {result}"); // false

            result = integers.IsProperSupersetOf(new[] { 10, 20 });
            Console.WriteLine($@"IsProperSupersetOf(new[] {{ 10, 20 }}) : {result}");   // true

            result = integers.IsProperSupersetOf(new[] { 10, 40, 50 });
            Console.WriteLine($@"IsProperSupersetOf(new[] {{ 10, 40, 50 }}) : {result}");   // false


            //public bool IsSubsetOf(IEnumerable<T> other);
            integers = new SortedSet<int>() { 10, 20, 30 };

            PrintSetLine(integers, "My SortedSet");

            result = integers.IsSubsetOf(new[] { 10, 20, 30, 40, 50 });
            Console.WriteLine($@"IsSubsetOf(new[] {{ 10, 20, 30, 40, 50 }}) : {result}");   // true

            result = integers.IsSubsetOf(new[] { 10, 20, 30 });
            Console.WriteLine($@"IsSubsetOf(new[] {{ 10, 20, 30 }}) : {result}");   // true

            result = integers.IsSubsetOf(new[] { 10, 40, 50 });
            Console.WriteLine($@"IsSubsetOf(new[] {{ 10, 40, 50 }}) : {result}");   // false

            result = integers.IsSubsetOf(new[] { 40, 50 });
            Console.WriteLine($@"IsSubsetOf(new[] {{  40, 50 }}) : {result}");  // false


            //public bool IsSupersetOf(IEnumerable<T> other);
            integers = new SortedSet<int>() { 10, 20, 30 };

            PrintSetLine(integers, "My SortedSet");

            result = integers.IsSupersetOf(new[] { 10, 20, 30, 40, 50 });
            Console.WriteLine($@"IsSupersetOf(new[] {{ 10, 20, 30, 40, 50 }}) : {result}");   // false

            result = integers.IsSupersetOf(new[] { 10, 20, 30 });
            Console.WriteLine($@"IsSupersetOf(new[] {{ 10, 20, 30 }}) : {result}"); // true

            result = integers.IsSupersetOf(new[] { 10, 20 });
            Console.WriteLine($@"IsSupersetOf(new[] {{ 10, 20 }}) : {result}");   // true

            result = integers.IsSupersetOf(new[] { 10, 40, 50 });
            Console.WriteLine($@"IsSupersetOf(new[] {{ 10, 40, 50 }}) : {result}");   // false

            //public bool Overlaps(IEnumerable<T> other);
            //public bool Overlaps(IEnumerable<T> other);
            integers = new SortedSet<int>() { 10, 20, 30 };

            PrintSetLine(integers, "My SortedSet");

            result = integers.Overlaps(new[] { 10, 20, 30, 40, 50 });
            Console.WriteLine($@"Overlaps(new[] {{ 10, 20, 30, 40, 50 }}) : {result}");   // true

            result = integers.Overlaps(new[] { 10, 20, 30 });
            Console.WriteLine($@"Overlaps(new[] {{ 10, 20, 30 }}) : {result}"); // true

            result = integers.Overlaps(new[] { 10, 20 });
            Console.WriteLine($@"Overlaps(new[] {{ 10, 20 }}) : {result}");   // true

            result = integers.Overlaps(new[] { 10, 40, 50 });
            Console.WriteLine($@"Overlaps(new[] {{ 10, 40, 50 }}) : {result}");   // tue

            result = integers.Overlaps(new[] { 40, 50 });
            Console.WriteLine($@"Overlaps(new[] {{ 40, 50 }}) : {result}");   // false

            // public void CopyTo(T[] array, int arrayIndex);
            // public void CopyTo(T[] array, int arrayIndex, int count);
            // public void CopyTo(T[] array);

            integers = new SortedSet<int>() { 10, 20, 30 };
            int[] arr1 = new int[integers.Count];
            PrintSetLine(integers, "My SortedSet");
            integers.CopyTo(arr1);
            PrintListLine(arr1, "My Copied Array");

            // public virtual SortedSet<T> GetViewBetween(T lowerValue, T upperValue);
            // -----------------------------------------------------------------------
            integers = new SortedSet<int> { 10, 20, 30, 40, 50, 60, 70 };
            PrintSetLine(integers);
            SortedSet<int> viewSet = integers.GetViewBetween(30, 50);
            PrintSetLine(viewSet, "View From integers.GetViewBetween(T lowerValue, T upperValue)");


            // public IEnumerable<T> Reverse();

            PrintSetLine(integers.Reverse(), "Print SortedSet With Reverse Enumerator");

        }


    }

    #endregion

    #region Working with the Dictionary<T> Class

    class WorkingWithGenericDictionary
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Generic Dictionary");
            Console.WriteLine("".PadLeft(40, '='));


            Dictionary<string, Array> numberGroups = new Dictionary<string, Array>();
            // Add() Method
            numberGroups.Add("integers", new int[] { 10, 20, 30, 40 });
            numberGroups.Add("doubles", new double[] { 10.45, 20.45, 30.45, 40.45 });
            numberGroups.Add("characters", new char[] { 'A', 'B', 'C', 'D' });

            PrintDictionary(numberGroups);


            // Create Object of Dictionary With Object Init Syntax
            Dictionary<string, Array> numberGroups2 = new Dictionary<string, Array>()
            {
                { "integers", new int[] { 10, 20, 30, 40 } },
                { "doubles", new double[] { 10.45, 20.45, 30.45, 40.45 }  },
                { "characters", new char[] { 'A', 'B', 'C', 'D' }}
            };

            PrintDictionary(numberGroups2);


            // Create Object of Dictionary With Dictionary Initialization Syntax
            Dictionary<string, Person> dictionaryInitSyntax = new Dictionary<string, Person>()
            {
                ["Kamal"] = new Person() { ID = 100, Name = "Kamal", Age = 20 },
                ["Ahmed"] = new Person() { ID = 200, Name = "Ahmed", Age = 24 },
                ["Shady"] = new Person() { ID = 300, Name = "Shady", Age = 29 }

            };

            PrintDictionary(dictionaryInitSyntax);


            // Create Object of Dictionary With Object Init Syntax
            Dictionary<string, Person> dictionaryOfPeople = new Dictionary<string, Person>()
            {
                // use of Object init Syntax as Dictionary<TKey, TValue> has Add() Function
                { "Moamen" , new Person(104, "Moamen", 25)},
                { "Mohammed" , new Person(103,"Mohammed",27)},
                { "Kamal" , new Person(107,"Kamal",24)},
                { "Mostafa" , new Person(101,"Mostafa",23)},
                { "Ali" , new Person(102,"Ali",30)},
                { "Waleed" , new Person(106,"Waleed",15)},


            };

            // Use KeyValuePair<TKey, TValue> to get Dictionary items item by item.
            Console.WriteLine("Print Dictionary: ");
            Console.WriteLine("".PadLeft(50, '='));

            foreach (KeyValuePair<string, Person> item in dictionaryOfPeople)
            {
                Console.WriteLine($"Item[{item.Key}] = {item.Value}");
            }
            Console.WriteLine();

            // Call Item From Dictionary With Key using [] Operator
            Person p1 = dictionaryOfPeople["Kamal"];
            Console.WriteLine($@"dictionaryOfPeople[""Kamal""] : {p1}");
            Console.WriteLine($@"dictionaryOfPeople[""Moamen""] : {dictionaryOfPeople["Moamen"]}");
            try
            {
                // Try To Use a Key Not Found in Dictionary will Throw Exception
                Console.WriteLine($@"dictionaryOfPeople[""Hammad""] : {dictionaryOfPeople["Hammad"]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, {0}", ex.Message);
            }

            // To avoid exceptions in getting a value with key may be not found, you can use:
            // public bool TryGetValue(TKey key, out TValue value);
            Console.WriteLine($@"dictionaryOfPeople.TryGetValue(""Moamen"", out Person p) 
                : {dictionaryOfPeople.TryGetValue("Moamen", out Person p2)}, {p2}");
            Console.WriteLine($@"dictionaryOfPeople.TryGetValue(""Hammad"", out Person p) 
                : {dictionaryOfPeople.TryGetValue("Hammad", out Person p3)}, {p3}");

            // public void Add(TKey key, TValue value);
            dictionaryOfPeople.Add("Helmy", new Person(105, "Helmy", 31));
            dictionaryOfPeople.Add("Sameer", new Person(109, "Sameer", 27));
            PrintDictionary(dictionaryOfPeople, "People After Add Two Entries");

            // public bool Remove(TKey key);
            dictionaryOfPeople.Remove("Helmy");
            dictionaryOfPeople.Remove("Sameer");
            PrintDictionary(dictionaryOfPeople, "People After Remove Two new Entries");

            // Count Property
            Console.WriteLine($@"dictionaryOfPeople has : {dictionaryOfPeople.Count} Person");

            // public bool ContainsKey(TKey key);
            Console.WriteLine($@"dictionaryOfPeople.ContainsKey(""Moamen"") : {dictionaryOfPeople.ContainsKey("Moamen")}");
            Console.WriteLine($@"dictionaryOfPeople.ContainsKey(""Mostafa"") : {dictionaryOfPeople.ContainsKey("Mostafa")}");
            Console.WriteLine($@"dictionaryOfPeople.ContainsKey(""Kemo"") : {dictionaryOfPeople.ContainsKey("Kemo")}");


            // public bool ContainsValue(TValue value);
            Console.WriteLine($@"dictionaryOfPeople.ContainsValue(new Person(104,""""): {dictionaryOfPeople.ContainsValue(new Person(104, ""))}");
            Console.WriteLine($@"dictionaryOfPeople.ContainsValue(new Person(-1,""Moamen""): {dictionaryOfPeople.ContainsValue(new Person(-1, "Moamen"))}");
            Console.WriteLine($@"dictionaryOfPeople.ContainsValue(new Person(104,""Moamen"",25): {dictionaryOfPeople.ContainsValue(new Person(104, "Moamen", 25))}");

            // Get All Keys
            // public ValueCollection Values { get; }
            Dictionary<string, Person>.ValueCollection values = dictionaryOfPeople.Values;
            PrintList(values, "Print Values Of Dictionary");

            // Get All Values
            // public KeyCollection Keys { get; }
            Dictionary<string, Person>.KeyCollection keys = dictionaryOfPeople.Keys;
            PrintList(keys, "Print Keys Of Dictionary");

            // Clear all Entries of the dictionary
            // public void Clear();
            dictionaryOfPeople.Clear();


            // TryAdd();
            // Try






        }

    }


    #endregion

    #region Working with the SortedDictionary<T> Class

    class WorkingWithGenericSortedDictionary
    {
        // Summary:
        //     Represents a collection of key/value pairs that are sorted on the key.
        // it's exaclty like Dictionary<T> except that it is sorted and when you enumerate it 
        // it will return data sorted depends on the key

        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Generic Sorted Dictionary");
            Console.WriteLine("".PadLeft(40, '='));

            // Create Object of SortedDictionary With Object Init Syntax
            // Using Default TKey Comparer
            SortedDictionary<string, Person> sortedDictionary2 = new SortedDictionary<string, Person>()
            {
                // use of Object init Syntax as Dictionary<TKey, TValue> has Add() Function
                { "Moamen" , new Person(104, "Moamen", 25)},
                { "Mohammed" , new Person(103,"Mohammed",27)},
                { "Kamal" , new Person(107,"Kamal",24)},
                { "Mostafa" , new Person(101,"Mostafa",23)},
                { "Ali" , new Person(102,"Ali",30)},
                { "Waleed" , new Person(106,"Waleed",15)},
            };

            PrintDictionary(sortedDictionary2, "Print SortedDictionary Items:");

        }

    }

    #endregion

    #region Working with the SortedList<T> Class

    class WorkingWithGenericSortedList
    {
        // Summary: 
        //     Represents a collection of key/value pairs that are sorted by key based
        //     on the associated System.Collections.Generic.IComparer`1 implementation.
        // it is functionaly the same as the SortedDictionary<T,K> except that
        // it is internaly uses a List
        // it is more memory efficient, but less in Modification that the SortedDictionary
        // it's Modification O is O(n) but SortedDictionary<T,K> is O(n log n)


        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Generic Sorted Dictionary");
            Console.WriteLine("".PadLeft(40, '='));

            // Create Object of SortedList With Object Init Syntax
            // Using Default TKey Comparer
            SortedList<string, Person> sortedDictionary2 = new SortedList<string, Person>()
            {
                // use of Object init Syntax as Dictionary<TKey, TValue> has Add() Function
                { "Moamen" , new Person(104, "Moamen", 25)},
                { "Mohammed" , new Person(103,"Mohammed",27)},
                { "Kamal" , new Person(107,"Kamal",24)},
                { "Mostafa" , new Person(101,"Mostafa",23)},
                { "Ali" , new Person(102,"Ali",30)},
                { "Waleed" , new Person(106,"Waleed",15)},
            };

            PrintDictionary(sortedDictionary2, "Print SortedList Items:");

        }

    }

    #endregion


    // ================================================
    // The System.Collections.ObjectModel Namespace
    // ================================================
    // namespace of it is System.Collections.ObjectModel;
    #region Working with the ObservableCollection<T> Class
    class WorkingWithGenericObservableCollection
    {
        // The ObservableCollection<T> class is useful in that it has the ability to inform external 
        // objects when its contents have changed in some way(as you might guess, working with 
        // ReadOnlyObservableCollection <T> is similar but read-only in nature).

        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Generic ObservableCollection");
            Console.WriteLine("".PadLeft(40, '='));

            // Create Object of ObservableCollection
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person(){ ID=100, Name="Moamen", Age=25},
                new Person(){ ID=200, Name="Mohammed", Age=59},
                new Person(){ ID=300, Name="Gamal", Age=59},
                new Person(){ ID=400, Name="Ahmed", Age=90},
                
            };

            // register listener
            people.CollectionChanged += peopleCollectionChanged;

            people.Add(new Person() { ID = 500, Name = "Soroor", Age = 100 });
            people.Add(new Person() { ID = 600, Name = "Rahma", Age = 30 });

            people.Remove(new Person(300, "Soroor", 100));
            people.RemoveAt(0);

            people.Insert(0, new Person(700, "Kamal", 29));

            people.Move(0, 1);

            people.Clear();

        }

        private static void peopleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("==================== Collection Observer ====================");
            Console.WriteLine($"Sender: {sender}");
            Console.WriteLine($"Action for Event: {e.Action}");
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    PrintList(e.NewItems, "New Items Added To ObservableCollection");
                    Console.WriteLine($"e.OldItemIndex : {e.OldStartingIndex}");
                    Console.WriteLine($"e.NewItemIndex : {e.NewStartingIndex}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    PrintList(e.OldItems, "Items Removed From ObservableCollection");
                    Console.WriteLine($"e.OldStartingIndex : {e.OldStartingIndex}");
                    Console.WriteLine($"e.NewStartingIndex : {e.NewStartingIndex}");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    PrintList(e.OldItems, "Replace Action OldItems ObservableCollection");
                    PrintList(e.NewItems, "Replace Action newItems  ObservableCollection");
                    Console.WriteLine($"e.OldStartingIndex : {e.OldStartingIndex}");
                    Console.WriteLine($"e.NewStartingIndex : {e.NewStartingIndex}");
                    break;
                case NotifyCollectionChangedAction.Move:
                    PrintList(e.OldItems, "Move Action OldItems ObservableCollection");
                    PrintList(e.NewItems, "Move Action newItems  ObservableCollection");
                    Console.WriteLine($"e.OldStartingIndex : {e.OldStartingIndex}");
                    Console.WriteLine($"e.NewStartingIndex : {e.NewStartingIndex}");
                    break;
                case NotifyCollectionChangedAction.Reset:
                    PrintList(e.OldItems, "Reset Action OldItems ObservableCollection");
                    PrintList(e.NewItems, "Reset Action newItems  ObservableCollection");
                    Console.WriteLine($"e.OldStartingIndex : {e.OldStartingIndex}");
                    Console.WriteLine($"e.NewStartingIndex : {e.NewStartingIndex}");
                    break;
                default:
                    break;

            }
            
            Console.WriteLine("=============================================================");

        }
    }

    #endregion


    #region Working With ReadOnly Collections

    // ================================================
    // Working With ReadOnly Collections
    // ================================================
    // read only collections are just a wrapper of it's underlaying collection
    // it consider as an interface/cover for the list
    // - you can't add or remove items from the readonly collection
    //   but you can add and remove from reference to it's underlaying collection
    //   so it is not immutable but just a read only interface pattern

    #endregion


    // namespace of it is System.Collections.ObjectModel;
    #region Working with the ReadOnlyCollection<T> Class
    // namespace of it is System.Collections.ObjectModel;
    // Provides the base class for a generic read-only collection.
    // 
    public class WorkingWithGenericReadOnlyCollection
    {


        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Generic ReadOnlyCollection");
            Console.WriteLine("".PadLeft(40, '='));

            // Create Object of ObservableCollection
            List<string> list = new List<string>() { "ali", "ahmed", "mohammed" };

            ReadOnlyCollection<string> readonlyList = new ReadOnlyCollection<string>(list);

            // now you can't add or remove using readonlyList
            //readonlyList.Add(); // add not exists

            // but you can add or remove to the underlaying collection
            // and that modification will reflect on the ReadOnlyCollection
            list.Add("Mahmmoud");

            Console.WriteLine(string.Join(", ", readonlyList));

            // Expected output: 
            // Working With Generic ReadOnlyCollection
            // ========================================
            // ali, ahmed, mohammed, Mahmmoud

        }

    }

    #endregion


    // namespace of it is System.Collections.ObjectModel;
    #region Working with the ReadOnlyObservableCollection<T> Class
    // namespace of it is System.Collections.ObjectModel;
    public class WorkingWithGenericReadOnlyObservableCollection
    {


        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With Generic ReadOnlyObservableCollection");
            Console.WriteLine("".PadLeft(40, '='));

            // Create Object of ObservableCollection
            ObservableCollection<string> list = new ObservableCollection<string>();

            ReadOnlyObservableCollection<string> list2 = new ReadOnlyObservableCollection<string>(list);

        }

    }

    #endregion


    #region Working With Immutable Collections
    // ================================================
    // Working With Immutable Collections
    // ================================================
    // Immutable collections: it is doesn't allow modification to be done in the same object
    //  all the modification methods returns a new list with the update in it
    //  without change the current collection

    // IImmutableList<> Interface has the following methods: 

    //IImmutableList<T> Add(T value);
    //IImmutableList<T> AddRange(IEnumerable<T> items);
    //IImmutableList<T> Clear();
    //int IndexOf(T item, int index, int count, IEqualityComparer<T>? equalityComparer);
    //IImmutableList<T> Insert(int index, T element);
    //IImmutableList<T> InsertRange(int index, IEnumerable<T> items);
    //int LastIndexOf(T item, int index, int count, IEqualityComparer<T>? equalityComparer);
    //IImmutableList<T> Remove(T value, IEqualityComparer<T>? equalityComparer);
    //IImmutableList<T> RemoveAll(Predicate<T> match);
    //IImmutableList<T> RemoveAt(int index);
    //IImmutableList<T> RemoveRange(IEnumerable<T> items, IEqualityComparer<T>? equalityComparer);
    //IImmutableList<T> RemoveRange(int index, int count);
    //IImmutableList<T> Replace(T oldValue, T newValue, IEqualityComparer<T>? equalityComparer);
    //IImmutableList<T> SetItem(int index, T value);



    //public ImmutableList<T>.Builder ToBuilder();

    public class WorkingWithImmutableCollections
    {

        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine("Working With ImmutableCollections");
            Console.WriteLine("".PadLeft(40, '='));


            // Create Object of ObservableCollection
            List<string> list = new List<string>() { "ali", "ahmed", "mohammed" };

            ImmutableList<string> imList = list.ToImmutableList();
            var newImList = imList.Add("ahmed");

            var newImList2 = newImList.Remove("ali");


            Console.WriteLine($"imList----: {string.Join(", ", imList)}");
            Console.WriteLine($"newImList-: {string.Join(", ", newImList)}");
            Console.WriteLine($"newImList2: {string.Join(", ", newImList2)}");

            // Expected output: 
            // Working With ImmutableCollections
            // ========================================
            // imList----: ali, ahmed, mohammed
            // newImList-: ali, ahmed, mohammed, ahmed
            // newImList2: ahmed, mohammed, ahmed



            // immutable types that are the immutable version of mutable collections

            ImmutableArray<string> imArray = list.ToImmutableArray();
            ImmutableHashSet<string> imHashset = list.ToImmutableHashSet();
            ImmutableDictionary<string,string> imDictionary = list.ToImmutableDictionary(k=> k);
            ImmutableSortedDictionary<string,string> imSortedDictionary = list.ToImmutableSortedDictionary(k=> k,v=> v);
            ImmutableSortedSet<string> imSortedSet = list.ToImmutableSortedSet(StringComparer.OrdinalIgnoreCase);



        }

    }




    #endregion




    class CollectionsTraining
    {

        public static void TestCollections()
        {

            //WorkingWithArrayList.Test();
            //WorkingWithStack.Test();
            //WorkingWithQueue.Test();
            //WorkingWithSortedList.Test();
            //WorkingWithHashtable.Test();
            //WorkingWithBitArray.Test();
            //WorkingWithHybridDictionary.Test();
            //WorkingWithListDictionary.Test();
            //WorkingWithStringCollection.Test();
            //WorkingWithBitVector32.Test();

            //BoxingAndUnboxing.Test();
            //TestTypeSafety.Test();
            //TestCustomCollectionsType.Test();


            // -------------------------------------------------------------------

            //TypeParameterForGenericMembers.Test();
            //TypeParameterForGenericInterfaces.Test();
            //CollectionInitializationSyntax.Test();

            //WorkingWithGenericList.Test();
            //WorkingWithGenericLinkedList.Test();
            //WorkingWithGenericStack.Test();
            //WorkingWithGenericQueue.Test();
            //WorkingWithGenericHashSet.Test();
            //WorkingWithGenericSortedSet.Test();
            //WorkingWithGenericDictionary.Test();
            //WorkingWithGenericSortedDictionary.Test();
            //WorkingWithGenericObservableCollection.Test();
            //WorkingWithGenericReadOnlyObservableCollection.Test();


        }

    }

}

//- Introduction to Collections and Generics
//- Nongeneric collections (System.Collections namespace)
//- Working with the ArrayList Class
//- Working with the Stack Class
//- Working with the Queue Class
//- Working with the SortedList Class
//- Working with the Hashtable Class
//- Working with the BitArray Class
//- Working with the HybridDictionary Class
//- Working with the ListDictionary Class
//- Working with the StringCollection Class
//- Working with the BitVector32 Class
//- Boxing and Unboxing
//- The Problems of Nongeneric Collections
//- A First Look at Generic Collections
//- The Role of Generic Type Parameters
//- Specifying Type Parameters for Generic Interfaces
//- The System.Collections.Generic Namespace
//- Understanding Collection Initialization Syntax
//- Working with the List<T> Class
//- Sort List Elements Using Default Comparer
//- Sort List Descending by ID
//- Sort List Ascending by Name
//- Sort List Ascending by Name Ignore Case
//- Sort List Descending by Name
//- Sort List Descending by Name Ignore Case
//- Binary Search On a List
//- Find Person With Specific ID or Name or Char of Name
//- Find Person Index With Specific ID or Name or Char of Name
//- Working with the LinkedList<T> Class
//- Working with the Stack<T> Class
//- Working with the Queue<T> Class
//- Working with the HashSet<T> Class
//- Working with the SortedSet<T> Class
//- Working with the Dictionary<T> Class
//- Working with the SortedDictionary<T> Class
//- Working with the ObservableCollection<T> Class
//- Working with the ReadOnlyObservableCollection<T> Class
