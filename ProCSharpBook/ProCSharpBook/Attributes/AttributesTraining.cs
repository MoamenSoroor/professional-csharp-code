using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using ProCSharpBook.ReflectionTraining;

// Assembly Attributes
[assembly: CLSCompliant(true)]

namespace ProCSharpBook.Attributes
{
    class AttributesTraining
    {

    }

    #region Understanding the Role of .NET Attributes
    // ------------------------ Understanding the Role of .NET Attributes -------------------------
    // attributes are nothing more than code annotations that can be applied to a given
    // type(class, interface, structure, etc.), member(property, method, etc.), assembly, or module

    //.NET attributes are class types that extend the abstract System.Attribute base class. 

    // As you explore the.NET namespaces, you will find many predefined attributes that you are able to use in your applications.
    //Furthermore, you are free to build custom attributes to further qualify the behavior of your types by creating
    //a new type deriving from Attribute

    // Table 15-3. A Tiny Sampling of Predefined Attributes
    // Attribute         Meaning in Life

    // [CLSCompliant]    Enforces the annotated item to conform to the rules of the Common Language
    //                   Specification(CLS). Recall that CLS-compliant types are guaranteed to be used
    //                   seamlessly across all.NET programming languages.

    // [DllImport]       Allows.NET code to make calls to any unmanaged C- or C++-based code
    //                   library, including the API of the underlying operating system. Do note that
    //                   [DllImport] is not used when communicating with COM-based software.

    // [Obsolete]        Marks a deprecated type or member. If other programmers attempt to use such
    //                   an item, they will receive a compiler warning describing the error of their ways.

    // [Serializable]    Marks a class or structure as being “serializable,” meaning it is able to persist its
    //                   current state into a stream.

    // [NonSerialized]   Specifies that a given field in a class or structure should not be persisted during
    //                   the serialization process.

    // [ServiceContract] Marks a method as a contract implemented by a WCF service.
    // ------------------------------------------------------------------------------------------------------------

    // ---------------<<< Note >>>-------------------
    // Understand that when you apply attributes in your code, the embedded metadata is essentially useless
    // until another piece of software explicitly reflects over the information.If this is not the case, the blurb of
    // metadata embedded within the assembly is ignored and completely harmless.
    // ----------------------------------------------

    // at this point, you should understand the following key points regarding .NET attributes:
    // - Attributes are classes that derive from System.Attribute.
    // - Attributes result in embedded metadata.
    // - Attributes are basically useless until another agent reflects upon them.
    // - Attributes are applied in C# using square brackets.



    // --------------------------------------------------------------------------------------------
    #endregion

    #region Attributes Consumers
    // ------------------------ Attributes Consumers -------------------------
    // Attribute Consumers
    // As you would guess, the .NET 4.7 Framework SDK ships with numerous utilities that are indeed on the
    // lookout for various attributes.The C# compiler (csc.exe) itself has been preprogrammed to discover the
    // presence of various attributes during the compilation cycle.For example, if the C# compiler encounters the
    // [CLSCompliant] attribute, it will automatically check the attributed item to ensure it is exposing only 
    // CLScompliant constructs. 
    // By way of another example, if the C# compiler discovers an item attributed with the [Obsolete] attribute, 
    // it will display a compiler warning in the Visual Studio Error List window.
    // In addition to development tools, numerous methods in the.NET base class libraries are
    // preprogrammed to reflect over specific attributes.For example, if you want to persist the state of an object
    // to file, all you are required to do is annotate your class or structure with the[Serializable] attribute.If the
    // Serialize() method of the BinaryFormatter class encounters this attribute, the object is automatically
    // persisted to file in a compact binary format.
    // Finally, you are free to build applications that are programmed to reflect over your own custom
    // attributes, as well as any attribute in the.NET base class libraries. By doing so, you are essentially able to
    // create a set of “keywords” that are understood by a specific set of assemblies.
    // -------------------------------------------------------------------------
    #endregion


    #region Applying Attributes in C#
    // ------------------------ Applying Attributes in C# -------------------------

    // This class can be saved to disk.
    [Serializable]
    public class Motorcycle
    {
        // However, this field will not be persisted.
        [NonSerialized]
        float weightOfCurrentPassengers;
        // These fields are still serializable.
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }

    // apply Obsolete attribute to class type --
    [Obsolete]
    class MyOldType
    {
        public MyOldType()
        {

        }
        // ...
    }

    

