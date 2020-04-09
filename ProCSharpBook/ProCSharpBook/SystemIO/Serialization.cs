using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

namespace ProCSharpBook.SystemIO
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

            using(FileStream stream = File.Create("user.dat"))
            {
                formatter.Serialize(stream, obj);
            }

            

        }


    }

    [Serializable]
    class UserPref
    {
        public string WindowColor { get; set; }

        public int FontSize { get; set; }

        public int WinWidth { get; set; }

        public int WinHeight { get; set; }

        public bool FullScreen { get; set; }

    }

    // --------------------------------------------------------------
    #endregion

}
