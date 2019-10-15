using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ===========================================================================================================
// Object-Oriented Programming with C#
// ===========================================================================================================
// CHAPTER 8: Working with Interfaces
// ===========================================================================================================
namespace CSharpBookTraining.OOP_Part3
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

        public int Prop { get; set; }
        public int ReadOnlyProp { get; }
        public int WriteOnlyProp { set; }

        // Error can't define private/private protected/internal/protected/internal protected accessors or actuators
        //public int PrivateWriteProp { get; private set; }
        //public int PrivateReadProp { private get; set; }

        // by default all methods and properties, are public abstract
        void AbsMethod();

        // by default all methods and properties, are public abstract
        public abstract void AbsMethod2();



    }

    class MyClass1 : Interface1
    {
        private int writeonlyVar;

        public int Prop { get; set; }

        public int ReadOnlyProp { get; }

        public int WriteOnlyProp { set => writeonlyVar = value; }

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
        private int writeonlyVar;

        public int Prop { get; set; }

        public int ReadOnlyProp { get; }

        public int WriteOnlyProp { set => writeonlyVar = value; }

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

        protected Employee():this("0000","Emp", 1000.0F)
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

        public Manager(string sSN, string name, float salary, string department):base(sSN, name,salary)
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

    class TestInterfaces6
    {
        public static void Test()
        {
            Employee emp1 = new Manager("1111", "Moamen",5000.0F, "Software Engineering");
            Employee emp2 = new SalesPerson("2222", "Mohammed", 4000.0F, "Port Said");
            Employee emp3 = new Worker("3333", "Gamal", 3000.0F, 12);

            // interface as an argument
            printEmp(emp1);
            printEmp(emp2);
            printEmp(emp3);

            // interface as an array
            IPrintable[] printableArray = { new Manager("Software"), new SalesPerson("Sers"), new Worker(10)};
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
        public static IPrintable UpdateSalary (Employee emp)
        {
            emp.Salary += 200;
            return emp;
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
            TestInterfaces6.Test();
        }

    }
    

}