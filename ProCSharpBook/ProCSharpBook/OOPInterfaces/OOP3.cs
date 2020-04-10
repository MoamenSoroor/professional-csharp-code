using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ===========================================================================================================
// Object-Oriented Programming with C#
// ===========================================================================================================
// CHAPTER 8: Working with Interfaces
// ===========================================================================================================
namespace ProCSharpBook.OOPInterfaces
{

    // ==============================> Understanding Interface Types <==============================
    // =============================================================================================
    // - An interface is nothing more than a named set of abstract members.
    // - An interface expresses a behavior that a given class or structure may choose to support.
    // - A class or structure can support as many interfaces as necessary, thereby supporting
    // (in essence) multiple behaviors.
    // 
    // Note:  By convention, .net interfaces are prefixed with a capital letter I. When you are creating your own
    //        custom interfaces, it is considered a best practice to do the same.

    // An interface can be a member of a namespace or a class and can contain signatures of the following members:
    // 1- Methods
    // 2- Properties
    // 3- Indexers
    // 4- Events

    // - interfaces may inherit any number of other intefaces
    // - classes always inherits one base class and can't inherits more than on class (Single Inheritance),
    //   but classes may inherit any number of interfaces with only one base class (implicity are Object).
    // - classes if not explicitly inherits a class, it is implicitly inherits Object class.
    // - you should set class before interfaces in subclass definition.
    // ==================================================================================================

    // ==============================> Defining Custom Interfaces <==============================

    #region Defining Interfaces 0
    interface Interface0
    {

    }

    class MyClass0 : Interface0
    {

    }

    class TestInterfaces0
    {
        public static void Test()
        {
            Interface0 inter0 = new MyClass0();
            Console.WriteLine($"inter0.GetType() : {inter0.GetType()}");
            Console.WriteLine($"inter0.ToString() : {inter0.ToString()}");

        }

    }


    #endregion

    #region Defining Interfaces 1

    // Can have only Constants and public abstract methods and properties
    // methods in interfaces is Implicity public abstract , so you don't need to 
    // write public abstract
    interface Interface1
    {
        // it can't have static and const members or have default implementation
        // default implementation will be available in c#8

        int Prop { get; set; }

        // Readonly Property in sight of the outside world but we can implement setter in the Implementation
        int ReadOnlyProp { get; }
        int ReadOnlyProp2 { get; }
        int ReadOnlyProp3 { get; }
        int ReadOnlyProp4 { get; }

        // Writeonly Property in sight of the outside world but we can implement getter in the Implementation
        int WriteOnlyProp { set; }
        int WriteOnlyProp2 { set; }
        int WriteOnlyProp3 { set; }
        int WriteOnlyProp4 { set; }

        // Error can't define private/private protected/internal/protected/internal protected accessors or actuators in interfaces but we can make that in the implementation.
        //public int PrivateWriteProp { get; private set; }
        //public int PrivateReadProp { private get; set; }

        // by default all methods and properties, are public abstract
        void AbsMethod();

        // by default all methods and properties, are public abstract
        void AbsMethod2();



    }

    class MyClass1 : Interface1
    {
        private int myValue;

        public int Prop { get; set; }

        // we can omit setter or we can make it public, private , protected, ...etc
        public int ReadOnlyProp { get; }
        public int ReadOnlyProp2 { get; set; }
        public int ReadOnlyProp3 { get; private set; }
        public int ReadOnlyProp4 { get; protected set; }


        // we can omit getter or we can make it public, private , protected, ...etc
        public int WriteOnlyProp { set => myValue = value; }
        public int WriteOnlyProp2 { get => myValue; set => myValue = value; }
        public int WriteOnlyProp3 { private get => myValue; set => myValue = value; }
        public int WriteOnlyProp4 { protected get => myValue; set => myValue = value; }

        public void AbsMethod()
        {
            Console.WriteLine("AbsMethod");
        }

        public void AbsMethod2()
        {
            Console.WriteLine("AbsMethod");
        }
    }

    // another class implements Interface1 interface
    class MyClass2 : Interface1
    {
        private int myValue;

        public int Prop { get; set; }

        // we can omit setter or we can make it public, private , protected, ...etc
        public int ReadOnlyProp { get; }
        public int ReadOnlyProp2 { get; set; }
        public int ReadOnlyProp3 { get; private set; }
        public int ReadOnlyProp4 { get; protected set; }


