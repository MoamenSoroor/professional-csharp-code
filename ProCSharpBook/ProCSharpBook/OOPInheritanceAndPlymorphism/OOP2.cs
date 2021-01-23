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

namespace ProCSharpBook.OOPInheritanceAndPlymorphism
{

    #region Inheritance
    // Inheritance Notes
    // ==============================================================================================================
    // - Inheritance represent is-a relationship
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

            // Error: Can't assign private field indirecty by non-private Property
            //this.privateField = 20;

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

    #endregion

    #region Polymorphism, The virtual, override and sealed Keywords

    // ===============================================> Polymorphism <==================================================
    // =================================================================================================================
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

    // Note Hierarchy: Object <- BaseClass3 <- Subclass3 <- SubSubClass3
    //                                      <- Subclass4
    class BaseClass3
    {
        protected string field;

        public virtual string Property
        {
            get 
            { 
                return field; 
            }
            set
            {
                field = "BaseClass3 has " + value;
            }
        }
        public virtual void PrintValue()
        {
            Console.WriteLine("BaseClass3 PrintValue() Method");
        }


        public virtual void PrintValue2()
        {
            Console.WriteLine("BaseClass3 PrintValue2() Method");
        }

    }

    class SubClass3 : BaseClass3
    {

        public override string Property
        {
            get
            {
                return field;
            }
            set
            {
                field = "SubClass3 has " + value;
            }
        }


        public override void PrintValue()
        {
            Console.WriteLine("SubClass3 Method");
        }

        
        // sealed keyword prevent class members from being overridden.
        public sealed override void PrintValue2()
        {
            Console.WriteLine("SubClass3 PrintValue2() Method");
        }


    }

    class SubSubClass3 : SubClass3
    {
        public override string Property
        {
            get
            {
                return field;
            }
            set
            {
                field = "SubSubClass3 has " + value;
            }
        }

        public override void PrintValue()
        {
            Console.WriteLine("SubSubClass3 Method");
        }

        // cannot override inherited member 'SubClass3.PrintValue2()' because it is sealed.

        //public override void PrintValue2()
        //{
        //    Console.WriteLine("SubSubClass3 PrintValue2() Method");
        //}

    }


    class SubClass4 : BaseClass3
    {
        public override string Property
        {
            get
            {
                return field;
            }
            set
            {
                field = "SubClass4 has " + value;
            }
        }

        public override void PrintValue()
        {
            Console.WriteLine("SubClass4 Method");
        }
    }

    class TestVirtualKeword
    {
        public static void Test()
        {
            BaseClass3 base1 = new BaseClass3();
            base1.PrintValue();
            base1.Property = "Value";
            Console.WriteLine(base1.Property);

            BaseClass3 baseSub3 = new SubClass3();
            baseSub3.PrintValue();
            baseSub3.Property = "Value";
            Console.WriteLine(baseSub3.Property);

            BaseClass3 subSub3 = new SubSubClass3();
            subSub3.PrintValue();
            subSub3.Property = "Value";
            Console.WriteLine(subSub3.Property);

            BaseClass3 baseSub4 = new SubClass4();
            baseSub4.PrintValue();
            baseSub4.Property = "Value";
            Console.WriteLine(baseSub4.Property);


        }

    }


    #endregion


    #region Sealed with Methods


    class MyNonSealed1
    {
        public virtual void MyMethod()
        {

        }
    }

    class MyNonSealed2: MyNonSealed1
    {
        public sealed override void MyMethod()
        {

        }
    }

    class MyNonSealed3 : MyNonSealed2
    {
        // Error cannot override inherited member 'MyNonSealed2.MyMethod()' because it is sealed 
        //public override void MyMethod()
        //{

        //}
    }


    #endregion

    #region Sealed with Classes


    sealed class MySealedClass
    {
        // not allowed to make virtual method in sealed class
        //public virtual void MyMethod() { }
        
    }

