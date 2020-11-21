using ProCSharpBook.ExtensionMethods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace ProCSharpBook.CSharpOperatorOverloading
{

    #region Understanding Indexer Methods
    // ------------------------ Understanding Indexer Methods -------------------------
    // the C# language provides the capability to design custom classes and structures that may be indexed just 
    // like a standard array, by defining an indexer method.This particular feature is most useful when you are
    // creating custom collection classes (generic or nongeneric).

    class Employee : IComparable<Employee>
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


        public Employee(int id, string name, int age)
        {
            this.ID = id;
            this.Name = name;
            this.Age = age;

        }

        public Employee() : this(0, "Emp_Name", 22) { }


        public override string ToString()
        {
            return $@"Employee{{ ID: {ID}, Name: {Name}, Age: {Age} }}";
        }

        public override bool Equals(object obj)
        {
            return this.ToString().Equals((obj as Employee)?.ToString());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public int CompareTo(Employee other)
        {
            return this.ToString().CompareTo(other.ToString());
        }


    }


    // Int Indexer Method
    // -----------------------------------------------------------------------------------
    class EmployeeCollection
    {

        private readonly List<Employee> employees;

        public List<Employee> Employees { get => employees; }

        public EmployeeCollection()
        {
            employees = new List<Employee>();
        }

        public Employee this[int index]
        {
            get => employees[index];        // expression bodied

            //get { return employees[index]; }

            set { this.employees[index] = value; }

        }

    }



    // String Indexer Method
    // -----------------------------------------------------------------------------------
    class EmployeeDictionary
    {

        private readonly Dictionary<string, Employee> employees;
        public Dictionary<string, Employee> Employees { get => employees; }

        public EmployeeDictionary()
        {
            employees = new Dictionary<string, Employee>();
        }

        public Employee this[string index]
        {
            get => employees[index];     // expression bodied

            set
            {
                this.employees[index] = value;
            }

        }

    }


    // Overloading Indexer Methods
    // -----------------------------------------------------------------------------------
    class EmployeeOverloadedIndexer
    {

        private readonly Dictionary<string, Employee> employees;

        public Dictionary<string, Employee> Employees { get => employees; }


        public EmployeeOverloadedIndexer()
        {
            employees = new Dictionary<string, Employee>();
        }

        // access with string: dictionary key
        public Employee this[string index]
        {
            get => employees[index];     // expression bodied
            set => this.employees[index] = value;

        }
        // access with int: 
        public Employee this[int index]
        {
            get { return this.employees.Where(p => p.Value.ID == index).FirstOrDefault().Value; }
            set
            {
                var key = this.employees.Where(p => p.Value.ID == index).FirstOrDefault().Key;
                this.employees[key] = value;
            }
        }




    }


    // Indexers with Multiple Dimensions
    // -----------------------------------------------------------------------------------
    struct Point
    {

        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj?.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"[ {X} , {Y} ]";
        }
    }

    class PointCollection
    {
        private readonly List<Point> points = new List<Point>();

        // Indexer with Multiple Dimensions
        public Point this[double x, double y]
        {
            get { return this.points.Where(p => p.Equals(new Point(x, y))).FirstOrDefault(); }
            set { this.points[this.points.IndexOf(new Point(x, y))] = value; }
        }

        public List<Point> Points { get => points; }


    }


    // Indexer Definitions on Interface Types
    // -----------------------------------------------------------------------------------
    // Indexers can be defined on a given .NET interface type to allow supporting types 
    // to provide a custom implementation.

    public interface IStringContainer
    {
        string this[int index] { get; set; }
    }

    class SomeClass : IStringContainer
    {
        private List<string> myStrings = new List<string>();

        // indexer implementation
        public string this[int index]
        {
            get => myStrings[index];
            set => myStrings.Insert(index, value);
        }
    }



    public class IndexerMethods
    {
        // Test Method
        public static void Test()
        {

            // Int Indexer Method Test
            // -----------------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("Int Indexer Method Test".Padding(10));
            var empCollection = new EmployeeCollection();
            empCollection.Employees.Add(new Employee(01, "Moamen", 25));
            empCollection.Employees.Add(new Employee(02, "Rahma", 30));
            empCollection.Employees.Add(new Employee(03, "Merona", 55));

            Console.WriteLine("Access With Int Indexer ==>");
            Console.WriteLine(empCollection[0]);
            Console.WriteLine(empCollection[1]);
            Console.WriteLine(empCollection[2]);

            empCollection[0] = new Employee(01, "Mohammed", 25);
            empCollection[1] = new Employee(02, "Amany", 30);
            empCollection[2] = new Employee(03, "Gamal", 55);


            Console.WriteLine("Updated Values With Int Indexer ==>");
            Console.WriteLine(empCollection[0]);
            Console.WriteLine(empCollection[1]);
            Console.WriteLine(empCollection[2]);



            // String Indexer Method Test
            // -----------------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("String Indexer Method Test".Padding(10));


            var empDict = new EmployeeDictionary();
            empDict.Employees.Add("emp1", new Employee(01, "Moamen", 25));
            empDict.Employees.Add("emp2", new Employee(02, "Rahma", 30));
            empDict.Employees.Add("emp3", new Employee(03, "Merona", 55));

            Console.WriteLine("Access With String Indexer ==>");
            Console.WriteLine(empDict["emp1"]);
            Console.WriteLine(empDict["emp2"]);
            Console.WriteLine(empDict["emp3"]);

            // Update Values With String Indexer
            empDict["emp1"] = new Employee(01, "Mohammed", 25);
            empDict["emp2"] = new Employee(02, "Amany", 30);
            empDict["emp3"] = new Employee(03, "Gamal", 55);


            Console.WriteLine("Updated Values With String Indexer ==>");
            Console.WriteLine(empDict["emp1"]);
            Console.WriteLine(empDict["emp2"]);
            Console.WriteLine(empDict["emp3"]);


            // Overloaded Indexer : String Index, and  Int Index
            // -----------------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("Overloaded Indexer : String Index, and  Int Index".Padding(10));

            var empDict2 = new EmployeeOverloadedIndexer();
            empDict2.Employees.Add("emp1", new Employee(01, "Moamen", 25));
            empDict2.Employees.Add("emp2", new Employee(02, "Rahma", 30));
            empDict2.Employees.Add("emp3", new Employee(03, "Merona", 55));

            Console.WriteLine("Access With String Indexer ==>");
            Console.WriteLine(empDict2["emp1"]);
            Console.WriteLine(empDict2["emp2"]);
            Console.WriteLine(empDict2["emp3"]);

            Console.WriteLine("Access With Int Indexer that represent Employee ID ==>");
            Console.WriteLine(empDict2[1]);
            Console.WriteLine(empDict2[2]);
            Console.WriteLine(empDict2[3]);

            // Update Values With String Indexer
            empDict2["emp1"] = new Employee(01, "Mohammed2", 25);
            empDict2["emp2"] = new Employee(02, "Amany2", 30);
            empDict2["emp3"] = new Employee(03, "Gamal2", 55);


            Console.WriteLine("Updated Values With String Indexer ==>");
            Console.WriteLine(empDict2["emp1"]);
            Console.WriteLine(empDict2["emp2"]);
            Console.WriteLine(empDict2["emp3"]);


            // Update Values With Int Indexer
            empDict2[01] = new Employee(01, "Mohammed3", 25);
            empDict2[02] = new Employee(02, "Amany3", 30);
            empDict2[03] = new Employee(03, "Gamal3", 55);


            Console.WriteLine("Updated Values With String Indexer ==>");
            Console.WriteLine(empDict2["emp1"]);
            Console.WriteLine(empDict2["emp2"]);
            Console.WriteLine(empDict2["emp3"]);





            // Indexer with Multiple Dimensions
            // -----------------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("Indexer with Multiple Dimensions".Padding(10));


            PointCollection points = new PointCollection();

            points.Points.Add(new Point(10, 20));
            points.Points.Add(new Point(11, 21));
            points.Points.Add(new Point(12, 22));

            Console.WriteLine("Acess with x, and y Multiple Dimensions Indexer ==>");
            Console.WriteLine(points[10, 20]);
            Console.WriteLine(points[11, 21]);
            Console.WriteLine(points[12, 22]);


            points[10, 20] = new Point(30, 40);
            points[11, 21] = new Point(31, 41);
            points[12, 22] = new Point(32, 42);

            Console.WriteLine("Acess with x, and y Multiple Dimensions Indexer After Changes ==>");
            Console.WriteLine(points[30, 40]);
            Console.WriteLine(points[31, 41]);
            Console.WriteLine(points[32, 42]);

        }


    }





    // --------------------------------------------------------------
    #endregion

    #region Understanding Operator Overloading
    // ------------------------ Understanding Operator Overloading -------------------------

    // C# Operator                       Is Overloaded
    // -------------------------------------------------------------------------------------------
    // +, -,! , ~, ++, --, true, false   Yes   These unary operators can be overloaded.
    // -------------------------------------------------------------------------------------------
    // +, -, *, /, %, &, |, ^, <<, >>    Yes   These binary operators can be overloaded.
    // -------------------------------------------------------------------------------------------
    // ==,!=, <, >, <=, >=               Yes   These comparison operators can be overloaded. C# demands that “like”
    //                                         operators(i.e., < and >, <= and >=, == and !=) are overloaded together.
    // -------------------------------------------------------------------------------------------
    // []                                No    The[] operator cannot be overloaded. As you saw earlier in this chapter,
    // -------------------------------------------------------------------------------------------
    // ()                                No    The () operator cannot be overloaded. As you will see later in this chapter,
    //                                          however, custom conversion methods provide the same functionality
    // -------------------------------------------------------------------------------------------
    // +=, -=, *=, /=, %=, &=, |=, ^=,          Shorthand assignment operators cannot be overloaded; however, you
    // <<=, >>=                          No    receive them as a freebie when you overload the related binary operator.
    // -------------------------------------------------------------------------------------------

    // Just a simple, everyday C# class.
    public class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2D(double xPos, double yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public override string ToString() => $"[{this.X}, {this.Y}]";

        public override bool Equals(object obj)
        {
            return this.ToString().Equals(obj?.ToString());
        }

        // binary operators +, -, *, /, %, &, |, ^, <<, >>
        // --------------------------------------------------------------
        public static Point2D operator +(Point2D p1, Point2D p2)
        {
            return new Point2D(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point2D operator -(Point2D p1, Point2D p2)
        {
            return new Point2D(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Point2D operator *(Point2D p1, Point2D p2)
        {
            return new Point2D(p1.X * p2.X, p1.Y * p2.Y);
        }

        public static Point2D operator /(Point2D p1, Point2D p2)
        {
            return new Point2D(p1.X / p2.X, p1.Y / p2.Y);
        }

        public static Point2D operator %(Point2D p1, Point2D p2)
        {
            return new Point2D(p1.X % p2.X, p1.Y % p2.Y);
        }

        public static Point2D operator +(Point2D p1, double scalar)
        {
            return new Point2D(p1.X + scalar, p1.Y + scalar);
        }

        public static Point2D operator -(Point2D p1, double scalar)
        {
            return new Point2D(p1.X - scalar, p1.Y - scalar);
        }

        public static Point2D operator *(Point2D p1, double scalar)
        {
            return new Point2D(p1.X * scalar, p1.Y * scalar);
        }

        public static Point2D operator /(Point2D p1, double scalar)
        {
            return new Point2D(p1.X / scalar, p1.Y / scalar);
        }

        public static Point2D operator %(Point2D p1, double scalar)
        {
            return new Point2D(p1.X % scalar, p1.Y % scalar);
        }


        // Unary Operator: +, -,! , ~, ++, --, true, false
        // --------------------------------------------------------------
        public static Point2D operator ++(Point2D p1)
        {
            return new Point2D(p1.X + 1, p1.Y + 1);
        }

        public static Point2D operator --(Point2D p1)
        {
            return new Point2D(p1.X - 1, p1.Y - 1);
        }

        public static Point2D operator +(Point2D p1)
        {
            return new Point2D(+p1.X, +p1.Y);
        }

        public static Point2D operator -(Point2D p1)
        {
            return new Point2D(-p1.X, -p1.Y);
        }

        // Equality Operators == and != must be overloaded together
        // --------------------------------------------------------------
        public static bool operator ==(Point2D p1, Point2D p2)
        {
            return p1.Equals(p2);
        }

        // == and != must be overloaded together
        public static bool operator !=(Point2D p1, Point2D p2)
        {
            return !p1.Equals(p2);
        }


        // comparison operators  <, >, <=, >=
        // --------------------------------------------------------------
        public static bool operator <(Point2D p1, Point2D p2)
        {
            return p1.X < p2.X && p1.Y < p2.Y;
        }


        public static bool operator <=(Point2D p1, Point2D p2)
        {
            return p1.X <= p2.X && p1.Y <= p2.Y;
        }

        public static bool operator >(Point2D p1, Point2D p2)
        {
            return p1.X > p2.X && p1.Y > p2.Y;
        }


        public static bool operator >=(Point2D p1, Point2D p2)
        {
            return p1.X >= p2.X && p1.Y >= p2.Y;
        }



    }

    class Bus
    {
        public BitArray Bits { get; }

        public Bus(BitArray bits)
        {
            Bits = (BitArray)bits.Clone();
        }

        public Bus() : this(8, false) { }

        public Bus(int width) : this(width, false) { }

        public Bus(int width, bool initValue)
        {
            Bits = new BitArray(width, initValue);
        }

        public static bool operator true(Bus b1)
        {
            foreach (bool item in b1.Bits)
            {
                if (item == false)
                    return false;
            }

            return true;
        }

        public static bool operator false(Bus b1)
        {
            foreach (bool item in b1.Bits)
            {
                if (item == true)
                    return true;
            }

            return false;
        }


        public static Bus operator &(Bus b1, Bus b2)
        {
            return new Bus(b1.Bits.And(b2.Bits));
        }

        public static Bus operator |(Bus b1, Bus b2)
        {
            return new Bus(b1.Bits.Or(b2.Bits));
        }

        public static Bus operator ^(Bus b1, Bus b2)
        {
            return new Bus(b1.Bits.Xor(b2.Bits));
        }




    }



    public class OperatorOverloading
    {
        // Test Method
        public static void Test()
        {
            Point2D p1 = new Point2D(10, 20);
            Point2D p2 = new Point2D(10, 20);
            Point2D p3 = new Point2D(30, 40);
            //Point2D p4 = new Point2D(30,40);

            Console.WriteLine("Operator Overloading Test".Padding(10));
            Console.WriteLine();
            Console.WriteLine("Points: ");
            Console.WriteLine("p1 = {0}", p1);
            Console.WriteLine("p2 = {0}", p2);
            Console.WriteLine("p3 = {0}", p3);
            Console.WriteLine();

            // Test Binary Operators
            Console.WriteLine("p1 + p2 = {0}", p1 + p2);
            Console.WriteLine("p1 - p2 = {0}", p1 - p2);
            Console.WriteLine("p1 * p2 = {0}", p1 * p2);
            Console.WriteLine("p1 / p2 = {0}", p1 / p2);
            Console.WriteLine("p1 % p2 = {0}", p1 % p2);

            // Test Binary Operators With Scalar
            Console.WriteLine("p1 + 10 = {0}", p1 + 10);
            Console.WriteLine("p1 - 10 = {0}", p1 - 10);
            Console.WriteLine("p1 * 10 = {0}", p1 * 10);
            Console.WriteLine("p1 / 10 = {0}", p1 / 10);
            Console.WriteLine("p1 % 10 = {0}", p1 % 10);

            // Test Equality Operators
            Console.WriteLine("p1 == p2 = {0}", p1 == p2);
            Console.WriteLine("p1 != p2 = {0}", p1 != p2);
            Console.WriteLine("p1 == p3 = {0}", p1 == p3);
            Console.WriteLine("p1 != p3 = {0}", p1 != p3);


            // Test Comparison Operators
            Console.WriteLine("p1 > p2 = {0}", p1 > p2);
            Console.WriteLine("p1 > p3 = {0}", p1 > p3);
            Console.WriteLine("p1 < p2 = {0}", p1 < p2);
            Console.WriteLine("p1 < p3 = {0}", p1 < p3);

            Console.WriteLine("p1 >= p2 = {0}", p1 >= p2);
            Console.WriteLine("p1 >= p3 = {0}", p1 >= p3);
            Console.WriteLine("p1 <= p2 = {0}", p1 <= p2);
            Console.WriteLine("p1 <= p3 = {0}", p1 <= p3);

            // Test Unary Operators
            Console.WriteLine();
            Console.WriteLine("p1 before p1++ = {0}", p1);
            Point2D p11 = p1++;
            Console.WriteLine("p1 after p1++  = {0}", p1);
            Console.WriteLine("p11 after p1++ = {0}", p11);


            Console.WriteLine();
            Console.WriteLine("p1 before p1-- = {0}", p1);
            p11 = p1--;
            Console.WriteLine("p1 after p1--  = {0}", p1);
            Console.WriteLine("p11 after p1-- = {0}", p11);

            Console.WriteLine();
            Console.WriteLine("p1 before ++p1 = {0}", p1);
            p11 = ++p1;
            Console.WriteLine("p1 after ++p1  = {0}", p1);
            Console.WriteLine("p11 after ++p1 = {0}", p11);

            Console.WriteLine();
            Console.WriteLine("p1 before --p1 = {0}", p1);
            p11 = --p1;
            Console.WriteLine("p1 after --p1  = {0}", p1);
            Console.WriteLine("p11 after --p1 = {0}", p11);

            Console.WriteLine();
            p2 = -p2;
            Console.WriteLine("p2 = - p2 then: p2 = {0} ", p2);

            Console.WriteLine();
            p2 = +p2; // do nothing !
            Console.WriteLine("p2 = + p2 then: p2 = {0} ", p2); // no Changes


            // bitwise work ...



        }


    }


    // --------------------------------------------------------------
    #endregion

    #region Understanding Custom Type Conversions
    // ------------------------ Understanding Custom Type Conversions -------------------------
    // Custom Type Conversions
    // Custom type conversion can be Explicit Conversion and implicit Conversion
    // - Implicit Conversion: is done without Casting Operator ()
    // - Explicit Conversion: is done by Casting Operator ()
    // Example: 
    //          int a = 123;
    //          long b = a; // Implicit conversion from int to long.
    //          int c = (int)b; // Explicit conversion from long to int.

    // Usage:
    // ------
    // 1- We can't directly make Reference types Conversions Except if they are in Parent Child Relation, 
    //    then, if two Reference types has no parent child relation, we can make use of Custom type conversion 
    //    to convert between them Implicitly or Explicitly
    // 
    // 2- Structures doesn't have hierarchy structures, so we can't inhert one from other, so if we want to 
    //    convert between structures we can Make a method to convert or make use of a Custom Type Conversions.
    //    Typically, this technique will be most helpful when you’re creating .NET structure types, given
    //    that they are unable to participate in classical inheritance(where casting comes for free)

    //  
    // C# provides two keywords, explicit and implicit, that you can use to control how your types respond 
    // during an attempted conversion. 

    // NOTE: 
    //  it is illegal to define explicit and implicit conversion functions on
    //  the same type if they do not differ by their return type or parameter set.
    //  This might seem like a limitation; however, 
    //  the second catch is that when a type defines an implicit conversion routine, 
    //  it is legal for the caller to make use of the explicit cast syntax!
    // 
    //  so in short, we can make use of implicit and explicit conversions if we define implicit conversion
    //  and if we define explicit conversion, we can't define implicit conversion, and we can't make use 
    //  of implicit conversion.





    public struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle(int w, int h) : this()
        {
            Width = w;
            Height = h;
        }

        public override string ToString() => $"Rectangle[Width = {Width}; Height = {Height}]";


        public static explicit operator Square(Rectangle rect)
        {
            return new Square() { Length = rect.Width };
        }

        public static implicit operator Rectangle(Square square)
        {
            return new Rectangle() { Width = square.Length, Height = square.Length };
        }
    }


    public struct Square
    {
        public int Length { get; set; }
        public Square(int l) : this()
        {
            Length = l;
        }

        public override string ToString() => $"Square[{Length}]";
    }


    // conversions with reference types
    // ------------------------------------------------------------------------

    class Person
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Person(): this(0,"Unknown")
        {

        }

        public Person(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public override string ToString()
        {
            return $"Person =  ID: {ID:04d} , Name: {Name}";
        }

        public override bool Equals(object obj)
        {
            return this.ToString().Equals(obj?.ToString());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        
    }


    class Patient: Person
    {
        public Patient(): this(0,"Unknown","Unknown")
        {
        }

        public Patient(int iD, string name) : base(iD, name)
        {
            this.Disease = "Unknown";
        }

        public Patient(int iD, string name, string disease) : base(iD, name)
        {
            this.Disease = disease;
        }

        public string Disease { get; set; }

        
        public override string ToString()
        {
            return base.ToString() + $" , Disease: {Disease}";
        }

        public override bool Equals(object obj)
        {
            return this.ToString().Equals(obj?.ToString());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static implicit operator Patient(Doctor doctor)
        {
            return new Patient(doctor.ID, doctor.Name);
        }

        
    }

    class Doctor : Person
    {
        public Doctor() : this(0, "Unknown", "Unknown")
        {
        }

        public Doctor(int iD, string name) : base(iD, name)
        {
            this.Specialization = "Unknown";
        }

        public Doctor(int iD, string name, string specialization) : base(iD, name)
        {
            this.Specialization = specialization;
        }

        public string Specialization { get; set; }


        public override string ToString()
        {
            return base.ToString() + $" , specialization: {Specialization}";
        }

        public override bool Equals(object obj)
        {
            return this.ToString().Equals(obj?.ToString());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static implicit operator Doctor(Patient patient)
        {
            return new Doctor(patient.ID, patient.Name);
        }
    }





    public class CustomTypeConversions
    {
        // Test Method
        public static void Test()
        {

            // conversions to Square
            // ---------------------------------------------
            Rectangle rect1 = new Rectangle(10,20);
            Console.WriteLine(rect1);

            Square square1 = (Square)rect1;
            Console.WriteLine(square1);

            // Note that we define conversionf from rectangle to square explicitly 
            // so we can't use implicit conversion
            //square1 = rect1; // Cannot implicitly convert type

            
            // conversions to rectangle
            // ---------------------------------------------
            Square square2 = new Square() { Length = 30 };
            Console.WriteLine(square2);

            // explicit and implicit conversions are accepted as 
            // we define implicit conversion when we convert from square to rectangle
            Rectangle rect2 = square2;
            Rectangle rect3 = (Rectangle) square2;
            Console.WriteLine(rect2);
            Console.WriteLine(rect3);


            // test passing rect and squares to Draw(Rectangle rect) method:
            Draw(new Rectangle() { Width = 5, Height = 10 });
            Draw(new Square() {  Length = 5 });


            // reference type conversions
            // ----------------------------------------------------------

            Doctor doctor = new Doctor();
            Patient patient = (Patient)doctor;
            patient = doctor;

            Patient patient2 = new Patient();
            Doctor doctor2 = (Doctor)patient2;
            doctor2 = patient2;



        }

        // we can pass squares and rectangles as we define implicit conversion to rectangle
        public static void Draw(Rectangle rect)
        {
            Console.WriteLine($"Draw(Rectangle rect) Method: {rect}");

            for (int i = 0; i < rect.Width; i++)
            {
                Console.WriteLine("".PadLeft(rect.Height,'*').Replace("*"," * "));
            }
        }


    }

    // --------------------------------------------------------------
    #endregion

    class OperatorOverloadingTraining
    {
        public static void Test()
        {
            IndexerMethods.Test();
            OperatorOverloading.Test();
            CustomTypeConversions.Test();
        }

    }
}
