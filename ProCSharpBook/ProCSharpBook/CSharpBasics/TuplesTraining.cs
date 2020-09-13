using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using ProCSharpBook.CSharpBasics;

namespace ProCSharpBook.CSharpBasics
{

    // Tuples Specification Notes
    //----------------------------------------------------------------------------------------------------
    // - Methods return a single object. Tuples enable you to package multiple values in that 
    //      single object more easily.
    // -  you could create a class or a struct to carry multiple elements returned from method. 
    //      Unfortunately, that's more work for you, and it obscures your design intent.
    //      Making a struct or class implies that you are defining a type with both data and behavior.
    //      Many times, you simply want to store multiple values in a single object.

    // - Tuples, which are lightweight data structures that contain multiple fields, 
    //      were actually added in C# 6 but in a very limited way.

    // - In C# 7, tuples use the new ValueTuple -structure drived from ValueType- data type 
    //       instead of reference types, potentially saving significant memory.

    // - An additional feature added in C# 7 is that each property in a tuple can be 
    //      assigned a specific name(just like variables), greatly enhancing the usability.

    // - All the ValueTuple types are mutable structs. Each member field is a public field.
    //      That makes them very lightweight. However, that means tuples should not be used
    //      where immutability is important.
    // - 

    public static class TuplesTraining
    {
        static TuplesTraining() { }