    // not allowed to inherit 
    // Error CS0509  'MySealedClass2': cannot derive from sealed type 'MySealedClass'	
    //class MySealedClass2 : MySealedClass
    //{
    //    public sealed override void MyMethod()
    //    {

    //    }
    //}

    #endregion

    #region base keyword

    // ==============================> base Keyword <==============================
    // The base keyword is used to access members of the base class from within a derived class:

    //  1- Call a method on the base class that has been overridden by another method.

    //  2- Specify which base-class constructor should be called when creating instances of the derived class.
    //
    // A base class access is permitted only in a constructor, an instance method, or an instance property accessor.


    class BaseKeywordClass
    {

        protected int intValue;

        public virtual int IntValue { get => intValue; set => intValue = value; }

        public string StringValue { get; set; }

        public BaseKeywordClass() : this(100, "String Value") { }

        public BaseKeywordClass(int intValue) : this(intValue, "String Value") { }

        public BaseKeywordClass(int intValue, string stringValue)
        {
            IntValue = intValue;
            StringValue = stringValue;
        }



        public virtual void PrintState()
        {
            Console.WriteLine($"IntValue    = {IntValue}");
            Console.WriteLine($"StringValue = {StringValue}");
        }


    }

    class BaseKeywordSubClass : BaseKeywordClass
    {

        private int intValue2;

        // base keyword with Constructor, calls constructor of base class
        // using base() with empty args, calls the base class Custom Constructor, that call
        // is done implicity if you don't specify it explicity
        public BaseKeywordSubClass() : base() { }

        // is the same as
        //public BaseKeywordSubClass() { }


        public BaseKeywordSubClass(int intValue2, string stringValue2) : base(200, "Set Base Class String from Subclass")
        {
            IntValue2 = intValue2;
            StringValue2 = stringValue2;
        }

        public BaseKeywordSubClass(int intValue, string stringValue, int intValue2, string stringValue2) : base(intValue, stringValue)
        {
            IntValue2 = intValue2;
            StringValue2 = stringValue2;
        }

        public override int IntValue { get => intValue + 2; set => intValue = value + 2; }


        // use base class version of IntValue Property
        public int IntValue2 { get => intValue2 + base.IntValue; set => intValue2 = value + base.IntValue; }

        public string StringValue2 { get; set; }


        // if method has be overrided, you can call the base class version of method by using base keyword
        public override void PrintState()
        {
            Console.WriteLine("<<< Print Base Class And Sub Class State >>>");
            Console.WriteLine($"IntValu2     = {IntValue2}");
            Console.WriteLine($"StringValue2 = {StringValue2}");
            base.PrintState();
        }

        public void PrintBaseState()
        {
            Console.WriteLine("<<< Print Only Base Class State >>>");
            base.PrintState();

        }




    }

    class TestBaseKeyword
    {
        public static void Test()
        {

            BaseKeywordClass basekey1 = new BaseKeywordClass(10, "String1");

            BaseKeywordSubClass basekey2 = new BaseKeywordSubClass(10, "String1", 20, "String2");

            basekey1.PrintState();
            basekey2.PrintState();


        }

    }

    #endregion

    #region Understanding Abstract Classes

    // ==============================> Understanding Abstract Classes <============================== 
    // ==============================================================================================
    // When a class has been defined as an abstract base class (via the abstract keyword), it may define any
    // number of abstract members.Abstract members can be used whenever you want to define a member that
    // does not supply a default implementation but must be accounted for by each derived class.
    // 
    // By doing so, you enforce a polymorphic interface on each descendant, leaving them to contend 
    // with the task of providing the details behind your abstract methods.
    //
    // Polymorphic Interface: Simply put, an abstract base class’s polymorphic interface simply refers to its set of 
    // virtual and abstract methods.This is much more interesting than first meets the eye because this trait of OOP 
    // allows you to build easily extendable and flexible software applications.
    //
    //
    //
    //



    // abstract class
    abstract class AbstractClass
    {

        // abstract property
        public abstract int AbstractProperty { get; set; }

