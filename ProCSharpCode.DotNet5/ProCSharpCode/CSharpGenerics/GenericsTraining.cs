using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ProCSharpCode.CSharpCollections;

namespace ProCSharpCode.CSharpGenerics
{

    #region Creating Custom Generic Methods

    // Creating Custom Generic Methods
    // =======================================================================================
    // While most developers typically use the existing generic types within the base class libraries, it is also
    // possible to build your own generic members and custom generic types.
    // When you build custom generic methods, you achieve a supercharged version of traditional method
    // overloading.In Chapter 2, you learned that overloading is the act of defining multiple versions of a single
    // method, which differ by the number of, or type of, parameters.
    // While overloading is a useful feature in an object-oriented language, one problem is that you can easily
    // end up with a ton of methods that essentially do the same thing.
    class TestCustomGenericMethods
    {

        public static void GenericMethod0<T>()
        {
            Console.WriteLine("============== Generic Method0 ============== ");
            Console.WriteLine($"Type Parameter: {typeof(T)}");
        }

        public static void GenericMethod1<T>(T arg1)
        {
            Console.WriteLine("============== Generic Method1 ============== ");
            Console.WriteLine($"Type Parameter: {typeof(T)}");
            Console.WriteLine($"Arg1 Value: {arg1}");
        }

        public static void GenericMethod2<T>(T arg1, T arg2)
        {
            Console.WriteLine("============== Generic Method2 ============== ");
            Console.WriteLine($"Type Parameter: {typeof(T)}");
            Console.WriteLine($"Arg1 Value: {arg1}");
            Console.WriteLine($"Arg2 Value: {arg2}");
        }

        public static void GenericMethod3<T>(T arg1, T arg2, T arg3)
        {
            Console.WriteLine("============== Generic Method3 ============== ");
            Console.WriteLine($"Type Parameter: {typeof(T)}");
            Console.WriteLine($"Arg1 Value: {arg1}");
            Console.WriteLine($"Arg2 Value: {arg2}");
            Console.WriteLine($"Arg3 Value: {arg3}");
        }

        public static void GenericMethod4<T1, T2>(T1 arg1, T2 arg2)
        {
            Console.WriteLine("============== Generic Method4 ============== ");
            Console.WriteLine($"Type Parameter1: {typeof(T1)}");
            Console.WriteLine($"Arg1 Value: {arg1}");
            Console.WriteLine($"Type Parameter2: {typeof(T2)}");
            Console.WriteLine($"Arg2 Value: {arg2}");
        }

        public static void GenericMethod5<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3)
        {
            Console.WriteLine("============== Generic Method5 ============== ");
            Console.WriteLine($"Type Parameter1: {typeof(T1)}");
            Console.WriteLine($"Arg1 Value: {arg1}");
            Console.WriteLine($"Type Parameter2: {typeof(T2)}");
            Console.WriteLine($"Arg2 Value: {arg2}");
            Console.WriteLine($"Type Parameter3: {typeof(T3)}");
            Console.WriteLine($"Arg3 Value: {arg3}");
        }

        public static T GenericMethod6<T>(T arg1)
        {
            Console.WriteLine("============== Generic Method6 ============== ");
            Console.WriteLine($"Type Parameter: {typeof(T)}");
            Console.WriteLine($"Arg1 Value: {arg1}");
            return arg1;
        }


