using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

// static imports
using static System.Math;


// ===========================================================================================================
// Object-Oriented Programming with C#
// ===========================================================================================================
// CHAPTER 5: Understanding Encapsulation
// ===========================================================================================================

namespace ProCSharpCode.OOPEncapsulation
{

    #region Introducing the C# Class Type, Fields, and Constructors, methods
    // Introducing the C# Class Type
    // ===========================================================================================================
    //  The most fundamental programming construct is the class type.
    // Formally, a class is a user-defined type that is composed of field data(often called member variables)
    // and members that operate on this data (such as constructors, properties, methods, events, and so forth).

    // A class is defined in C# using the class keyword. Here is the simplest possible declaration:
    // ********************************************************************************************
    class Car0 { }

    // ==============================> a Class With State <==============================
    class Car1
    {
        // The 'state' of the Car.
        public string petName;
        public int currSpeed;
    }

    class TestCar1
    {
        public static void Test()
        {
            Console.WriteLine("***** Fun with Class Types *****\n");
            // Allocate and configure a Car object.
            Car1 myCar = new Car1();
            myCar.petName = "Henry";
            myCar.currSpeed = 10;

            Console.WriteLine($"my {myCar.petName} speed is {myCar.currSpeed}");
        }
    }

    // Note
    // -------------------------------------------------------------------------------------------------------------------
    // Field data of a class should seldom (if ever) be defined as public. to preserve the integrity of your
    // state data, it is a far better design to define data as private (or possibly protected) and allow controlled access
    // to the data via properties. however, to keep this first example as simple as  possible, public data fits the bill.
    // -------------------------------------------------------------------------------------------------------------------


    // ==============================> A Class With a Method <==============================
    // After you have defined the set of member variables representing the state of the class, the next design
    // step is to establish the members that model its behavior.For this example, the Car class will define one
    // method named SpeedUp() and another named PrintState(). Update your class as so:
    class Car2
    {
        // The 'state' of the Car.
        public string petName;
        public int currSpeed;

        // The functionality of the Car.
        // Using the expression-bodied member syntax introduced in C# 6
        public void PrintState() => Console.WriteLine("{0} is going {1} MPH.", petName, currSpeed);
        public void SpeedUp(int delta)
        {
            currSpeed += delta;
        }
    }

    // ==============================> The Creation of objects <==============================