        // we can omit getter or we can make it public, private , protected, ...etc
        public int WriteOnlyProp { set => myValue = value; }
        public int WriteOnlyProp2 { get => myValue; set => myValue = value; }
        public int WriteOnlyProp3 { private get => myValue; set => myValue = value; }
        public int WriteOnlyProp4 { protected get => myValue; set => myValue = value; }

        public void AbsMethod()
        {
            Console.WriteLine("AbsMethod");
        }

        public void AbsMethod2()
        {
            Console.WriteLine("AbsMethod");
        }
    }

    class TestInterfaces1
    {
        public static void Test()
        {
            Interface1 inter1 = new MyClass1();
            inter1.AbsMethod();
            inter1.AbsMethod2();
            Console.WriteLine($"inter1.ReadOnlyProp: {inter1.ReadOnlyProp}");
            Console.WriteLine($"inter1.ReadOnlyProp: {inter1.Prop}");


        }

    }


    #endregion


    #region Build Hierarchy of interfaces and classes
    // - interfaces may inherit any number of other intefaces
    // - classes always inherits one base class and can't inherits more than on class (Single Inheritance),
    //   but classes may inherit any number of interfaces with only one base class (implicity are Object).
    // - classes if not explicitly inherits a class, it is implicitly inherits Object class.
    // - you should set class before interfaces in subclass definition.
    interface Interface21
    {
        // Abstract Members of Interface21
        void AbsMethod21();
    }

    interface Interface22
    {
        // Abstract Members of Interface22
        void AbsMethod22();
    }

    interface Interface23 : Interface21, Interface22
    {
        // Abstract Members of Interface21,Interface22, and Interface23
        void AbsMethod23();
    }


    class MyClass21
    {
        // Members of MyClass21
        public void Method21()
        {
            Console.WriteLine("MyClass21 Method");
        }
    }

    class MyClass22 : MyClass21, Interface21
    {
        public void AbsMethod21()
        {
            Console.WriteLine("Interface21 AbsMethod21 in MyClass22 implementation");
        }
    }

    class MyClass23 : MyClass21, Interface21, Interface22 // ,...etc of interfaces
    {
        public void AbsMethod21()
        {
            Console.WriteLine("Interface21 AbsMethod21 in MyClass22 implementation");
        }

        public void AbsMethod22()
        {
            Console.WriteLine("Interface22 AbsMethod22 in MyClass23 implementation");
        }
    }



    class TestInterfaces2
    {
        public static void Test()
        {
            Interface21 inter1 = new MyClass22();
            inter1.AbsMethod21();

            MyClass21 myclass1 = new MyClass22();
            myclass1.Method21();

            MyClass21 myclass2 = new MyClass23();
            myclass2.Method21();

            Interface21 inter2 = new MyClass23();
            inter2.AbsMethod21();

            Interface22 inter3 = new MyClass23();
            inter3.AbsMethod22();
        }

    }


    #endregion


    #region Abstract Classes and Interfaces
    // abstract classes:  
    // -----------------
    // - With regard to it's Use Cases:
    //      - when you want to make a hierarchy of classes all must inherits common members.
    // - With regard to it's Definition:
    //      - can't make instance of it.
    //      - may have abstract and implemented members.
    //      - may have const and static members.
    //
    // - with regard to Derived Types:
    //      - drived types can extends only one abstract class, if you want more use interfaces and Delegation Models
    //      - 

    // interfaces:
    // ------------
    // - With regard to it's Use Cases:
    //      - when you want to add a feature to a specefic Types of a hierarchy. or add feature to different hierarchies
    // - With regard to it's Definition:
    //      - can't make instance of it
    //      - may have abtract members but it can't have any implemented member [may be in the future default implementation]
    //      - can't have const and static members [may be in the future]
    // - with regard to Derived Types:
    //      - drived types can implements any number of interfaces. [Interface Driven Programming]
    //      - 


    interface Interface3
    {
        void AbsMethod3();
    }

    abstract class AbsClass31
    {
        public abstract void AbsMethod31();
    }

    class MyClass31 : AbsClass31, Interface3
    {
        // method of interface
        public void AbsMethod3()
        {
            Console.WriteLine("AbsMethod3 method Implementation of Interface3 in MyClass31");
        }

        // method of abstract class
        public override void AbsMethod31()
        {
            Console.WriteLine("AbsMethod3 method Implementation of Interface3 in MyClass31");
        }
    }

    class TestInterfaces3
    {
        public static void Test()
        {
            AbsClass31 absclass1 = new MyClass31();
            absclass1.AbsMethod31();

            Interface3 inter3 = new MyClass31();
            inter3.AbsMethod3();


        }

    }


