using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using ProCSharpCode.OOPExamples;
using static System.Environment;


namespace ProCSharpCode.ReflectionTraining
{
    #region System.Reflection Namespace
    // ------------------------ System.Reflection Namespace-------------------------
    // ===============================================================================================================
    // In the.NET universe, reflection is the process of runtime type discovery. Using reflection services, you are
    // able to programmatically obtain the same metadata information displayed by ildasm.exe using a friendly
    // object model.

    // Like any namespace, System.Reflection (which is defined in mscorlib.dll) contains a number of
    // related types.Table 15-1 lists some of the core items you should be familiar with.

    //    Table 15-1. A Sampling of Members of the System.Reflection Namespace

    // Type          Meaning in Life
    // -------------------------------------------------------------------------------------------------------------------
    // Assembly      
    //              This abstract class contains a number of members that allow you to load, investigate,
    //              and manipulate an assembly.
    // -------------------------------------------------------------------------------------------------------------------
    // AssemblyName 
    //              This class allows you to discover numerous details behind an assembly’s identity
    //              (version information, culture information, and so forth).
    // -------------------------------------------------------------------------------------------------------------------
    // EventInfo     
    //              This abstract class holds information for a given event.
    // -------------------------------------------------------------------------------------------------------------------
    // FieldInfo 
    //              This abstract class holds information for a given field.
    // -------------------------------------------------------------------------------------------------------------------
    // MemberInfo 
    //              This is the abstract base class that defines common behaviors for the EventInfo,
    //              FieldInfo, MethodInfo, and PropertyInfo types.
    // -------------------------------------------------------------------------------------------------------------------
    // MethodInfo 
    //              This abstract class contains information for a given method.
    // -------------------------------------------------------------------------------------------------------------------
    // Module 
    //              This abstract class allows you to access a given module within a multifile assembly.
    // -------------------------------------------------------------------------------------------------------------------
    // ParameterInfo 
    //              This class holds information for a given parameter.
    // -------------------------------------------------------------------------------------------------------------------
    // PropertyInfo 
    //              This abstract class holds information for a given property
    // -------------------------------------------------------------------------------------------------------------------
    // -------------------------------------------------------------------------
    #endregion

    #region System.Type Class
    // ------------------------ System.Type Class -------------------------
    // -------------------------------------------------------------------------------------------------------------------
    // The System.Type class defines a number of members that can be used to examine a type’s metadata, a great
    // number of which return types from the System.Reflection namespace.For example, Type.GetMethods()
    // returns an array of MethodInfo objects, Type.GetFields() returns an array of FieldInfo objects, and
    // so on.The complete set of members exposed by System.Type is quite expansive; however, Table 15-2
    // offers a partial snapshot of the members supported by System.Type(see the .NET Framework 4.7 SDK
    // documentation for full details).

    // Table 15-2. Select Members of System.Type
    // Member                        Meaning in Life
    // ----------------------------------------------------------------------------------------------------------------------------
    // IsAbstract                    These properties(among others) allow you to discover a number of basic
    // IsArray                       traits about the Type you are referring to(e.g., if it is an abstract entity, an
    // IsClass                       array, a nested class, and so forth).
    // IsCOMObject
    // IsEnum
    // IsGenericTypeDefinition
    // IsGenericParameter
    // IsInterface
    // IsPrimitive
    // IsNestedPrivate
    // IsNestedPublic
    // IsSealed
    // IsValueType
    // -------------------------------------------------------------------------------------------------------------------
    // GetConstructors()            These methods(among others) allow you to obtain an array representing
    // GetEvents()                  the items(interface, method, property, etc.) you are interested in. Each
    // GetFields()                  method returns a related array(e.g., GetFields() returns a FieldInfo
    // GetInterfaces()              array, GetMethods() returns a MethodInfo array, etc.). Be aware that each of
    // GetMembers()                 these methods has a singular form(e.g., GetMethod(), GetProperty(), etc.)
    // GetMethods()                 that allows you to retrieve a specific item by name, rather than an array of
    // GetNestedTypes()             all related items.
    // GetProperties()
    // FindMembers()                This method returns a MemberInfo array based on search criteria.
    // GetType()                    This static method returns a Type instance given a string name.
    // InvokeMember()               This method allows “late binding” for a given item.You’ll learn about late
    //                              binding later in this chapter.
    // ----------------------------------------------------------------------------------------------------------------------------

