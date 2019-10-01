using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace pro_csharp_book_training
{
    // C# Pogramming Language
    // -------------------------------------------------------------------------------------------
    // C# (pronounced "See Sharp") is a simple, modern, object-oriented, and type-safe programming 
    // language. C# has its roots in the C family of languages and will be immediately familiar to
    // C, C++, Java, and JavaScript programmers. 

    // C# is an object-oriented language, but C# further includes support 
    // for component-oriented programming. 

    // C# has a unified type system. All C# types, including primitive types such as int and 
    // double, inherit from a single root object type. Thus, all types share a set of common 
    // operations, and values of any type can be stored, transported, and operated upon in a 
    // consistent manner. Furthermore, C# supports both user-defined reference types and 
    // value types, allowing dynamic allocation of objects as well as in-line storage of 
    // lightweight structures.
    // 
    // the next overviews will provide basic information about all elements of the language 
    // and give you the information necessary to dive deeper into elements of the C# language.

    // -------------------------------------------------------------------------------------------
    // Program Structure
    // -------------------------------------------------------------------------------------------
    // -------------------------------------------------------------------------------------------
    // The key organizational concepts in C# are programs, namespaces, types, members, and assemblies.
    // C# programs consist of one or more source files. Programs declare types, which contain members
    // and can be organized into namespaces. Classes and interfaces are examples of types. 
    // Fields, methods, properties, and events are examples of members. When C# programs are compiled,
    // they are physically packaged into assemblies. 
    // Assemblies typically have the file extension .exe or .dll, 
    // depending on whether they implement applications or libraries, respectively.

    // -------------------------------------------------------------------------------------------
    // Types and variables
    // -------------------------------------------------------------------------------------------
    // -------------------------------------------------------------------------------------------
    // There are two kinds of types in C#: value types and reference types. Variables of value types
    // directly contain their data whereas variables of reference types store references to their 
    // data, the latter being known as objects. 

    // With reference types, it is possible for two variables to reference the same object and thus
    // possible for operations on one variable to affect the object referenced by the other variable. 

    // With value types, the variables each have their own copy of the 
    // data, and it is not possible for operations on one to affect the other
    // (except in the case of ref and out parameter variables).

    // The following provides an overview of C#’s type system.

    // 1- Value types

    //      - Simple types
    //          # Signed integral: sbyte, short, int, long
    //          # Unsigned integral: byte, ushort, uint, ulong
    //          # Unicode characters: char
    //          # IEEE binary floating-point: float, double
    //          # High-precision decimal floating-point: decimal
    //          # Boolean: bool

    //      - Enum types
    //          # User-defined types of the form enum E {...}

    //      - Struct types
    //          # User-defined types of the form struct S {...}

    //      - Nullable value types
    //          # Extensions of all other value types with a null value

    //      - Tuple Types: 
    //          types that you define using a lightweight syntax. 
    //          Drived from TupleValue Structure (that is drived from ValueType)
    //          # user-defined types of the form 
    //              (Type [Name1], Type [Name2] ,..., Type [NameX]) TupleName = (Value1, Value2, ...,ValueX);
    //              var TupleName = ([Name1:] Value1, [Name2:] Value2, ..., [NameX:]ValueX);
    //              

    // 2- Reference types

    //     - Class types
    //          # Ultimate base class of all other types: object
    //          # Unicode strings: string
    //          # User-defined types of the form class C {...}

    //     - Interface types
    //          # User-defined types of the form interface I {...}

    //     - Array types
    //          # Single- and multi-dimensional, for example, int[] and int[,]

    //     - Delegate types
    //          # User-defined types of the form delegate int D(...)

    //
    //  Built-in types
    // -------------------------------------------------------------------------------------------
    //  C# type       .NET type             ValueType / ReferenceType
    // ------------------------------------------------------------------------------------------
    //  bool          System.Boolean        Structure
    //  byte          System.Byte           Structure
    //  sbyte         System.SByte          Structure
    //  char          System.Char           Structure
    //  decimal       System.Decimal        Structure
    //  double        System.Double         Structure
    //  float         System.Single         Structure
    //  int           System.Int32          Structure
    //  uint          System.UInt32         Structure
    //  long          System.Int64          Structure
    //  ulong         System.UInt64         Structure
    //  object        System.Object         Class
    //  short         System.Int16          Structure
    //  ushort        System.UInt16         Structure
    //  string        System.String         Class
    // ------------------------------------------------------------------------------------------

    // The following table summarizes C#'s numeric types.

    // Category         Bits    Type        Range/Precision
    // ------------------------------------------------------------------------------------------
    // Signed integral	
    // ------------------------------------------------------------------------------------------
    //                  8	    sbyte	    -128...127
    //                  16	    short	    -32,768...32,767
    //                  32	    int	        -2,147,483,648...2,147,483,647
    //                  64	    long	    -9,223,372,036,854,775,808...9,223,372,036,854,775,807

    // Unsigned integral                    
    // ------------------------------------------------------------------------------------------
    //                  8	    byte	    0...255
    //                  16	    ushort	    0...65,535
    //                  32	    uint	    0...4,294,967,295
    //                  64	    ulong	    0...18,446,744,073,709,551,615

    // Floating point                       
    // ------------------------------------------------------------------------------------------
    //                  32	    float	    1.5 × 10^−45 to 3.4 × 10^38, 7-digit precision
    //                  64	    double	    5.0 × 10^−324 to 1.7 × 10^308, 15-digit precision

    // Decimal                              
    // ------------------------------------------------------------------------------------------
    //                  128	    decimal	    1.0 × 10^−28 to 7.9 × 10^28, 28-digit precision
    // ------------------------------------------------------------------------------------------



    // -------------------------------------------------------------------------------------------
    // C# Operators
    // -------------------------------------------------------------------------------------------  
    // -------------------------------------------------------------------------------------------
    // The following table lists the C# operators starting with the highest precedence to the lowest. 
    // The operators within each row have the same precedence.
    // -------------------------------------------------------------------------------------------
    // 
    // ----------------------- Primary Operators -----------------------
    // x.y          Member Access operator
    // x?.y         Null-conditional operator
    // x?[y]        Null-conditional operator
    // f(x)         Invocation operator ()
    // a[i]         Indexer operator []
    // x++          Increment operator ++
    // x--          Decrement operator --
    // new          new operator
    // typeof       typeof operator
    // checked      Operator
    // unchecked    Operator
    // default      default operator 
    // nameof       nameof operator
    // delegate     delegate operator
    // sizeof       sizeof operator
    // stackalloc   stackalloc operator
    // x->y         Pointer member access operator

    // ----------------------- Unary Operators -----------------------
    // +x           Unary plus and minus operators
    // -x           Unary plus and minus operators
    // !x           Logical negation operator !
    // ~x           Bitwise complement operator ~
    // ++x          Postfix increment operator
    // --x          Postfix decrement operator
    // ^x           Index from end operator ^
    // (T) x        Cast operator ()
    // await        await operator 
    // &x           Address-of operator &
    // * x          Pointer indirection operator *
    // true         true Operator
    // false        false Operator

    // ----------------------- Range -----------------------
    // x..y         Range Operator 

    // ----------------------- Multiplicative -----------------------
    // x * y        Multiplication operator *
    // x / y        Division operator /
    // x % y        Remainder operator %

    // ----------------------- Additive -----------------------
    // x + y        Addition  operator +
    // x – y        Subtraction  operator -
    // ----------------------- Shift -----------------------
    // x << y       Left-shift operator <<
    // x >> y       Right-shift operator >>

    // ----------------------- Relational and type-testing -----------------------
    // x < y        Less Than Operator <
    // x > y        Greater Than Operator >
    // x <= y       Less Than Or Equal Operator >
    // x >= y       Greater Than Or Equal Operator >
    // is           is Operator
    // as	        as Operator

    // ----------------------- Equality -----------------------
    // x == y       Equality operator ==
    // x != y       Inequality operator !=

    // ----------------------- Boolean logical AND or bitwise logical AND -----------------------
    // x & y                    

    // ----------------------- Boolean logical XOR or bitwise logical XOR -----------------------
    // x ^ y                    

    // ----------------------- Boolean logical OR or bitwise logical OR -----------------------
    // x | y                    

    // ----------------------- Conditional AND -----------------------
    // x && y                   

    // ----------------------- Conditional OR -----------------------
    // x || y 

    // ----------------------- Null-coalescing operator -----------------------
    // x ?? y 

    // ----------------------- Conditional operator -----------------------
    // c? t : f 

    // ----------------------- Assignment and lambda declaration -----------------------
    // x = y        Assignment Operator =
    // x += y       Shortcut of x = x + y
    // x -= y       Shortcut of x = x - y
    // x *= y       Shortcut of x = x * y
    // x /= y       Shortcut of x = x / y
    // x %= y       Shortcut of x = x % y
    // x &= y       Shortcut of x = x & y
    // x |= y       Shortcut of x = x | y
    // x ^= y       Shortcut of x = x ^ y
    // x <<= y      Shortcut of x = x << y
    // x >>= y      Shortcut of x = x >> y
    // x ??= y      Shortcut of x = x ?? y
    // =>	        Lambda Operator

    // Operator associativity
    // ------------------------------------------------------------------------------------------- 
    // When operators have the same precedence, associativity of the operators determines the order
    // in which the operations are performed:

    // - Left-associative operators are evaluated in order from left to right.Except for the assignment 
    //   operators and the null-coalescing operator ??, all binary operators are left-associative.

    //   For example, a + b - c is evaluated as (a + b) - c.

    // - Right-associative operators are evaluated in order from right to left.The assignment 
    //   operators, the null-coalescing operator ??, and the conditional operator ?: are 
    //   right-associative.For example, x = y = z is evaluated as x = (y = z).

    // Use parentheses to change the order of evaluation imposed by operator associativity

    class BasicsTraining
    {
        public static void TestBasics()
        {
            //
            // mybytevar
            // mysbytevar
            // mydecimalvar
            // mydoubleva
            // myfloatvar
            // myintvar
            // myuintvar
            // mylongvar
            // myulongvar
            // myshortvar
            // myushortvar

            // The default literal is a new feature in C# 7.1 that allows for assigning 
            // a variable the default value for its data type. 
            byte mybytevar = default;       // 0
            sbyte mysbytevar = default;     // 0
            decimal mydecimalvar = default;     // 0
            double mydoublevar = default;       // 0
            float myfloatvar = default;     // 0
            int myintvar = default;     // 0
            uint myuintvar = default;       // 0
            long mylongvar = default;       // 0
            ulong myulongvar = default;     // 0
            short myshortvar = default;     // 0
            ushort myushortvar = default;       // 0

            Console.WriteLine(mybytevar);
            Console.WriteLine(mysbytevar);
            Console.WriteLine(mydecimalvar);
            Console.WriteLine(mydoublevar);
            Console.WriteLine(myfloatvar);
            Console.WriteLine(myintvar);
            Console.WriteLine(myuintvar);
            Console.WriteLine(mylongvar);
            Console.WriteLine(myulongvar);
            Console.WriteLine(myshortvar);
            Console.WriteLine(myushortvar);

            // Simple Data Type Suffix:
            // -----------------------------------------------
            // byte suffix :    no suffix
            // sbyte suffix :   no suffix
            // decimal suffix : m or M
            // double suffix :  d or D
            // float suffix :   f or F
            // int suffix :     no suffix
            // uint suffix :    u or U
            // long suffix :    l or L
            // ulong suffix :   ul or UL or uL or Ul
            // short suffix :   no suffix
            // ushort suffix :  no suffix

            mybytevar = 10;
            mysbytevar = 10;
            mydecimalvar = 12351412m;
            mydoublevar = 340001212.1212;
            myfloatvar = 9129323.123123F;
            myintvar = 500_444_333;
            myuintvar = 4000U;
            mylongvar = 402302332344L;
            myulongvar = 402331233232UL;
            myshortvar = 3400;
            myushortvar = 3400;

            // System.DataType is the same as simple data type
            System.Byte mybytevar1 = default;
            System.SByte mysbytevar1 = default;
            System.Decimal mydecimalvar1 = default;
            System.Double mydoublevar1 = default;
            System.Single myfloatvar1 = default;
            System.Int32 myintvar1 = default;
            System.UInt32 myuintvar1 = default;
            System.Int64 mylongvar1 = default;
            System.UInt64 myulongvar1 = default;
            System.Int16 myshortvar1 = default;
            System.UInt16 myushortvar1 = default;

            // Implicit Local Type Variable (var)
            var mybytevar2 = (byte)0;
            var mysbytevar2 = (sbyte)0;
            var mydecimalvar2 = 0m; // or d
            var mydoublevar2 = 0d;
            var myfloatvar2 = 0f;
            var myintvar2 = 0;
            var myuintvar2 = 0u;
            var mylongvar2 = 0l;
            var myulongvar2 = 0ul;
            var myshortvar2 = (short)0;
            var myushortvar2 = (ushort)0;


            // Implicit Up Casting
            object mybytevar3 = (byte)0;
            object mysbytevar3 = (sbyte)0;
            object mydecimalvar3 = 0m; // or d
            object mydoublevar3 = 0d;
            object myfloatvar3 = 0f;
            object myintvar3 = 0;
            object myuintvar3 = 0u;
            object mylongvar3 = 0l;
            object myulongvar3 = 0ul;
            object myshortvar3 = (short)0;
            object myushortvar3 = (ushort)0;

            // Dynamic Type
            // When you assign a class object to the dynamic type, then the compiler does 
            // not check for the right method and property name of the dynamic type which 
            // holds the custom class object.
            // You can also pass a dynamic type parameter in the method so that the method 
            // can accept any type of parameter at run time.As shown in the below example.
            // Dynamic is useful when we need to code using reflection or dynamic languages
            // or with the COM objects and when getting result out of the LinQ queries.

            dynamic mydynamic = (byte)0;
            mydynamic = (sbyte)0;
            mydynamic = 0m; // or d
            mydynamic = 0d;
            mydynamic = 0f;
            mydynamic = 0;
            mydynamic = 0u;
            mydynamic = 0l;
            mydynamic = 0ul;
            mydynamic = (short)0;
            mydynamic = (ushort)0;
            mydynamic = "Hello World";

            // -------------------------------------------------------------------------------------------
            // Implicit numeric conversions (Widening)
            // -------------------------------------------------------------------------------------------
            // -------------------------------------------------------------------------------------------
            // Widening: term define an implicit upword cast that doesn't result a loss of data.

            // The Rules of Conversion:
            // -------------------------------------------------------------------------------
            // First, we order the data types from the smalles to the greatest in storage:
            //      sbyte, byte, short, ushort, int, uint, long, ulong, float, double.
            // 2- From Signed To Upper Signed 
            // 3- From Unsigned To Upper Signed, and Upper Unsigned
            // 4- From Signed and Unsigned To float, double, decimal, and char
            // 5- From float To double
            // -------------------------------------------------------------------------------

            // The following is an implicit data types conversion table.
            // Implicit Conversion

            // From             To
            // -------------------------------------------------------------------------------------------
            // sbyte            short, int, long, float, double, decimal
            // byte             short, ushort, int, uint, long, ulong, float, double, decimal
            // short            int, long, float, double, or decimal
            // ushort           int, uint, long, ulong, float, double, or decimal
            // int              long, float, double, or decimal
            // uint             long, ulong, float, double, or decimal
            // long             float, double, or decimal
            // ulong            float, double, or decimal
            // char             ushort, int, uint, long, ulong, float, double, or decimal
            // float            Double
            // -------------------------------------------------------------------------------------------
            // Another Table shape:
            // From             To
            // -------------------------------------------------------------------------------------------
            // sbyte            to decimal, double, float, long, int, short
            // short            to decimal, double, float, long, int
            // int              to decimal, double, float, long
            // long             to decimal, double, float

            // byte             to decimal, double, float, ulong, long, uint, int, ushort, short
            // ushort           to decimal, double, float, ulong, long, uint, int 
            // uint             to decimal, double, float, ulong, long
            // ulong            to decimal, double, float

            // char             to decimal, double, float, ulong, long, uint, int, ushort
            // float            to double
            // -------------------------------------------------------------------------------------------




            // --------------------- Signed Data Implicit Conversions ------------------------
            sbyte mysbyte2 = 10;
            byte mybyte2 = 11;
            short myshort2 = 12;
            ushort myushort2 = 13;
            int myint2 = 14;
            uint myuint2 = 15;
            long mylong2 = 16;
            ulong myulong2 = 17;
            float myfloat2 = 18;
            double mydouble2 = 19;
            decimal mydecimal2 = 20;
            char mychar2 = 'A';

            //  sbyte        mysbyte2
            //  byte         mybyte2
            //  short        myshort2 
            //  ushort       myushort2  
            //  int          myint2
            //  uint         myuint2
            //  long         mylong2
            //  ulong        myulong2 
            //  float        myfloat2 
            //  double       mydouble2  
            //  decimal      mydecimal2   
            //  char         mychar2   


            // Implicity Convert from sbyte:
            myshort2 = mysbyte2;
            myint2 = mysbyte2;
            mylong2 = mysbyte2;
            myfloat2 = mysbyte2;
            mydouble2 = mysbyte2;
            mydecimal2 = mysbyte2;

            // Implicity Convert from short:
            myint2 = myshort2;
            mylong2 = myshort2;
            myfloat2 = myshort2;
            mydouble2 = myshort2;
            mydecimal2 = myshort2;

            // Implicity Convert from int:
            mylong2 = myint2;
            myfloat2 = myint2;
            mydouble2 = myint2;
            mydecimal2 = myint2;

            // Implicity Convert from long
            myfloat2 = mylong2;
            mydouble2 = mylong2;
            mydecimal2 = mylong2;

            // Implicity Convert from float
            mydouble2 = myfloat2;


            // --------------------- Unsigned Data Implicit Conversions ------------------------
            //  Implicity Convert from byte:
            // --------------------------
            myshort2 = mybyte2;
            myushort2 = mybyte2;
            myint2 = mybyte2;
            myuint2 = mybyte2;
            mylong2 = mybyte2;
            myulong2 = mybyte2;
            myfloat2 = mybyte2;
            mydouble2 = mybyte2;
            mydecimal2 = mybyte2;


            // Implicity Convert from ushort:
            myint2 = myushort2;
            myuint2 = myushort2;
            mylong2 = myushort2;
            myulong2 = myushort2;
            myfloat2 = myushort2;
            mydouble2 = myushort2;
            mydecimal2 = myushort2;

            // Implicity Convert from uint:
            mylong2 = myuint2;
            myfloat2 = myuint2;
            mydouble2 = myuint2;
            mydecimal2 = myuint2;

            // Implicity Convert from ulong
            myfloat2 = myulong2;
            mydouble2 = myulong2;
            mydecimal2 = myulong2;

            // Implicity Convert from float;
            mydouble2 = myfloat2;

            // Implicit Convert to decimal: all except float, and double
            mydecimal2 = mysbyte2;
            mydecimal2 = mybyte2;
            mydecimal2 = myshort2;
            mydecimal2 = myushort2;
            mydecimal2 = myint2;
            mydecimal2 = myuint2;
            mydecimal2 = mylong2;
            mydecimal2 = myulong2;
            mydecimal2 = mychar2;

            // Impicit Convert from char: All except sbyte, byte, short
            myushort2 = mychar2;
            myint2 = mychar2;
            myuint2 = mychar2;
            mylong2 = mychar2;
            myulong2 = mychar2;
            myfloat2 = mychar2;
            mydouble2 = mychar2;
            mydecimal2 = mychar2;




            // Explicit numeric Conversions (Narrowing) or (numeric Casting)
            // -------------------------------------------------------------------------------------------
            // -------------------------------------------------------------------------------------------
            // when there are possible loss of data. we need Explicit conversion.
            // Compiler error will be thrown, if we didn't make explicit conversion when required.

            // Rules that determind the need of explicit numeric conversion:
            // -----------------------------------------------------
            // 1- From Signed To Unsigned Data
            // 2- From Greater To Smaller
            // 3- From All Numerics To char
            // 4- From double, and float To decimal

            // -----------------------------------------------------

            // Shape of Casting:
            //      typename = (typename) oldtype;

            // Explicit Numeric Conversions Table
            // From             To
            // -------------------------------------------------------------------------------------------
            // byte             to char, sbyte
            // ushort           to char, sbyte, byte, short
            // uint             to char, sbyte, byte, short, ushort, int
            // ulong            to char, sbyte, byte, short, ushort, int, uint, long

            // sbyte            to char, byte, ushort, uint, ulong
            // short            to char, byte, ushort, uint, ulong, sbyte
            // int              to char, byte, ushort, uint, ulong, sbyte, short
            // long             to char, byte, ushort, uint, ulong, sbyte, short, int

            // float            to char, sbyte, byte, ushort, short, int, uint, decimal
            // double           to char, sbyte, byte, ushort, short, int, uint, decimal
            // decimal          to char, sbyte, byte, ushort, short, int, uint, float, double
            // -------------------------------------------------------------------------------------------

            //  sbyte        mysbyte2
            //  byte         mybyte2
            //  short        myshort2 
            //  ushort       myushort2  
            //  int          myint2
            //  uint         myuint2
            //  long         mylong2
            //  ulong        myulong2 
            //  float        myfloat2 
            //  double       mydouble2  
            //  decimal      mydecimal2   
            //  char         mychar2   




            // Silent Overflow
            // -------------------------------------------------------------------------
            // 1- the default behaviour of the compiler is to allow overflow silently,
            //    so if some of your code in your app doesn't accept Silent Overflow,
            //    - you can surrount your code with checked keyword that throws 
            //      OverflowException, and handle the exception with try catch
            //    - if most of your code doesn't allow Overflow, you can use 
            //      /checked flag of compiler options that doesn't allow silent Overflow,
            //      and in that case if you have little cases you can allow Slient Overflow,
            //      you can use unchecked Keyword.

            // silent overflow example
            short a = 25_000;
            short b = (short)(a * 2);

            long lg = long.MaxValue / 2;
            int sum = (int)lg;

            Console.WriteLine($"silent overflow, b = {b}");
            // b = -32536 but it suppose to be 50_000

            // a question why compiler grapped the next overflow and let the previous overflow
            //int xx = int.MaxValue * 2;
            //Console.WriteLine("default of compiler xx = " + xx);


            // Prevent silent overflow with checked keyword surrounding a statment
            try
            {
                short a2 = 25_000;
                short b2 = checked((short)(a2 * 2));

                long lg2 = long.MaxValue / 2;
                int sum2 = checked((int)lg2);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("use of checked with statement: " + ex.Message);
            }


            // Prevent silent overflow with checked keyword surrounding block of code statements
            try
            {
                checked
                {
                    short a3 = 25_000;
                    short b3 = (short)(a3 * 2);

                    long lg3 = long.MaxValue / 2;
                    int sum3 = (int)lg3;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("use of checked with block: " + ex.Message);
            }

            // to allow overflow under /checked compiler flag
            // -----------------------------------------------------------------------

            // Allow overflow with unchecked keyword surrounding statement
            short a4 = 25_000;
            short b4 = unchecked((short)(a4 * 2));

            long lg4 = long.MaxValue / 2;
            int sum4 = unchecked((int)lg4);
            Console.WriteLine($"use of unchecked b4 = {b4} sum4 = {sum4}");

            // Allow overflow with unchecked keyword surrounding block of code statements
            unchecked
            {
                short a5 = 25_000;
                short b5 = (short)(a5 * 2);

                long lg5 = long.MaxValue / 2;
                int sum5 = (int)lg5;
                Console.WriteLine($"use of unchecked block b5 = {b5} sum5 = {sum5}");
            }

            // Checked and Unchecked Summary
            // -------------------------------------------------------------------------------
            // So, to summarize the C# checked and unchecked keywords, 
            // remember that the default behavior of the .NET runtime is to ignore 
            // arithmetic overflow/ underflow. 
            // When you want to selectively handle discrete statements, make use of 
            // the checked keyword.If you want to trap overflow errors throughout your 
            // application, enable the / checked flag.
            // Finally, the unchecked keyword can be used if you have a block of code  
            // where overflow is acceptable(and thus should not trigger a runtime exception).

            // Parsing From string
            try
            {
                sbyte mysbyte3 = sbyte.Parse("20");
                byte mybyte3 = byte.Parse("21");
                short myshort3 = short.Parse("32");
                ushort myushort3 = ushort.Parse("43");
                int myint3 = int.Parse("400000");
                uint myuint3 = uint.Parse("12312");
                long mylong3 = long.Parse("424523");
                ulong myulong3 = ulong.Parse("23233");
                float myfloat3 = float.Parse("2233.05334");
                double mydouble3 = double.Parse("234234234.34223");
                decimal mydecimal3 = decimal.Parse("44234234.23423");
                char mychar3 = char.Parse("a");

                Console.WriteLine($"Parse sbyte = {mysbyte3}");
                Console.WriteLine($"Parse byte = {mybyte3}");
                Console.WriteLine($"Parse short = {myshort3}");
                Console.WriteLine($"Parse ushort = {myushort3}");
                Console.WriteLine($"Parse int = {myint3}");
                Console.WriteLine($"Parse uint = {myuint3}");
                Console.WriteLine($"Parse long = {mylong3}");
                Console.WriteLine($"Parse ulong = {myulong3}");
                Console.WriteLine($"Parse float = {myfloat3}");
                Console.WriteLine($"Parse double = {mydouble3}");
                Console.WriteLine($"Parse decimal = {mydecimal3}");
                Console.WriteLine($"Parse char = {mychar3}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // sbyte    issbyteParsed      mysbyte4
            // byte     isbyteParsed       mybyte4
            // short    isshortParsed      myshort4
            // ushort   isushortParsed     myushort4
            // int      isintParsed        myint4
            // uint     isuintParsed       myuint4
            // long     islongParsed       mylong4
            // ulong    isulongParsed      myulong4
            // float    isfloatParsed      myfloat4
            // double   isdoubleParsed     mydouble4
            // decimal  isdecimalParsed    mydecimal4
            // char     ischarParsed       mychar4

            // TryParse
            bool issbyteParsed = sbyte.TryParse("100", out sbyte mysbyte4);
            bool isbyteParsed = byte.TryParse("100", out byte mybyte4);
            bool isshortParsed = short.TryParse("100", out short myshort4);
            bool isushortParsed = ushort.TryParse("100", out ushort myushort4);
            bool isintParsed = int.TryParse("100", out int myint4);
            bool isuintParsed = uint.TryParse("100", out uint myuint4);
            bool islongParsed = long.TryParse("100", out long mylong4);
            bool isulongParsed = ulong.TryParse("100", out ulong myulong4);
            bool isfloatParsed = float.TryParse("100", out float myfloat4);
            bool isdoubleParsed = double.TryParse("100", out double mydouble4);
            bool isdecimalParsed = decimal.TryParse("100", out decimal mydecimal4);
            bool ischarParsed = char.TryParse("5", out char mychar4);

            Console.WriteLine(issbyteParsed ? $"{mysbyte4}" : "mysbyte4 TryParsing Failed!");
            Console.WriteLine(isbyteParsed ? $"{mybyte4}" : "mybyte4 TryParsing Failed!");
            Console.WriteLine(isshortParsed ? $"{myshort4}" : "myshort4 TryParsing Failed!");
            Console.WriteLine(isushortParsed ? $"{myushort4}" : "myushort4 TryParsing Failed!");
            Console.WriteLine(isintParsed ? $"{myint4}" : "myint4 TryParsing Failed!");
            Console.WriteLine(isuintParsed ? $"{myuint4}" : "myuint4 TryParsing Failed!");
            Console.WriteLine(islongParsed ? $"{mylong4}" : "mylong4 TryParsing Failed!");
            Console.WriteLine(isulongParsed ? $"{myulong4}" : "myulong4 TryParsing Failed!");
            Console.WriteLine(isfloatParsed ? $"{myfloat4}" : "myfloat4 TryParsing Failed!");
            Console.WriteLine(isdoubleParsed ? $"{mydouble4}" : "mydouble4 TryParsing Failed!");
            Console.WriteLine(isdecimalParsed ? $"{mydecimal4}" : "mydecimal4 TryParsing Failed!");
            Console.WriteLine(ischarParsed ? $"{mychar4}" : "mychar4 TryParsing Failed!");

            // Convert Class
            // You can call a method of the Convert class to convert any supported type 
            // This is possible for each type that supports the IConvertible interface.

            try
            {
                // To SByte
                sbyte mysbyte5;
                mysbyte5 = Convert.ToSByte("100");
                mysbyte5 = Convert.ToSByte(mysbyte4);
                mysbyte5 = Convert.ToSByte(mybyte4);
                mysbyte5 = Convert.ToSByte(myshort4);
                mysbyte5 = Convert.ToSByte(myushort4);
                mysbyte5 = Convert.ToSByte(myint4);
                mysbyte5 = Convert.ToSByte(myuint4);
                mysbyte5 = Convert.ToSByte(mylong4);
                mysbyte5 = Convert.ToSByte(myulong4);
                mysbyte5 = Convert.ToSByte(myfloat4);
                mysbyte5 = Convert.ToSByte(mydouble4);
                mysbyte5 = Convert.ToSByte(mydecimal4);
                mysbyte5 = Convert.ToSByte(mychar4);

                // To Int16
                short myshort5;
                myshort5 = Convert.ToInt16("100");
                myshort5 = Convert.ToInt16(mysbyte4);
                myshort5 = Convert.ToInt16(mybyte4);
                myshort5 = Convert.ToInt16(myshort4);
                myshort5 = Convert.ToInt16(myushort4);
                myshort5 = Convert.ToInt16(myint4);
                myshort5 = Convert.ToInt16(myuint4);
                myshort5 = Convert.ToInt16(mylong4);
                myshort5 = Convert.ToInt16(myulong4);
                myshort5 = Convert.ToInt16(myfloat4);
                myshort5 = Convert.ToInt16(mydouble4);
                myshort5 = Convert.ToInt16(mydecimal4);
                myshort5 = Convert.ToInt16(mychar4);

                // To Int32
                int myint5 = Convert.ToInt32("100");
                myint5 = Convert.ToInt32(mysbyte4);
                myint5 = Convert.ToInt32(mybyte4);
                myint5 = Convert.ToInt32(myshort4);
                myint5 = Convert.ToInt32(myushort4);
                myint5 = Convert.ToInt32(myint4);
                myint5 = Convert.ToInt32(myuint4);
                myint5 = Convert.ToInt32(mylong4);
                myint5 = Convert.ToInt32(myulong4);
                myint5 = Convert.ToInt32(myfloat4);
                myint5 = Convert.ToInt32(mydouble4);
                myint5 = Convert.ToInt32(mydecimal4);
                myint5 = Convert.ToInt32(mychar4);

                

                // To Int64
                long mylong5;
                mylong5 = Convert.ToInt64("100");
                mylong5 = Convert.ToInt64(mysbyte4);
                mylong5 = Convert.ToInt64(mybyte4);
                mylong5 = Convert.ToInt64(myshort4);
                mylong5 = Convert.ToInt64(myushort4);
                mylong5 = Convert.ToInt64(myint4);
                mylong5 = Convert.ToInt64(myuint4);
                mylong5 = Convert.ToInt64(mylong4);
                mylong5 = Convert.ToInt64(myulong4);
                mylong5 = Convert.ToInt64(myfloat4);
                mylong5 = Convert.ToInt64(mydouble4);
                mylong5 = Convert.ToInt64(mydecimal4);
                mylong5 = Convert.ToInt64(mychar4);



                // To Byte
                byte mybyte5;
                mybyte5 = Convert.ToByte("100");
                mybyte5 = Convert.ToByte(mysbyte4);
                mybyte5 = Convert.ToByte(mybyte4);
                mybyte5 = Convert.ToByte(myshort4);
                mybyte5 = Convert.ToByte(myushort4);
                mybyte5 = Convert.ToByte(myint4);
                mybyte5 = Convert.ToByte(myuint4);
                mybyte5 = Convert.ToByte(mylong4);
                mybyte5 = Convert.ToByte(myulong4);
                mybyte5 = Convert.ToByte(myfloat4);
                mybyte5 = Convert.ToByte(mydouble4);
                mybyte5 = Convert.ToByte(mydecimal4);
                mybyte5 = Convert.ToByte(mychar4);

                // To Int16
                ushort myushort5;
                myushort5 = Convert.ToUInt16("100");
                myushort5 = Convert.ToUInt16(mysbyte4);
                myushort5 = Convert.ToUInt16(mybyte4);
                myushort5 = Convert.ToUInt16(myshort4);
                myushort5 = Convert.ToUInt16(myushort4);
                myushort5 = Convert.ToUInt16(myint4);
                myushort5 = Convert.ToUInt16(myuint4);
                myushort5 = Convert.ToUInt16(mylong4);
                myushort5 = Convert.ToUInt16(myulong4);
                myushort5 = Convert.ToUInt16(myfloat4);
                myushort5 = Convert.ToUInt16(mydouble4);
                myushort5 = Convert.ToUInt16(mydecimal4);
                myushort5 = Convert.ToUInt16(mychar4);

                // To Int32
                uint myuint5;
                myuint5 = Convert.ToUInt32("100");
                myuint5 = Convert.ToUInt32(mysbyte4);
                myuint5 = Convert.ToUInt32(mybyte4);
                myuint5 = Convert.ToUInt32(myshort4);
                myuint5 = Convert.ToUInt32(myushort4);
                myuint5 = Convert.ToUInt32(myint4);
                myuint5 = Convert.ToUInt32(myuint4);
                myuint5 = Convert.ToUInt32(mylong4);
                myuint5 = Convert.ToUInt32(myulong4);
                myuint5 = Convert.ToUInt32(myfloat4);
                myuint5 = Convert.ToUInt32(mydouble4);
                myuint5 = Convert.ToUInt32(mydecimal4);
                myuint5 = Convert.ToUInt32(mychar4);



                // To Int64
                ulong myulong5;
                myulong5 = Convert.ToUInt64("100");
                myulong5 = Convert.ToUInt64(mysbyte4);
                myulong5 = Convert.ToUInt64(mybyte4);
                myulong5 = Convert.ToUInt64(myshort4);
                myulong5 = Convert.ToUInt64(myushort4);
                myulong5 = Convert.ToUInt64(myint4);
                myulong5 = Convert.ToUInt64(myuint4);
                myulong5 = Convert.ToUInt64(mylong4);
                myulong5 = Convert.ToUInt64(myulong4);
                myulong5 = Convert.ToUInt64(myfloat4);
                myulong5 = Convert.ToUInt64(mydouble4);
                myulong5 = Convert.ToUInt64(mydecimal4);
                myulong5 = Convert.ToUInt64(mychar4);



                // To float
                float myfloat5;
                myfloat5 = Convert.ToSingle("100");
                myfloat5 = Convert.ToSingle(mysbyte4);
                myfloat5 = Convert.ToSingle(mybyte4);
                myfloat5 = Convert.ToSingle(myshort4);
                myfloat5 = Convert.ToSingle(myushort4);
                myfloat5 = Convert.ToSingle(myint4);
                myfloat5 = Convert.ToSingle(myuint4);
                myfloat5 = Convert.ToSingle(mylong4);
                myfloat5 = Convert.ToSingle(myulong4);
                myfloat5 = Convert.ToSingle(myfloat4);
                myfloat5 = Convert.ToSingle(mydouble4);
                myfloat5 = Convert.ToSingle(mydecimal4);
                //myfloat5 = Convert.ToSingle(mychar4);

                // To double
                double mydouble5;
                mydouble5 = Convert.ToDouble("100.5");
                mydouble5 = Convert.ToDouble(mysbyte4);
                mydouble5 = Convert.ToDouble(mybyte4);
                mydouble5 = Convert.ToDouble(myshort4);
                mydouble5 = Convert.ToDouble(myushort4);
                mydouble5 = Convert.ToDouble(myint4);
                mydouble5 = Convert.ToDouble(myuint4);
                mydouble5 = Convert.ToDouble(mylong4);
                mydouble5 = Convert.ToDouble(myulong4);
                mydouble5 = Convert.ToDouble(myfloat4);
                mydouble5 = Convert.ToDouble(mydouble4);
                mydouble5 = Convert.ToDouble(mydecimal4);
                //mydouble5 = Convert.ToDouble(mychar4);

                // To decimal
                decimal mydecimal5;
                mydecimal5 = Convert.ToDecimal("100.5");
                mydecimal5 = Convert.ToDecimal(mysbyte4);
                mydecimal5 = Convert.ToDecimal(mybyte4);
                mydecimal5 = Convert.ToDecimal(myshort4);
                mydecimal5 = Convert.ToDecimal(myushort4);
                mydecimal5 = Convert.ToDecimal(myint4);
                mydecimal5 = Convert.ToDecimal(myuint4);
                mydecimal5 = Convert.ToDecimal(mylong4);
                mydecimal5 = Convert.ToDecimal(myulong4);
                mydecimal5 = Convert.ToDecimal(myfloat4);
                mydecimal5 = Convert.ToDecimal(mydouble4);
                mydecimal5 = Convert.ToDecimal(mydecimal4);
                //mydecimal5 = Convert.ToDecimal(mychar4);

                // To char
                char mychar5;
                mychar5 = Convert.ToChar("1");
                mychar5 = Convert.ToChar(mysbyte4);
                mychar5 = Convert.ToChar(mybyte4);
                mychar5 = Convert.ToChar(myshort4);
                mychar5 = Convert.ToChar(myushort4);
                mychar5 = Convert.ToChar(myint4);
                mychar5 = Convert.ToChar(myuint4);
                mychar5 = Convert.ToChar(mylong4);
                mychar5 = Convert.ToChar(myulong4);
                //mychar5 = Convert.ToChar(myfloat4);
                //mychar5 = Convert.ToChar(mydouble4);
                //mychar5 = Convert.ToChar(mydecimal4);
                //mychar5 = Convert.ToChar(mychar4);

                // To string
                string mystring5;
                mystring5 = Convert.ToString("1");
                mystring5 = Convert.ToString(mysbyte4);
                mystring5 = Convert.ToString(mybyte4);
                mystring5 = Convert.ToString(myshort4);
                mystring5 = Convert.ToString(myushort4);
                mystring5 = Convert.ToString(myint4);
                mystring5 = Convert.ToString(myuint4);
                mystring5 = Convert.ToString(mylong4);
                mystring5 = Convert.ToString(myulong4);
                mystring5 = Convert.ToString(myfloat4);
                mystring5 = Convert.ToString(mydouble4);
                mystring5 = Convert.ToString(mydecimal4);
                mystring5 = Convert.ToString(mychar4);

                // To bool
                bool mybool5;
                mybool5 = Convert.ToBoolean("True");
                mybool5 = Convert.ToBoolean(mysbyte4);
                mybool5 = Convert.ToBoolean(mybyte4);
                mybool5 = Convert.ToBoolean(myshort4);
                mybool5 = Convert.ToBoolean(myushort4);
                mybool5 = Convert.ToBoolean(myint4);
                mybool5 = Convert.ToBoolean(myuint4);
                mybool5 = Convert.ToBoolean(mylong4);
                mybool5 = Convert.ToBoolean(myulong4);
                mybool5 = Convert.ToBoolean(myfloat4);
                mybool5 = Convert.ToBoolean(mydouble4);
                mybool5 = Convert.ToBoolean(mydecimal4);
                //mybool5 = Convert.ToBoolean(mychar4);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Convert Failed: " + ex.Message); 
            }






            // Simple Type int with some important methods
            Console.WriteLine("Integer Data Type");
            int x1;
            x1 = 10;
            int x2 = 10;
            int x3 = default;
            var x4 = 10;
            Console.WriteLine($"x1,x2,x3,x4 = {(x1, x2, x3, x4)}");
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);
            Console.WriteLine(int.Equals(x1, x2));

            // - TryParse integers: Successful Parse Cases
            // ----------------------------------------------------------------------------------
            int myvar1;
            bool isParsed = int.TryParse("100", out myvar1);
            Console.WriteLine(isParsed ? $"{myvar1}" : "myvar1 Parsing Failed!");

            isParsed = int.TryParse("100", out int myvar2);
            Console.WriteLine(isParsed ? $"{myvar2}" : "myvar2 Parsing Failed!");

            // compression of expressions
            Console.WriteLine($"{(int.TryParse("100", out myvar2) ? $"{myvar2}" : "myvar2 Parsing Failed!")}");


            // - TryParse integers: Failed Parse Cases
            // ----------------------------------------------------------------------------------
            int myvar3;
            isParsed = int.TryParse("Moamen", out myvar3);
            Console.WriteLine(isParsed ? $"{myvar3}" : "myvar3 Parsing Failed!");

            isParsed = int.TryParse("100tone", out int myvar4);
            Console.WriteLine(isParsed ? $"{myvar4}" : "myvar4 Parsing Failed!");

            // compression of expressions
            Console.WriteLine($"{(int.TryParse("1 0 0", out myvar4) ? $"{myvar4}" : "myvar4 Parsing Failed!")}");

            // Parse Integer
            try
            {
                // success
                Console.WriteLine($"{int.Parse("100")}");
                // failure
                Console.WriteLine($"{int.Parse("100sd")}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Convert
            // You can call a method of the Convert class to convert any supported type to an Int32 value. 
            // This is possible because Int32 supports the IConvertible interface.
            int x = Convert.ToInt32("100");
            long l1 = 100L; // or 100l


            Console.WriteLine();

            // integer(Int32) is a Structure drived from Object->ValueType
            // So it inherts all Object methods and considered Value Type(Located at Stack not Heap)
            // The Default Integral Numeric Storage is Int32 or int
            // All Integral Literal without are 





            // Unicode characters: char
            // IEEE binary floating-point: float, double
            // High-precision decimal floating-point: decimal
            // Boolean: bool




        }
    }
}