using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpCode.AnonymousTypes
{
    //    Defining an Anonymous Type
    // ===========================================================================
    // When you define an anonymous type, you do so by using the var keyword(see Chapter 3) in conjunction
    // with object initialization syntax(see Chapter 5). You must use the var keyword because the compiler will
    // automatically generate a new class definition at compile time(and you never see the name of this class in
    // your C# code). The initialization syntax is used to tell the compiler to create private backing fields and 
    // (readonly) properties for the newly created type.

    //    So, at this point, simply understand that anonymous types allow you to quickly model the “shape” of
    //data with very little overhead. This technique is little more than a way to whip up a new data type on the fly,
    //which supports bare-bones encapsulation via properties and acts according to value-based semantics

    //    The Internal Representation of Anonymous Types
    // ============================================================================
    //All anonymous types are automatically derived from System.Object and, therefore, support each of the
    //members provided by this base class. Given this, you could invoke ToString(), GetHashCode(), Equals(),
    //or GetType()

    // if you have the next anon type
    // var myCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
    //    The following C# code approximates the compiler-generated class used to represent the myCar object
    //(which again can be verified using ildasm.exe):
    // ---------------------------------------------------------------------------------------------
    //  internal sealed class <>f__AnonymousType0<<Color>j__TPar,
    //  <Make>j__TPar, <CurrentSpeed>j__TPar>
    //  {
    //      // Read-only fields.
    //      private readonly <Color>j__TPar<Color> i__Field;
    //      private readonly <CurrentSpeed>j__TPar<CurrentSpeed> i__Field;
    //      private readonly <Make>j__TPar<Make> i__Field;
    //      // Default constructor.
    //      public <>f__AnonymousType0(<Color>j__TPar Color,
    //      <Make>j__TPar Make, <CurrentSpeed>j__TPar CurrentSpeed);
    //      // Overridden methods.
    //      public override bool Equals(object value);
    //      public override int GetHashCode();
    //      public override string ToString(); 
    //      
    //      // Read-only properties.
    //      public <Color>j__TPar Color { get; }
    //      public <CurrentSpeed>j__TPar CurrentSpeed { get; }
    //      public <Make>j__TPar Make { get; }
    //  }
    // ---------------------------------------------------------------------------------------------
    // Perhaps most important, notice that each name-value pair defined using the object initialization syntax
    // is mapped to an identically named read-only property and a corresponding private read-only backing field.

    //    The Implementation of ToString() , GetHashCode() and Equals()
    // ===============================================================================================
    //All anonymous types automatically derive from System.Object and are provided with an overridden version
    //of Equals(), GetHashCode(), and ToString(). The ToString() implementation simply builds a string from
    //each name-value pair.Here’s an example:
    // ---------------------------------------------------------------------------------------------
    //  public override string ToString()
    //  {
    //      StringBuilder builder = new StringBuilder();
    //      builder.Append("{ Color = ");
    //      builder.Append(this.< Color > i__Field);
    //      builder.Append(", Make = ");
    //      builder.Append(this.< Make > i__Field);
    //      builder.Append(", CurrentSpeed = ");
    //      builder.Append(this.< CurrentSpeed > i__Field);
    //      builder.Append(" }");
    //      return builder.ToString();
    //  }
    // ---------------------------------------------------------------------------------------------
    // The GetHashCode() implementation computes a hash value using each anonymous type’s
    // member variables as input to the System.Collections.Generic.EqualityComparer<T> type.Using this
    // implementation of GetHashCode(), two anonymous types will yield the same hash value if (and only if)
    //they have the same set of properties that have been assigned the same values.Given this implementation,
    //anonymous types are well-suited to be contained within a Hashtable container.
    //
    // The Equals() is overrided to act according to value-based semantics. 
    // but == and != operators still work with Reference-based semantics.

    // Use Case of Anonymous Types
    // ============================================================================================
    // but you might still be wondering exactly where(and when) to use this new language feature.To be blunt, anonymous type
    //declarations should be used sparingly, typically only when making use of the LINQ technology set
    // You would never want to abandon the use of strongly typed classes/structures simply for
    //the sake of doing so, given anonymous types’ numerous limitations, which include the following:
    //•	 You don’t control the name of the anonymous type.
    //•	 Anonymous types always extend System.Object.
    //•	 The fields and properties of an anonymous type are always read-only(Immutable).
    //•	 Anonymous types cannot support events, custom methods, custom operators, or custom overrides.
    //•	 Anonymous types are always implicitly sealed.
    //•	 Anonymous types are always created using the default constructor.
    //However, when programming with the LINQ technology set, you will find that in many cases this syntax
    //can be helpful when you want to quickly model the overall shape of an entity rather than its functionality.


    static class MyAnonymousTypes
    {
        public static void Test()
        {
            Console.WriteLine("***** Fun with Anonymous Types *****\n");

            // Make an anonymous type representing a car using hard coded data. 
            var myCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };

            // Reflect over what the compiler generated.
            ReflectOverAnonymousType(myCar);

            // Now show the color and make.
            Console.WriteLine("My car is a {0} {1}.", myCar.Color, myCar.Make);

            // Now call our helper method to build anonymous type via args. 
            BuildAnonType("BMW", "Black", 90);

            EqualityTest();

        }

        static void BuildAnonType(string make, string color, int currSp)
        {
            // Build anon type using incoming args. 
            var car = new { Make = make, Color = color, Speed = currSp };

            // Note you can now use this type to get the property data!
            Console.WriteLine("You have a {0} {1} going {2} MPH",
              car.Color, car.Make, car.Speed);

            // Anon types have custom implementations of each virtual 
            // method of System.Object. For example:
            Console.WriteLine("ToString() == {0}", car.ToString());
        }

        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of: {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}", obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("obj.ToString() == {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());
            Console.WriteLine();
        }

        static void EqualityTest()
        {
            // Make 2 anonymous classes with identical name/value pairs.
            // when the two anonymous types have the same property name with the same order
            // the compiler consider them instance of the same anonymous type, 
            // and if values are the same, Equals() will results true, but == and != Operators will 
            // results false, This Result is because anonymous types do not receive overloaded 
            // versions of the C# equality operators (== and !=).
            var firstCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
            var secondCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };

            // Are they considered equal when using Equals()?
            if (firstCar.Equals(secondCar))
                Console.WriteLine("Same anonymous object!");
            else
                Console.WriteLine("Not the same anonymous object!");

            // Are they considered equal when using ==?
            if (firstCar == secondCar)
                Console.WriteLine("Same anonymous object!");
            else
                Console.WriteLine("Not the same anonymous object!");

            // Are these objects the same underlying type?
            if (firstCar.GetType().Name == secondCar.GetType().Name)
                Console.WriteLine("We are both the same type!");
            else
                Console.WriteLine("We are different types!");

            // Show all the details.
            Console.WriteLine();
            ReflectOverAnonymousType(firstCar);
            ReflectOverAnonymousType(secondCar);
        }

        public static void AnonymousTypeInsideAnotherAnonymousType()
        {
            var purcaseItem = new
            {
                TimeBought = DateTime.Now,
                ItemBought = new { Color = "Red", Make = "Saab", CurrentSpeed = 55 },
                Price = 34.000
            };

            Console.WriteLine("ToString() == {0}", purcaseItem.ToString());

            ReflectOverAnonymousType(purcaseItem);
        }




        public static void IdentityOfAnonymousObject()
        {

            var obj1 = new{ Id = 1, Name = "Moamen" };
            // another object create but order of properties changed;
            var another1 = new { Name = "Moamen", Id = 1 };


            var obj2 = new { Id = 2, Name = "Ahmed" };
            // another object create but order of properties changed;
            var another2 = new { Name = "Ahmed", Id = 2 };

            




            Console.WriteLine(obj1.GetType().Name);
            Console.WriteLine(another1.GetType().Name);

            Console.WriteLine(obj2.GetType().Name);
            Console.WriteLine(another2.GetType().Name);


            // equals will not work with different anonymous types
            Console.WriteLine(obj1.Equals(another1));

            // equals will not work with different anonymous types
            Console.WriteLine(obj2.Equals(another1));



        }



    }


    //    Remarks - Summary
    // =============================================================================================
    // Anonymous types are class types that derive directly from object, and that cannot be cast to any type 
    // except object. The compiler provides a name for each anonymous type, although your application cannot 
    // access it.From the perspective of the common language runtime, an anonymous type is no different 
    // from any other reference type.
    // If two or more anonymous object initializers in an assembly specify a sequence of properties that 
    // in the same order and that have the same names and types, the compiler treats the objects as instances
    // of the same type.They share the same compiler-generated type information.
    //
    // You cannot declare a field, a property, an event, or the return type of a method as having an type. 
    // Similarly, you cannot declare a formal parameter of a method, property, constructor, or indexer as 
    // having an anonymous type. To pass an anonymous type, or a collection that contains anonymous types, 
    // as an argument to a method, you can declare the parameter as type object. However, doing this defeats 
    // the purpose of strong typing. If you must store query results or pass them outside the method boundary, 
    // consider using an ordinary named struct or class instead of an anonymous type.
    // Because the Equals and GetHashCode methods on anonymous types are defined in terms of the Equals 
    // GetHashCode methods of the properties, two instances of the same anonymous type are equal only if 
    // all their properties are equal (with the same name and the same order).
    // ====================================================================================================

    // Two Anynomous types are from the same type if they are with the same property name and 
    // the property type type the same property order
}