    #endregion


    #region Interfaces Casting Rules, as, and is Keywords
    interface Interface4
    {
        void Method42();
    }

    class MyClass4
    {
        public void Method4()
        {
            Console.WriteLine("MyClass4 Method4 implementation");
        }
    }

    class MyClass42 : MyClass4, Interface4
    {
        public void Method42()
        {
            Console.WriteLine("Interface4 Method4 implementation");
        }
    }

    class MyClass43 : MyClass4
    {
        public void Method43()
        {
            Console.WriteLine("MyClass43 Method43 implementation");
        }
    }

    class TestInterfaces4
    {
        public static void Test()
        {
            MyClass42 myclass1 = new MyClass42();

            // ==============================> Casting with Casting Operator <==============================
            try
            {
                // cast to interface with normal implicit casting, or Casting Operator if not possible 
                // [ Note it may throws InvalidCastException ]

                Interface4 inter1 = myclass1;
                inter1.Method42();
            }
            catch (InvalidCastException exp)
            {
                Console.WriteLine(exp.Message);
            }

            // ==============================> Casting with as Operator <==============================

            Interface4 inter2 = myclass1 as Interface4;
            if (inter2 == null)
                Console.WriteLine("NULL Reference, InvalidCast! ");
            else
                inter2.Method42();

            // ==============================> Casting with is Operator <==============================
            if (myclass1 is Interface4)
                ((Interface4)myclass1).Method42(); // short notation if you don't need reference

            if (myclass1 is Interface4)
            {
                Interface4 inter3 = (Interface4)myclass1;
                inter3.Method42(); // short notation
            }
            else
                Console.WriteLine("NULL Reference, InvalidCast with is Operator ");

            // Using is Operator with Casted Reference assignment [new feature in C# 7 ]
            if (myclass1 is Interface4 inter4)
            {
                inter4.Method42(); // short notation
            }
            else
                Console.WriteLine("NULL Reference, InvalidCast with is Operator ");

        }

    }


    #endregion


    #region Interface as a Parameter, Return Type, and Array of Interface Type
    interface IPrintable
    {
        void Print();
    }

    abstract class Employee : IPrintable
    {
        public string SSN { get; set; }
        public string Name { get; set; }
        public float Salary { get; set; }

        protected Employee() : this("0000", "Emp", 1000.0F)
        {

        }

        protected Employee(string sSN, string name, float salary)
        {
            SSN = sSN;
            Name = name;
            Salary = salary;
        }

        public virtual void Print()
        {
            Console.WriteLine("================ Basic Info ================");
            Console.WriteLine($"SSN   : {SSN}");
            Console.WriteLine($"Name  : {Name}");
            Console.WriteLine($"Salary: {Salary}");

        }
    }

    class Manager : Employee
    {
        public Manager(string department)
        {
            Department = department;
        }

        public Manager(string sSN, string name, float salary, string department) : base(sSN, name, salary)
        {
            Department = department;
        }