    // *******   Obtaining a Type Reference Using System.Object.GetType()   *******
    // ------------------------------------------------------------------------------------------------------------------
    // You can obtain an instance of the Type class in a variety of ways.However, the one thing you cannot do is
    // directly create a Type object using the new keyword, as Type is an abstract class. Regarding your first choice,
    // recall that System.Object defines a method named GetType(), which returns an instance of the Type class
    // that represents the metadata for the current object.
    //-------------------------------------------------------------------------
    //      // Obtain type information using a SportsCar instance.
    //      SportsCar sc = new SportsCar();
    //      Type t = sc.GetType();
    //-------------------------------------------------------------------------
    //    Obviously, this approach will work only if you have compile-time knowledge of the type you want
    //    to reflect over (SportsCar in this case) and currently have an instance of the type in memory. Given this
    //      restriction, it should make sense that tools such as ildasm.exe do not obtain type information by directly
    //    calling System.Object.GetType() for each type, given that ildasm.exe was not compiled against your
    //    custom assemblies.

    // *******  Obtaining a Type Reference Using typeof()  *******
    //-------------------------------------------------------------------------
    // The next way to obtain type information is using the C# typeof operator, like so:
    // 
    // // Get the type using typeof.
    // Type t = typeof(SportsCar);
    // 
    // Unlike System.Object.GetType(), the typeof operator is helpful in that you do not need to first create an
    // object instance to extract type information. However, your codebase must still have compile-time knowledge of
    // the type you are interested in examining, as typeof expects the strongly typed name of the type.
    // -------------------------------------------------------------------------


    //   *******   Obtaining a Type Reference Using System.Type.GetType()  static method *******
    // ---------------------------------------------------------------------------------------------
    //  To obtain type information in a more flexible manner, you may call the static GetType() member of the
    //  System.Type class and specify the fully qualified string name of the type you are interested in examining.
    //  Using this approach, you do not need to have compile-time knowledge of the type you are extracting
    //  metadata from, given that Type.GetType() takes an instance of the omnipresent System.String.
    // ------------------------------------------------------------------------------------------------------
    //      Obtain type information using the static Type.GetType() method
    //      (don't throw an exception if SportsCar cannot be found and ignore case).
    //      Type t = Type.GetType("CarLibrary.SportsCar", false, true);
    // ------------------------------------------------------------------------------------------------------
    //  ■ Note When i say you do not need compile-time knowledge when calling Type.GetType(), i am referring
    //    to the fact that this method can take any string value whatsoever (rather than a strongly typed variable). of
    //    course, you would still need to know the name of the type in a “stringified” format!
    // ---------------------------------------------------------------------------------------------

    // ---------------<<< Notes about getting Type Reference >>>-------------------
    // you can get Type using three ways: 
    // 1 - with object.GetType() inherted method to all other types, 
    // 2 - with typeof() operator that takes type Name Like System.DateTime, System.String,...etc, which get an instance of Type
    //
    // 3 - with the static method Type.GetType(string) that takes a string represent the fully qualified name of the type you are 
    //      interesting to examine, this way is more flexable than others, as you can supply Your string in rutime(requests it at runtime), 
    //      on the other hand, the other ways require compile-time knowledge of the type you would to reflect, 
    //      that make type is embedded in to you code and can't be changed except if you compile your code again !!
    // ----------------------------------------------


    #endregion

    #region Getting Type Reference Approaches 
    // ------------------------ Getting Type Reference Approaches  -------------------------