        public static void TestTuples()
        {
            // Notice that they don’t all have to be the same data type.
            (int, string, bool) values = (10, "Moamen", true);

            // you can use Implicity typed var
            var varValues = (Math.PI, "Math", false);

            // By default, the compiler assigns each property the name ItemX, 
            //  where X represents the one based position in the tuple. 
            //  X starts from 1 to n the number of elements in tuple.
            Console.WriteLine(values.Item1);
            Console.WriteLine(values.Item2);
            Console.WriteLine(values.Item3);

            Console.WriteLine(values.GetType().Name);

            Console.WriteLine(values.Item1.GetType().FullName);
            Console.WriteLine(values.Item2.GetType().FullName);
            Console.WriteLine(values.Item3.GetType().FullName);

            #region Named and unnamed tuples - Deconstruction Tuples

            // Named and unnamed tuples
            //------------------------------------------------------------------------------------------
            // The ValueTuple struct - drived from ValueType - has fields named Item1, Item2, Item3, and so on,
            //      similar to the properties defined in the existing Tuple types.
            //      These names are the only names you can use for unnamed tuples. 
            //      When you do not provide any alternative field names to a tuple, 
            //      you've created an unnamed tuple.

            // Named tuples still have elements named Item1, Item2, Item3 and so on. 
            //      But they also have synonyms for any of those elements that you have named.

            //  In Named tuples, The compiled Microsoft Intermediate Language (MSIL) does not 
            //      include the names you've given to tuple elements.

            // Unnamed tuples
            (int, bool) tuple1 = (10, true);
            var tuple2 = (10, true);
            (int, bool) tuple3 = (integer: 10, boolean: true); // right side names ignored by compiler

            // named tuples
            (int integer, bool boolean) tuple4 = (10, true);
            var tuple5 = (integer: 10, boolean: true);

            (int integer, bool boolean) tuple6 = (myInt: 10, myBool: true); // right side names ignored by compiler

            // Deconstruction tuple
            (int integer, bool boolean) = (10, true);

            var (integer1, boolean1) = (10, true);

            (var integer2, var boolean2) = (10, true);


            // Specific names can be added to each property in the tuple on either the right side or the left side of
            //      the statement.
            // Left Side Named Properties
            //------------------------------------------------------------------------------------------
            (int MyInt, string Mystr, bool MyBool) rightSideTuple = (10, "Moamen", true);
            // the properties on the tuple can be accessed using the field names as well as the ItemX notation

            Logger.Title("rightSideTuple with ItemX call");
            Console.WriteLine(rightSideTuple.Item1);
            Console.WriteLine(rightSideTuple.Item2);
            Console.WriteLine(rightSideTuple.Item3);

            Logger.Title("rightSideTuple with Named Properties call");
            Console.WriteLine(rightSideTuple.MyInt);
            Console.WriteLine(rightSideTuple.MyBool);
            Console.WriteLine(rightSideTuple.Mystr);

            // var with Right Side Named Properties - Names as part of the tuple initialization -:
            //------------------------------------------------------------------------------------------
            var leftSideTupleWithVar = (MyInt: 10, MyStr: "Moamen", MyBool: true);

            Logger.Title("leftSideTuple with ItemX call");
            Console.WriteLine(leftSideTupleWithVar.Item1);
            Console.WriteLine(leftSideTupleWithVar.Item2);
            Console.WriteLine(leftSideTupleWithVar.Item3);

            Logger.Title("leftSideTupleWithVar with Named Properties call");
            Console.WriteLine(leftSideTupleWithVar.MyInt);
            Console.WriteLine(leftSideTupleWithVar.MyStr);
            Console.WriteLine(leftSideTupleWithVar.MyBool);


            // var with Left Side Named Properties
            //------------------------------------------------------------------------------------------
            var (MyInt, MyStr, MyBool) = (10, "Moamen", true);
            Logger.Title("leftSideTupleWithVar with ItemX call");
            Console.WriteLine(leftSideTupleWithVar.Item1);
            Console.WriteLine(leftSideTupleWithVar.Item2);
            Console.WriteLine(leftSideTupleWithVar.Item3);

            Logger.Title("leftSideTupleWithVar with Named Properties call");
            Console.WriteLine(leftSideTupleWithVar.MyInt);
            Console.WriteLine(leftSideTupleWithVar.MyStr);
            Console.WriteLine(leftSideTupleWithVar.MyBool);


            // Both Sides Named Properties (Left names ignored and can't be used)
            //------------------------------------------------------------------------------------------
            // While it is not a compiler error to assign names on both sides of the statement,
            //      if you do, the right side will be ignored, and only the left-side names are used.
            (int MyInt, string Mystr, bool MyBool) bothSidesTuple = (MyIntValue: 10, MyStringValue: "Moamen", MyBoolValue: true);

            Logger.Title("bothSidesTuple with ItemX call");
            Console.WriteLine(bothSidesTuple.Item1);
            Console.WriteLine(bothSidesTuple.Item2);
            Console.WriteLine(bothSidesTuple.Item3);

            Logger.Title("bothSidesTuple with Left Named Properties call");
            Console.WriteLine(bothSidesTuple.MyInt);
            Console.WriteLine(bothSidesTuple.Mystr);
            Console.WriteLine(bothSidesTuple.MyBool);

            // ERROR: Cannot Access Tuples With Left Named Properties call when there are Right Names 
            //Logger.Title("bothSidesTuple with Right Named Properties call");
            //Console.WriteLine(bothSidesTuple.MyIntValue);
            //Console.WriteLine(bothSidesTuple.MyStrValue);
            //Console.WriteLine(bothSidesTuple.MyBoolValue);


            // Left Side Named Properties with Right Side Explicit properties Types -without var keyword-
            //------------------------------------------------------------------------------------------
            // NOTE: Note that when setting the names on the right, you must use the keyword var. 
            //      Setting the data types specifically(even without custom names) triggers 
            //      the compiler to use the left side, assign the properties using the ItemX notation,
            //      and ignore any of the custom names set on the right.The following two examples ignore
            //      the MyIntValue, MyStringValue and MyBoolValue names:

            (int, string, bool) leftSideTuple = (MyIntValue: 10, MyStringValue: "Moamen", MyBoolValue: true);


            // So the only way to access the last tuple is to use ItemX notation
            Logger.Title("leftSideTuple with Right Side Explicit properties Types -without var keyword-");
            Console.WriteLine(leftSideTuple.Item1);
            Console.WriteLine(leftSideTuple.Item2);
            Console.WriteLine(leftSideTuple.Item3);

            #endregion

            #region Tuple Projection Initializers
            // Tuple Projection Initializers
            //------------------------------------------------------------------------------------------
            // Beginning with C# 7.1, the field names for a tuple may be provided from the variables used to
            //  initialize the tuple. This is referred to as tuple projection initializers.

            Logger.Title("Tuple Projection Initializers");
            double sum = 12.5;
            int count = 5;
            // projected names
            var accumulation = (count, sum);
            Console.WriteLine("accumulation.count = " + accumulation.count);
            Console.WriteLine("accumulation.sum = " + accumulation.sum);

            // You can use Projected Names, or update it with new Explicit Names.
            // If an explicit name is given, that takes precedence over any projected name.
            // and compile error with appear if you call elements with projected names     

            // explicit names
            var accumulation2 = (count2: count, sum2: sum);
            Console.WriteLine("accumulation.count2 = " + accumulation2.count2);
            Console.WriteLine("accumulation.sum2 = " + accumulation2.sum2);
            // compile Error if you use projected names, as explicit names canceled projected names
            //Console.WriteLine("accumulation.sum = " + accumulation2.sum);
            //Console.WriteLine("accumulation.count = " + accumulation2.count);

            // For any field where an explicit name is not provided, an applicable implicit name is projected.

            var stringContent = "The answer to everything";
            var mixedTuple = (42, stringContent);
            Console.WriteLine($"mixedTuple = ({mixedTuple.Item1} , {mixedTuple.stringContent})");

            // Mixed tuple with explicit name for first element, and projected name for second element.
            var mixedTuple2 = (integer: 42, stringContent);
            Console.WriteLine($"mixedTuple2 = ({mixedTuple2.integer} , {mixedTuple2.stringContent})");

            // There are two conditions where candidate field names are not projected onto the tuple field:
            // 1- When the candidate name is a reserved tuple name. 
            //      Examples include Item3, ToString or Rest.
            // 2- When the candidate name is a duplicate of another tuple field name,
            //      either explicit or implicit.

            // Neither of these conditions cause compile-time errors.Instead, 
            //      the elements without projected names do not have semantic 
            //      names projected for them.

            // Projection Failure First Case:
            int num = 10;
            int Item2 = 20;
            var tuple7 = (Item2, num);
            // projection failed as Item2 ia << Reserved Tuple Name >> , and now:
            // first element can be accessed only with implicit name (Item1)
            Console.WriteLine(tuple7.Item1);
            // second element can be accessed with projected name (num) and implicit name (Item2)
            Console.WriteLine(tuple7.num);
            Console.WriteLine(tuple7.Item2);

            // Projection Failure Second Case:

            var point1 = (X: 10, Y: 20);
            var point2 = (X: 30, Y: 40);
            // Projection failed because of Names Ambiguity due to duplication of another tuple field name
            var xCoords = (point1.X, point2.X);
            // we can access xCoords only with Implicit names ItemX Notation
            Console.WriteLine(xCoords.Item1);
            Console.WriteLine(xCoords.Item2);

            //Console.WriteLine(xCoords.X);

            // These situations do not cause compiler errors because that would be a 
            //      breaking change for code written with C# 7.0, when tuple field name 
            //      projections were not available.

            #endregion

            #region Equality in Tuples

            // Equality in Tuples

            // Beginning with C# 7.3, tuple types support the == and != operators. 
            // These operators work by comparing each member of the left argument to
            // each member of the right argument in order. These comparisons short-circuit.
            Logger.Title("Equality in Tuples");
            var left = (a: 5, b: 10);
            var right = (a: 5, b: 10);
            Console.WriteLine(left == right); // displays 'true'

            // Tuple equality also performs implicit conversions on each member of both tuples. 
            // These include lifted conversions, widening conversions, or other implicit conversions.

            // Tuple equality performs lifted conversions if one of the tuples is a nullable tuple
            Logger.Title("lifted conversions if one of the tuples is a nullable tuple");
            var left2 = (a: 10, b: 20);
            (int? a, int? b) nullableRight = (10, 20);
            Console.WriteLine(left2 == nullableRight);

            // converted type of left is (long, long)
            (long a, long b) longTuple = (5, 10);
            Console.WriteLine(left == longTuple); // Also true

            // comparisons performed on (long, long) tuples
            (long a, int b) longFirst = (5, 10);
            (int a, long b) longSecond = (5, 10);
            Console.WriteLine(longFirst == longSecond); // Also true

            // The names of the tuple members do not participate in tests for equality.However,
            //  if one of the operands is a tuple literal with explicit names, the compiler 
            //  generates warning CS8383 if those names do not match the names of the other operand. 

            (int a, string b) pair = (1, "Hello");
            (int z, string y) another = (1, "Hello");
            Console.WriteLine(pair == another); // true. Member names don't participate.
            Console.WriteLine(pair == (z: 1, y: "Hello")); // warning: literal contains different member names

            //Finally, tuples may contain nested tuples. 
            // Tuple equality compares the "shape" of each operand through nested tuples.

            (int, (int, int)) nestedTuple = (1, (2, 3));
            Console.WriteLine(nestedTuple == (1, (2, 3)));

            // It's a compile time error to compare two tuples for equality (or inequality) 
            //      when they have different shapes. The compiler won't attempt any deconstruction 
            //      of nested tuples in order to compare them.

            #endregion


            #region Assignment and tuples
            //The language supports assignment between tuple types that have the same number of elements, 
            //      where each right-hand side element can be implicitly converted to its corresponding 
            //      left hand side element. Other conversions aren't considered for assignments. 
            //      It's a compile time error to assign one tuple to another when they have different shapes. 
            //      The compiler won't attempt any deconstruction of nested tuples in order to assign them. 
            //      Let's look at the kinds of assignments that are allowed between tuple types.

            // The 'arity' and 'shape' of all these tuples are compatible. 
            // The only difference is the field names being used.
            var unnamed = (42, "The meaning of life");
            var anonymous = (16, "a perfect square");
            var named = (Answer: 42, Message: "The meaning of life");
            var differentNamed = (SecretConstant: 42, Label: "The meaning of life");

            //  all of these assignments work:
            unnamed = named;

            named = unnamed;
            // 'named' still has fields that can be referred to
            // as 'answer', and 'message':
            Console.WriteLine($"{named.Answer}, {named.Message}");

            // unnamed to unnamed:
            anonymous = unnamed;

            // named tuples.
            named = differentNamed;
            // The field names are not assigned. 'named' still has 
            // fields that can be referred to as 'answer' and 'message':
            Console.WriteLine($"{named.Answer}, {named.Message}");

            // With implicit conversions:
            // int can be implicitly converted to long
            (long, string) conversion = named;

            // explicit conversion of tuple
            (short, string) conversion2 = ((short)named.Answer, named.Message );

            // Notice that the names of the tuples are not assigned. The values of the elements
            //      are assigned following the order of the elements in the tuple.

            // Tuples of different types or numbers of elements are not assignable:
            // Does not compile.
            // CS0029: Cannot assign Tuple(int,int,int) to Tuple(int, string)
            //var differentShape = (1, 2, 3);
            //named = differentShape;





            #endregion

            #region Tuples As Method Return Values

            // Tuples As Method Return Values
            //------------------------------------------------------------------------------------------
            //out parameters were used to return more than one value from a method call.There
            //are additional ways to do this, such as creating a class or structure specifically to return 
            //the values.But if this class or struct is only to be used as a data transport for one method,
            //that is extra work and extra code that doesn’t need to be developed.
            //Tuples are perfectly suited for this task, are lightweight, and are easy to declare and use.

            var samples = FillTheseValues();
            Console.WriteLine($"Int is: {samples.a}");
            Console.WriteLine($"String is: {samples.b}");
            Console.WriteLine($"Boolean is: {samples.c}");


            var nameTuple = SplitName("Moamen");
            Console.WriteLine($"Name: {nameTuple.first}{(nameTuple.second == "" ? "" : " ")}{nameTuple.second}{(nameTuple.last == "" ? "" : " ")}{nameTuple.last}");

            nameTuple = SplitName("Moamen Mohammed");
            WriteName(nameTuple);

            nameTuple = SplitName("Moamen Mohammed Soroor");
            WriteName(nameTuple);

            nameTuple = SplitName("Moamen Mohammed Gamal Soroor");
            WriteName(nameTuple);

            nameTuple = SplitName("Moamen Mohammed Gamal Mohammed Soroor");
            WriteName(nameTuple);

            nameTuple = SplitName("Moamen MG.Soroor");
            WriteName(nameTuple);

            // Discards with Tuples
            //------------------------------------------------------------------------------------------
            // Following up on the SplitNames() example, suppose you know that you need only 
            //      the first and last names and don’t care about the second.

            var (first, _, last) = SplitName("Moamen Mohammed Soroor");
            Console.WriteLine($"{first}:{last}");

            var (first2, _, _) = SplitName("Moamen Mohammed Soroor");
            Console.WriteLine($"{first2}");

            #endregion


            #region Deconstructing with Tuples

            // Deconstruction
            //------------------------------------------------------------------------------------------
            // You can unpackage all the items in a tuple by deconstructing the tuple returned by a method. 
            //      There are three different approaches to deconstructing tuples.





            //MyPoint Sructure Variable
            MyPoint p1 = new MyPoint(10, 20);

            // deconstructing
            var pointValues = p1.Deconstruct();
            Console.WriteLine($"pointValues.px = {pointValues.XPos}");
            Console.WriteLine($"pointValues.py = {pointValues.YPos}");


            // deconstructing
            var (XPos2, YPos2) = p1.Deconstruct();
            Console.WriteLine($"px = {XPos2}");
            Console.WriteLine($"py = {YPos2}");

            #endregion

        }