        // method
        public void Method()
        {
            Console.WriteLine("Method inside Abstract Class");
        }

        // abstract method
        public abstract void AbstractMethod();

    }

    class SubClassOfAbstractClass : AbstractClass
    {
        protected int abstractPropertyField;

        public override int AbstractProperty { get => abstractPropertyField; set => abstractPropertyField = value; }

        public override void AbstractMethod()
        {
            Console.WriteLine("Overridden of AbstractMethod()");
        }

        

    }

    class TestAbstractClasses
    {
        public static void Test()
        {
            AbstractClass abs = new SubClassOfAbstractClass();

            abs.AbstractMethod();
        }
    }

    #endregion

    #region Understanding Member Shadowing
    // ==============================> Understanding Member Shadowing <==============================

    // if you there is a method in the base class and one with the same signature in the subclass:
    // 1- if The base class method is not marked with virtual: shadowig occurs
    // 2- if The sub class method is not marked with override: shadowig occurs
    // 3- if The base class method is not marked with virtual, and The sub class method
    //    is not marked with override: shadowig occurs

    // To prevent ambiguity: c# provide new keyword before method signature, to be aware of Shadowing
    // and if you omit it, you will face Warning



    class BaseMemberShadowing
    {

        public void ShadowingMethod1()
        {
            Console.WriteLine("BaseClass ShadowingMethod1");
        }

        public virtual void ShadowingMethod2()
        {
            Console.WriteLine("BaseClass ShadowingMethod2");
        }

        public void ShadowingMethod3()
        {
            Console.WriteLine("BaseClass ShadowingMethod3");
        }

        public void ShadowingMethod4()
        {
            Console.WriteLine("BaseClass ShadowingMethod3");
        }


    }

    class SubMemberShadowing : BaseMemberShadowing
    {

        // shadowing, as base and sub class methods are not decorated with any of (virtual, override, new)
        public void ShadowingMethod1()
        {
            Console.WriteLine("SubClass ShadowingMethod1");
        }

        // shadowing, as subclass method is not marked as override, even though, base class is marked as virtual
        public void ShadowingMethod2()
        {
            Console.WriteLine("SubClass ShadowingMethod2");
        }

        // shadowing, as base class method is not marked with virtual, even though, sub class method is marked as Override 
        // [NOTE Error will be thrown if you mark subclass version of a method wih override when base class version is not marked as virtual ]
        public void ShadowingMethod3()
        {
            Console.WriteLine("SubClass ShadowingMethod3");
        }


        // shadowing with new keyword to avoid ambiguity
        public new void ShadowingMethod4()
        {
            Console.WriteLine("SubClass ShadowingMethod3");
        }



    }

    class TestMemberShadowing
    {
        public static void Test()
        {
            BaseMemberShadowing mybase = new SubMemberShadowing();
            // you can find that polymorphic behaviour is not occured
            mybase.ShadowingMethod1();
            mybase.ShadowingMethod2();
            mybase.ShadowingMethod3();
            mybase.ShadowingMethod4();

            Console.WriteLine();
            SubMemberShadowing mysub = (SubMemberShadowing) mybase;
            // you can find that polymorphic behaviour is not occured
            mysub.ShadowingMethod1();
            mysub.ShadowingMethod2();
            mysub.ShadowingMethod3();
            mysub.ShadowingMethod4();


        }

    }




    #endregion

    #region Understanding Base Class/Derived Class Casting Rules, as and is keywords

    // ==============================> Understanding Base Class/Derived Class Casting Rules <==============================

    class BaseClass4
    {
        public virtual void VirtualMethod()
        {
            Console.WriteLine("Base Class Virtual Method");
        }


        public void ShadowingMethod()
        {
            Console.WriteLine("Base Class Shadowing method");
        }


    }

    class SubClass41 : BaseClass4
    {
        public override void VirtualMethod()
        {
            Console.WriteLine("Sub class 1 Overrided Method");
        }

