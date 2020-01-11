using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpBook.CSharpGenerics
{

    // Creating Custom Generic Methods
    // ========================================================================================================
    class TestCustomGenericMethods
    {
        // you can create generic method by specify type parameter after method name.
        public static void PrintType<T>(T t)
        {
            Console.WriteLine("Type:" + t.GetType().FullName + "; Value:" + t);
        }



        public static void PrintType2<T>()
        {
            Console.WriteLine("Print Type -> " + (typeof(T).FullName));
        }


        // where clause and default(T) operator
        public static void PrintType3<T>() 
            where T : new()
        {
            T t = default(T) ?? new T();
            Console.WriteLine("Type:" + t.GetType().FullName + "; Value:" + t);
        }


        public static void Test()
        {
            PrintType<int>(0);
            PrintType<float>(0.0f);
            PrintType<double>(0.0);
            PrintType<string>("My Str");


            PrintType(0);
            PrintType(0.0f);
            PrintType(0.0);
            PrintType("My Str");



            PrintType2<int>();
            PrintType2<float>();
            PrintType2<double>();
            


        }

    }

    // Creating Custom Generic Methods
    // ========================================================================================================
    struct Point<T>
    {

        private T xPos, yPos;

        public Point(T x , T y)
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

    class TestGenericStrcuture
    {
        public static void Test()
        {
            Point<int> intPoint = new Point<int>();
            Console.WriteLine(intPoint);
            Point<double> doublePoint = new Point<double>();
            Console.WriteLine(doublePoint);
        }

    }

    class GenericsTraining
    {
        public static void Test()
        {
            //TestCustomGenericMethods.Test();
            TestGenericStrcuture.Test();
        }

    }

}