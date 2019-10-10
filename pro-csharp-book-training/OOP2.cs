using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

// ===========================================================================================================
// Object-Oriented Programming with C#
// ===========================================================================================================
// CHAPTER 5: Understanding Inheritance and Polymorphism
// ===========================================================================================================

namespace CSharpBookTraining.OOP_Part2
{
    // Inheritance Notes
    // ==============================================================================================================
    // - Ineritance represent is-a relationship
    // - C# is Single Inheritance Language, any class may inhert only one class, but it may inherit any numberr of interfaces.

    // - sealed keyword before class prevent it from being inherited
    // - base keyword allow you to access Base Class Members except private members

    // Each Class is Implicity derived from System.Object, if it is not Explicity derived from any other Class.

    // The following table lists the categories of types that you can create in C# and the types from which they implicitly 
    // inherit. Each base type makes a different set of members available through inheritance to implicitly derived types.
    // ======================================================
    // Type         category Implicitly inherits from
    // ======================================================
    // class        Object
    // struct       ValueType, Object
    // enum         Enum, ValueType, Object
    // delegate     MulticastDelegate, Delegate, Object

    // implicity inherts System.Object
    class BaseClass1
    {

    }

    // explicity inherts System.Object
    class BaseClass2 : Object
    {

    }

    // ==============================> Inheritance Mechanism <==============================

    // inherts object
    class BaseClass
    {
        private int privateField;

        protected int PrivateFieldProperty { get => privateField; set => privateField = value; }

        protected int protectedField;

        protected void ProtectedBaseClassMethod()
        {

        }

        private void PrivateBaseClassMethod()
        {

        }

        public static void StaticMethodInheritanceTest()
        {

            Console.WriteLine("Base class static method");
        }


    }

    // inherts BaseClass -> Object
    class SubClass1 : BaseClass
    {
        // SubClass1 now has all members of BaseClass, and Object, but private Members 
        // is not reachable, and it may be reached by other base class Members
        public void TestDrivedClass1()
        {
            // Error can't access private members
            //Console.WriteLine(this.privateField);

            // access private field indirecty by non-private Property
            Console.WriteLine(this.PrivateFieldProperty);

            // assign private field indirecty by non-private Property
            this.PrivateFieldProperty = 20;

            // access protected base class field
            Console.WriteLine(this.protectedField);

            // assign protected base class field
            this.protectedField = 10;

            // call base class protected method in subclass
            this.ProtectedBaseClassMethod();

            // Error: can't access private members
            //this.PrivateBaseClassMethod();


        }

        public static void StaticMethodInheritanceTest()
        {

            Console.WriteLine("sub class static method");
        }

    }

    // inherts BaseClass -> Object
    class SubClass2 : BaseClass
    {

    }


    class TestInheritance
    {
        public static void Test()
        {
            
        }

    }

    // ==============================> Polymorphism <==============================
    // The final pillar of OOP is polymorphism.This trait captures a language’s ability to treat related objects in
    // a similar manner.Specifically, this tenant of an object-oriented language allows a base class to define a
    // set of members(formally termed the polymorphic interface) that are available to all descendants.A class’s
    // polymorphic interface is constructed using any number of virtual or abstract members. 

    // ========================> The virtual and override Keywords <========================
    // Polymorphism provides a way for a subclass to define its own version of a method defined by its base class,
    // using the process termed method overriding.

    // If a base class wants to define a method that may be
    // (but does not have to be) overridden by a subclass, it must mark the method with the virtual keyword.

    // When a subclass wants to change the implementation details of a virtual method, it does so using the
    // override keyword.

    class BaseClass3
    {

        public void PrintValue()
        {
            Console.WriteLine("BaseClass3 Method");
        }

    }

    class SubClass3 : BaseClass3
    {

        public void PrintValue()
        {
            Console.WriteLine("SubClass3 Method");
        }

    }


    class SubClass4 : BaseClass3
    {
        public void PrintValue()
        {
            Console.WriteLine("SubClass4 Method");
        }
    }

    class TestPolymorphism
    {
        public static void Test()
        {
            BaseClass3 base1 = new BaseClass3();
            base1.PrintValue();

            BaseClass3 baseSub3 = new SubClass3();
            baseSub3.PrintValue();

            BaseClass3 baseSub4 = new SubClass4();
            baseSub4.PrintValue();


        }

    }


    // Employee Implicity Inherits System.Object
    class Employee 
    {

        // ==============================> Fields <==============================
        private string name;


        // ==============================> Properties <==============================
        public string Ssn { get; protected set; }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public int Age { get; set; }
        public float Pay { get; set; }


        // ==============================> Constructors <==============================
        public Employee() : this("EmpSSN","EmpName",30, 2000.00F)
        {

        }

        public Employee(string ssn, string name, int age, float pay)
        {
            Ssn = ssn;
            Name = name;
            Age = age;
            Pay = pay;
        }

        // ==============================> Methods <==============================
        public void PrintStatus()
        {
            Console.WriteLine($"Ssn  = {Ssn }");
            Console.WriteLine($"Name = {Name}");
            Console.WriteLine($"Age  = {Age }");
            Console.WriteLine($"Pay  = {Pay }");
        }

        
        public virtual void GiveBonus(float amount)
        {
            Pay += amount;
        }


    }


    class Manager : Employee
    {
        public int StockOptions { get; set; }




    }

    class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }
    }

    class PTSalesPerson : SalesPerson
    {
        public int WorkTime { get; set; }


    }


    static class TestInheritanceExample
    {
        public static void Test()
        {
            
        }


    }



    static class OOPTraining
    {
        public static void TestOOP()
        {
            TestPolymorphism.Test();


        }
    }
}