    public class ApplyingAttributes
    {
        // Test Method
        public static void Test()
        {


        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Multiple Attributes within a Single Item
    // ------------------------ Multiple Attributes applied with a Single Item -------------------------
    // As you might guess, a single item can be attributed with multiple attributes. 
    // To apply multiple attributes to a single item, simply use a comma-delimited list.

    // A two attributes applied to Type !!
    [Serializable, Obsolete("Use another vehicle!")]
    public class HorseAndBuggy
    {
        // ...
    }


    // As an alternative, you can also apply multiple attributes on a single item by 
    // stacking each attribute as follows(the end result is identical) :

    // the same as comma-delimited list
    [Serializable]
    [Obsolete("Use another vehicle!")]
    public class HorseAndBuggy2
    {
        // ...
    }
    // --------------------------------------------------------------
    #endregion


    #region C# Attribute Shorthand Notation
    // ------------------------ C# Attribute Shorthand Notation -------------------------
    // As a naming convention, all .NET attributes(including custom attributes you may create yourself)
    // are suffixed with the Attribute token. However, to simplify the process of applying attributes, 
    // the C# language does not require you to type in the Attribute suffix.
    
    
    [SerializableAttribute] // only in c#, the same as [Serializable]
    [ObsoleteAttribute("Use another vehicle!")] // only in c#, the same as [Obsolete("Use another vehicle!")]
    public class HorseAndBuggy3
    {
        // ...
    }

    // ---------------<<< Note >>>-------------------
    // Be aware that this is a courtesy provided by C#. Not all .NET-enabled languages support this shorthand
    // attribute syntax.
    // ----------------------------------------------


    // --------------------------------------------------------------
    #endregion

    #region Specifying Constructor Parameters for Attributes
    // ------------------------ Specifying Constructor Parameters for Attributes -------------------------
    [Serializable]
    [Obsolete("Use another vehicle!")] // Notice  Constructor String Parameter
    public class HorseAndBuggy4
    {
        // ...
    }

    // Notice that the[Obsolete] attribute is able to accept what appears to be a constructor parameter.If you view
    // the formal definition of the[Obsolete] attribute by right-clicking the item in the code editor and selecting
    // the Go To Definition menu option, you will find that this class indeed provides a constructor receiving a
    // System.String.
    // ------------------------------------------------------------------------------
    // public sealed class ObsoleteAttribute : Attribute
    // {
    //     public ObsoleteAttribute(string message, bool error);
    //     public ObsoleteAttribute(string message);
    //     public ObsoleteAttribute();
    //     public bool IsError { get; }
    //     public string Message { get; }
    // }
    // ===============================================================================

    // NOTE: ----------------------------------------------------------------------------------------------
    // Understand that when you supply constructor parameters to an attribute, the attribute is not allocated
    // into memory until the parameters are reflected upon by another type or an external tool.The string data
    // defined at the attribute level is simply stored within the assembly as a blurb of metadata.
    // ----------------------------------------------------------------------------------------------------

    // The Obsolete Attribute in Action
    // Now that HorseAndBuggy has been marked as obsolete, if you were to allocate an instance of this type:

    class RunHorseAndBuggy
    {
        void UseHorseAndBuggy()
        {

            HorseAndBuggy4 mule = new HorseAndBuggy4();
        }
    }

    // you would find that the supplied string data is extracted and displayed within the Error List window of Visual
    // Studio, as well as on the offending line of code when you hover your mouse cursor above the obsolete type

    // --------------------------------------------------------------
    #endregion

    #region Building, Applying, and Consuming Custom Attributes
    // ------------------------ Building, Applying, and Consuming Custom Attributes -------------------------
    
    // ======================= Building A Custom Attributes ===========================
    // A custom attribute.
    public sealed class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public VehicleDescriptionAttribute(string vehicalDescription) => Description = vehicalDescription;
        public VehicleDescriptionAttribute() { }

    }

    // ■ Note for security reasons, it is considered a.net best practice to design all custom attributes as sealed.
    //   in fact, Visual studio provides a code snippet named Attribute that will dump out a 
    //   new System.Attributederived class into your code window.

    // ======================= Applying Custom Attributes ===========================
    // Given that VehicleDescriptionAttribute is derived from System.Attribute, you are now able to annotate
    // your vehicles as you see fit.For testing purposes, add the following class definitions to your new class library :