    public class GettingTypeRefApproaches
    {
        // Test Method
        public static void Test()
        {
            // Obtain type information using a SalesPerson instance.
            SalesPerson salesPerson = new SalesPerson("Moamen", "Soroor", 25);


            // Obtaining a Type Reference Using System.Object.GetType() - instance method
            Type type = salesPerson.GetType();
            Console.WriteLine(type.Name);

            // Obtaining a Type Reference Using typeof() - operator takes
            Type type2 = typeof(SalesPerson);
            Console.WriteLine(type.Name);



            // Obtaining a Type Reference Using System.Type.GetType() - static method
            // ------------------------------------------------------------------------------------------
            // The Type.GetType() method has been overloaded to allow you to specify two Boolean parameters,
            // one of which controls whether an exception should be thrown if the type cannot be found, and the other of
            // which establishes the case sensitivity of the string.
            // defaults are case sensitivity with no error thrown if 

            // public static Type GetType(string typeName);     
            // it Gets the System.Type with the specified name, performing a case-sensitive search, no error thrown.
            // if not a type, returns null
            Type type3 = Type.GetType("System.String");
            Console.WriteLine(type3.Name);

            // public static Type GetType(string typeName, bool throwOnError);
            Type type5 = Type.GetType("System.String", false);
            Console.WriteLine(type5.Name);

            // public static Type GetType(string typeName, bool throwOnError, bool ignoreCase);
            Type type4 = Type.GetType("system.string", false, true);
            Console.WriteLine(type4.Name);


            // However, when you want to obtain metadata for a type within an external private
            // assembly, the string parameter is formatted using the type’s fully qualified name, followed by a comma,
            // followed by the friendly name(Assembly name without .dll or .exe) of the assembly containing the type.

            //"fullyQualifiedName, AssemblyFriendlyName"


            // Obtain type information for a type within an external assembly.
            Type type6 = Type.GetType("CarLibrary.Car, CarLibrary"); // "fullyQualifiedName, AssemblyFriendlyName"

            Console.WriteLine(type6.Name);

            // As well, do know that the string passed into Type.GetType() may specify a plus token(+) to denote a
            // nested type.

            // Obtain type information for a nested enumeration
            // within the current assembly.
            Type type7 = Type.GetType("CarLibrary.JamesBondCar+SpyOptions");
            Console.WriteLine(type7.Name);







        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Building a Custom Metadata Viewer To discover Reflection
    // ------------------------ Building a Custom Metadata Viewer -------------------------

    public class MetadataViewer
    {
        // Test Method
        public static void Test()
        {
            //Reflect(Type.GetType("System.Int32"));
            //Reflect(Type.GetType("System.Collections.ArrayList"));
            //Reflect(Type.GetType("System.Threading.Thread"));
            //Reflect(Type.GetType("System.Void"));
            //Reflect(Type.GetType("System.IO.BinaryWriter"));
            //Reflect(Type.GetType("System.Math"));
            //Reflect(Type.GetType("System.Collections.Generic.List`1"));
            //Reflect(Type.GetType("System.Collections.Generic.Dictionary`2"));

            Console.WriteLine(Reflect(Type.GetType("System.Collections.ArrayList")));
        }

        public static string Reflect(Type t)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"=================== Metadata Viewer ====================");
            builder.AppendLine(ReflectOverType(t));
            builder.AppendLine(ReflectOverFields(t));
            builder.AppendLine(ReflectOverProperties(t));
            builder.AppendLine(ReflectOverMethods(t));
            builder.AppendLine(ReflectOverEvents(t));
            builder.AppendLine("=========================================================");
            return builder.ToString();
        }


        public static string ReflectOverType(Type t)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine();
            builder.AppendLine("Reflect Over Type various States:");
            builder.AppendLine("----------------------------------------------");
            builder.AppendLine($"Type-----------: {t.FullName}");
            builder.AppendLine($"BaseType-------: {t.BaseType?.FullName}"); // if a type is an interface null will be returned
            builder.AppendLine($"ImplInterfaces-:{NewLine}{string.Join(NewLine, (from inter in t.GetInterfaces() select "".PadLeft(18) + inter.FullName))}");
            builder.AppendLine($"Namespace------: {t.Namespace}");
            builder.AppendLine($"AssemblyName---: {t.AssemblyQualifiedName}");

            builder.Append($"Flags--------:");
            builder.Append(t.IsClass ? " [Class]" : "");
            builder.Append(t.IsValueType ? " [ValueType]" : "");
            builder.Append(t.IsInterface ? " [Interface]" : "");
            builder.Append(t.IsEnum ? " [Enum]" : "");
            builder.Append(t.IsGenericTypeDefinition ? " [Generic]" : "");
            builder.Append(t.IsAbstract ? " [Abstract]" : "");
            builder.Append(t.IsSealed ? " [Sealed]" : "");
            builder.Append(t.IsVisible ? " [Visiable]" : "");
            builder.Append(t.IsNested ? " [Nested]" : "");
            builder.AppendLine();
            return builder.ToString();
        }