        public string Department { get; set; }
        public override void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Manager Info:");
            Console.WriteLine("===========================================");
            base.Print();
            Console.WriteLine("================ Specific Info ================");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine();
        }
    }

    class SalesPerson : Employee
    {
        public SalesPerson(string city)
        {
            City = city;
        }

        public SalesPerson(string sSN, string name, float salary, string city) : base(sSN, name, salary)
        {
            City = city;
        }

        public string City { get; set; }
        public override void Print()
        {
            Console.WriteLine();
            Console.WriteLine("SalesPerson Info:");
            Console.WriteLine("===========================================");
            base.Print();
            Console.WriteLine("================ Specific Info ================");
            Console.WriteLine($"City: {City}");
            Console.WriteLine();
        }
    }

    class Worker : Employee
    {

        public Worker(int workHours) : base()
        {
            WorkHours = workHours;
        }

        public Worker(string sSN, string name, float salary, int workHours) : base(sSN, name, salary)
        {
            WorkHours = workHours;
        }

        public int WorkHours { get; set; }
        public override void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Worker Info:");
            Console.WriteLine("===========================================");
            base.Print();
            Console.WriteLine("================ Specific Info ================");
            Console.WriteLine($"WorkHours: {WorkHours}");
            Console.WriteLine();
        }
    }

    class TestInterfaces5
    {
        public static void Test()
        {
            Employee emp1 = new Manager("1111", "Moamen", 5000.0F, "Software Engineering");
            Employee emp2 = new SalesPerson("2222", "Mohammed", 4000.0F, "Port Said");
            Employee emp3 = new Worker("3333", "Gamal", 3000.0F, 12);

            // interface as an argument
            printEmp(emp1);
            printEmp(emp2);
            printEmp(emp3);

            // interface as an array
            IPrintable[] printableArray = { new Manager("Software"), new SalesPerson("Sers"), new Worker(10) };
            foreach (IPrintable item in printableArray)
            {
                item.Print();
            }

            // interface as return type
            IPrintable print1 = UpdateSalary(emp1);
            IPrintable print2 = UpdateSalary(emp2);
            IPrintable print3 = UpdateSalary(emp3);

            print1.Print();
            print2.Print();
            print3.Print();
        }

        // interface as a Parameter
        private static void printEmp(IPrintable printable)
        {
            printable.Print();
        }


        // interface as return type
        public static IPrintable UpdateSalary(Employee emp)
        {
            emp.Salary += 200;
            return emp;
        }
    }


    #endregion


    #region Explicit Interface Implementation

    // ==============================> Explicit Interface <==============================
    // - Explicit Interface implementation, allow you to define a method for each interface if there are
    //   a name conflicts. but it doesn't allow to use methods with implementaion Type, and you should cast type
    //   to a specific interface to be able to use explicit methods of it.

    // - if you didn't use explicit interface, you should implement one method that is 
    //   considered for the trhee interfaces.

    interface IFilePrintable
    {
        void Print();
    }

    interface IDataPrintable
    {
        void Print();
    }

    interface IConsolePrintable
    {
        void Print();
    }

    class Person0 : IFilePrintable, IDataPrintable, IConsolePrintable
    {
        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime BirthDate { get; set; }

        public Person0() : this(100, "FName", "LName", new DateTime(1995, 1, 22)) { }

        public Person0(int iD, string fname, string lname, DateTime birthDate)
        {
            ID = iD;
            Fname = fname;
            Lname = lname;
            BirthDate = birthDate;
        }

        // one method implementation for all the three interfaces.
        public void Print()
        {
            Console.WriteLine("Print Method that are for the 3 interfaces");
        }
    }

    class Person : IFilePrintable, IDataPrintable, IConsolePrintable
    {
        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime BirthDate { get; set; }

        public Person() : this(100, "FName", "LName", new DateTime(1995, 1, 22)) { }

        public Person(int iD, string fname, string lname, DateTime birthDate)
        {
            ID = iD;
            Fname = fname;
            Lname = lname;
            BirthDate = birthDate;
        }


        void IConsolePrintable.Print()
        {
            Console.WriteLine("Write to Console");
        }

        void IDataPrintable.Print()
        {
            Console.WriteLine("Write to Database");
        }

        void IFilePrintable.Print()
        {
            Console.WriteLine("Write to File");
        }

        



    }

    class TestInterfaces6
    {
        public static void Test()
        {

            // ====================> Without Explicit Interface Implementation <======================

            Console.WriteLine("------ Without Using Explicit Interface Implementation ------");

            Person0 p1 = new Person0();
            p1.Print();

            IConsolePrintable cpr = p1;
            IFilePrintable fpr = p1;
            IDataPrintable dpr = p1;
            cpr.Print();
            fpr.Print();
            dpr.Print();


            // ====================> Using Explicit Interface Implementation <======================
            Console.WriteLine("------ Using Explicit Interface Implementation ------");


            Person p2 = new Person();

            // Error, we can't use explicit implementation without casting to the Interface type
            // p2.Print();

            IConsolePrintable cpr2 = p2;
            IFilePrintable fpr2 = p2;
            IDataPrintable dpr2 = p2;
            cpr2.Print();
            fpr2.Print();
            dpr2.Print();


        }

    }

    #endregion

    // ==============================> Discover some .NET Interfaces <==============================

    #region ICloneable Interface
    // namespace System
    //{
    //    //
    //    // Summary:
    //    //     Supports cloning, which creates a new instance of a class with the same value
    //    //     as an existing instance.
    //    public interface ICloneable
    //    {
    //        //
    //        // Summary:
    //        //     Creates a new object that is a copy of the current instance.
    //        //
    //        // Returns:
    //        //     A new object that is a copy of this instance.
    //        object Clone();
    //    }
    //}

    class Point : ICloneable
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point() : this(0.0F, 0.0F) { }
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public void PrintPoint()
        {
            Console.WriteLine($"Point [ X = {X}; Y = {Y} ]");
        }



        public object Clone()
        {
            return new Point(X, Y);
        }
    }

    class TestInterfaces7
    {
        public static void Test()
        {
            Point p1 = new Point(10, 20);

            Point p2 = p1;

            Point p3 = (Point)p1.Clone();

            Console.WriteLine("Print p1:");
            p1.PrintPoint();

            p3.X = 40;
            p3.Y = 50;

            Console.WriteLine("After Change Cloned ref p3 states, Print p1 then p3:");
            p1.PrintPoint();
            p3.PrintPoint();


            p2.X = 40;
            p2.Y = 50;

            Console.WriteLine("After Change ref p2 states, Print p1 then p2:");
            p1.PrintPoint();
            p2.PrintPoint();

        }

    }


    // ==============================> The object.MemberWiseClone() Method  <==============================
    // Creates a shallow copy of the current object
    // Shallow Copy means that it copy value types , and copy reference of reference value
    // if you want to make deep copy you should manually copy values of reference types.
    // 
    // 
    // update Clone Method to use in it object.MemberwiseClone()
    class Point2 : Point
    {
        public Point2()
        {
        }

        public Point2(float x, float y) : base(x, y)
        {

        }

        public new object Clone()
        {
            // create shallow copy
            return this.MemberwiseClone();
        }

    }


    // ==============================> shallow copy when there are References <==============================

    class CoordinateInfo : ICloneable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CoordinateInfo() : this("Custom Coordinate Name", "Custom Coordinate Description") { }
        public CoordinateInfo(string name) : this(name, "Custom Coordinate Description") { }

        public CoordinateInfo(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $@"CoordinateInfo
        {{
            Name: {Name};
            Description: {Description};
        }}";

        }

        public object Clone()
        {
            return new CoordinateInfo((string)Name.Clone(), (string)Description.Clone());
        }
    }

    class PointInfo : ICloneable
    {

        // ------------------------ Constructors -------------------------
        #region Constructors

        public PointInfo(int iD, string name, string description, CoordinateInfo coordinateInfo)
        {
            ID = iD;
            Name = name;
            Description = description;
            CoordinateInfo = coordinateInfo;
        }

        public PointInfo(int iD, string name, string description)
            : this(iD, name, description, new CoordinateInfo()) { }

        public PointInfo()
            : this(111, "Custom Point Info", "Custom Point Description", new CoordinateInfo()) { }

        // --------------------- End of Constructors ---------------------
        #endregion

        // ------------------------ Properties -------------------------
        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CoordinateInfo CoordinateInfo { get; set; }

        // --------------------- End of Properties ---------------------
        #endregion

        // ------------------------ Methods -------------------------
        #region Methods
        public override string ToString()
        {
            return $@"PointInfo
    {{
        ID: {ID};
        Name: {Name};
        Description: {Description};
        {CoordinateInfo}
        
    }}";
        }

        public object Clone()
        {
            return new PointInfo(ID, (string)Name.Clone(), (string)Description.Clone(), (CoordinateInfo)CoordinateInfo.Clone());
        }

        // --------------------- End of Methods ---------------------
        #endregion


    }

    // ----------------------- Shallow Copy using protected Method MemberwiseClone() -----------------------
    class Point3 : Point
    {
        public PointInfo PointInfo { get; set; }
        public Point3()
        {
            PointInfo = new PointInfo();
        }

        public Point3(float x, float y) : base(x, y)
        {
            PointInfo = new PointInfo();
        }

        public Point3(float x, float y, PointInfo pointInfo) : base(x, y)
        {
            PointInfo = pointInfo;
        }

        public Point3(PointInfo pointInfo)
        {
            PointInfo = pointInfo;
        }

        public new object Clone()
        {
            // create shallow copy
            return this.MemberwiseClone();
        }


        public override string ToString()
        {
            return $@"Point
{{
    X = {X};
    Y = {Y};
    {PointInfo}
}}
";

        }
    }

    // ----------------------- Deep Copy using Clone() using nested Clone() -----------------------
    class Point4 : Point3
    {
        public Point4() { }

        public Point4(PointInfo pointInfo) : base(pointInfo) { }

        public Point4(float x, float y) : base(x, y) { }

        public Point4(float x, float y, PointInfo pointInfo) : base(x, y, pointInfo) { }


        // Deep Copy
        public new object Clone()
        {
            // create Deep copy
            Point4 newPoint = (Point4)this.MemberwiseClone();
            newPoint.PointInfo = (PointInfo)this.PointInfo.Clone();
            newPoint.PointInfo.CoordinateInfo = (CoordinateInfo)this.PointInfo.CoordinateInfo.Clone();


            return newPoint;
        }
    }

    // ----------------------- Deep Copy using Clone() without using nested Clone() -----------------------
    class Point5 : Point4
    {
        public Point5() { }

        public Point5(PointInfo pointInfo) : base(pointInfo) { }

        public Point5(float x, float y) : base(x, y) { }

        public Point5(float x, float y, PointInfo pointInfo) : base(x, y, pointInfo) { }


        // Deep Copy without using Clone of type memebers.
        public new object Clone()
        {
            // create Deep Copy without using Clone of type memebers.
            Point4 newPoint = (Point4)this.MemberwiseClone();
            newPoint.PointInfo = new PointInfo
            {
                ID = this.PointInfo.ID,
                Name = this.PointInfo.Name,
                Description = this.PointInfo.Description,
                CoordinateInfo = new CoordinateInfo
                {
                    Name = this.PointInfo.CoordinateInfo.Name,
                    Description = this.PointInfo.CoordinateInfo.Description
                }

            };


            return newPoint;
        }
    }

    class TestInterfaces8
    {
        public static void Test()
        {
            Point4 p1 = new Point4(10, 20)
            {

                PointInfo = new PointInfo(111, "My Pointy", "this is my lovely Pointy.")
                {
                    CoordinateInfo = new CoordinateInfo("My Cool Coord System", "this is my cool coordinate System.")
                }
            };


            // ==============================> Copy By Reference <==============================
            Console.WriteLine("========= Copy By Reference =========");
            Point4 p2 = p1;

            Console.WriteLine($"-> Point1 Data: {p1}");

            Console.WriteLine($"-> Point2 Data: {p2}");

            Console.WriteLine("=================================================");


            p2.PointInfo.CoordinateInfo = new CoordinateInfo("new Cool Coord System", "new Coord describe.");

            Console.WriteLine($"-> Point1 Data: {p1}");

            Console.WriteLine($"-> Point2 Data: {p2}");


            // ==============================> Deep Copy with Clone() Method <==============================
            Console.WriteLine("========= Deep Copy with Clone() Method =========");

            p2 = (Point4)p1.Clone();

            Console.WriteLine($"-> Point1 Data: {p1}");

            Console.WriteLine($"-> Point2 Data: {p2}");

            Console.WriteLine("=================================================");


            p2.PointInfo.CoordinateInfo = new CoordinateInfo("Very new Cool Coord System", "Very new Coord describe.");

            Console.WriteLine($"-> Point1 Data: {p1}");

            Console.WriteLine($"-> Point2 Data: {p2}");


        }

    }

    #endregion


    #region The IComparable and The IComparer Interface
    // -------------------------------------------------------------------------------------
    // The IComparable Interface
    // -------------------------------------------------------------------------------------
    // The System.IComparable interface specifies a behavior that allows an object to be sorted based on some
    // specified key.Here is the formal definition:
    // // This interface allows an object to specify its
    // // relationship between other like objects.
    // -----------------------------------------------------------------------------------------------------
    // public interface IComparable
    //    {
    //        int CompareTo(object o);
    //    }
    // -----------------------------------------------------------------------------------------------------
    // 
    // -----------------------------------------------------------------------------------------------------
    // Table CompareTo() Return Values
    // -----------------------------------------------------------------------------------------------------
    // CompareTo() Return Value          Description
    // -----------------------------------------------------------------------------------------------------
    // Any number less than zero         This instance comes before the specified object in the sort order.
    // Zero                              This instance is equal to the specified object.
    // Any number greater than zero      This instance comes after the specified object in the sort order.
    // -----------------------------------------------------------------------------------------------------

    public class Car : IComparable
    {

        // ------- Sorting using strongly associated property ---------
        public static IComparer NameComparer
        {
            get { return (IComparer)new CarNameComparer(); }
        }

        public static IComparer SpeedComparer
        {
            get { return (IComparer)new CarSpeedComparer(); }
        }

        public static IComparer SpeedComparer2 { get; } = new CarSpeedComparer();


        public string PetName { get; set; }
        public int Speed { get; set; }

        public Car() : this("Custom Pet Name", 20) { }

        public Car(string petName, int speed)
        {
            PetName = petName;
            Speed = speed;
        }

        public override string ToString()
        {
            return $"Car {{ PetName: {PetName}; Speed: {Speed} }}";
        }

        // method of IComparable Interface
        // Comparison depends on speed
        public int CompareTo(object obj)
        {
            //return Speed.CompareTo(obj);
            Car aCar = obj as Car;
            if (aCar != null)
            {
                return this.Speed > aCar.Speed ? 1 : this.Speed == aCar.Speed ? 0 : -1;
            }
            else
                throw new ArgumentException("Parameter is not a Car!");
        }


        public class CarNameComparer : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                Car car1 = obj1 as Car;
                Car car2 = obj2 as Car;

                if (car1 != null && car2 != null)
                {
                    return string.Compare(car1.PetName, car2.PetName);
                    //return car1.PetName.CompareTo(car2.PetName);
                }
                else
                    throw new ArgumentException("Parameter is not a Car!");

            }
        }

        public class CarSpeedComparer : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                Car car1 = obj1 as Car;
                Car car2 = obj2 as Car;

                if (car1 != null && car2 != null)
                {
                    return car1.Speed.CompareTo(car2.Speed);
                }
                else
                    throw new ArgumentException("Parameter is not a Car!");

            }
        }

    }

    class TestInterfaces9
    {
        public static void Test()
        {

            Car[] carArray = new Car[4];
            carArray[0] = new Car("Hondai", 100);
            carArray[1] = new Car("Nissan", 50);
            carArray[2] = new Car("Toyota", 70);
            carArray[3] = new Car("Chevrolet", 10);

            foreach (var item in carArray)
            {
                Console.WriteLine(item);
            }


            Array.Sort(carArray);

            Console.WriteLine();
            Console.WriteLine("After Sorting array with the Iplementation of IComparable Interface");
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var item in carArray)
            {
                Console.WriteLine(item);
            }



            // ----------------------- Sorting Depends on IComparer Interface -----------------------
            carArray[0] = new Car("Hondai", 100);
            carArray[1] = new Car("Nissan", 50);
            carArray[2] = new Car("Toyota", 70);
            carArray[3] = new Car("Chevrolet", 10);

            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in carArray)
            {
                Console.WriteLine(item);
            }


            Array.Sort(carArray, new Car.CarSpeedComparer());

            Console.WriteLine();
            Console.WriteLine("After Sorting Array with Speed using IComparer Interface");
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var item in carArray)
            {
                Console.WriteLine(item);
            }


            Array.Sort(carArray, new Car.CarNameComparer());

            Console.WriteLine();
            Console.WriteLine("After Sorting Array with PetName using IComparer Interface");
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var item in carArray)
            {
                Console.WriteLine(item);
            }


            // ----------------------- Sorting using strongly associated property -----------------------
            carArray[0] = new Car("Hondai", 100);
            carArray[1] = new Car("Nissan", 50);
            carArray[2] = new Car("Toyota", 70);
            carArray[3] = new Car("Chevrolet", 10);

            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in carArray)
            {
                Console.WriteLine(item);
            }

            Array.Sort(carArray, Car.SpeedComparer);

            Console.WriteLine();
            Console.WriteLine("After Sorting Array with Speed using IComparer Interface");
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var item in carArray)
            {
                Console.WriteLine(item);
            }


            Array.Sort(carArray, Car.NameComparer);

            Console.WriteLine();
            Console.WriteLine("After Sorting Array with PetName using IComparer Interface");
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var item in carArray)
            {
                Console.WriteLine(item);
            }



        }

    }


    #endregion


    #region The IEnumerable and IEnumerator Interfaces
    // -------------------------------------------------------------------------------------
    // The IEnumerable and IEnumerator Interfaces
    // -------------------------------------------------------------------------------------

    // This interface informs the caller
    // that the object's items can be enumerated.
    // -------------------------------------------------------------------------------------
    // public interface IEnumerable
    // {
    //     IEnumerator GetEnumerator();
    // }
    // -------------------------------------------------------------------------------------


    // This interface allows the caller to
    // obtain a container's items.
    // -------------------------------------------------------------------------------------
    // public interface IEnumerator
    // {
    //     bool MoveNext(); // Advance the internal position of the cursor.
    //     object Current { get; } // Get the current item (read-only property).
    //     void Reset(); // Reset the cursor before the first member.
    // }
    // -------------------------------------------------------------------------------------

    class GarageEnumerator : IEnumerator
    {
        private Garage garage;

        private int counter = -1;

        public GarageEnumerator(Garage garage)
        {
            this.garage = garage;
        }

        public object Current { get => garage.CarArray[counter]; }

        public bool MoveNext()
        {
            counter++;

            return (counter < garage.CarArray.Length);
        }

        public void Reset()
        {
            counter = -1;
        }
    }


    // Garage contains a set of Car objects.
    public class Garage : IEnumerable
    {
        protected Car[] carArray = new Car[4];
        // Fill with some Car objects upon startup.

        public Car[] CarArray { get => carArray; }
        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GarageEnumerator(this);

        }
    }

    // another implementation of GetEnumerator()


    public class Garage2 : Garage, IEnumerable
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return carArray.GetEnumerator();

        }
    }

    // ==============================> yield Contextual Keyword <==============================
    public class Garage3 : Garage, IEnumerable
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var car in CarArray)
            {
                yield return car;
            }

        }
    }

    public class Garage4 : Garage, IEnumerable
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            // this code executed when MoveNext() Method is Called not when GetEnumerator Method is called
            yield return CarArray[0];
            yield return CarArray[1];
            yield return CarArray[2];
            yield return CarArray[3];

        }
    }

    class TestInterfaces10
    {
        public static void Test()
        {
            Console.WriteLine("***** Fun with IEnumerable / IEnumerator *****\n");
            Garage carLot = new Garage();
            // Hand over each car in the collection?
            foreach (Car c in carLot)
            {
                Console.WriteLine("{0} is going {1} MPH",
                c.PetName, c.Speed);
            }

            // ----------------------------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("***** Fun with IEnumerable / IEnumerator yield contextual keyword *****\n");
            Garage3 carLot3 = new Garage3();
            // Hand over each car in the collection?
            foreach (Car c in carLot3)
            {
                Console.WriteLine("{0} is going {1} MPH",
                c.PetName, c.Speed);
            }

            // ----------------------------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("***** Fun with IEnumerable / IEnumerator yield contextual keyword *****\n");
            Garage4 carLot4 = new Garage4();
            // Hand over each car in the collection?
            foreach (Car c in carLot4)
            {
                Console.WriteLine("{0} is going {1} MPH",
                c.PetName, c.Speed);
            }


        }

    }


    #endregion

    #region yield Contextual Keyword, with IEnumerable and IEnumerator
    // "The yield keyword signals to the compiler that the method in which it appears is an iterator block. 
    // The compiler generates a class to implement the behavior that is expressed in the iterator block. 
    // In the iterator block, the yield keyword is used together with the return keyword to provide a value 
    // to the enumerator object. This is the value that is returned, for example, in each loop of a foreach statement. 
    // The yield keyword is also used with break to signal the end of iteration."
    class Sequence
    {

        public int Start { get; }
        public int Counter { get; set; }

        public int Max { get; set; }

        public int Step { get; set; }

        public Sequence(int start, int max, int step)
        {
            Start = start;
            Counter = start;
            Max = max;
            Step = step;
        }

        public Sequence() : this(0, 1000, 1) { }

        public void Reset()
        {
            Counter = Start;
        }



        public IEnumerator GetEnumerator()
        {
            Console.WriteLine("Code In Enumerator Method");
            for (; Counter < Max; Counter+=Step)
            {
                Console.WriteLine("One Yield Retrun Execution");
                yield return Counter;

            }

            Console.WriteLine("End of Enumerator");

        }

    }


    class TestInterfaces11
    {
        public static void Test()
        {
            Sequence seq = new Sequence(0,15,2);

            Console.WriteLine("========== Enumerator Execution with MoveNext() and Current Property =============");
            IEnumerator en = seq.GetEnumerator();
            Console.WriteLine("After GetEnumerator() Call");

            while(en.MoveNext())
                Console.WriteLine("Current = " + en.Current);

            seq.Reset();
            Console.WriteLine("========== Another Approach with foreach =============");
            foreach (var item in seq)
            {
                Console.WriteLine($"next: {item}");
            }


        }

    }


    #endregion





    // ==============================> The Whole Training Call <==============================

    class OOPTraining
    {
        public static void TestOOP()
        {
            //TestInterfaces0.Test();
            //TestInterfaces1.Test();
            //TestInterfaces2.Test();
            //TestInterfaces3.Test();
            //TestInterfaces4.Test();
            //TestInterfaces5.Test();
            //TestInterfaces6.Test();
            //TestInterfaces7.Test();
            //TestInterfaces8.Test();
            //TestInterfaces9.Test();
            //TestInterfaces10.Test();
            TestInterfaces11.Test();
        }

    }


}