using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace ProCSharpCode.SystemIO
{
    
    #region Understanding Object Serialization
    // ------------------------ Understanding Object Serialization -------------------------
    // The term serialization describes the process of persisting(and possibly transferring) the state of an object
    // into a stream(e.g., file stream and memory stream). 
    // 
    // The persisted data sequence contains all the necessary information you need to reconstruct(or deserialize) 
    // the state of the object for use later.Using this technology makes it trivial to save vast amounts of data 
    // (in various formats). In many cases, saving application data using serialization services results in less 
    // code than using the readers/writers you find in the System.IO namespace.
    public class ObjectSerialization
    {
        // Test Method
        public static void Test()
        {




        }

        public static void SerializeObject()
        {
            UserPref obj = new UserPref()
            {
                FontSize = 20,
                FullScreen = false,
                WindowColor = "Black",
                WinHeight = 500,
                WinWidth = 600
            };

            // The BinaryFormatter persists state data in a binary format.
            // You would need to import System.Runtime.Serialization.Formatters.Binary
            // to gain access to BinaryFormatter.
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = File.Create("user.dat"))
            {
                formatter.Serialize(stream, obj);
            }
        }

        public static void DeserializeObject()
        {

        }
    }

    // Configuring Objects for Serialization
    // =====================================
    // To make an object available to.NET serialization services, all you need to do is decorate each related class
    // (or structure) with the[Serializable] attribute.

    // If you determine that a given type has some member data
    // that should not (or perhaps cannot) participate in the serialization scheme, you can mark such fields with
    // the[NonSerialized] attribute.
    // 
    // This can be helpful if you want to reduce the size of the persisted data and
    // you have member variables in a serializable class that do not need to be remembered(e.g., fixed values,
    // random values, and transient data).

    [Serializable]
    class UserPref
    {
        public string WindowColor { get; set; }

        public int FontSize { get; set; }

        public int WinWidth { get; set; }

        public int WinHeight { get; set; }

        public bool FullScreen { get; set; }

        public override string ToString()
        {
            //return base.ToString();
            return $"UserPref[WindowColor:{WindowColor}, FontSize:{FontSize}, WinWidth:{WinWidth}, WinHeight:{WinHeight}, FullScreen:{FullScreen}]";
        }
    }

    // --------------------------------------------------------------
    #endregion

    #region Object Graph
    // ------------------------ Object Graph -------------------------
    // the CLR will account for all related objects to ensure that data is persisted correctly
    // when an object is serialized.This set of related objects is referred to as an object graph.Object graphs provide a
    // simple way to document how a set of items refer to each other. 

    // When reading object graphs, you can use the phrase depends on or refers to when connecting the
    // arrows.
    //  the graph representing the relationships among your objects is established automatically behind the scenes

    // Strictly speaking, the XmlSerializer type (described later in this chapter) does not persist state
    //using object graphs; however, this type still serializes and deserializes related objects in a predictable manner.

    // -------------------------------------------------------------------------
    #endregion

    #region Defining Serializable Types
    // ------------------------ Defining Serializable Types -------------------------
    // 
    // Be aware that you cannot inherit the [Serializable] attribute from a parent class. Therefore, if you
    // derive a class from a type marked[Serializable], the child class must be marked[Serializable] as well,
    // or it cannot be persisted.In fact, all objects in an object graph must be marked with the[Serializable]
    // attribute.If you attempt to serialize a nonserializable object using the BinaryFormatter or SoapFormatter,
    // you will receive a SerializationException at runtime.
    // 

    //      [Serializable]
    //      public class Radio
    //      {
    //          public bool hasTweeters;
    //          public bool hasSubWoofers;
    //          public double[] stationPresets;
    //          [NonSerialized]
    //          public string radioID = "XF-552RR6";
    //      }

    //      [Serializable]
    //      public class Car
    //      {
    //          public Radio theRadio = new Radio();
    //          public bool isHatchBack;
    //      }

    //      [Serializable]
    //      public class JamesBondCar : Car
    //      {
    //          public bool canFly;
    //          public bool canSubmerge;
    //      }
    // --------------------------------------------------------------
    #endregion

    #region Public Fields, Private Fields, and Public Properties
    // ------------------------ Public Fields, Private Fields, and Public Properties -------------------------
    // If you persist an object’s state using the BinaryFormatter or SoapFormatter , it makes absolutely no difference.
    // These types are programmed to serialize all serializable fields of a type, regardless of whether they are 
    // public fields, private fields, or private fields exposed through public properties.

    // XmlSerializer type doesn't serialize private fields without public property
    // ---------------------------------------------------------------------------
    // The situation is quite different if you use the XmlSerializer type, however. This type will only serialize
    // public data fields or private data exposed by public properties.

    [Serializable]
    public class Person
    {
        // A public field.
        public bool isAlive = true;
        // A private field.
        private int personAge = 21;
        // Public property/private data.
        private string fName = string.Empty;
        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }
    }

    // --------------------------------------------------------------
    #endregion

    #region Choosing a Serialization Formatter
    // ------------------------ Choosing a Serialization Formatter -------------------------
    //    After you configure your types to participate in the.NET serialization scheme by applying the necessary
    //attributes, your next step is to choose which format(binary, SOAP, or XML) you should use when persisting
    //your object’s state.Each possibility is represented by the following classes:
    //•	 BinaryFormatter: serialize with full details 
    //•	 SoapFormatter  : serialize with full details 
    //•	 XmlSerializer  : serialize without full details

    // BinaryFormatter
    // ===============
    // The BinaryFormatter type serializes your object’s state to a stream using a compact binary format.This
    // type is defined within the System.Runtime.Serialization.Formatters.Binary namespace that is part of
    // mscorlib.dll.If you want to gain access to this type, you can specify the following C# using directive:
    // ---------------------------------------------------------
    // // Gain access to the BinaryFormatter in mscorlib.dll.
    // using System.Runtime.Serialization.Formatters.Binary;
    // ---------------------------------------------------------

    // UseCase:
    // -------
    //the BinaryFormatter an ideal choice when you want to transport objects by value(e.g., as a full copy)
    //across machine boundaries for .NET-centric applications.
    // ==========================================================================================================


    // SoapFormatter
    // ===============
    // The SoapFormatter type persists an object’s state as a SOAP message(the standard XML format for
    // passing messages to/from a SOAP-based web service). This type is defined within the System.Runtime.
    // Serialization.Formatters.Soap namespace, which is defined in a separate assembly.Thus, to format
    // your object graph into a SOAP message, you must first set a reference to System.Runtime.Serialization.
    // Formatters.Soap.dll using the Visual Studio Add Reference dialog box and then specify the following C#
    // using directive:
    // ---------------------------------------------------------
    // // Must reference System.Runtime.Serialization.Formatters.Soap.dll.
    // using System.Runtime.Serialization.Formatters.Soap;
    // ---------------------------------------------------------

    // UseCase:
    // -------
    // SoapFormatter and XmlSerializer are ideal choices when you need to ensure as broad 
    // a reach as possible for the persisted tree of objects.
    // ==========================================================================================================




    // XmlSerializer
    // ===============
    // Finally, if you want to persist a tree of objects as an XML document, you can use the XmlSerializer
    // type.To use this type, you need to specify that you are using the System.Xml.Serialization namespace and
    // set a reference to the assembly System.Xml.dll.As luck would have it, all Visual Studio project templates
    // automatically reference System.Xml.dll; therefore, all you need to do is use the following namespace:
    // ---------------------------------------------------------
    // // Defined within System.Xml.dll.
    // using System.Xml.Serialization;
    // ---------------------------------------------------------

    // UseCase:
    // -------
    // SoapFormatter and XmlSerializer are ideal choices when you need to ensure as broad 
    // a reach as possible for the persisted tree of objects.

    // ==========================================================================================================
    // Conclus
    // If you want to persist an object’s state in a manner that can be used by any operating system (e.g.,
    // Windows, macOS, and various Linux distributions), application framework(e.g., .NET, Java Enterprise
    // Edition, and COM), or programming language, you do not want to maintain full type fidelity because you
    // cannot assume all possible recipients can understand.NET-specific data types.Given this, SoapFormatter
    // and XmlSerializer are ideal choices when you need to ensure as broad a reach as possible for the persisted
    // tree of objects.
    // --------------------------------------------------------------
    #endregion


    #region The IFormatter and IRemotingFormatter Interfaces
    // ------------------------ The IFormatter and IRemotingFormatter Interfaces -------------------------
    //Regardless of which formatter you choose to use, be aware that all of them derive directly from
    //System.Object, so they do not share a common set of members from a serialization-centric base class.
    //However, the BinaryFormatter and SoapFormatter types do support common members through the
    //implementation of the IFormatter and IRemotingFormatter interfaces(strange as it might seem, the
    //XmlSerializer implements neither).
    // ---------------------------------------------------------------------
    // public interface IFormatter
    // {
    //     SerializationBinder Binder { get; set; }
    //     StreamingContext Context { get; set; }
    //     ISurrogateSelector SurrogateSelector { get; set; }
    //     object Deserialize(Stream serializationStream);
    //     void Serialize(Stream serializationStream, object graph);
    // }
    // ---------------------------------------------------------------------
    // 
    // ---------------------------------------------------------------------
    // public interface IRemotingFormatter : IFormatter
    // {
    //      object Deserialize(Stream serializationStream, HeaderHandler handler);
    //      void Serialize(Stream serializationStream, object graph, Header[] headers);
    // }
    // ---------------------------------------------------------------------
    // -------------------------------------------------------------------------

    #endregion

    #region Serializing and Deserializing Objects
    // ------------------------ Serializing and Deserializing Objects -------------------------


    #region Types In Use
    // ------------------------ Types In Use -------------------------
    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;
        [NonSerialized]
        public string radioID = "XF-552RR6";
    }

    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }

    //[XmlRoot(Namespace = "http://www.Company.com")]  // for XmlSerializer
    [Serializable]
    public class JamesBondCar : Car
    {
        public static JamesBondCar CreateDefaultCar()
        {

            return CreateDefaultCar(true, false, true);
        }

        public static JamesBondCar CreateDefaultCar(bool canFly, bool canMerge, bool isNewCar)
        {
            JamesBondCar jbc = new JamesBondCar(canFly, canMerge, isNewCar);
            //jbc.canFly = true;
            //jbc.IsNewCar(false);
            jbc.theRadio.stationPresets = new double[] { 89.3, 105.1, 97.1 };
            jbc.theRadio.hasTweeters = true;
            jbc.theRadio.radioID = "New-552RR6";
            return jbc;
        }



        [XmlAttribute]
        public bool canFly;

        [XmlAttribute]
        public bool canMerge;

        [XmlAttribute]
        private bool isNewCar;      // not writed to xml file


        public JamesBondCar() { }

        public JamesBondCar(bool canFly, bool canMerge, bool isNewCar)
        {
            this.canFly = canFly;
            this.canMerge = canMerge;
            this.isNewCar = isNewCar;
        }

        public override string ToString()
        {
            return $@"
JamesBondCar : 
    canFly = {this.canFly}
    canMerge = {this.canMerge}
    isNewCar = {this.isNewCar}
    theRadio.stationPresets = {string.Join(", ", this.theRadio.stationPresets)}
    theRadio.hasTweeters = {this.theRadio.hasTweeters}
    theRadio.radioID = {this.theRadio.radioID}
";
        }

        public void IsNewCar(bool NewCar)
        {
            this.isNewCar = NewCar;

        }




    }
    // -------------------------------------------------------------------------
    #endregion

    #region Serializing Objects Using the BinaryFormatter
    // ------------------------ Serializing Objects Using the BinaryFormatter -------------------------

    public class SerializingUsingBinaryFormatter
    {
        // Test Method
        public static void Test()
        {
            Console.WriteLine("***** Fun with Object Serialization using BinaryFormatter *****\n");
            // Make a JamesBondCar and set state.
            JamesBondCar jbc = JamesBondCar.CreateDefaultCar();


            // Now save the car to a specific file in a binary format.
            SaveAsBinaryFormat(jbc, "CarData.dat");

            LoadFromBinaryFile("CarData.dat");
        }

        public static void SaveAsBinaryFormat(object obj, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, obj);
            }
        }

        public static object LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = File.OpenRead(fileName))
            {
                JamesBondCar jbc = (JamesBondCar)formatter.Deserialize(stream);
                Console.WriteLine(jbc);

            }
            return null;
        }

    }





    // --------------------------------------------------------------
    #endregion

    #region Serializing Objects Using the SoapFormatter
    // ------------------------ Serializing Objects Using the SoapFormatter -------------------------

    public class SerializingUsingSoapFormatter
    {
        // Test Method
        public static void Test()
        {
            Console.WriteLine("***** Fun with Object Serialization using SoapFormatter *****\n");
            // Make a JamesBondCar and set state.
            JamesBondCar jbc = JamesBondCar.CreateDefaultCar();


            // Now save the car to a specific file in a binary format.
            SaveAsSoapFormat(jbc, "CarDataSoap.dat");

            LoadFromSoapFile("CarDataSoap.dat");

        }

        public static void SaveAsSoapFormat(object obj, string fileName)
        {
            SoapFormatter formatter = new SoapFormatter();

            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, obj);
            }
        }

        public static object LoadFromSoapFile(string fileName)
        {
            SoapFormatter formatter = new SoapFormatter();

            using (FileStream stream = File.OpenRead(fileName))
            {
                JamesBondCar jbc = (JamesBondCar)formatter.Deserialize(stream);
                Console.WriteLine(jbc);
                return jbc;
            }

        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Serializing Objects Using the XmlSerializer
    // ------------------------ Serializing Objects Using the XmlSerializer -------------------------
    //Note The XmlSerializer demands that all serialized types in the object graph support a default
    //constructor(so be sure to add it back if you define custom constructors). If this is not the case, you will receive
    //an InvalidOperationException at runtime.

    public class SerializingUsingXmlSerializer
    {
        // Test Method
        public static void Test()
        {
            Console.WriteLine("***** Fun with Object Serialization using XmlFormatter *****\n");
            // Make a JamesBondCar and set state.
            JamesBondCar jbc = JamesBondCar.CreateDefaultCar();


            // Now save the car to a specific file in a binary format.
            SaveAsXmlFormat(jbc, "CarDataXml.dat");

            LoadFromXmlFile("CarDataXml.dat");

        }

        private static void SaveAsXmlFormat(JamesBondCar objectGraph, string fileName)
        {
            // using System.Xml.Serialization;
            XmlSerializer formatter = new XmlSerializer(typeof(JamesBondCar));

            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, objectGraph);
            }

            Console.WriteLine("=> Saved car in XML format!");
        }

        private static void LoadFromXmlFile(string fileName)
        {
            // using System.Xml.Serialization;
            XmlSerializer formatter = new XmlSerializer(typeof(JamesBondCar));

            using (FileStream stream = File.OpenRead(fileName))
            {
                JamesBondCar car = (JamesBondCar)formatter.Deserialize(stream);
                Console.WriteLine(car);
            }
        }

    }

    // --------------------------------------------------------------
    #endregion

    #region Generalization of Formatters Serialize and Deserialize
    // ------------------------ Generalization of Formatters Serialize and Deserialize -------------------------

    public class Formatters
    {
        public static void SerializeWithBinaryFormatter(object objGraph, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, objGraph);
            }
            Console.WriteLine("SerializeWithBinaryFormatter Done!");
        }

        public static T LoadFromBinaryFile<T>(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = File.OpenRead(fileName))
            {
                return (T)formatter.Deserialize(stream);

            }

        }

        public static void SerializeWithSoapFormatter(object objGraph, string fileName)
        {
            SoapFormatter formatter = new SoapFormatter();

            using (FileStream stream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, objGraph);
            }
            Console.WriteLine("SerializeWithSoapFormatter Done!");
        }

        public static T LoadFromSoapFile<T>(string fileName)
        {
            SoapFormatter formatter = new SoapFormatter();

            using (FileStream stream = File.OpenRead(fileName))
            {
                return (T)formatter.Deserialize(stream);

            }
        }

        public static void SerializeWithXmlSerializer<T>(object objGraph, string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, objGraph);
            }
            Console.WriteLine("SerializeWithXmlSerializer Done!");
        }

        public static T LoadFromXmlFile<T>(string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            using (FileStream stream = File.OpenRead(fileName))
            {
                return (T)formatter.Deserialize(stream);

            }
        }

    }

    // --------------------------------------------------------------
    #endregion

    #region Serializing Collections of Objects
    // ------------------------ Serializing Collections of Objects -------------------------
    // Note: Soap Serializer does not support serializing Generic Types 
    // The SoapFormatter class can only serialize objects that could have been created with .NET 1.1.
    // As generic types were not introduced until.NET 2.0, they cannot therefore be serialized.
    // If you're trying to serialize a List, then you could use an ArrayList instead or, if you're 
    // trying to serialize a generic Dictionary then you could use a Hashset.
    public class SerializingCollections
    {
        // Test Method
        public static void Test()
        {
            List<JamesBondCar> cars = new List<JamesBondCar>()
            {
                JamesBondCar.CreateDefaultCar(true,true,false),
                JamesBondCar.CreateDefaultCar(true,false,false),
                JamesBondCar.CreateDefaultCar(false,true,false),
                JamesBondCar.CreateDefaultCar(false,true,true)
            };

            Formatters.SerializeWithBinaryFormatter(cars, "CarStock.dat");

            Formatters.SerializeWithXmlSerializer<List<JamesBondCar>>(cars, "CarStockXml.dat");


            Console.WriteLine(string.Join($"{Environment.NewLine}", Formatters.LoadFromBinaryFile<List<JamesBondCar>>("CarStock.dat")));

            Console.WriteLine(string.Join($"{Environment.NewLine}", Formatters.LoadFromXmlFile<List<JamesBondCar>>("CarStockXml.dat")));


        }



    }

    // --------------------------------------------------------------
    #endregion

    #region Customizing Serialization Using ISerializable
    // ------------------------ Customizing Serialization Using ISerializable -------------------------

    [Serializable]
    public class UserChoises : ISerializable
    {
        // constructors

        // ctor for the deserialization process
        protected UserChoises(SerializationInfo info, StreamingContext context)
        {
            BackgroundColor = info.GetString("BackColor").ToLower();
            ForgroundColor = info.GetString("ForColor").ToLower();
            Width = info.GetInt32("Win_Width");
            Height = info.GetInt32("Win_Height");
        }

        public UserChoises()
        {

        }

        // Fields And Properties
        public string BackgroundColor { get; set; } = "Red";
        public string ForgroundColor { get; set; } = "Black";
        public int Height { get; set; } = 1600;
        public int Width { get; set; } = 1800;





        // GetObjectData Method for the Serialization process
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("BackColor", BackgroundColor.ToUpper());
            info.AddValue("ForColor", ForgroundColor.ToUpper());
            info.AddValue("Win_Width", Width);
            info.AddValue("Win_Height", Height);
        }


        public override string ToString()
        {
            //return base.ToString();

            return $@"UserChoises: 
    BackgroundColor = {BackgroundColor}
    ForgroundColor  = {ForgroundColor}
    Width           = {Width}
    Height          = {Height}
";
        }
    }

    public class CustomizingSerialization
    {
        // Test Method
        public static void Test()
        {
            UserChoises obj = new UserChoises();

            Formatters.SerializeWithBinaryFormatter(obj, "UserChoises.dat");
            Formatters.SerializeWithSoapFormatter(obj, "UserChoisesSoap.dat");
            Formatters.SerializeWithXmlSerializer<UserChoises>(obj, "UserChoisesXml.dat");

            Console.WriteLine(Formatters.LoadFromBinaryFile<UserChoises>("UserChoises.dat"));
            Console.WriteLine(Formatters.LoadFromSoapFile<UserChoises>("UserChoisesSoap.dat"));
            Console.WriteLine(Formatters.LoadFromXmlFile<UserChoises>("UserChoisesXml.dat"));

            // note that XMLSerializer doesn't affected with Customizations with ISerializable Inteface

        }


    }

    



    // --------------------------------------------------------------
    #endregion

    #region Customizing Serialization Using Attributes
    // ------------------------ Customizing Serialization Using Attributes -------------------------
    //Although implementing the ISerializable interface is one way to customize the serialization process,
    //the preferred way to customize the serialization process is to define methods that are attributed with any
    //of the new serialization-centric attributes: [OnSerializing], [OnSerialized], [OnDeserializing], or
    //[OnDeserialized]. Using these attributes is less cumbersome than implementing ISerializable because
    //you do not need to interact manually with an incoming SerializationInfo parameter.Instead, you can
    //modify your state data directly, while the formatter operates on the type

    // Note:
    // ======
    // When you define methods decorated with these attributes, you must define the methods so they receive
    // a StreamingContext parameter and return nothing(otherwise, you will receive a runtime exception). 

    // so, our Attributes are:
    // [OnSerializing]
    // [OnSerialized]
    // [OnDeserializing]
    // [OnDeserialized]

    [Serializable]
    public class UserChoisesWithAttributes
    {
        // constructors

        public UserChoisesWithAttributes()
        {

        }

        // Fields And Properties
        public string BackgroundColor { get; set; } = "Red";
        public string ForgroundColor { get; set; } = "Black";
        public int Height { get; set; } = 1600;
        public int Width { get; set; } = 1800;


        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            // Called during the serialization process.
            BackgroundColor = BackgroundColor.ToUpper();
            ForgroundColor  = ForgroundColor.ToUpper();

        }


        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // Called when the deserialization process is complete.
            BackgroundColor = BackgroundColor.ToLower();
            ForgroundColor = ForgroundColor.ToLower();
        }





        public override string ToString()
        {
            //return base.ToString();

            return $@"UserChoises: 
    BackgroundColor = {BackgroundColor}
    ForgroundColor  = {ForgroundColor}
    Width           = {Width}
    Height          = {Height}
";
        }
    }

   
    public class CustomizingSerializationUsingAttributes
    {
        // Test Method
        public static void Test()
        {
            UserChoisesWithAttributes obj = new UserChoisesWithAttributes();

            Formatters.SerializeWithBinaryFormatter(obj, "UserChoisesAtr.dat");
            Formatters.SerializeWithSoapFormatter(obj, "UserChoisesAtrSoap.dat");
            Formatters.SerializeWithXmlSerializer<UserChoisesWithAttributes>(obj, "UserChoisesAtrXml.dat");

            Console.WriteLine(Formatters.LoadFromBinaryFile<UserChoisesWithAttributes>("UserChoisesAtr.dat"));
            Console.WriteLine(Formatters.LoadFromSoapFile<UserChoisesWithAttributes>("UserChoisesAtrSoap.dat"));
            Console.WriteLine(Formatters.LoadFromXmlFile<UserChoisesWithAttributes>("UserChoisesAtrXml.dat"));


        }


    }

    // --------------------------------------------------------------
    #endregion


    // -------------------------------------------------------------------------
    #endregion



}