    // Assign description using a "named property."
    [Serializable]
    [VehicleDescription(Description = "My rocking Harley")]     // using Named Property like Named Parameters
    public class Motorcycle2
    { 
        
    }

    [Serializable]
    [Obsolete("Use another vehicle!")]
    [VehicleDescription("The old gray mare, she ain't what she used to be...")]
    public class HorseAndBuggy5
    { 
        
    }

    [VehicleDescription("A very long, slow, but feature-rich auto")]
    public class Winnebago
    { 

    }

    // ------------------------ Named Property Syntax -------------------------
    // Notice that the description of the Motorcycle is assigned a description using a new bit of attribute- centric
    // syntax termed a named property.In the constructor of the first[VehicleDescription] attribute, you set the
    // underlying string data by using the Description property.If this attribute is reflected upon by an external
    // agent, the value is fed into the Description property (named property syntax is legal only if the attribute
    // supplies a writable.NET property).
    [VehicleDescription(Description = "My rocking Harley")]     // using Named Property like Named Parameters
    public class Motorcycle3
    {
        // ...
    }

    // --------------------------------------------------------------
    #endregion


    #region Restricting Attribute Usage
    // ------------------------ Restricting Attribute Usage -------------------------
    // you may want to build a custom attribute that can be applied only to select code elements.If you want 
    // to constrain the scope of a custom attribute, you will need to apply the[AttributeUsage] attribute on 
    // the definition of your custom attribute.The [AttributeUsage] attribute allows you to supply any 
    // combination of values (via an OR operation) from the AttributeTargets enumeration, like so:

    // This enumeration defines the possible targets of an attribute.
    // --------------------------------------------------------------
    // public enum AttributeTargets
    // {
    //     All, Assembly, Class, Constructor,
    //     Delegate, Enum, Event, Field, GenericParameter,
    //     Interface, Method, Module, Parameter,
    //     Property, ReturnValue, Struct
    // }
    // ==============================================================

    // AllowMultiple and Inherited named property within [AttributeUsage]
    // ------------------------------------------------------------------
    // Furthermore, [AttributeUsage] also allows you to optionally set a named property(AllowMultiple)
    // that specifies whether the attribute can be applied more than once on the same item(the default is false).
    // As well, [AttributeUsage] allows you to establish whether the attribute should be inherited by derived
    // classes using the Inherited named property(the default is true).
    // To establish that the[VehicleDescription] attribute can be applied only once on a class or structure,
    // you can update the VehicleDescriptionAttribute definition as follows:

    // This time, we are using the AttributeUsage attribute
    // to annotate our custom attribute.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class VehicleDescription2Attribute : System.Attribute
    {
        // ...
    }

    // With this, if a developer attempted to apply the [VehicleDescription] attribute on anything other than
    // a class or structure, he or she is issued a compile-time error.

    // use attribute Code Snippet

    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class MyAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string positionalString;

        // This is a positional argument
        public MyAttribute(string positionalString)
        {
            this.positionalString = positionalString;

            // TODO: Implement code here

            throw new NotImplementedException();
        }

        public string PositionalString
        {
            get { return positionalString; }
        }

        // This is a named argument
        public int NamedInt { get; set; }
    }

    // --------------------------------------------------------------
    #endregion

    #region Assembly-Level Attributes
    // ------------------------ Assembly-Level Attributes -------------------------
    // Assembly-Level Attributes
    // It is also possible to apply attributes on all types within a given assembly using the [assembly:] tag.For
    // example, assume you want to ensure that every public member of every public type defined within your
    // assembly is CLS compliant.

    // To do so, simply add the following assembly-level attribute at the top of any C# source code file. Be
    // aware that all assembly- or module-level attributes must be listed outside the scope of any namespace
    // scope! If you add assembly- or module-level attributes to your project, here is a recommended file layout to
    // follow:
    // -------------------------------------------------------------------------------------------------
    //
    //  // List "using" statements first.
    //  using System;
    //  using System.Collections.Generic;
    //  using System.Linq;
    //  using System.Text;

    //  // Now list any assembly- or module-level attributes.
    //  // Enforce CLS compliance for all public types in this assembly.
    //  [assembly: CLSCompliant(true)]

    //  // Now, your namespace(s) and types.
    //  namespace AttributedCarLibrary
    //  {
    //      // Types...
    //  }
    // =================================================================================================