        private static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string.";
            c = true;
        }
        // By using a tuple, you can remove the parameters and still get the three values back.
        private static (int a, string b, bool c) FillTheseValues()
        {
            return (9, "Enjoy your string.", true);
        }

        private static (string first, string second, string last) SplitName(string name)
        {
            string[] result = name.Split(new[] { ' ', '.' });
            if (result.Length == 1)
                return (result[0], "", "");
            else if (result.Length == 2)
                return (result[0], "", result[1]);
            else if (result.Length == 3)
                return (result[0], result[1], result[2]);
            else
            {
                string middle = string.Join(" ", result, 1, result.Length - 2);
                return (result[0], middle, result[result.Length - 1]);
            }

        }

        private static void WriteName((string first, string second, string last) name)
        {
            string result = name.first + (name.second == "" ? "" : " ") + name.second + (name.last == "" ? "" : " ") + name.last;
            Console.WriteLine(result);
        }

        private static void WriteName2((string, string, string) name)
        {
            string result = name.Item1 + (name.Item2 == "" ? "" : " ") + name.Item2 + (name.Item3 == "" ? "" : " ") + name.Item3;
            Console.WriteLine(result);
        }

    }

    struct MyPoint
    {
        // Fields of the structure.
        public int X;
        public int Y;
        // A custom constructor.
        public MyPoint(int XPos, int YPos)
        {
            X = XPos;
            Y = YPos;
        }
        public (int XPos, int YPos) Deconstruct() => (X, Y);
    }


}