    class TestCar2
    {
        public static void Test()
        {
            Console.WriteLine("***** Fun with Class Types *****\n");
            // Allocate and configure a Car object.
            Car2 myCar = new Car2();
            myCar.petName = "Henry";
            myCar.currSpeed = 10;
            // Speed up the car a few times and print out the
            // new state.
            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }
        }
    }


    // =====================================> Constructors <======================================================

    // The Role of the Default Constructor
    // ===========================================================================================================
    // Every C# class is provided with a “freebie” default constructor that you can redefine if need be. By definition,
    // a default constructor never takes arguments.After allocating the new object into memory, the default
    // constructor ensures that all field data of the class is set to an appropriate default value(see Chapter 3 for
    // information regarding the default values of C# data types).
    // If you are not satisfied with these default assignments, you may redefine the default constructor to suit
    // your needs.To illustrate, update your C# Car class as follows:

    public class Car3
    {
        // The 'state' of the Car.
        public string petName;
        public int currSpeed;

        // A custom default constructor.
        public Car3()
        {
            petName = "Chuck";
            currSpeed = 10;
        }

        public void PrintState() => Console.WriteLine("{0} is going {1} MPH.", petName, currSpeed);
        public void SpeedUp(int delta)
        {
            currSpeed += delta;
        }
    }

    class TestCar3
    {
        public static void Test()
        {
            Console.WriteLine("***** Fun with Class Types *****\n");
            // Allocate and configure a Car object.
            Car3 myCar = new Car3();
            // Speed up the car a few times and print out the
            // new state.
            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }
        }
    }

    // Defining Custom Constructors
    // ===========================================================================================================
    // Typically, classes define additional constructors beyond the default. In doing so, you provide the object user
    // with a simple and consistent way to initialize the state of an object directly at the time of creation.Ponder the
    // following update to the Car class, which now supports a total of three constructors:
    class Car4
    {
        // The 'state' of the Car.
        public string petName;
        public int currSpeed;
        // A custom default constructor.
        public Car4()
        {
            petName = "Chuck";
            currSpeed = 10;
        }
        // Here, currSpeed will receive the
        // default value of an int (zero).
        public Car4(string pn)
        {
            petName = pn;
        }

        public Car4(int speed) => currSpeed = speed;

        // Let caller set the full state of the Car.
        public Car4(string pn, int cs)
        {
            petName = pn;
            currSpeed = cs;
        }

        public void PrintState() => Console.WriteLine("{0} is going {1} MPH.", petName, currSpeed);
        public void SpeedUp(int delta) => currSpeed += delta;



    }

    class TestCar4
    {
        public static void Test()
        {
            Console.WriteLine("***** Fun with Class Types *****\n");
            // Make a Car called Chuck going 10 MPH.
            Car4 chuck = new Car4();
            chuck.PrintState();
            // Make a Car4 called Mary going 0 MPH.
            Car4 mary = new Car4("Mary");
            mary.PrintState();
            // Make a Car4 called Daisy going 75 MPH.
            Car4 daisy = new Car4("Daisy", 75);
            daisy.PrintState();
        }
    }


    // Constructors as Expression-Bodied Members(New)
    // ===========================================================================================================
    // C# 7 builds on the C# 6 expression-bodied member style, adding additional uses for the new style.
    // Constructors, finalizers, and get/set accessors on properties and indexers now accept the new syntax.
    // With this in mind, the previous constructor can be written like this:
    // Here, currSpeed will receive the
    // default value of an int (zero).
    // *******************************************************
    // public Car(string pn) => petName = pn;
    // *******************************************************
    // The second constructor is not a valid candidate, since expression bodied members are designed for
    // one-line methods.


    // The Default Constructor Revisited
    // ===========================================================================================================
    // - If you define your class without any constructor,  the C# compiler grants you a default in order 
    //   to allow the object user to allocate an instance of your type with field data set to the correct
    //   default values.
    // 
    // - If you define your class with Custom constructors without reimplement default, the C# compiler 
    //   wouldn't grant you a default Constructor, and you can't call the default constructor, as it assumes 
    //   that you will take care of your constructors, and you don't want to use default one.

    // - If you define your class with Custom constructors and reimplement default one, you are free to use any of your  
    //   constructor
    // 
    // - NOTE: The default constructor will set all data members to default values, and if you implement it in your code
    //         if you let the constructor body empty it will set all state members to it's defaults.


    // The Role of the this Keyword
    // ===========================================================================================================
    // C# supplies a this keyword that provides access to the current class instance. One possible use of the this
    // keyword is to resolve scope ambiguity


    // Chaining Constructor Calls Using this
    // ===========================================================================================================
    // Another use of the this keyword is to design a class using a technique termed constructor chaining. This
    // design pattern is helpful when you have a class that defines multiple constructors.Given that constructors
    // often validate the incoming arguments to enforce various business rules, it can be quite common to find
    // redundant validation logic within a class’s constructor set.
    // 

    class Car5
    {
        public const int MaxSpeed = 90;
        // The 'state' of the Car.
        public string petName;
        public int currSpeed;



        public Car5() : this("Chuck", 10)
        {
            // use this to make constructor chaining to prevent redandant validation logic
        }


        public Car5(string name) : this(name, 0)
        {
            // use this to make constructor chaining to prevent redandant validation logic
        }

        public Car5(int speed) : this("Chuky", speed)
        {
            // use this to make constructor chaining to prevent redandant validation logic
        }

        // the most big constructor is the best constructor to set our validation and business logic
        // then let our constructor call it with this()
        public Car5(string name, int speed)
        {
            petName = name;
            currSpeed = speed;
            if (currSpeed > MaxSpeed)
                currSpeed = MaxSpeed;
        }

        public void PrintState() => Console.WriteLine("{0} is going {1} MPH.", petName, currSpeed);
        public void SpeedUp(int delta) => currSpeed += delta;



    }

    class TestCar5
    {
        public static void Test()
        {
            Console.WriteLine("***** Fun with Class Types *****\n");
            // Make a Car called Chuck going 10 MPH.
            Car5 chuck = new Car5();
            chuck.PrintState();

            // Make a Car called Mary going 0 MPH.
            Car5 mary = new Car5("Mary");
            mary.PrintState();

            // Make a Car called Chuky going 40 MPH.
            Car5 chuck40 = new Car5(40);
            chuck40.PrintState();

            // Make a Car called Daisy going 75 MPH.
            Car5 daisy = new Car5("Daisy", 75);
            daisy.PrintState();
        }
    }
    //when you make use of this technique, you do tend to end up with a more maintainable and concise class
    //definition. Again, using this technique, you can simplify your programming tasks, as the real work is
    //delegated to a single constructor (typically the constructor that has the most parameters), while the other
    //constructors simply “pass the buck.”

    // The flow of constructor logic is as follows:
    //      • You create your object by invoking the constructor requiring a single int.
    //      • This constructor forwards the supplied data to the master constructor and provides
    //        any additional startup arguments not specified by the caller.
    //      • The master constructor assigns the incoming data to the object’s field data.
    //      • Control is returned to the constructor originally called and executes any remaining code statements.
    //          


    // Optional Parameters and named Arguments with Constructors
    // ===========================================================================================================
    // if you use optional parameters in your class constructors, you can achieve the same benefits as
    // constructor chaining, with considerably less code.
    // Note that A parameter is a variable in a method definition. When a method is called, the arguments are 
    // the data you pass into the method's.
    class Car6
    {
        public const int MaxSpeed = 90;
        // The 'state' of the Car.
        public string petName;
        public int currSpeed;

        // Only one Master Constructor with Optional Args is the same as make constructor Chainning.
        // The only difference is in call Constructor, and want to pass the second args only without first args
        // you must use named Arguments
        public Car6(string name = "Ford", int speed = 10)
        {
            petName = name;
            currSpeed = speed;
            if (currSpeed > MaxSpeed)
                currSpeed = MaxSpeed;
        }

        public void PrintState() => Console.WriteLine("{0} is going {1} MPH.", petName, currSpeed);
        public void SpeedUp(int delta) => currSpeed += delta;



    }

    class TestCar6
    {
        public static void Test()
        {
            Console.WriteLine("***** Fun with Class Types *****\n");
            // Make a Car called Chuck going 10 MPH.
            Car6 chuck = new Car6();
            chuck.PrintState();

            // Make a Car called Mary going 0 MPH.
            Car6 mary = new Car6("Mary");
            mary.PrintState();

            // Make a Car called Chuky going 40 MPH.
            Car6 chuck40 = new Car6(speed: 40);
            chuck40.PrintState();

            // Make a Car called Daisy going 75 MPH.
            Car6 daisy = new Car6("Daisy", 75);
            daisy.PrintState();
        }
    }


    #endregion



    #region Understanding the static Keyword

    // Understanding the static Keyword
    // ===========================================================================================================
    // A C# class may define any number of static members, which are declared using the static keyword. When
    // you do so, the member in question must be invoked directly from the class level, rather than from an object
    // reference variable.

    // While any class can define static members, they are quite commonly found within utility classes.
    // By definition, a utility class is a class that does not maintain any object-level state and is not created with
    // the new keyword.Rather, a utility class exposes all functionality as class-level(aka static) members.

    // the static keyword can be applied to the following:
    // • Data of a class
    // • Methods of a class
    // • Properties of a class
    // • A constructor
    // • The entire class definition
    // • In conjunction with the C# using keyword

    // Defining Static Field Data
    // ===========================================================================================================
    // Most of the time when designing a class, you define data as instance-level data or, said another way, as
    // nonstatic data.When you define instance-level data, you know that every time you create a new object, the
    // object maintains its own independent copy of the data.In contrast, when you define static data of a class, the
    // memory is shared by all objects of that category.
    // static data is perfect when you have a value that should be common to all objects of that category.

    // Some Notes:
    // - Static data can be accessed by other static and non-static members
    // - Static data can be updated by other static and non-static members

    class StaticFieldClass
    {
        private static int staticField;

    }


    // Defining Static Method
    // ===========================================================================================================
    // it is used to make Operation on the Static data, and add a logic to it.
    // Some Notes:
    // - static method can be accessed by static and non-static members
    // - static method can access static members, but it can't access non-static member
    // - static method can update static data, but it can't update non-static data.
    class StaticMethodClass
    {
        private static int staticField;

        public static void StaticMethod()
        {
            // can access all static members
            // but can't access non static members
            
            // 
        }


    }




    // Defining Static Constructors
    // ===========================================================================================================
    // Simply put, a static constructor is a special constructor that is an ideal place to initialize the values of
    // static data when the value is not known at compile time(e.g., you need to read in the value from an external
    // file, read in the value from a database, generate a random number, or whatnot). 

    // The CLR calls all static constructors before the first use(and never calls them again for that
    // instance of the application).

    // Here are a few points of interest regarding static constructors:
    // --------------------------------------------------------------------
    // • A given class may define only a single static constructor.In other words, the static
    //   constructor cannot be overloaded.
    // • A static constructor does not take an access modifier and cannot take any
    //   parameters.
    // • A static constructor executes exactly one time, regardless of how many objects of the
    //   type are created.
    // • The runtime invokes the static constructor when it creates an instance of the class or
    //   before accessing the first static member invoked by the caller.
    // • The static constructor executes before any instance-level constructors.

    class StaticConstructorClass
    {
        private static int field;

        static StaticConstructorClass()
        {
            // Initialize static Member Here
            // is prefered when static members can't be initialized inline
            for (int i = 0; i < 10; i++)
            {
                field += i;
            }
        }


    }

    // Defining Static Classes
    // ===========================================================================================================
    // It is also possible to apply the static keyword directly on the class level. When a class has been defined as
    // static, it is not creatable using the new keyword, and it can contain only members or data fields marked with
    // the static keyword.If this is not the case, you receive compiler errors.

    // Note: 
    // ----------------------------------------------------------------
    // recall that a class (or structure) that exposes only static functionality is often termed a utility class.
    // When designing a utility class, it is good practice to apply the static keyword to the class definition
    // Static classes cancontain static members!
    static class TimeUtilClass
    {
        public static void PrintTime()
        => Console.WriteLine(DateTime.Now.ToShortTimeString());
        public static void PrintDate()
        => Console.WriteLine(DateTime.Today.ToShortDateString());

        public static void Test()
        {
            // This is just fine.
            PrintDate();
            PrintTime();

            // Compiler error! Can't create instance of static classes!
            //TimeUtilClass u = new TimeUtilClass();
        }
    }

    // Importing Static Members via the C# using Keyword
    // ===========================================================================================================
    // C# 6 added support for importing static members with the using keyword. To illustrate, consider the C# file
    // currently defining the utility class. Because you are making calls to the WriteLine() method of the Console
    // class, as well as the Now property of the DateTime class, you must have a using statement for the System
    // namespace.Since the members of these classes are all static, you could alter your code file with the following
    // static using directives:

    // // Import the static members of Console and DateTime.
    // using static System.Console;
    // using static System.DateTime;
    // using static System.Math;

    // You shouldn't over use static import as it cause of confusion
    static class MathUtilClass
    {
        // Note we use PI without using class name and dot operator e.g Math.PI
        public static void PrintAreaOfCircle(double radius)
        {
            Console.WriteLine($"Circle Area = {radius * radius * PI}");
        }

        public static void PrintSphereVolume(double radius)
        {
            Console.WriteLine($"Sphere Volume = {4 * radius * radius * radius * PI / 3}");
        }

        public static void PrintSphereArea(double radius)
        {
            Console.WriteLine($"Sphere Area = {4 * radius * radius * PI}");
        }

        public static void Test()
        {
            PrintAreaOfCircle(10);
            PrintSphereArea(3);
            PrintSphereVolume(3);
        }
    }

    #endregion



    #region Introduction to Three OOP Pillars
    // ===========================================================================================================
    // Defining the Pillars of OOP
    // ===========================================================================================================
    // All object-oriented languages(C#, Java, C++, Visual Basic, etc.) must contend with three core principles,
    // often called the pillars of object-oriented programming (OOP).

    // • Encapsulation: How does this language hide an object’s internal implementation
    //   details and preserve data integrity?

    // • Inheritance: How does this language promote code reuse?

    // • Polymorphism: How does this language let you treat related objects in a similar way?

    //   Before digging into the syntactic details of each pillar, it is important that you understand the basic role
    //   of each.Here is an overview of each pillar.

    // The Role of Encapsulation
    // -------------------------
    // The first pillar of OOP is called encapsulation.This trait boils down to the language’s ability to hide
    // unnecessary implementation details from the object user.

    // The Role of Inheritance
    // -----------------------
    // The next pillar of OOP, inheritance, boils down to the language’s ability to allow you to build new class
    // definitions based on existing class definitions. In essence, inheritance allows you to extend the behavior of
    // a base (or parent) class by inheriting core functionality into the derived subclass(also called a child class).
    // it is considered as an implementation of Is-a Relationship

    // Employee     is-a    Person
    // Car          is-a    Vehicle

    // Another Programming Model is Delegation/Containment/Aggregation Model
    // ---------------------------------------------------------------------
    // There is another form of code reuse in the world of OOP: the containment/delegation model also
    // known as the “has-a” relationship or aggregation.This form of reuse is not used to establish parent-child
    // relationships.Rather, the “has-a” relationship allows one class to define a member variable of another class
    // and expose its functionality(if required) to the object user indirectly.

    // Car has-a Radio
    // Person has-a PhoneNumber


    // The Role of Polymorphism
    // ------------------------
    // The final pillar of OOP is polymorphism.This trait captures a language’s ability to treat related objects in
    // a similar manner.Specifically, this tenant of an object-oriented language allows a base class to define a
    // set of members(formally termed the polymorphic interface) that are available to all descendants.A class’s
    // polymorphic interface is constructed using any number of virtual or abstract members. 
    #endregion


    #region Access Modifiers

    // C# Access Modifiers
    // ===========================================================================================================
    // C# Access Modifier        May Be Applied To               Meaning in Life
    // ===========================================================================================================
    // public                    Types or type members          Public items have no access restrictions.A public
    //                                                          member can be accessed from an object, as well
    //                                                          as any derived class. A public type can be accessed
    //                                                          from other external assemblies.
    // ------------------------------------------------------------------------------------------------------------
    // private                   Type members or nested types   Private items can be accessed only by the class
    //                                                          (or structure) that defines the item.
    // ------------------------------------------------------------------------------------------------------------
    // protected                 Type members or nested types   Protected items can be used by the class that
    //                                                          defines it and any child class. However, protected
    //                                                          items cannot be accessed from the outside world
    //                                                          using the C# dot operator.
    // ------------------------------------------------------------------------------------------------------------
    // internal                  Types or type members          Internal items are accessible only within the
    //                                                          current assembly.Therefore, if you define a set of
    //                                                          internal types within a.NET class library, other
    //                                                          assemblies are not able to use them.
    // ------------------------------------------------------------------------------------------------------------
    // protected internal        Type members or nested types   When the protected and internal keywords are
    //                                                          combined on an item, the item is accessible within
    //                                                          the defining assembly, within the defining class,
    //                                                          and by derived classes.
    // ------------------------------------------------------------------------------------------------------------
    // private protected         Type members or nested types    Access is limited to the containing class or types 
    //                                                           derived from the containing class within the current 
    //                                                           assembly.Available since C# 7.2.
    // ------------------------------------------------------------------------------------------------------------

    // ==========================================================================================================================
    // Order of Type Members Access Modifiers from the smallest
    // ====================================================================================================================
    // C# Access Modifier  Allow Places             
    // ====================================================================================================================
    // private             Type Defines Member         
    // --------------------------------------------------------------------------------------------------------------------
    // private protected   Type Defines Member, Internal derived Types ,   
    // --------------------------------------------------------------------------------------------------------------------
    // internal            Type Defines Member, Internal derived Types , Inside Assemply  
    // --------------------------------------------------------------------------------------------------------------------
    // protected           Type Defines Member, Internal derived Types , External Derived Types        
    // --------------------------------------------------------------------------------------------------------------------
    // protected internal  Type Defines Member, Internal derived Types , Inside Assemply, External Derived Types
    // --------------------------------------------------------------------------------------------------------------------
    // public              Type Defines Member, Internal derived Types , Inside Assemply, External Derived Types, Outside Assembly
    // --------------------------------------------------------------------------------------------------------------------

    // The Default Access Modifiers
    // ===========================================================================================================
    // By default, Type Members are implicitly private 
    // while Types are implicitly internal.

    // Implicity internal
    class MyInternalClass { }

    // Implicity internal
    class MyPrivateMembers
    {
        // implicity private
        int privateInteger;

        // implicity private
        MyPrivateMembers()
        {
            Console.WriteLine("Implicity Private CTOR");
        }

        // implicity private
        void PrivateMethod()
        {
            Console.WriteLine("Implicity Private Method");
        }

    }

    class TestModifier
    {
        public static void Test()
        {

        }
    } 
    #endregion


    #region The First Pillar: C#’s Encapsulation Services
    // ===========================================================================================================
    // The First Pillar: C#’s Encapsulation Services
    // ===========================================================================================================
    // The concept of encapsulation revolves around the notion that an object’s data should not be directly
    // accessible from an object instance.Rather, class data is defined as private. If the object user wants to alter
    // the state of an object, it does so indirectly using public members.


    // Example Showes the need of Encapsulation:
    class Book
    {
        // public field
        public int numberOfPages;
    }

    class EncapsulationTest
    {
        public void Test()
        {
            Book novel = new Book();
            // Note Here not valid number of pages
            // we need a way to add business logic to provide data integrity
            // If your current system has a business rule that states a
            // book must be between 1 and 1,000 pages, you are at a loss to enforce this . 
            // programmatically Because of this, public fields typically have no place in a 
            // production-level class definition
            novel.numberOfPages = 990_992_400;
        }
    }

    // Encapsulation provides a way to preserve the integrity of an object’s state data.Rather than defining
    // public fields(which can easily foster data corruption), you should get in the habit of defining private data,
    // which is indirectly manipulated using one of two main techniques.
    //
    //      • You can define a pair of public accessor(get) and mutator(set) methods.
    //
    //      • You can define a public .NET property.
    // 
    // Whichever technique you choose, the point is that a well-encapsulated class should protect its data
    // and hide the details of how it operates from the prying eyes of the outside world.
    // This is often termed blackbox programming. 
    #endregion


    #region Encapsulation Using Traditional Accessors and Mutators
    // Encapsulation Using Traditional Accessors and Mutators
    // ======================================================
    // Over the remaining pages in this chapter, you will be building a fairly complete class that models a general
    // employee.
    // Example Showes the need of Encapsulation:
    class Employee1
    {
        // Field data.
        private string empName;
        private int empID;
        private float empPay;
        private int empAge;
        // Constructors.
        public Employee1() : this("Employee", 0, 30, 0.0f) { }
        public Employee1(string name, int id, int age, float pay)
        {
            SetEmpName(name);
            SetEmpID(id);
            SetEmpPay(pay);
            SetEmpAge(age);
        }


        // Accessors(get Methods)
        // -------------------------------------------------------------------------
        public string GetEmpName()
        {
            return empName;
        }
        public int GetEmpID()
        {
            return empID;
        }

        public int GetEmpAge()
        {
            return empAge;
        }

        public float GetEmpPay()
        {
            return empPay;
        }

        // Mutators(set Methods)
        // -------------------------------------------------------------------------
        public void SetEmpName(string name)
        {
            // Do a check on incoming value
            // before making assignment.
            if (name.Length > 15)
                Console.WriteLine("Error! Name length exceeds 15 characters!");
            else
                empName = name;
        }

        public void SetEmpID(int id)
        {
            this.empID = id;
        }

        public void SetEmpAge(int age)
        {
            this.empAge = age;
        }


        public void SetEmpPay(float pay)
        {
            this.empPay = pay;
        }

        // Methods.
        // -------------------------------------------------------------------------
        public void GiveBonus(float amount)
        {
            empPay += amount;
        }
        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", empName);
            Console.WriteLine("ID: {0}", empID);
            Console.WriteLine("Age: {0}", empAge);
            Console.WriteLine("Pay: {0}", empPay);
        }


    }

    class Employee1Test
    {
        public static void Test()
        {
            // Encapsulation Using Traditional Accessors and Mutators
            // ------------------------------------------------------
            Employee1 emp1 = new Employee1();
            emp1.SetEmpName("Moamen");
            emp1.SetEmpID(9999);
            emp1.SetEmpAge(40);
            emp1.SetEmpPay(20_000.00F);

            Console.WriteLine("Employee Info Using Traditional Accessors and Mutators:");
            Console.WriteLine("=======================================================");
            Console.WriteLine($"name:{emp1.GetEmpName()}");
            Console.WriteLine($"ID  : {emp1.GetEmpID()}");
            Console.WriteLine($"Age : {emp1.GetEmpAge()}");
            Console.WriteLine($"Pay : {emp1.GetEmpPay()}");
            Console.WriteLine();

            // to increase Age Value, you can do the following:
            emp1.SetEmpAge(emp1.GetEmpAge() + 1);
            // you can see that Accessors and Mutators makes your types harder to manipulate.
        }
    } 
    #endregion


    #region Encapsulation Using .NET Properties

    // Encapsulation Using .NET Properties
    // ===================================
    // Although you can encapsulate a piece of field data using traditional get and set methods, .NET languages
    // prefer to enforce data encapsulation state data using properties. First, understand that properties are just a
    // simplification for “real” accessor and mutator methods.Therefore, as a class designer, you are still able to
    // perform any internal logic necessary before making the value assignment(e.g., uppercase the value, scrub
    // the value for illegal characters, check the bounds of a numerical value, and so on).
    // A C# property is composed by defining a get scope (accessor) and set scope (mutator) directly within
    // the property itself.Notice that the property specifies the type of data it is encapsulating by what appears to
    // be a return value.

    // Within a set scope of a property, you use a token named value, which is used to represent the incoming
    // value used to assign the property by the caller.This token is not a true C# keyword but is what is known as
    // a contextual keyword. When the token value is within the set scope of the property, it always represents the
    // value being assigned by the caller, and it will always be the same underlying data type as the property itself

    // Here is the updated Employee class, now enforcing encapsulation of each field using property syntax
    // rather than traditional get and set methods:
    class Employee2
    {

        // Constructors.
        public Employee2() : this("Employee", 0, 0, 0.0f) { }
        public Employee2(string name, int id, int age, float pay)
        {
            // Better! Use properties when setting class data.
            // This reduces the amount of duplicate error checks.
            this.EmpName = name;
            this.EmpID = id;
            this.EmpAge = age;
            this.EmpPay = pay;
        }

        // .NET Properties
        // -------------------------------------------------------------------------
        private string empName;
        private int empID;
        private float empPay;
        private int empAge;

        // Add business rules to the sets of EmpName properties
        public string EmpName
        {
            get
            {
                return empName;
            }

            set
            {
                // Do a check on incoming value
                // before making assignment.
                if (value.Length > 15)
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                else
                    empName = value;
            }
        }


        // We could add additional business rules to the sets of these properties;
        // however, there is no need to do so for this example.
        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }

        public float EmpPay
        {
            get { return empPay; }
            set { empPay = value; }
        }

        public int EmpAge
        {
            get { return empAge; }
            set { empAge = value; }
        }

        // Methods.
        // -------------------------------------------------------------------------
        public void GiveBonus(float amount)
        {
            EmpPay += amount;
        }
        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", EmpName);
            Console.WriteLine("ID: {0}", EmpID);
            Console.WriteLine("Age: {0}", EmpAge);
            Console.WriteLine("Pay: {0}", EmpPay);
        }
    }

    class Employee2Test
    {
        public static void Test()
        {
            // Encapsulation Using .NET Properties
            // ------------------------------------------------------
            Employee2 emp1 = new Employee2();

            //After you have these properties in place, it appears to the caller that it is getting and setting a public
            //point of data; however, the correct get and set block is called behind the scenes to preserve encapsulation.

            // Set the Properties
            emp1.EmpName = "Moamen";
            emp1.EmpID = 9999;
            emp1.EmpAge = 40;
            emp1.EmpPay = 20_000.00F;

            // Get the Properties
            Console.WriteLine("Employee Info using .Net Properties:");
            Console.WriteLine("====================================");
            Console.WriteLine($"name:{emp1.EmpName}");
            Console.WriteLine($"ID: {emp1.EmpID}");
            Console.WriteLine($"Age: {emp1.EmpAge}");
            Console.WriteLine($"Pay: {emp1.EmpPay}");
            Console.WriteLine();

            // to increase Age Value, you can do the following:
            emp1.EmpAge++;
            // Properties(as opposed to accessor and mutator methods) make your types easier to manipulate,
            // in that properties are able to respond to the intrinsic operators of C#.
        }
    }

    // Properties as Expression-Bodied Members(New)
    // ============================================
    // As mentioned previously, property get and set accessors can also be written as expression-bodied
    // members.The rules and syntax are the same: single-line methods can be written using the new syntax.


    class TestExpressionBodiedProperties
    {
        private int age;

        public int Age
        {
            get => age;
            set => age = value;
        }

    }
    // Both syntaxes compile down to the same IL, so which syntax you use is completely up to you.

    // Using Properties Within a Class Definition
    // ==========================================
    // to prevent redandant code and error checking you can use the properties to set your logic, 
    // and then, use it also inside class definition, in constructors, methods, other properties, ...etc
    // and don't over use the Fields in your class definition.

    // Read-Only and Write-Only Properties
    // ===================================
    // When encapsulating data, you might want to configure a read-only property.To do so, simply omit the set
    // block.Likewise, if you want to have a write-only property, omit the get block.

    class ReadOnlyProperty
    {

        private int age;

        public ReadOnlyProperty()
        {
            // you cann't set property in class Member
            //Age = 40;

            // instead you can set data field and add business logic.
            age = 40;
        }

        // Read Only Property
        public int Age
        {
            get { return age; }
            //set { age = value; }
        }

        public void PrintState()
        {
            // You can get property in the class members
            Console.WriteLine($"Age = {Age}");
        }

    }

    class TestReadOnlyProperty
    {
        public static void Test()
        {
            ReadOnlyProperty prop = new ReadOnlyProperty();
            // You can't set the property in the production class 
            //prop.Age = 30;

            // but you can get it's value
            Console.WriteLine($"Age = {prop.Age}");
        }
    }

    // =========================================================================================================
    class WriteOnlyProperty
    {
        private int age;

        public WriteOnlyProperty()
        {
            Age = 40;

            // Cann't read property
            //int half = Age / 2;
            //Console.WriteLine($"Age = {Age}");

            // instead you can depend on data field

            Console.WriteLine($"age = {age}");
        }

        // Write Only Property
        public int Age
        {
            //get { return age; }
            set { age = value; }
        }

        public void PrintState()
        {
            // Cann't read property
            //Console.WriteLine($"Age = {Age}");
        }
    }

    class TestWriteOnlyProperty
    {
        public static void Test()
        {
            WriteOnlyProperty prop = new WriteOnlyProperty();
            // You can set the property in the production class 
            prop.Age = 30;

            // but you can't get it's value
            //Console.WriteLine($"Age = {prop.Age}");
        }
    }

    // =========================================================================================================
    class PrivateWriteProperty
    {

        private int age;

        public PrivateWriteProperty()
        {
            // Private set allow class members to write property value, but the outside world can't.
            Age = 40;

        }

        // Read Only Property
        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        public void PrintState()
        {
            // You can get property in the class members
            Console.WriteLine($"Age = {Age}");
        }

    }

    class TestPrivateWriteProperty
    {
        public static void Test()
        {
            PrivateWriteProperty prop = new PrivateWriteProperty();
            // You can't set the property in the production class 
            //prop.Age = 30;

            // but you can get it's value
            Console.WriteLine($"Age = {prop.Age}");
        }
    }

    // =========================================================================================================
    class PrivateReadProperty
    {

        private int age;

        public PrivateReadProperty()
        {
            // you can set the property inside and outside class members
            Age = 40;
        }

        // Private Read Property
        public int Age
        {
            private get { return age; }
            set { age = value; }
        }

        public void PrintState()
        {
            // You can get property in the class members
            Console.WriteLine($"Age = {Age}");
        }

    }

    class TestPrivateReadProperty
    {
        public static void Test()
        {
            PrivateReadProperty prop = new PrivateReadProperty();
            // You can set the property in the production class 
            prop.Age = 30;

            // but you can't get it's value, outside class definition
            //Console.WriteLine($"Age = {prop.Age}");
        }
    }

    // =========================================================================================================
    // Note: you can use protected, internal modifier instead of private modifier, to control the accessability
    // of set or get part of our property, but the access level must be less than the property access level

    class AnotherPropertyAccessModifier
    {

        private int myfield;

        public int MyProperty
        {
            get { return myfield; }
            protected set { myfield = value; }
        }

        private int myfield2;

        public int MyProperty2
        {
            get { return myfield2; }
            internal set { myfield2 = value; }
        }

        private int myfield3;

        public int MyProperty3
        {
            get { return myfield3; }
            protected internal set { myfield3 = value; }
        }

        private int myfield4;

        public int MyProperty4
        {
            get { return myfield4; }
            private protected set { myfield4 = value; }
        }




        private int myfield5;

        public int MyProperty5
        {
            protected get { return myfield5; }
            set { myfield5 = value; }

        }

        private int myfield6;

        public int MyProperty6
        {
            internal get { return myfield6; }
            set { myfield6 = value; }

        }

        private int myfield7;

        public int MyProperty7
        {
            protected internal get { return myfield7; }
            set { myfield7 = value; }

        }


        private int myfield8;

        public int MyProperty8
        {
            private protected get { return myfield8; }
            set { myfield8 = value; }

        }

    }


    #endregion


    #region Automatic Properties

    // Understanding Automatic Properties
    // ==================================
    class Employee3
    {

        // Constructors.
        public Employee3() : this("Employee", 0, 0, 0.0f) { }
        public Employee3(string name, int id, int age, float pay)
        {
            // Better! Use properties when setting class data.
            // This reduces the amount of duplicate error checks.
            this.EmpName = name;
            this.EmpID = id;
            this.EmpAge = age;
            this.EmpPay = pay;
            
        }

        // .NET Properties
        // -------------------------------------------------------------------------
        private string empName;

        // Add business rules to the sets of EmpName properties
        public string EmpName
        {
            get
            {
                return empName;
            }

            set
            {
                // Do a check on incoming value
                // before making assignment.
                if (value.Length > 15)
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                else
                    empName = value;
                
            }
        }


        // We could add additional business rules to the sets of these properties;
        // however, there is no need to do so for this example.

        public int EmpID { get; set; }

        public int EmpAge { get; set; }

        public float EmpPay { get; set; }

        // Methods.
        // -------------------------------------------------------------------------
        public void GiveBonus(float amount)
        {
            EmpPay += amount;
            
        }
        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", EmpName);
            Console.WriteLine("ID: {0}", EmpID);
            Console.WriteLine("Age: {0}", EmpAge);
            Console.WriteLine("Pay: {0}", EmpPay);
        }
    }

    class Employee3Test
    {
        public static void Test()
        {
            // Encapsulation Using .NET Properties
            // ------------------------------------------------------
            Employee3 emp1 = new Employee3();

            //After you have these properties in place, it appears to the caller that it is getting and setting a public
            //point of data; however, the correct get and set block is called behind the scenes to preserve encapsulation.

            // Set the Properties
            emp1.EmpName = "Moamen";
            emp1.EmpID = 9999;
            emp1.EmpAge = 40;
            emp1.EmpPay = 20_000.00F;

            

            // to increase Age Value, you can do the following:
            emp1.EmpAge++;

            // Get the Properties
            Console.WriteLine("Employee Info using .Net Properties:");
            Console.WriteLine("====================================");
            Console.WriteLine($"name:{emp1.EmpName}");
            Console.WriteLine($"ID: {emp1.EmpID}");
            Console.WriteLine($"Age: {emp1.EmpAge}");
            Console.WriteLine($"Pay: {emp1.EmpPay}");
            Console.WriteLine();


        }
    }


    class AutomaticProperties
    {
        public int AutoProp1 { get; set; }

        // Write Access Control
        // -------------------------------------------------------- 
        public int AutoProp2 { get; } // can be set only in constructor or static constructor if it is a static property
        public int AutoProp3 { get; private set; }
        public int AutoProp4 { get; protected set; }
        public int AutoProp5 { get; internal set; }
        public int AutoProp6 { get; protected set; }
        public int AutoProp7 { get; protected internal set; }
        public int AutoProp8 { get; private protected set; }

        // Read Access Control
        // --------------------------------------------------------
        // you can't make Auto Write-Only Property, as you can't read it any where.
        //public int AutoProp9 { set; }
        public int AutoProp10 { private get; set; }
        public int AutoProp11 { protected get; set; }
        public int AutoProp12 { internal get; set; }
        public int AutoProp13 { protected get; set; }
        public int AutoProp14 { protected internal get; set; }
        public int AutoProp15 { private protected get; set; }

        // The Automatic Property Access Control with get/set Access Control
        // --------------------------------------------------------

        // public Property access allows get/set access control to be Any of the following
        // access modifiers: private, private protected, internal, protected, and protected internal
        public int AutoProp17 { get; set; }

        // protected internal Property access allows get/set access control to be Any of the following
        // access modifiers: private, private protected, internal, and protected
        protected internal int AutoProp18 { get; set; }

        // protected Property access allows get/set access control to be Any of the following
        // access modifiers: private, private protected, and internal
        protected int AutoProp19 { get; set; }

        // internal Property access allows get/set access modifier to be  private, or private protected
        internal int AutoProp20 { get; set; }

        // private protected Property access allows get/set access control to be private only
        private protected int AutoProp21 { get; set; }

        // private Property access modifier doesn't allow any of get/set access modifier
        private int AutoProp22 { get; set; }

    }

    // Automatic Properties Default Values and Initialization
    // ------------------------------------------------------
    // the hidden backing fields will be assigned a safe default value
    // (false for Booleans and 0 for numerical data, and null for References).

    // Initialization: since the release of C# 6,  C# now allows you to assign an initial value to the
    //  underlying backing field generated by the compiler.This alleviates you from the hassle of adding 
    // additional code statements in class constructors to ensure property data comes to life as intended.
    class AutoPropertyDefaults
    {
        public int IntAuto { get; set; } // = 0;
        public int IntAuto2 { get; set; } = 10;

        public bool BooleanAuto { get; set; } // = false;
        public bool BoleanAuto2 { get; set; } = true;

        public Employee2 EmpAuto { get; set; } // = null;
        public Employee2 EmpAuto2 { get; set; } = new Employee2();

        public AutoPropertyDefaults()
        {

        }

        public void PrintPropValues()
        {
            Console.WriteLine("Print Auto Default and Custom Values");
            Console.WriteLine("=====================================");
            Console.WriteLine("IntAuto     = " + IntAuto);
            Console.WriteLine("IntAuto2    = " + IntAuto2);
            Console.WriteLine("BooleanAuto = " + BooleanAuto);
            Console.WriteLine("BoleanAuto2 = " + BoleanAuto2);
            Console.WriteLine("EmpAuto     = " + (EmpAuto == null ? "NULL" : EmpAuto.ToString()));
            Console.WriteLine("EmpAuto2    = " + EmpAuto2);



        }

        public static void Test()
        {
            AutoPropertyDefaults obj = new AutoPropertyDefaults();
            obj.PrintPropValues();
        }

    } 
    #endregion


    #region Object Initialization Syntax
    // Understanding Object Initialization Syntax
    // ==============================================================================================================
    // object initialization syntax is just shorthand notation for the syntax used to create a class variable using
    // a default constructor and to set the state data property by property



    enum PointColor
    { LightBlue, BloodRed, Gold }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointColor Color { get; set; }
        public Point(int xVal, int yVal)
        {
            X = xVal;
            Y = yVal;
            Color = PointColor.Gold;
        }
        public Point(PointColor ptColor)
        {
            Color = ptColor;
        }
        public Point()
        : this(PointColor.BloodRed) { }
        public void DisplayStats()
        {
            Console.WriteLine("[{0}, {1}]", X, Y);
            Console.WriteLine("Point is {0}", Color);
        }
    }


    class Rectangle
    {
        private Point topLeft = new Point();
        private Point bottomRight = new Point();

        public Point TopLeft { get => topLeft; set => topLeft = value; }
        public Point BottomRight { get => bottomRight; set => bottomRight = value; }

        public void DisplayStats()
        {
            Console.WriteLine("[TopLeft: {0}, {1}, {2} BottomRight: {3}, {4}, {5}]",
            TopLeft.X, TopLeft.Y, TopLeft.Color,
            BottomRight.X, BottomRight.Y, BottomRight.Color);
        }
    }

    class ObjectInit
    {
        public static void Test()
        {
            // Make a Point by setting each property manually.
            Point firstPoint = new Point();
            firstPoint.X = 10;
            firstPoint.Y = 10;
            firstPoint.DisplayStats();

            // Or make a Point via a custom constructor.
            Point anotherPoint = new Point(20, 20);
            anotherPoint.DisplayStats();

            // Or make a Point using object init syntax.
            // Here, the default constructor is called implicitly.
            Point finalPoint = new Point { X = 30, Y = 30 };
            finalPoint.DisplayStats();


            // Here, the default constructor is called explicitly.
            Point finalPoint2 = new Point() { X = 30, Y = 30 };
            finalPoint2.DisplayStats();

            // Calling a custom constructor.
            Point pt = new Point(10, 16) { X = 100, Y = 100 };
            pt.DisplayStats();

            // Calling a more interesting custom constructor with init syntax.
            // Note that if data point passed to constructor, and then assigned in
            //  object initialization syntax, the value assigned in object init sytax will be the right value.
            Point goldPoint = new Point(PointColor.Gold) { X = 90, Y = 20 };
            goldPoint.DisplayStats();

            // Create and initialize a Rectangle.
            Rectangle myRect = new Rectangle
            {
                TopLeft = new Point { X = 10, Y = 10 },
                BottomRight = new Point { X = 200, Y = 200 }
            };

            // Old-school approach.
            Rectangle r = new Rectangle();
            Point p1 = new Point();
            p1.X = 10;
            p1.Y = 10;
            r.TopLeft = p1;
            Point p2 = new Point();
            p2.X = 200;
            p2.Y = 200;
            r.BottomRight = p2;

        }

    } 
    #endregion


    #region const, readonly keywords
    // Fields
    public class Fields
    {
        // Const Fields:
        // ==============================================================================================================
        // C# offers the const keyword to define constant data, which can never change after the initial assignment. 
        // Some Notes
        // - constant fields of a class are implicitly static, so it's called in class level not in the object level
        // - const Fields should be initialized at the time you define it.
        // - const Fields value can't be changed after it's creation.

        public const int constField = 40;

        // static property for const field should be Read Only Property (can't have set clause)
        public static int PropertyOfConstField
        {
            get { return constField; }
            //set { constField = value; }    // Error
        }


        // Static ReadOnly Fields:
        // ==============================================================================================================
        // C# allows making readonly fields static by add static keyword, that make readonly field on the class level
        // - it also can be initialied at runtime (in the definition, or in the static constructor), then it's value 
        //   can't be changed.

        // The Difference Between const , and static readonly fields is:
        // -------------------------------------------------------------
        // - const fields determined at Compile-time, but static readonly fields can be determined at runtime.
        // - const fields must be initialized with it's definition, but static readonly fields must be initialized 
        //   with it's definition, and/or in static constructor.
        // - both const and readonly fields values can't be changed after it's allowed itialization places.

        private static readonly int readonlyStaticField;

        private static readonly int readonlyStaticField2 = 20;

        // static property for read only field should be Read Only Property (can't have set clause)
        public static int PropertyOfStaticReadonlyField
        {
            get { return readonlyStaticField; }
            //set { readonlyStaticField = value; }    // Error 
        }


        // Static Constructor
        static Fields()
        {
            //constField = 40;
            readonlyStaticField = 40;
            readonlyStaticField2 = 40;
        }

        // Static Method: here you can't change const or static readonly fields
        public void TestStatic()
        {
            //constField = 40;
            //readonlyStaticField = 40;
            //readonlyStaticField2 = 40;
        }

        // ReadOnly Fields:
        // ==============================================================================================================
        // C# offers the readonly keyword to define readonly fields, that can be initialized in the runtime, (within it's definition
        // and in the constructor), then it's value cannot be changed.
        // - so it must be assigned in it's definition or in the constructor, then it can't be changed.


        private readonly int readonlyField;
        private readonly int readonlyField2 = 40;

        // property for read only field should be Read Only Property
        public int PropertyOfReadonlyField
        {
            get { return readonlyField; }
            //set { readonlyField = value; }    // Error 
        }

        // Construtor
        public Fields()
        {
            readonlyField = 10;
            readonlyField2 = 10;
        }

        // Method: here we can't change readonly fields
        public void TestFields()
        {
            //readonlyField = 10;
            //readonlyField2 = 10;
        }



    }

    class TestFields
    {
        public static void Test()
        {
            Fields obj = new Fields();
            // readonly fields can't be changed 
            //obj.readonlyField = 10;
            //obj.readonlyField2 = 10;
        }
    }


    // Const Within Methods Body
    // ==============================================================================================================

    class TestConstValues
    {
        public static void Test()
        {
            const int ID = 100; // must be initialized with it's definition
            //ID = 200;         // it's value can't be changed after it's creation
            Console.WriteLine($"ID = {ID}");

            // A local constant data point can be directly accessed.
            const string fixedStr = "Fixed string Data";
            Console.WriteLine($"fixedStr = {fixedStr}");
            // Error!
            // fixedStr = "This will not work!";
        }


    } 
    #endregion


    #region Partial Keyword within a class

    // Partial Classes
    // ==============================================================================================================
    // Last but not least, it is important to understand the role of the C# partial keyword. 
    // Using partial classes, you could choose to move(for example) the properties, constructors, and field
    // data into a new file named Employee.Core.cs(the name of the file is irrelevant). The first step is to add the
    // partial keyword to the current class definition and cut the code to be placed into the new file.

    partial class PartialClassTest
    {
        private int field1 = 10;
        private int field2 = 10;
        public PartialClassTest()
        {

        }

        public PartialClassTest(int prop1, int prop2)
        {
            Prop1 = prop1;
            Prop2 = prop2;
        }

        public int Prop1 { get; set; }
        public int Prop2 { get; set; } = 40;



        public void Method()
        {

        }


    }

    // assume we are in different file
    partial class PartialClassTest
    {

        public static int myProperty { get; set; } = 10;

        // read only property
        public static int MyProperty
        {
            get { return myProperty; }
            //set { myProperty = value; }
        }


        public static void StaticMethod()
        {

        }
    }
    #endregion


    #region Nested Types (Classes)

    // ==============================> Nesed Types <==============================
    // In C# (as well as other .NET languages), it is possible to define a type (enum, class, interface,
    // struct, or delegate) directly within the scope of a class or structure.

    // When you have done so,  the nested(or “inner”) type is considered a member of the nesting(or “outer”)
    // class and in the eyes of the runtime can be manipulated like any other member(fields, properties,
    // methods, and events). 

    //  To understand this technique, ponder the following traits of nesting a type:
    //
    //  • Nested types allow you to gain complete control over the access level of the inner
    //    type because they may be declared privately (recall that non-nested classes cannot
    //    be declared using the private keyword).
    //
    //  • Because a nested type is a member of the containing class, it can access private
    //    members of the containing class.
    //
    //  • Often, a nested type is useful only as a helper for the outer class and is not intended
    //    for use by the outside world.

    public class OuterClass
    {
        // ==============================> OuterClass Static Members <==============================

        private static int outerStaticField;
        public static int outerStaticProp { get; set; }

        // Define static object of the inner class
        public static InnerClass innerClassStaticObject;

        static OuterClass()
        {
            // initialize static object of the inner class
            innerClassStaticObject = new InnerClass();

            // Use of InnerClass Static Members without restrictions 
            InnerClass.InnerStaticMethod();

        }

        public static void StaticMethod()
        {
            // initialize static object of the inner class
            innerClassStaticObject = new InnerClass();

            // Use of InnerClass Static Members without restrictions 
            InnerClass.InnerStaticMethod();
        }

        public static class StaticInnerClass
        {
            static StaticInnerClass()
            {

            }

        }







        // ==============================> Outer Class Members <==============================

        private int outerField;
        public int OuterProp { get; set; }


        // Define object of the inner class
        public InnerClass innerClassObject;

        public OuterClass()
        {
            // Initialize object of the inner class
            innerClassObject = new InnerClass();

            // Use of InnerClass Static Members without restrictions
            InnerClass.InnerStaticMethod();
        }

        public void OuterMethod()
        {
            // Initialize Non static object of the inner class
            innerClassObject = new InnerClass();

            // Use of InnerClass Static Members without restrictions
            InnerClass.InnerStaticMethod();
        }


        // ==============================> Inner Class <==============================

        // Inner Classes Notes:
        // - Inner class can access All Container Class Members like any other members in the class
        // - Container Class can access Inner Class Static Member, but it can't access Non-Static Members.

        // - Inner class can create any members inside it.
        // - Container Class can create instances of inner class,then use it, and can use it's static members.
        // - The Outside World, can Create Instances from Inner Classes if it's not private

        public class InnerClass
        {
            // ==============================> InnerClass Static Members <==============================

            private static int InnerStaticField;
            public static int InnerStaticProp { get; set; }

            // Define static object of the OuterClass
            private static OuterClass outerClassStaticObject;

            static InnerClass()
            {
                // Initialize static object of the OuterClass
                outerClassStaticObject = new OuterClass();

                // Access OuterClass Static Members Without Restrictions
                OuterClass.StaticMethod();

            }

            public static void InnerStaticMethod()
            {
                // Initialize static object of the OuterClass
                outerClassStaticObject = new OuterClass();

                // Access OuterClass Static Members Without Restrictions
                OuterClass.StaticMethod();

            }


            // ==============================> Inner Class Non-Static Memberrs <==============================

            // Inner Class Members can access Outer Class Members, but the opposite doesn't work.

            private int InnerField;
            public int InnerProp { get; set; }

            public InnerClass()
            {

            }

            public void InnerMethod()
            {

            }

        }



        // A private nested type can only be used by members
        // of the containing class.
        private class PrivateInnerClass { }
    }


    // ==============================> Deep Nested Classes <==============================
    // The nesting process can be as “deep” as you require.

    public class OuterClass2
    {

        OuterInnerClass innerClass;

        // Deep Inner class definition in the outer class
        OuterInnerClass.InnerInnerClass deepInnerObject;

        public OuterClass2()
        {
            innerClass = new OuterInnerClass();
            deepInnerObject = new OuterInnerClass.InnerInnerClass();
        }

        public class OuterInnerClass
        {

            // Inner Class of Inner Class of Outer Class
            public class InnerInnerClass
            {
                // You can define more Nested Classes
            }
        }
    }

    class TestNestedTypes
    {
        public TestNestedTypes()
        {
            OuterClass outclass = new OuterClass();

            // Create InnerClass Object
            OuterClass.InnerClass innerclass = new OuterClass.InnerClass();

            // Deep Inner class definition
            OuterClass2.OuterInnerClass.InnerInnerClass deepInnerObject
                = new OuterClass2.OuterInnerClass.InnerInnerClass();

        }
    }
    #endregion



    #region Init-only property 
    // Init-only property 
    // ==============================================================================================================
    // Init-only property or indexer can only be assigned in an object initializer,
    // or on 'this' or 'base' in an instance constructor or an 'init' accessor.


    public class InitOnlyProperty
    {
        public int First { get; init; }

        public InitOnlyProperty()
        {
            // valid
            First = 10;
        }


        public void SetFirst()
        {
            //First = 120; // not valid
        }


    }

    public class InitOnlyPropertySubClass : InitOnlyProperty
    {
        
        public InitOnlyPropertySubClass():base()
        {
            // valid
            base.First = 10;
            this.First = 10;
            First = 10;
        }


        public void SetFirst2()
        {
            //First = 120; // not valid
        }




    }
    public class TestInitOnlyProperty
    {
        public static void Test()
        {

            // valid in the initializer.
            InitOnlyProperty obj = new InitOnlyProperty() { First = 200 };

            //obj.First = 20; // can't be setted
        }
    }

    #endregion




    static class OOPTraining
    {
        public static void TestOOP()
        {
            TestCar1.Test();
            TestCar2.Test();
            TestCar3.Test();
            TestCar4.Test();
            TestCar5.Test();
            TestCar6.Test();

            TimeUtilClass.Test();
            MathUtilClass.Test();
            Employee1Test.Test();
            Employee2Test.Test();
            Employee3Test.Test();
            AutoPropertyDefaults.Test();
            ObjectInit.Test();
            TestFields.Test();
            TestConstValues.Test();



        }
    }


}