    // If you now add a bit of code that falls outside the CLS specification(such as an exposed 
    // point of unsigned data):

    // Ulong types don't jibe with the CLS.
    public class Winnebago2
    {
        public ulong notCompliant; // you are issued a compiler warning.
    }

    // LOOK at the top of File you will see the example 

    // --------------------------------------------------------------
    #endregion

    #region The Visual Studio AssemblyInfo.cs File
    // ------------------------ The Visual Studio AssemblyInfo.cs File -------------------------
    // This file is a handy place to put attributes that are to be applied at the assembly level.You might recall
    // from Chapter 14, during the examination of.NET assemblies, that the manifest contains assembly- level
    // metadata, much of which comes from the assembly-level attributes shown in Table 15-4

    // Table 15-4. Select Assembly-Level Attributes

    // Attribute               Meaning in Life
    // --------------------------------------------------------------------------------------------------
    // [AssemblyCompany]       Holds basic company information
    // --------------------------------------------------------------------------------------------------
    // [AssemblyCopyright]     Holds any copyright information for the product or assembly
    // --------------------------------------------------------------------------------------------------
    // [AssemblyCulture]       Provides information on what cultures or languages the assembly supports
    // --------------------------------------------------------------------------------------------------
    // [AssemblyDescription]   Holds a friendly description of the product or modules that make up the assembly
    // --------------------------------------------------------------------------------------------------
    // [AssemblyKeyFile]       Specifies the name of the file containing the key pair used to sign the assembly(i.e., establish a strong name)
    // --------------------------------------------------------------------------------------------------
    // [AssemblyProduct]       Provides product information
    // --------------------------------------------------------------------------------------------------
    // [AssemblyTrademark]     Provides trademark information
    // --------------------------------------------------------------------------------------------------
    // [AssemblyVersion]       Specifies the assembly’s version information, in the format<major.minor.build.revision>

    // --------------------------------------------------------------
    #endregion

    #region Reflecting on Attributes Using Early Binding
    // ------------------------ Reflecting on Attributes Using Early Binding -------------------------
    // Remember that an attribute is quite useless until another piece of software reflects over its values.Once a
    // given attribute has been discovered, that piece of software can take whatever course of action necessary.

    // this “other piece of software” could discover the presence of a custom attribute
    // using either early binding or late binding.

    class ReflectOnAttributesUsingEarlyBinding
    {
        public static void Test()
        {
            Type type = typeof(Winnebago);
            Console.WriteLine(MetadataViewer.ReflectOverType(type));
            

            //object[] attributes = type.GetCustomAttributes(false);

            //object[] attributes = type.GetCustomAttributes(typeof(VehicleDescriptionAttribute), false);

            object[] attributes = (from obj in type.GetCustomAttributes(false)
                                  where obj is VehicleDescriptionAttribute
                                  select obj).ToArray();

            Console.WriteLine("Reflecting on VehicleDescriptionAttribute Using Early Binding:-");
            Console.WriteLine("---------------------------------------------------------------------");
            // read attributes
            foreach (VehicleDescriptionAttribute item in attributes)
            {
                Console.WriteLine(item.Description);
            }

        }

    }

    // The Type.GetCustomAttributes() method returns an object array that represents all the attributes
    // applied to the member represented by the Type(the Boolean parameter controls whether the search
    // should extend up the inheritance chain). Once you have obtained the list of attributes, iterate over each
    // VehicleDescriptionAttribute class and print out the value obtained by the Description property.
    // --------------------------------------------------------------
    #endregion

    #region Reflecting on Attributes Using Late Binding
    // ------------------------ Reflecting on Attributes Using Late Binding -------------------------
    // . It is also possible to make use of dynamic loading and late binding to reflect over attributes.
    class ReflectOnAttributesUsingLateBinding
    {
        public static void Test()
        {
            
            Assembly asm = Assembly.Load("AttributedCarLibrary");

            Type vehicleDescribition = asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");

            PropertyInfo prop = vehicleDescribition.GetProperty("Description");

            foreach (Type item in asm.GetTypes())
            {
                object [] objs = item.GetCustomAttributes(vehicleDescribition,false);
                foreach (var obj in objs)
                {
                    Console.WriteLine($"{item.Name}: {prop.GetValue(obj)}");
                }
            }

        }

    }

    // --------------------------------------------------------------
    #endregion
}