        public static string ReflectOverFields(Type t)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendLine("Reflect Over Fields:");
            builder.AppendLine("----------------------------------------------");
            foreach (FieldInfo item in t.GetFields())
            {
                builder.AppendLine();
                builder.AppendLine("Field ");
                builder.AppendLine("--------------------------------");
                builder.AppendLine($"Name--: {item.Name}");
                builder.AppendLine($"Type--: {item.FieldType.FullName}");
                builder.Append($"Flags-:");
                builder.Append(item.IsPublic ? " [public]" : "");
                builder.Append(item.IsPrivate ? " [private]" : "");
                builder.Append(item.IsFamily ? " [protected]" : "");
                builder.Append(item.IsAssembly ? " [internal]" : "");
                builder.Append(item.IsFamilyOrAssembly ? " [protected internal]" : "");
                builder.Append(item.IsFamilyAndAssembly ? " [private protected]" : "");
                builder.Append(item.IsStatic ? " [static]" : "");
                builder.Append(item.IsLiteral ? " [readonly]" : "");
                builder.AppendLine();

            }
            builder.AppendLine();
            return builder.ToString();
        }


        public static string ReflectOverProperties(Type t)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendLine("Reflect Over Properties:");
            builder.AppendLine("----------------------------------------------");
            foreach (PropertyInfo item in t.GetProperties())
            {
                builder.AppendLine("Property: ");
                builder.AppendLine("--------------------------------");
                builder.AppendLine($"Name--: {item.Name}");
                builder.AppendLine($"Type--: {item.PropertyType.FullName}");
                builder.Append($"Flags-:");
                builder.Append(item.CanRead ? " [Read]" : "[Not Read]");
                builder.Append(item.CanWrite ? " [Write]" : "[Not Written]");
                //builder.Append(item.CanRead ? " [Read]" : "");
                //builder.Append(item.CanWrite ? " [Write]" : "");
                builder.AppendLine();
                ReflectOverGetterAndSetter(item);
                builder.AppendLine();
            }
            builder.AppendLine();
            return builder.ToString();
        }

        public static string ReflectOverGetterAndSetter(PropertyInfo prop)
        {
            StringBuilder builder = new StringBuilder();

            var setter = prop.SetMethod;
            var getter = prop.GetMethod;

            if (setter != null)
            {
                builder.Append($"Setter: ");
                builder.Append(setter.IsPublic ? " [public]" : "");
                builder.Append(setter.IsPrivate ? " [private]" : "");
                builder.Append(setter.IsFamily ? " [protected]" : "");
                builder.Append(setter.IsAssembly ? " [internal]" : "");
                builder.Append(setter.IsFamilyOrAssembly ? " [protected internal]" : "");
                builder.Append(setter.IsFamilyAndAssembly ? " [private protected]" : "");

                builder.AppendLine();
            }


            if (getter != null)
            {
                builder.Append($"Getter: ");
                builder.Append(getter.IsPublic ? " [public]" : "");
                builder.Append(getter.IsPrivate ? " [private]" : "");
                builder.Append(getter.IsFamily ? " [protected]" : "");
                builder.Append(getter.IsAssembly ? " [internal]" : "");
                builder.Append(getter.IsFamilyOrAssembly ? " [protected internal]" : "");
                builder.Append(getter.IsFamilyAndAssembly ? " [private protected]" : "");

                builder.AppendLine();
            }
                
            return builder.ToString();
        }

            public static string ReflectOverEvents(Type t)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendLine("Reflect Over Events:");
            builder.AppendLine("----------------------------------------------");
            foreach (EventInfo item in t.GetEvents())
            {
                builder.AppendLine($"Event: {item.Name}");
            }
            builder.AppendLine();
            return builder.ToString();
        }


        public static string ReflectOverMethods(Type t)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendLine("Reflect Over Methods:");
            builder.AppendLine("----------------------------------------------");
            var methods = from method in t.GetMethods()
                          select $"{method.ReturnType.FullName}" +
                          $" {method.Name}(" +
                          string.Join(", ",method.GetParameters().Select(par => $"{par.ParameterType} {par.Name}"))
                          + ");";

            foreach (string item in methods)
            {
                builder.AppendLine(item);
            }
            builder.AppendLine();
            return builder.ToString();
        }

        public static string ReflectOnImplementedInterfaces(Type t)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendLine("Reflect Over Impl Interfaces: ");
            builder.AppendLine("----------------------------------------------");
            foreach (Type item in t.GetInterfaces())
            {
                builder.AppendLine($"Impl Interface: {item.FullName}");
            }
            builder.AppendLine();
            return builder.ToString();
        }

    }

    // --------------------------------------------------------------
    #endregion

    #region Dynamically Loading Assemblies
    // ------------------------ Dynamically Loading Assemblies -------------------------
    // Formally speaking, the act of loading external assemblies on demand is known as a dynamic load.
    // System.Reflection defines a class named Assembly.Using this class, you are able to dynamically
    // load an assembly, as well as discover properties about the assembly itself.

    // Assembly: Display Name / Qualified Name: the set of items identifying an assembly is termed the display name.
    //      Name (,Version = major.minor.build.revision) (,Culture = culture token) (, PublicKeyToken= public key token)
    // ex:  CarLibrary, Version=1.0.0.0, PublicKeyToken=null, Culture=""
    // 
    public class DynamicLoadAssembly
    {
        // Test Method
        public static void Test()
        {
            try
            {
                // dynamic load an assembly
                //Console.WriteLine(ReflectOverAssembly(Assembly.Load("CarLibrary")));
                //Console.WriteLine(ReflectOverAssembly(Assembly.LoadFrom(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7\System.dll")));

                // dynamic load assembly using assembly display name
                string asmName = @"System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
                Console.WriteLine(ReflectOverAssembly(Assembly.Load(asmName)));


                // you can use AssemblyName Class to create assembly qualififed name

            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, can't find assembly.");
            }
        }

        public static Assembly Load(string assembly)
        {

            // Try to load assembly.
            try
            {
                return Assembly.Load(assembly);
            }
            catch
            {
                Console.WriteLine("Sorry, can't find assembly.");
                return null;
            }
        }

        public static Assembly LoadFrom(string assemblyFile)
        {

            // Try to load assembly.
            try
            {
                return Assembly.LoadFrom(assemblyFile);
            }
            catch
            {
                Console.WriteLine("Sorry, can't find assembly.");
                return null;
            }
        }

        // FullName - DisplayName - QualifiedName
        public static string GetAssemblyFullName(string location)
        {
            return AssemblyName.GetAssemblyName(location).FullName;
        }

        public static string ReflectOverAssembly(Assembly asm)
        {
            if (asm == null)
                return "";
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Assembly-----: {asm.FullName}");
            builder.AppendLine("=================================================");
            builder.AppendLine($"Location-----: {asm.Location}");
            //builder.AppendLine($"IsSharedAsm--: {asm.GlobalAssemblyCache}");
            builder.AppendLine($"FriendlyName-: {asm.GetName().Name}");
            builder.AppendLine($"Version------: {asm.GetName().Version}");
            builder.AppendLine($"PublicKey----: {string.Join(" ",asm.GetName().GetPublicKeyToken())}");
            builder.AppendLine($"Culture------: {asm.GetName().CultureInfo.DisplayName}");
            builder.AppendLine();
            builder.AppendLine($"--- Types Lives in Assembly:---");
            var types = from t in asm.GetTypes() 
                        select (t.IsClass ? "Class     " : t.IsInterface ? "Interface " : t.IsValueType ? t.IsEnum ? "Enum      " : "ValueType " : "") + t.FullName ;
            builder.AppendLine(string.Join(NewLine, types));
            //Type[] types = asm.GetTypes();
            //builder.AppendLine(" ---------------Types Full Details ---------------");
            //foreach (var item in types)
            //{
            //    builder.AppendLine(MetadataViewer.Reflect(item));
            //}

            builder.AppendLine("========================= End =========================");
            return builder.ToString();
        }



    }

    // --------------------------------------------------------------
    #endregion

    #region Understanding Late Binding
    // ------------------------ Understanding Late Binding -------------------------
    //Simply put, late binding is a technique in which you are able to create an instance of a given type and invoke
    //its members at runtime without having hard-coded compile-time knowledge of its existence.

    public class LateBinding
    {
        // Test Method
        public static void Test()
        {
            try
            {
                // dynamic load asm
                Assembly asm = Assembly.Load("CarLibrary");

                // get a Type ref of a type
                Type minivan = asm.GetType("CarLibrary.MiniVan");

                // Create an Object of the Type With Late Binding
                object obj = Activator.CreateInstance(minivan);

                // get The MethodInfo of the needed method to Invoke it.
                MethodInfo method = minivan.GetMethod("TurboBoost");

                // Invoke the method by late binding
                method.Invoke(obj, null);


                // Try to invoke another method with Parameters: void TurnOnRadio(bool, CarLibrary.MusicMedia)
                // ------------------------------------------------------------------
                // get The MethodInfo of the needed method to Invoke it.
                MethodInfo method2 = minivan.GetMethod("TurnOnRadio");

                // Invoke the method by late binding: with specifying parameters 
                // the first are bool and the other are enum.
                method2.Invoke(obj, new object [] { true, 2});


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Can't Load Assembly or Create Instance or Invoke Methods!!");
            }
            
            

        }


    }

    // --------------------------------------------------------------
    #endregion
    


}
