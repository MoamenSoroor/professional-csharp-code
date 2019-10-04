
using System;

namespace CSharpBookTraining
{
    // Structure Specification Notes
    //----------------------------------------------------------------------------------------------------
    // - A structure (such as an enumeration) is a user-defined type.

    // - Structures considered Value-based as It is derived from ValueType class, so: 
    //      it is treated as a Variable not as an Object and allocated in Stack not in the Heap
    //      Simply put, data allocated on the stack can be created and destroyed quickly, 
    //      as its lifetime is determined by the defining scope.

    // - you can think of a structure as a “lightweight class type”

    // - It cannot be used to build a family of related types.

    // - When you need to build a family of related types through inheritance, 
    //      you will need to make use of class types

    // - Structures used for modeling mathematical, geometrical, 
    //      and other “atomic” entities in your application.

    // - Structures doesn't accepts protected Modifier

    // Structure Programming Notes
    //----------------------------------------------------------------------------------------------------
    // - 
    // - 
    // - 
    // - The three Paradigms of Creating Structure Variables is:
    //     1- Creating Variable without Constructor - e.g Point p1; - :
    //          With that way, all Data fields doesn't assigned to any value in Structure Variable Creation 
    //          so you will face a Compile error if you don't assign it after structure creation in that way.
    //     2- Creating Variable with default constructor e.g Point p1 = new Point();
    //          Here, All Data Fields are set to it's default values e.g int to 0, float and double to 0.0,
    //          and all objects are set to null.
    //     3- Creating Variable with Custom Constructor e.g Point p1 = new Point(10,20);
    //          Here, you must assign all data fields to it's value. or else, you will face Compile Error. 
    // - 

    public static class StructuresTraining
    {
        static StructuresTraining() { }

        public static void TestStructures()
        {
            Console.WriteLine("#-------------< Test Structures >-------------#");
            // Create an initial Point.
            Point myPoint;
            myPoint.X = 349;
            myPoint.Y = 76;
            myPoint.Display();
            // Adjust the X and Y values.
            myPoint.Increment();
            myPoint.Display();

            // Create Point Variable without Constructor
            Point p1;
            p1.X = 10;
            //Error: Compile Error, because Variable p1.Y is not assigned.
            //p1.Display();

            //Creating Variable with default constructor
            Point p2 = new Point();
            // Will dislay default values 0 for int, 0.0 for float and double, null for object
            p2.Display();

            // Creating Variable with custom constructor
            Point p3 = new Point("P3", 10, 20);
            // Will dislay default values 0 for int, 0.0 for float and double, null for object
            p3.Display();





            Console.ReadLine();

        }
    }
    


    struct MyStruct
    {
        //public int myField;
        //private int myField2;
        // Error structure doesn't accept protected Modifier for any member
        // protected int myField3;

        // Accepts Automatic Property
        public string Name { get; set; }

        // Accepts Fields
        private int age;

        // Accepts Properties
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 1)
                    value = 1;
                age = value;
            }
        }

        // Accepts Methods
        public void Print()
        {
            Console.WriteLine($"Name:{Name}; Age:{Age}; Birth Year:{DateTime.Now.Year - Age}");
        }


        // 


    }


    struct Point
    {
        // Fields of the structure.
        public int X;
        public int Y;

        // Not allowed to redefine default constructor
        // public Point2() { }

        // if you didn't assigned all data points in custom constructor Compile Error will appear.
        // public Point2(int x, int y) { this.X = x; }

        public Point(string name1 ,int x , int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // You can Overload Constructors
        public Point(int x)
        {
            this.X = x;
            this.Y = x;
        }

        // Add 1 to the (X, Y) position.
        public void Increment()
        {
            X++; Y++;
        }
        // Subtract 1 from the (X, Y) position.
        public void Decrement()
        {
            X--; Y--;
        }
        // Display the current position.
        public void Display()
        {
            Console.WriteLine("X = {1}, Y = {2}", X, Y);
        }
    }



}