        public new void ShadowingMethod()
        {
            Console.WriteLine("Sub Class 1 Shadowing method");
        }
    }

    class SubClass42 : BaseClass4
    {
        public override void VirtualMethod()
        {
            Console.WriteLine("Sub class 2 Overrided Method");
        }

        public new void ShadowingMethod()
        {
            Console.WriteLine("Sub class 2 Shadowing method");
        }
    }


    class TestCastingRules
    {
        public static void Test()
        {
            Console.WriteLine("<<<<<<< Understanding Base Class/Derived Class Casting Rules >>>>>>>>");

            // Implicit Up Casting , as it is safe casting, you don't need to use cast operator
            // -----------------------------------------------
            Console.WriteLine("================== Base Class Reference to Sub class 1 =======================");
            BaseClass4 baseReference = new SubClass41();
            baseReference.VirtualMethod();
            baseReference.ShadowingMethod();

            // Explicit Down Casting, to down the reference to the lower classes (Derived Classes), you need to use Casting Operator
            // as the casting is not safe, my be reference of base class references derived class that is not you want to convert to.
            // -----------------------------------------------
            Console.WriteLine("================== Convert Base Class 1 Reference To Sub Class 1 Reference =======================");
            SubClass41 subReference = (SubClass41)baseReference;
            baseReference.VirtualMethod();
            baseReference.ShadowingMethod();

            // Implicit Up Casting, as it is safe casting, you don't need to use cast operator.
            // -----------------------------------------------
            Console.WriteLine("================== Convert Sub Class 1 Reference To Base Class 1 =======================");
            //BaseClass4 baseReference2 = subReference;
            BaseClass4 baseReference2 = (BaseClass4)subReference;
            baseReference2.VirtualMethod();
            baseReference2.ShadowingMethod();


            // Implicit Up Casting, as it is safe casting, you don't need to use cast operator.
            // -----------------------------------------------
            Console.WriteLine("================== Base Class Reference to Sub class 2 =======================");
            BaseClass4 baseReferenceToSub42 = new SubClass42();
            baseReferenceToSub42.VirtualMethod();
            baseReferenceToSub42.ShadowingMethod();



            // Casting Error , you can't cast from subclass1 to subclass2
            // -----------------------------------------------
            Console.WriteLine("================== Invalid Cast =======================");
            SubClass42 subReference42 = new SubClass42();
            //System.InvalidCastException: Unable to cast object of type 'SubClass41' to type 'SubClass42'.
            // subReference42 = (SubClass42)subReference;


            try
            {
                // System.InvalidCastException: 'Unable to cast object of type 'SubClass41' to type 'SubClass42'.'
                subReference42 = (SubClass42)baseReference;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }

    // ==============================> as keyword <==============================
    class TestAsKeyword
    {
        public static void Test()
        {
            // ==============================> as keyword <==============================
            // if we need to prevent exceptions we can use as keyword

            object[] things = new object[4];
            things[0] = 10;
            things[1] = new SubClass41();
            things[2] = 10.23;
            things[3] = new SubClass42();

            // we need now to perform operation in BaseClass4 Drived classes Methods

            foreach (var item in things)
            {
                // using that code we need try catch stmt to catch InvaledCastingException
                // as in things array there are many items that are not BaseClass4
                // BaseClass4 baseRef = (BaseClass4)item;
                // baseRef.VirtualMethod();

                // instead, we use as keyword that cast item if it is castable, otherwise returns null
                // and this approach is much faster than Exceptions Throwing
                BaseClass4 baseRef = item as BaseClass4;


                // check if null 
                if (baseRef != null)
                {
                    // your operation on subclasses goes here!!
                    baseRef.VirtualMethod();
                }


            }
        }

    }


    // ==============================> is keyword <==============================
    class TestIsKeyword
    {
        public static void Test()
        {
            // ==============================> is keyword <==============================
            // In addition to the as keyword, the C# language provides the is keyword to determine whether two items are
            // compatible.Unlike the as keyword, however, the is keyword returns false, rather than a null reference, if
            // the types are incompatible.

            object[] things = new object[4];
            things[0] = 10;
            things[1] = new SubClass41();
            things[2] = 10.23;
            things[3] = new SubClass42();

            // then we use is keyword that returns true if types are compatble, otherwise, returns false
            // then we need to cast our item to make our operation

            foreach (var item in things)
            {
                if (item is BaseClass4)
                {
                    BaseClass4 baseRef = (BaseClass4)item;
                    baseRef.VirtualMethod();
                }


            }

            // note that in the previous example, there are casting check, then we done our casting,
            // and in that way there are to casting: first in check, then if is keyword returns true
            // you make your cast.

            // New in C# 7, the is keyword can also assign the converted type to a variable if the cast works. This cleans
            // up the preceding method by preventing the “double-cast” problem.In the preceding example, the first cast
            // is done when checking to see whether the type matches, and if it does, then the variable has to be cast again.
            foreach (var item in things)
            {
                if (item is BaseClass4 baseRef)
                {
                    baseRef.VirtualMethod();
                }


            }


        }

    }


    #endregion

    #region Pattern Matching in Switch Statements

    // NOTE: Discards with the is Keyword (New) used with if and switch statements

    #endregion

    #region Employee Example on OOP

    // ==============================> Employee Example on OOP <==============================
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
        public Employee() : this("EmpSSN", "EmpName", 30, 2000.00F)
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
    #endregion

    #region The Master Parent Class: System.Object
    // ==============================> The Master Parent Class: System.Object <==============================
    // ======================================================================================================
    // In the.NET universe, every type ultimately derives from a base class named System.Object, which can
    // be represented by the C# object keyword (lowercase o). The Object class defines a set of common members
    // for every type in the framework.In fact, when you do build a class that does not explicitly define its parent,
    // the compiler automatically derives your type from Object.If you want to be clear in your intentions, you are
    // free to define classes that derive from Object as follows(however, again, there is no need to do so) :
    // Here we are explicitly deriving from System.Object.
    class MyClass : object
    {

    }


    // Like any class, System.Object defines a set of members.In the following formal C# definition, note
    // that some of these items are declared virtual, which specifies that a given member may be overridden by a
    // subclass, while others are marked with static (and are therefore called at the class level):

    // ==============================> Object Class Members <==============================
    //
    // Constructor
    // ----------------------------------------
    //      public Object();
    // 
    // Destructor
    // ----------------------------------------
    //      ~Object();
    // 
    // Static Members
    // ----------------------------------------
    //      public static bool Equals(Object objA, Object objB);
    //      public static bool ReferenceEquals(Object objA, Object objB);
    // 
    // Virtual Members
    // ----------------------------------------
    //      public virtual bool Equals(Object obj);
    //      public virtual int GetHashCode();
    //      public virtual string ToString();
    // 
    // Instance Members , Non-Virtual Members
    // ----------------------------------------
    //      public Type GetType();
    //      protected Object MemberwiseClone();

    // ==============================> Core Members of System.Object <==============================
    //Instance Method of Object Class with Meaning in Life
    // ---------------------------------------------------

    // Equals() 
    // ------------------------------------------------------------------------------------------
    // By default, this method returns true only if the items being
    // compared refer to the same item in memory.Thus, Equals() is used
    // to compare object references, not the state of the object. Typically,
    // this method is overridden to return true only if the objects being
    // compared have the same internal state values(that is, value-based
    // semantics).
    // 
    // Be aware that if you override Equals(), you should also override
    // GetHashCode(), as these methods are used internally by Hashtable
    // types to retrieve subobjects from the container.
    // Also recall from Chapter 4 that the ValueType class overrides
    // this method for all structures, so they work with value-based
    // comparisons.


    // Finalize() or ~Object()
    // ------------------------------------------------------------------------------------------
    // For the time being, you can understand this method (when
    // overridden) is called to free any allocated resources before the
    // object is destroyed.I talk more about the CLR garbage collection
    // services in Chapter 9.

    // GetHashCode() 
    // ------------------------------------------------------------------------------------------
    // This method returns an int that identifies a specific object instance.


    // ToString() 
    // ------------------------------------------------------------------------------------------
    // This method returns a string representation of this object, using
    // the <namespace>.<type name> format(termed the fully qualified
    // name). This method will often be overridden by a subclass to return
    // a tokenized string of name/value pairs that represent the object’s
    // internal state, rather than its fully qualified name.

    // GetType() 
    // ------------------------------------------------------------------------------------------
    // This method returns a Type object that fully describes the object
    // you are currently referencing.In short, this is a Runtime Type
    // Identification (RTTI) method available to all objects (discussed in
    // greater detail in Chapter 15).

    // MemberwiseClone() 
    // ------------------------------------------------------------------------------------------
    // This method exists to return a member-by-member copy of the
    // current object, which is often used when cloning an object
    // (see Chapter 8).

    // ===========================================================================================

    class Person
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public Person() : this("Person Name",20)
        {

        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void PrintPersonInfo()
        {
            Console.WriteLine($"{nameof(Name)} = {Name}");
            Console.WriteLine($"{nameof(Age)} = {Age}");
        }

    }

    // ==============================> Override ToString() Virtual Method <==============================

    class Person2: Person
    {
        public Person2()
        {
        }

        public Person2(string name, int age) : base(name, age)
        {
        }

        public override string ToString()
        {
            //return base.ToString();

            return $"Person [Name:{Name}, Age:{Age}]";
        }
    }


    // ==============================> Overriding System.Object.Equals() <==============================
    // Let’s also override the behavior of Object.Equals() to work with value-based semantics.Recall that by
    // default, Equals() returns true only if the two objects being compared reference the same object instance in
    // memory.
    class Person3 : Person
    {
        public Person3()
        {
        }

        public Person3(string name, int age) : base(name, age)
        {
        }

        // Override Equals to work with Value-based semantics.
        public override bool Equals(object obj)
        {
            //return base.Equals(obj);

            if (obj is Person3 p3 && obj != null)
            {
                return (this.Name == p3.Name && this.Age == p3.Age) ? true : false;
            }
            else
                return false;
        }
    }


    // another approach to make Equals() value-based semantic, is to override ToString() Method and Used it inside Equals()
    // to compare two Objects of Persons.
    // and in this way, we avoid Casting
    class Person4 : Person
    {
        public Person4()
        {
        }

        public Person4(string name, int age) : base(name, age)
        {
        }

        public override string ToString()
        {
            return $"Person[Name: {Name}, Age: {Age}]";
        }

        // Override Equals to work with Value-based semantics depends on ToString().
        public override bool Equals(object obj)
        {
            //return base.Equals(obj);

            return this.ToString() == obj?.ToString();
        }
    }


    // ==============================> Overriding System.Object.GetHashCode() <==============================
    // When a class overrides the Equals() method, you should also override the default implementation of
    // GetHashCode(). Simply put, a hash code is a numerical value that represents an object as a particular state.For
    // example, if you create two string variables that hold the value Hello, you would obtain the same hash code.
    // However, if one of the string objects were in all lowercase(hello), you would obtain different hash codes.

    // By default, System.Object.GetHashCode() uses your object’s current location in memory to yield the
    // hash value.However, if you are building a custom type that you intend to store in a Hashtable type (within
    // the System.Collections namespace), you should always override this member, as the Hashtable will be
    // internally invoking Equals() and GetHashCode() to retrieve the correct object.

    // 
    class Person5 : Person
    {
        public string Ssn { get; set; }
        public Person5()
        {
            Ssn = "000000000000000";
        }

        public Person5(string ssn, string name, int age) : base(name, age)
        {
            Ssn = ssn;
        }

        public override string ToString()
        {
            return $"Person[SSN:{Ssn}, Name: {Name}, Age: {Age}]";
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj?.ToString();
        }

        public override int GetHashCode()
        {
            // if we have a unique value for each object like ssn and id, we can depends on it to get unique HashCode()
            //return Ssn.GetHashCode();

            // another way is to use overrrided ToString() Method that never returns the same string 
            // except if the two objects is identical
            return ToString().GetHashCode();

            // or use one of hasing algorithms
        }



    }

    // ==============================> The Static Members of System.Object <==============================
    // public static bool Equals(Object objA, Object objB);
    //      it is depends on objects type entered to it, value-based, or Reference-based
    //
    // public static bool ReferenceEquals(Object objA, Object objB);
    //      it checks for reference in equality

    class TestObjectStaticMembers
    {
        public static void Test()
        {
            Person5 p1 = new Person5("12345678","Moamen",20);
            Person5 p2 = new Person5("12345678","Moamen",20);
            Person5 p3 = new Person5("91919191", "Shady",22);

            Console.WriteLine();
            Console.WriteLine("equality of p1 and p2");
            CheckEquals(p1, p2);

            Console.WriteLine();
            Console.WriteLine("equality of p1 and p3");
            CheckEquals(p1, p3);

            // the both are referenceEquals
            Person5 p4 = p1;
            Person5 p5 = p1;

            Console.WriteLine();
            Console.WriteLine("equality of p4 and p5");
            CheckEquals(p4, p5);

            // the both are referenceEquals
            Person5 p6 = p3;
            Person5 p7 = p3;

            Console.WriteLine();
            Console.WriteLine("equality of p6 and p7");
            CheckEquals(p6, p7);


        }

        public static void CheckEquals(Person5 p1, Person5 p2)
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine($"object.Equals = {object.Equals(p1, p2)}");
            Console.WriteLine($"object.ReferenceEquals = {object.ReferenceEquals(p1, p2)}");

        }


    }