        public static void Test()
        {
            Console.WriteLine("Test Generic Methods");
            Console.WriteLine("".PadLeft(50, '-'));

            GenericMethod0<int>();
            GenericMethod0<string>();

            GenericMethod1<int>(10);
            GenericMethod1<string>("Moamen");


            GenericMethod2<int>(10, 20);
            GenericMethod2<string>("Moamen", "Mohammed");


            GenericMethod3<int>(10, 20, 30);
            GenericMethod3<string>("Moamen", "Mohammed", "Gamal");

            GenericMethod4<int, string>(10, "Moamen");
            GenericMethod4<string, int>("Moamen", 10);
            GenericMethod4<string, string>("Moamen", "Mohammed");
            GenericMethod4<int, int>(10, 20);

            GenericMethod5<int, int, int>(10, 20, 30);
            GenericMethod5<string, string, string>("Moamen", "Mohammed", "Gamal");
            GenericMethod5<string, int, DateTime>("Moamen", 20, DateTime.Now);

            Console.WriteLine(GenericMethod6<int>(10));
            Console.WriteLine(GenericMethod6<string>("Helmy"));
            Console.WriteLine(GenericMethod6<DateTime>(DateTime.Now));

            // Inference of Type Parameters
            // When you invoke generic methods such as Swap<T>, you can optionally omit the type parameter if
            // (and only if) the generic method requires arguments because the compiler can infer the type parameter
            // based on the member parameters.

            // Compiler Error: The Type Arguments Can't be inferred from the usage of the method
            //GenericMethod0();
            //GenericMethod0();

            GenericMethod1(10);
            GenericMethod1("Moamen");


            GenericMethod2(10, 20);
            GenericMethod2("Moamen", "Mohammed");


            GenericMethod3(10, 20, 30);
            GenericMethod3("Moamen", "Mohammed", "Gamal");

            GenericMethod4(10, "Moamen");
            GenericMethod4("Moamen", 10);
            GenericMethod4("Moamen", "Mohammed");
            GenericMethod4(10, 20);

            GenericMethod5(10, 20, 30);
            GenericMethod5("Moamen", "Mohammed", "Gamal");
            GenericMethod5("Moamen", 20, DateTime.Now);

            Console.WriteLine(GenericMethod6(10));
            Console.WriteLine(GenericMethod6("Helmy"));
            Console.WriteLine(GenericMethod6(DateTime.Now));



        }

    }

    #endregion

    #region Inference of Type Parameters
    // ------------------------ Inference of Type Parameters -------------------------
    // When you invoke generic methods such as Swap<T>, you can optionally omit the type parameter if
    // (and only if) the generic method requires arguments because the compiler can infer the type parameter
    // based on the member parameters.
    class TestInferenceOfTypeParameter
    {

        public static void GenericMethod0<T>()
        {
            Console.WriteLine("============== Generic Method0 ============== ");
            Console.WriteLine($"Type Parameter: {typeof(T)}");
        }

        public static void GenericMethod1<T>(T arg1)
        {
            Console.WriteLine("============== Generic Method1 ============== ");
            Console.WriteLine($"Type Parameter: {typeof(T)}");
            Console.WriteLine($"Arg1 Value: {arg1}");
        }

        public static void GenericMethod2<T>(T arg1, T arg2)
        {
            Console.WriteLine("============== Generic Method2 ============== ");
            Console.WriteLine($"Type Parameter: {typeof(T)}");
            Console.WriteLine($"Arg1 Value: {arg1}");
            Console.WriteLine($"Arg2 Value: {arg2}");
        }

        public static void GenericMethod3<T>(T arg1, T arg2, T arg3)
        {
            Console.WriteLine("============== Generic Method3 ============== ");
            Console.WriteLine($"Type Parameter: {typeof(T)}");
            Console.WriteLine($"Arg1 Value: {arg1}");
            Console.WriteLine($"Arg2 Value: {arg2}");
            Console.WriteLine($"Arg3 Value: {arg3}");
        }

        public static void GenericMethod4<T1, T2>(T1 arg1, T2 arg2)
        {
            Console.WriteLine("============== Generic Method4 ============== ");
            Console.WriteLine($"Type Parameter1: {typeof(T1)}");
            Console.WriteLine($"Arg1 Value: {arg1}");
            Console.WriteLine($"Type Parameter2: {typeof(T2)}");
            Console.WriteLine($"Arg2 Value: {arg2}");
        }

        public static void GenericMethod5<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3)
        {
            Console.WriteLine("============== Generic Method5 ============== ");
            Console.WriteLine($"Type Parameter1: {typeof(T1)}");
            Console.WriteLine($"Arg1 Value: {arg1}");
            Console.WriteLine($"Type Parameter2: {typeof(T2)}");
            Console.WriteLine($"Arg2 Value: {arg2}");
            Console.WriteLine($"Type Parameter3: {typeof(T3)}");
            Console.WriteLine($"Arg3 Value: {arg3}");
        }

        public static T GenericMethod6<T>(T arg1)
        {
            Console.WriteLine("============== Generic Method6 ============== ");
            Console.WriteLine($"Type Parameter: {typeof(T)}");
            Console.WriteLine($"Arg1 Value: {arg1}");
            return arg1;
        }


        public static void Test()
        {
            Console.WriteLine("Test Generic Methods");
            Console.WriteLine("".PadLeft(50, '-'));

            GenericMethod0<int>();
            GenericMethod0<string>();

            GenericMethod1<int>(10);
            GenericMethod1<string>("Moamen");


            GenericMethod2<int>(10, 20);
            GenericMethod2<string>("Moamen", "Mohammed");


            GenericMethod3<int>(10, 20, 30);
            GenericMethod3<string>("Moamen", "Mohammed", "Gamal");

            GenericMethod4<int, string>(10, "Moamen");
            GenericMethod4<string, int>("Moamen", 10);
            GenericMethod4<string, string>("Moamen", "Mohammed");
            GenericMethod4<int, int>(10, 20);

            GenericMethod5<int, int, int>(10, 20, 30);
            GenericMethod5<string, string, string>("Moamen", "Mohammed", "Gamal");
            GenericMethod5<string, int, DateTime>("Moamen", 20, DateTime.Now);

            Console.WriteLine(GenericMethod6<int>(10));
            Console.WriteLine(GenericMethod6<string>("Helmy"));
            Console.WriteLine(GenericMethod6<DateTime>(DateTime.Now));

            // Inference of Type Parameters
            // When you invoke generic methods such as Swap<T>, you can optionally omit the type parameter if
            // (and only if) the generic method requires arguments because the compiler can infer the type parameter
            // based on the member parameters.

            // Compiler Error: The Type Arguments Can't be inferred from the usage of the method
            //GenericMethod0();
            //GenericMethod0();

            GenericMethod1(10);
            GenericMethod1("Moamen");


            GenericMethod2(10, 20);
            GenericMethod2("Moamen", "Mohammed");


            GenericMethod3(10, 20, 30);
            GenericMethod3("Moamen", "Mohammed", "Gamal");

            GenericMethod4(10, "Moamen");
            GenericMethod4("Moamen", 10);
            GenericMethod4("Moamen", "Mohammed");
            GenericMethod4(10, 20);

            GenericMethod5(10, 20, 30);
            GenericMethod5("Moamen", "Mohammed", "Gamal");
            GenericMethod5("Moamen", 20, DateTime.Now);

            Console.WriteLine(GenericMethod6(10));
            Console.WriteLine(GenericMethod6("Helmy"));
            Console.WriteLine(GenericMethod6(DateTime.Now));



        }

    }

    // --------------------------------------------------------------
    #endregion


    #region Creating Custom Generic Structures
    // Creating Custom Generic Structures
    // =========================================================================================
    struct Point<T>
    {

        private T xPos, yPos;

        public Point(T x, T y)
        {
            xPos = x;
            yPos = y;
        }

        public T XPos
        {
            get { return xPos; }
            set { xPos = value; }
        }

        public T YPos
        {
            get { return yPos; }
            set { yPos = value; }
        }

        public override string ToString() => $"[{xPos}, {yPos}]";

    }

    class TestGenericStructures
    {
        public static void Test()
        {
            Console.WriteLine("Test Generic Struct");
            Console.WriteLine("".PadLeft(50, '-'));
            Point<int> intPoint = new Point<int>();
            Console.WriteLine(intPoint);
            Point<double> doublePoint = new Point<double>();
            Console.WriteLine(doublePoint);
        }

    }
    #endregion

    #region Creating Custom Generic Classes
    // Creating Custom Generic Classes
    // =========================================================================================

    class MyGenericClass<T>
    {
        private T genericMemberVariable;

        public MyGenericClass(T value)
        {
            genericMemberVariable = value;
        }

        public T genericMethod(T genericParameter)
        {
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), genericParameter);
            Console.WriteLine("Return type: {0}, value: {1}", typeof(T).ToString(), genericMemberVariable);

            return genericMemberVariable;
        }

        public T genericProperty { get; set; }
    }




    class TestGenericClasses
    {
        public static void Test()
        {
            Console.WriteLine("Test Generic Classes");
            Console.WriteLine("".PadLeft(50, '-'));
            MyGenericClass<string> strGenericClass = new MyGenericClass<string>("Hello Generic World");

            strGenericClass.genericProperty = "This is a generic property example.";
            string result = strGenericClass.genericMethod("Generic Parameter");
            Console.WriteLine(result);
        }

    }

    #endregion

    #region The default Keyword in Generic Code

    // The default Keyword in Generic Code
    // With the introduction of generics, the C# default keyword has been given a dual identity. In addition
    // to its use within a switch construct, it can also be used to set a type parameter to its default value.This is
    // helpful because a generic type does not know the actual placeholders up front, which means it cannot safely
    // assume what the default value will be.The defaults for a type parameter are as follows:
    // •	 Numeric values have a default value of 0.
    // •	 Reference types have a default value of null.
    // •	 Fields of a structure are set to 0 (for value types) or null (for reference types).

    struct Point2<T>
    {
        public T PosX { get; set; }
        public T PosY { get; set; }

        public Point2(T posX, T posY)
        {
            PosX = posX;
            PosY = posY;
        }

        // default(T)
        public void ResetPoint()
        {
            PosX = default(T);
            PosY = default(T);
        }

        public override bool Equals(object obj)
        {
            return this.ToString().Equals(obj?.ToString());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"Point[ X={PosX}, Y={PosY} ]";
        }
    }



    class TestDefaultKeyword
    {
        public static void Test()
        {
            // Point using double.
            Point2<double> p2 = new Point2<double>(5.4, 3.3);
            Console.WriteLine("p2.ToString()={0}", p2.ToString());
            p2.ResetPoint();
            Console.WriteLine("p2.ToString()={0}", p2.ToString());
            Console.ReadLine();
        }

    }

    #endregion

    #region Constraining Type Parameters
    // the.NET platform allows you to use the where keyword to get extremely specific about what a given
    // type parameter must look like.
    // Using this keyword, you can add a set of constraints to a given type parameter, which the C# compiler
    // will check at compile time. Specifically, you can constrain a type parameter as described in Table 9-8

    //    Table 9-8.        Possible Constraints for Generic Type Parameters
    //Generic Constraint            Meaning in Life
    // ---------------------------------------------------------------------------------------------
    // where T : struct 
    //          The type parameter<T> must have System.ValueType in its chain of
    //          inheritance (i.e., <T> must be a structure).
    // ---------------------------------------------------------------------------------------------
    // where T : class 
    //          The type parameter<T> must not have System.ValueType in its chain
    //          of inheritance (i.e., <T> must be a reference type).
    // ---------------------------------------------------------------------------------------------
    // where T : new() 
    //          The type parameter<T> must have a default constructor.This is
    //          helpful if your generic type must create an instance of the type
    //          parameter because you cannot assume you know the format of
    //          custom constructors. Note that this constraint must be listed last on a
    //          multiconstrained type.
    // ---------------------------------------------------------------------------------------------
    // where T : NameOfBaseClass 
    //          The type parameter <T> must be derived from the class specified by
    //          NameOfBaseClass.
    // ---------------------------------------------------------------------------------------------
    // where T : NameOfInterface 
    //          The type parameter <T> must implement the interface specified by
    //          NameOfInterface.You can separate multiple interfaces as a
    //          comma-delimited list
    // ---------------------------------------------------------------------------------------------



    public class MyClass1
    {

    }

    // Class Without Default Constructor
    public class MyClass2
    {
        public MyClass2(object arg1)
        {

        }
    }

    public class MyClass3 : MyClass1
    {
        public MyClass3()
        {

        }
    }

    public class MyClass4 : MyClass3
    {
        public MyClass4()
        {

        }
    }

    public class MyClass5 : IComparable, ICloneable
    {
        public MyClass5()
        {

        }

        object ICloneable.Clone()
        {
            return null;
        }

        int IComparable.CompareTo(object obj)
        {
            return 0;
        }
    }

    public class MyClass6 : MyClass1, IComparable, ICloneable
    {
        public MyClass6()
        {

        }

        object ICloneable.Clone()
        {
            return null;
        }

        int IComparable.CompareTo(object obj)
        {
            return 0;
        }

    }

    enum MyEnum
    {
        A = 0, B, C
    }

    // ValueType
    public class MyGenericClass2<T> where T : struct
    {

    }

    // ValueType with Interfaces Constraints
    public class MyGenericClass3<T> where T : struct, IComparable, ICloneable
    {

    }

    // Reference Type Constraint
    public class MyGenericClass4<T> where T : class
    {

    }

    // Reference Type Constraint with Many Custom Interfaces Constraints
    public class MyGenericClass5<T> where T : class, IComparable, ICloneable
    {

    }

    // Custom BaseClass Constraint
    public class MyGenericClass6<T> where T : MyClass1
    {

    }

    // Custom Interface Constraint
    public class MyGenericClass7<T> where T : IComparable
    {

    }

    // Many Custom Interface Constraints
    public class MyGenericClass8<T> where T : IComparable, ICloneable
    {

    }

    // A Base Class With Many Custom Interface Constraints
    public class MyGenericClass9<T> where T : MyClass1, IComparable, ICloneable
    {

    }


    // MyGenericClass derives from object, while
    // contained items must have a default ctor.
    public class MyGenericClass10<T> where T : new()
    {

    }

    // Reference Type Must have a default Constructor Constraints
    public class MyGenericClass11<T> where T : class, new()
    {

    }

    // a Custom Class Must have a default Constructor Constraints
    public class MyGenericClass12<T> where T : MyClass1, new()
    {

    }

    // a BaseClass, default Constructor Constraints
    public class MyGenericClass13<T> where T : IComparable, new()
    {

    }

    // a BaseClass,Many Interfaces , default Constructor Constraints
    public class MyGenericClass14<T> where T : class, IComparable, ICloneable, new()
    {

    }

    class TestGenericsConstraints
    {
        public static void Test()
        {


            MyGenericClass2<int> genericClass21 = new MyGenericClass2<int>();
            //MyGenericClass2<MyClass1> genericClass22 = new MyGenericClass2<MyClass1>();
            //MyGenericClass2<MyClass2> genericClass23 = new MyGenericClass2<MyClass2>();
            //MyGenericClass2<MyClass3> genericClass24 = new MyGenericClass2<MyClass3>();
            //MyGenericClass2<MyClass4> genericClass25 = new MyGenericClass2<MyClass4>();
            //MyGenericClass2<MyClass5> genericClass26 = new MyGenericClass2<MyClass5>();
            //MyGenericClass2<MyClass6> genericClass27 = new MyGenericClass2<MyClass6>();


            //MyGenericClass3<int> genericClass31 = new MyGenericClass3<int>();
            //MyGenericClass3<MyClass1> genericClass32 = new MyGenericClass3<MyClass1>();
            //MyGenericClass3<MyClass2> genericClass33 = new MyGenericClass3<MyClass2>();
            //MyGenericClass3<MyClass3> genericClass34 = new MyGenericClass3<MyClass3>();
            //MyGenericClass3<MyClass4> genericClass35 = new MyGenericClass3<MyClass4>();
            //MyGenericClass3<MyClass5> genericClass36 = new MyGenericClass3<MyClass5>();
            //MyGenericClass3<MyClass6> genericClass37 = new MyGenericClass3<MyClass6>();


            //MyGenericClass4<int> genericClass41 = new MyGenericClass4<int>();
            MyGenericClass4<MyClass1> genericClass42 = new MyGenericClass4<MyClass1>();
            MyGenericClass4<MyClass2> genericClass43 = new MyGenericClass4<MyClass2>();
            MyGenericClass4<MyClass3> genericClass44 = new MyGenericClass4<MyClass3>();
            MyGenericClass4<MyClass4> genericClass45 = new MyGenericClass4<MyClass4>();
            MyGenericClass4<MyClass5> genericClass46 = new MyGenericClass4<MyClass5>();
            MyGenericClass4<MyClass6> genericClass47 = new MyGenericClass4<MyClass6>();


            //MyGenericClass5<int> genericClass51 = new MyGenericClass5<int>();
            //MyGenericClass5<MyClass1> genericClass52 = new MyGenericClass5<MyClass1>();
            //MyGenericClass5<MyClass2> genericClass53 = new MyGenericClass5<MyClass2>();
            //MyGenericClass5<MyClass3> genericClass54 = new MyGenericClass5<MyClass3>();
            //MyGenericClass5<MyClass4> genericClass55 = new MyGenericClass5<MyClass4>();
            MyGenericClass5<MyClass5> genericClass56 = new MyGenericClass5<MyClass5>();
            MyGenericClass5<MyClass6> genericClass57 = new MyGenericClass5<MyClass6>();


            //MyGenericClass6<int> genericClass61 = new MyGenericClass6<int>();
            MyGenericClass6<MyClass1> genericClass62 = new MyGenericClass6<MyClass1>();
            //MyGenericClass6<MyClass2> genericClass63 = new MyGenericClass6<MyClass2>();
            MyGenericClass6<MyClass3> genericClass64 = new MyGenericClass6<MyClass3>();
            MyGenericClass6<MyClass4> genericClass65 = new MyGenericClass6<MyClass4>();
            //MyGenericClass6<MyClass5> genericClass66 = new MyGenericClass6<MyClass5>();
            MyGenericClass6<MyClass6> genericClass67 = new MyGenericClass6<MyClass6>();


            MyGenericClass7<int> genericClass71 = new MyGenericClass7<int>();
            //MyGenericClass7<MyClass1> genericClass72 = new MyGenericClass7<MyClass1>();
            //MyGenericClass7<MyClass2> genericClass73 = new MyGenericClass7<MyClass2>();
            //MyGenericClass7<MyClass3> genericClass74 = new MyGenericClass7<MyClass3>();
            //MyGenericClass7<MyClass4> genericClass75 = new MyGenericClass7<MyClass4>();
            MyGenericClass7<MyClass5> genericClass76 = new MyGenericClass7<MyClass5>();
            MyGenericClass7<MyClass6> genericClass77 = new MyGenericClass7<MyClass6>();


            //MyGenericClass8<int> genericClass81 = new MyGenericClass8<int>();
            //MyGenericClass8<MyClass1> genericClass82 = new MyGenericClass8<MyClass1>();
            //MyGenericClass8<MyClass2> genericClass83 = new MyGenericClass8<MyClass2>();
            //MyGenericClass8<MyClass3> genericClass84 = new MyGenericClass8<MyClass3>();
            //MyGenericClass8<MyClass4> genericClass85 = new MyGenericClass8<MyClass4>();
            MyGenericClass8<MyClass5> genericClass86 = new MyGenericClass8<MyClass5>();
            MyGenericClass8<MyClass6> genericClass87 = new MyGenericClass8<MyClass6>();


            //MyGenericClass9<int> genericClass91 = new MyGenericClass9<int>();
            //MyGenericClass9<MyClass1> genericClass92 = new MyGenericClass9<MyClass1>();
            //MyGenericClass9<MyClass2> genericClass93 = new MyGenericClass9<MyClass2>();
            //MyGenericClass9<MyClass3> genericClass94 = new MyGenericClass9<MyClass3>();
            //MyGenericClass9<MyClass4> genericClass95 = new MyGenericClass9<MyClass4>();
            //MyGenericClass9<MyClass5> genericClass96 = new MyGenericClass9<MyClass5>();
            MyGenericClass9<MyClass6> genericClass97 = new MyGenericClass9<MyClass6>();


            MyGenericClass10<int> genericClass101 = new MyGenericClass10<int>();
            MyGenericClass10<MyClass1> genericClass102 = new MyGenericClass10<MyClass1>();
            //MyGenericClass10<MyClass2> genericClass103 = new MyGenericClass10<MyClass2>();
            MyGenericClass10<MyClass3> genericClass104 = new MyGenericClass10<MyClass3>();
            MyGenericClass10<MyClass4> genericClass105 = new MyGenericClass10<MyClass4>();
            MyGenericClass10<MyClass5> genericClass106 = new MyGenericClass10<MyClass5>();
            MyGenericClass10<MyClass6> genericClass107 = new MyGenericClass10<MyClass6>();


            //MyGenericClass11<int> genericClass111 = new MyGenericClass11<int>();
            MyGenericClass11<MyClass1> genericClass112 = new MyGenericClass11<MyClass1>();
            //MyGenericClass11<MyClass2> genericClass113 = new MyGenericClass11<MyClass2>();
            MyGenericClass11<MyClass3> genericClass114 = new MyGenericClass11<MyClass3>();
            MyGenericClass11<MyClass4> genericClass115 = new MyGenericClass11<MyClass4>();
            MyGenericClass11<MyClass5> genericClass116 = new MyGenericClass11<MyClass5>();
            MyGenericClass11<MyClass6> genericClass117 = new MyGenericClass11<MyClass6>();


            //MyGenericClass12<int> genericClass121 = new MyGenericClass12<int>();
            MyGenericClass12<MyClass1> genericClass122 = new MyGenericClass12<MyClass1>();
            //MyGenericClass12<MyClass2> genericClass123 = new MyGenericClass12<MyClass2>();
            MyGenericClass12<MyClass3> genericClass124 = new MyGenericClass12<MyClass3>();
            MyGenericClass12<MyClass4> genericClass125 = new MyGenericClass12<MyClass4>();
            //MyGenericClass12<MyClass5> genericClass126 = new MyGenericClass12<MyClass5>();
            MyGenericClass12<MyClass6> genericClass127 = new MyGenericClass12<MyClass6>();


            MyGenericClass13<int> genericClass131 = new MyGenericClass13<int>();
            //MyGenericClass13<MyClass1> genericClass132 = new MyGenericClass13<MyClass1>();
            //MyGenericClass13<MyClass2> genericClass133 = new MyGenericClass13<MyClass2>();
            //MyGenericClass13<MyClass3> genericClass134 = new MyGenericClass13<MyClass3>();
            //MyGenericClass13<MyClass4> genericClass135 = new MyGenericClass13<MyClass4>();
            MyGenericClass13<MyClass5> genericClass136 = new MyGenericClass13<MyClass5>();
            MyGenericClass13<MyClass6> genericClass137 = new MyGenericClass13<MyClass6>();


            //MyGenericClass14<int> genericClass141 = new MyGenericClass14<int>();
            //MyGenericClass14<MyClass1> genericClass142 = new MyGenericClass14<MyClass1>();
            //MyGenericClass14<MyClass2> genericClass143 = new MyGenericClass14<MyClass2>();
            //MyGenericClass14<MyClass3> genericClass144 = new MyGenericClass14<MyClass3>();
            //MyGenericClass14<MyClass4> genericClass145 = new MyGenericClass14<MyClass4>();
            MyGenericClass14<MyClass5> genericClass146 = new MyGenericClass14<MyClass5>();
            MyGenericClass14<MyClass6> genericClass147 = new MyGenericClass14<MyClass6>();
        }

    }

    #endregion

    #region Multiple Type Parameter, and Multiple Where Clauses
    // Multiple Type Parameter, and Multiple Where Clauses

    class MultipleTypeParameter<T1, T2, T3>
    {
        public MultipleTypeParameter()
        {

        }
    }

    class MultipleWhere<T1, T2, T3>
        where T1 : struct
        where T2 : class, new()
        //where T3 : IComparable

    {
        public MultipleWhere()
        {

        }
    }


    class TestMultipleTypeMultipleWhere
    {
        public void Test()
        {
            Console.WriteLine("Test Multiple Type and Multiple Where Clauses");
            Console.WriteLine("".PadLeft(50, '-'));
            MultipleTypeParameter<int, object, List<double>> obj1 = new MultipleTypeParameter<int, object, List<double>>();
            MultipleWhere<int, object, List<double>> obj2 = new MultipleWhere<int, object, List<double>>();


        }


    }

    #endregion

    class GenericsTraining
    {
        public static void Test()
        {
            TestCustomGenericMethods.Test();
            TestInferenceOfTypeParameter.Test();
            TestGenericStructures.Test();
            TestGenericClasses.Test();
            TestDefaultKeyword.Test();
            TestGenericsConstraints.Test();
        }

    }

}