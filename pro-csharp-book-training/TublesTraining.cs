using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace pro_csharp_book_training
{

    // Tuples Specification Notes
    //----------------------------------------------------------------------------------------------------
    // - Tuples, which are lightweight data structures that contain multiple fields, were actually added in C# 6
    //      but in a very limited way.
    // - In C# 7, tuples use the new ValueTuple data type instead of reference types, potentially saving
    //      significant memory.
    // - An additional feature added in C# 7 is that each property in a tuple can be assigned a specific
    //      name(just like variables), greatly enhancing the usability.
    // - 
    // - 

    public static class TuplesTraining
    {
        static TuplesTraining(){ }

        public static void TestTuples()
        {
            // Notice that they don’t all have to be the same data type.
            (int, string, bool) values = (10, "Moamen", true);

            // you can use Impicity typed var
            var varValues = (Math.PI, "Math" , false);

            // By default, the compiler assigns each property the name ItemX, where X represents the one based
            //      position in the tuple.
            Console.WriteLine(values.Item1);
            Console.WriteLine(values.Item2);
            Console.WriteLine(values.Item3);

            Console.WriteLine(values.GetType().Name);

            Console.WriteLine(values.Item1.GetType().FullName);
            Console.WriteLine(values.Item2.GetType().FullName);
            Console.WriteLine(values.Item3.GetType().FullName);

            // Specific names can also be added to each property in the tuple on either the right side or the left side of
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

            // var with Right Side Named Properties
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

            Logger.Title("leftSideTuple with ItemX call");
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

            // Inferred Tuple Names
            //------------------------------------------------------------------------------------------
            Logger.Title("Inferred Tuple Names");
            var foo = (Prop1: "first", Prop2: "second");
            var bar = (foo.Prop1, foo.Prop2);
            var bar2 = (BarProp1: foo.Prop1, BarProp2: foo.Prop2);
            Console.WriteLine($"{bar.Prop1};{bar.Prop2}");
            Console.WriteLine($"{bar2.BarProp1};{bar2.BarProp1}");

            // Value Types To Tuple Conversion without Named Properties (from C# 7.1)
            int var1 = 10, var2 = 20;
            var myTuple = (var1, var2);

            // Value Types To Tuple Conversion (from C# 7.0)
            var myTuple2 = (TupleVar1: var1, TupleVar2: var2);

            Console.WriteLine(myTuple == (var1, var2));
            Console.WriteLine(myTuple == myTuple2);


            // Tuple To Value Types Conversion
            var1 = myTuple.Item1;
            var2 = myTuple.Item2;



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

            // Deconstructing with Tuples
            //------------------------------------------------------------------------------------------
            MyPoint p1 = new MyPoint(10, 20);

            var pointValues = p1.Deconstruct();
            Console.WriteLine($"px = {pointValues.XPos}");
            Console.WriteLine($"py = {pointValues.YPos}");



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
            string [] result = name.Split(new [] { ' ','.'});
            if (result.Length == 1)
                return (result[0], "", "");
            else if (result.Length == 2)
                return (result[0], "", result[1]);
            else if (result.Length == 3)
                return (result[0], result[1], result[2]);
            else
            {
                string middle = string.Join(" ", result, 1, result.Length - 2);
                return (result[0], middle, result[2]);
            }

        }

        private static void WriteName((string first, string second, string last) name)
        {
            string result = name.first + (name.second == ""? "":" ") + name.second + (name.last == "" ? "" : " ") + name.last;
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