    class TestMasterClass
    {
        public static void Test()
        {
            Person p1 = new Person();
            p1.PrintPersonInfo();
            // object inherted members
            Console.WriteLine($" p1.GetType() : {p1.GetType()}");
            Console.WriteLine($"p1.GetHashCode() : {p1.GetHashCode()}");
            Console.WriteLine($"p1.ToString() : {p1.ToString()}");

            Console.WriteLine("Person After Override ToString()");
            Console.WriteLine("================================");
            Person2 p2 = new Person2("Mohammed" , 24);
            Console.WriteLine(p2);

            Console.WriteLine();
            Console.WriteLine("Person After Override Equals()");
            Console.WriteLine("================================");

            Person3 p3 = new Person3("Mohammed", 24);
            Person3 p32 = new Person3("Mohammed", 24);
            Person3 p33 = new Person3("Shady", 25);

            Console.WriteLine("p3.Equals(p32) = " + p3.Equals(p32));
            Console.WriteLine("p3.Equals(p33) = " + p3.Equals(p33));

            Console.WriteLine();
            Console.WriteLine("Person After Override Equals() using ToString() Method");
            Console.WriteLine("================================");
            Person4 p4 = new Person4("Mohammed", 24);
            Person4 p45 = new Person4("Mohammed", 24);
            Person4 p46 = new Person4("Shady", 25);

            Console.WriteLine("p4.Equals(p45) = " + p4.Equals(p45));
            Console.WriteLine("p4.Equals(p46) = " + p4.Equals(p46));



            Console.WriteLine("==============> Test Object Static Members <===================");
            TestObjectStaticMembers.Test();

        }

    }

    #endregion

    static class OOPTraining
    {
        public static void TestOOP()
        {
            //TestBaseKeyword.Test();
            //TestVirtualKeword.Test();
            //TestAbstractClasses.Test();
            //TestMemberShadowing.Test();
            //TestCastingRules.Test();
            //TestAsKeyword.Test();
            //TestIsKeyword.Test();
            TestMasterClass.Test();

        }
    }
}