using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ProCSharpCode.SystemIO
{

    #region Chapter 20: File I/O and Object Serialization
    // ------------------------ Chapter 20: File I/O and Object Serialization -------------------------

    // This chapter examines a number of I/O-related topics as seen through the eyes of the.NET
    // Framework.
    // 
    // The first order of business is to explore the core types defined in the System.IO namespace 
    // and learn how to modify a machine’s directory and file structure programmatically.
    // 
    // The next task is to explore various ways to read from and write to 
    // 1- character-based data stores. 
    // 2- binary-based data stores. 
    // 3- string-based data stores. 
    // 4- memory-based data stores.
    // 

    // Exploring the System.IO Namespace
    // ---------------------------------------------------------------------------------------------
    // In the framework of .NET, the System.IO namespace is the region of the base class libraries devoted to
    // file-based(and memory-based) input and output(I/O) services.
    // Assemblies: you can find System.IO namspace at mscorelib.dll and System.dll

    // Many of the types within the System.IO namespace focus on the programmatic manipulation of
    // physical directories and files.However, additional types provide support to read data from and write data to
    // string buffers, as well as raw memory locations.Table 20-1 outlines the core (nonabstract) classes, providing
    // a road map of the functionality in System.IO.

    // Table 20-1. Key Members of the System.IO Namespace
    // ------------------------------------------------------------------------------------------------
    // Nonabstract I/O class        Meaning in Life
    // ------------------------------------------------------------------------------------------------
    // BinaryReader
    // BinaryWriter
    //                      These classes allow you to store and retrieve primitive data types(integers,
    //                      Booleans, strings, and whatnot) as a binary value.
    // 
    // StreamReader
    // StreamWriter
    //                      You use these classes to store (and retrieve) textual information to (or from)
    //                      a file.These types do not support random file access. (base: TextReader/TextWriter) 
    // StringReader
    // StringWriter
    //                      Like the StreamReader/StreamWriter classes, these classes also work with
    //                      textual information.However, the underlying storage is a string buffer rather
    //                      than a physical file. (base: TextReader/TextWriter abstract classes) 
    // 
    // BufferedStream       This class provides temporary storage for a stream of bytes that you can
    //                      commit to storage at a later time. (base: Stream abstract class) 
    // 
    // MemoryStream         This class provides random access to streamed data stored in memory rather
    //                      than in a physical file. (base: Stream abstract class) 
    // 
    // FileStream           This class gives you random file access(e.g., seeking capabilities) with data
    //                      represented as a stream of bytes. (base: Stream abstract class) 
    // 
    // FileSystemWatcher    This class allows you to monitor the modification of external files in a
    //                      specified directory.
    // 
    // Path                 This class performs operations on System.String types that contain file or
    //                      directory path information in a platform-neutral manner. 
    // Directory            
    // DirectoryInfo        
    //                      You use these classes to manipulate a machine’s directory structure.
    //                      The Directory type exposes functionality using static members, while
    //                      the DirectoryInfo type exposes similar functionality from a valid object
    //                      reference. (DirectoryInfo base: FileSystemInfo abstract class) 
    // File                 
    // FileInfo             
    //                      You use these classes to manipulate a machine’s set of files. The File type
    //                      exposes functionality using static members, while the FileInfo type exposes
    //                      similar functionality from a valid object reference.
    //                      (FileInfo base: FileSystemInfo abstract class) 
    // 
    // DriveInfo            This class provides detailed information regarding the drives that a given
    //                      machine uses.
    //                      
    // 
    // ------------------------------------------------------------------------------------------------
    //
    // In addition to these concrete class types, System.IO defines a number of enumerations, as well as a set
    // of abstract classes(e.g., Stream, TextReader, and TextWriter), that define a shared polymorphic interface to
    // all descendants.
    // 

    // --------------------------------------------------------------
    #endregion

    #region The Abstract FileSystemInfo Base Class
    // ------------------------ The Abstract FileSystemInfo Base Class -------------------------
    //The DirectoryInfo and FileInfo types receive many behaviors from the abstract FileSystemInfo
    //base class. For the most part, you use the members of the FileSystemInfo class to discover general
    //characteristics(such as time of creation, various attributes, and so forth) about a given file or directory.
    //Table 20-2 lists some core properties of interest

    // Table 20-2. FileSystemInfo Properties
    // -----------------------------------------------------------------------------------------------
    // Property         Meaning in Life
    // -----------------------------------------------------------------------------------------------
    // Name             Obtains the name of the current file or directory
    // FullName         Gets the full path of the directory or file
    // Extension        Retrieves a file’s extension
    // Exists           Determines whether a given file or directory exists
    // 
    // CreationTime     Gets or sets the time of creation for the current file or directory
    // LastAccessTime   Gets or sets the time the current file or directory was last accessed
    // LastWriteTime    Gets or sets the time when the current file or directory was last written to
    // 
    // Attributes       Gets or sets the attributes associated with the current file that are represented by
    //                  the FileAttributes enumeration(e.g., is the file or directory read-only, encrypted,
    //                  hidden, or compressed?)
    // 
    // Delete()         delete a given file or directory from the hard drive
    // 
    // Refresh()        you can call Refresh() prior to obtaining attribute information to ensure 
    //                  that the statistics regarding the current file(or directory) are not outdated.
    // -----------------------------------------------------------------------------------------------

    // --------------------------------------------------------------
    #endregion


    #region DirectoryInfo Class Type
    // ------------------------ DirectoryInfo Class Type -------------------------
    //The first creatable I/O-centric type you will examine is the DirectoryInfo class. This class contains a set
    //of members used for creating, moving, deleting, and enumerating over directories and subdirectories.In
    //addition to the functionality provided by its base class (FileSystemInfo), DirectoryInfo offers the key
    //members detailed in Table 20-3.
    // 
    // Table 20-3. Key Members of the DirectoryInfo Type
    // -----------------------------------------------------------------------------------------------
    // Member               Meaning in Life
    // -----------------------------------------------------------------------------------------------
    // Create()              
    // CreateSubdirectory()              
    //                       Creates a directory(or set of subdirectories) when given a path name
    //  
    // Delete()              Deletes a directory and all its contents
    //  
    // GetDirectories()      Returns an array of DirectoryInfo objects that represent all subdirectories
    //                       in the current directory
    //  
    // GetFiles()            Retrieves an array of FileInfo objects that represent a set of files in the given
    //                       directory
    //  
    // MoveTo()              Moves a directory and its contents to a new path
    //                       Parent Retrieves the parent directory of this directory
    //                       Root Gets the root portion of a path
    // -----------------------------------------------------------------------------------------------
    public class DirectoryInfoClass
    {
        // Test Method
        public static void Test()
        {
            // Use the dot(.) notation if you want to obtain access to the current working directory
            DirectoryInfo currentDir = new DirectoryInfo(".");
            


            // In the second example, you assume that the path passed into the constructor(C:\Windows) already
            // exists on the physical machine. 
            // 
            // However, if you attempt to interact with a nonexistent directory, a System.
            // IO.DirectoryNotFoundException is thrown.
            //
            // 
            // Bind to C:\Windows
            // using a verbatim string.
            DirectoryInfo dir2 = new DirectoryInfo(@"C:\Windows");


            // if you specify a directory that is not yet created, you need
            // to call the Create() method before proceeding
            // 
            // Bind to a nonexistent directory, then create it.
            DirectoryInfo dir3 = new DirectoryInfo(@"C:\MyCode\Testing");
            //dir3.Create();


            // After you create a DirectoryInfo object, you can investigate 
            // the underlying directory contents using any of the properties 
            // inherited from FileSystemInfo.
            // 
            // Dump directory information.
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine($"dir.FullName       = {dir.FullName}");
            Console.WriteLine($"dir.Name           = {dir.Name}");
            Console.WriteLine($"dir.Parent         = {dir.Parent}");
            Console.WriteLine($"dir.CreationTime   = {dir.CreationTime}");
            Console.WriteLine($"dir.LastAccessTime = {dir.LastAccessTime}");
            Console.WriteLine($"dir.LastWriteTime  = {dir.LastWriteTime}");
            Console.WriteLine($"dir.Attributes     = {dir.Attributes}");
            Console.WriteLine($"dir.Root           = {dir.Root}");


            try
            {
                ShowDirectoryInfo(@"C:\Users\moame\OneDrive\Documents");

                ShowDirectoryInfo(@"C:\ProCode\CSharpCode");
            }
            catch (DirectoryNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }

        }

        public static void ShowDirectoryInfo(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists)
            {
                Console.WriteLine($"dir.FullName       = {dir.FullName}");
                Console.WriteLine($"dir.Name           = {dir.Name}");
                Console.WriteLine($"dir.Parent         = {dir.Parent}");
                Console.WriteLine($"dir.CreationTime   = {dir.CreationTime}");
                Console.WriteLine($"dir.LastAccessTime = {dir.LastAccessTime}");
                Console.WriteLine($"dir.LastWriteTime  = {dir.LastWriteTime}");
                Console.WriteLine($"dir.Attributes     = {dir.Attributes}");
                Console.WriteLine($"dir.Root           = {dir.Root}");
            }
            else
                throw new DirectoryNotFoundException($@"DirectoryNotFoundException: ""{path}"" Directory not exists!");

        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Enumerating Files with the DirectoryInfo Type
    // ------------------------ Enumerating Files with the DirectoryInfo Type -------------------------

    public class EnumeratingFiles
    {
        
        // DisplayImageFiles
        public static void Test()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            // retrieve all *.jpg images in all directories under C:\Windows\Web\Wallpaper
            FileInfo[] images = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            
            // How many were found?
            Console.WriteLine("Found {0} *.jpg files\n", images.Length);

            foreach (var im in images)
            {
                Console.WriteLine("---------- File ---------- ");
                Console.WriteLine("Name      : {0}",im.Name);
                Console.WriteLine("Extension : {0}",im.Extension);
                Console.WriteLine("Length : {0}",im.Length);
                Console.WriteLine("Creation  : {0}", im.CreationTime);
                Console.WriteLine("Attributes: {0}", im.Attributes);
                Console.WriteLine();
            }
        }

        public static void ShowFileInfo()
        {

        }



    }

    // --------------------------------------------------------------
    #endregion

    #region Creating Subdirectories with the DirectoryInfo Type
    // ------------------------ Creating Subdirectories with the DirectoryInfo Type -------------------------

    public class CreatingSubdirectories
    {
        // Test Method
        public static void Test()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\");

            // Create \MyFolder off application directory.
            var dir2 = dir.CreateSubdirectory(@"MyFolder");
            Console.WriteLine($@"MyFolder Path: {dir2}");

            // Create \MyFolder off application directory.
            var dir3 = dir.CreateSubdirectory(@"MyFolder2\App\Data");
            Console.WriteLine($@"MyFolder Path: {dir3}");

        }


    }

    // --------------------------------------------------------------
    #endregion


    #region Working with the Directory Type
    // ------------------------ Working with the Directory Type -------------------------

    // For the most part, the static members of Directory mimic the functionality provided by the instance-level
    // members defined by DirectoryInfo.
    // 
    // Recall, however, that the members of Directory typically return string
    // data rather than strongly typed FileInfo/DirectoryInfo objects.
    public class WorkingWithDirectoryType
    {
        // Test Method
        public static void Test()
        {
            // List All Logical Drivers in your machine
            string[] drivers = Directory.GetLogicalDrives();

            Console.WriteLine("Your Logical Drivers:");
            foreach (var driver in drivers)
            {
                Console.WriteLine(driver);
            }
            Console.WriteLine();


            // delete previously created C:\MyFolder , and C:\MyFolder2\App\Data
            // Delete what was created.
            Console.WriteLine("delete Previously Created directories.");
            try
            {
                // delete empty Directory
                Directory.Delete(@"C:\MyFolder");
                Console.WriteLine(@"Folder C:\MyFolder Deleted Successfully");

                // delete directory with it's files and folders.
                // The second parameter specifies whether you
                // wish to destroy any subdirectories.
                Directory.Delete(@"C:\MyFolder2",true);
                Console.WriteLine(@"Folder C:\MyFolder2 Deleted Successfully");

            }
            catch (IOException ioexp)
            {
                Console.WriteLine(ioexp.Message);
            }


        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Working with the DriveInfo Class Type
    // ------------------------ Working with the DriveInfo Class Type -------------------------

    public class WorkWithDriveInfo
    {
        // Test Method
        public static void Test()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                Console.WriteLine("Drive Info".PadLeft(25,'-').PadRight(25,'-'));
                Console.WriteLine($@"drive.Name: {drive.Name}");
                Console.WriteLine($@"drive.Type: {drive.DriveType}");

                // Check to see whether the drive is mounted.
                if (drive.IsReady)
                {
                    
                    Console.WriteLine("Total Size: {0}",drive.TotalSize);
                    Console.WriteLine("Total Free: {0}",drive.TotalFreeSpace);
                    Console.WriteLine("Total Free: {0}",drive.AvailableFreeSpace);
                    Console.WriteLine("Drive Format: {0}",drive.DriveFormat);
                    Console.WriteLine("Drive Label :{0}",drive.VolumeLabel);
                }

            }


        }


    }

    // --------------------------------------------------------------
    #endregion


    #region Working with the FileInfo Class
    // ------------------------ Working with the FileInfo Class -------------------------
    // the FileInfo class allows you to obtain details regarding
    // existing files on your hard drive(e.g., time created, size, and file attributes) 
    // and aids in the creation, copying, moving, and destruction of files.
    // In addition to the set of functionality inherited by FileSystemInfo

    // Table 20-4. FileInfo Core Members
    // ------------------------------------------------------------------------------------
    // Name             Gets the name of the file
    // Length           Gets the size of the current file
    // Directory        Gets an instance of the parent directory
    // DirectoryName    Gets the full path to the parent directory
    // Create()         Creates a new file and returns a FileStream object (described later) to interact with the newly created file    
    // CreateText()     Creates a StreamWriter object that writes a new text file
    //
    // Delete()         Deletes the file to which a FileInfo instance is bound
    // MoveTo()         Moves a specified file to a new location, providing the option to specify a new file name
    // CopyTo()         Copies an existing file to a new file
    // 
    // Open()           Opens a file with various read/write and sharing privileges
    // OpenRead()       Creates a read-only FileStream object
    // OpenWrite()      Creates a write-only FileStream object
    // OpenText()       Creates a StreamReader object (described later) that reads from an existing text file 
    // AppendText()     Creates a StreamWriter object (described later) that appends text to a file
    public class WorkingWithFileInfo
    {
        // Test Method
        public static void Test()
        {
            

        }





    }

    // --------------------------------------------------------------
    #endregion

    #region The FileInfo.Create() Method
    // ------------------------ The FileInfo.Create() Method -------------------------
    // The FileInfo.Create() Method
    // Some Notes:
    // 
    // -  FileInfo.Create() method returns a FileStream object, which exposes synchronous
    //    and asynchronous write/read operations to/from the underlying file.
    // 
    // - the FileStream object returned by FileInfo.Create() grants full read/write access to all users.
    // 
    // - after you finish with the current FileStream object, you must ensure you close down
    //   the handle to release the underlying unmanaged stream resources.
    // 
    // - Given that FileStream implements IDisposable, you can use the C# using scope 
    //   to allow the compiler to generate the teardown logic
    public class FileInfoCreateMethod
    {
        // Test Method
        public static void Test()
        {
            FileInfo file = new FileInfo(@"C:\Test.dat");
            FileStream fstream = file.Create();

            // use FileStream Here

            // you must Close down file stream.
            fstream.Close();

            // ---------------------------------------------------------

            // Defining a using scope for file I/O
            // types is ideal.
            FileInfo file2 = new FileInfo(@"C:\Test2.dat");
            using (FileStream fs = file2.Create())
            {
                // Use the FileStream object...

                // Write something
                var str = "Hello Test2.dat File...";
                byte[] strBytes = Encoding.Default.GetBytes(str);
                fs.Write(strBytes, 0, strBytes.Length);

            }

        }


    }

    // --------------------------------------------------------------
    #endregion


    #region The FileInfo.Open() Method
    // ------------------------ The FileInfo.Open() Method -------------------------
    // Notes:
    // - You can use the FileInfo.Open() method to open existing files, 
    // - as well as to create new files with far more precision than you can with FileInfo.Create()
    // - Once the call to Open() completes, you are returned a FileStream object.
    // - 
    public class FileInfoOpenMethod
    {
        // Test Method
        public static void Test()
        {
            FileInfo file = new FileInfo(@"C:\Test3.dat");
            using(FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                // Use the FileStream object...
                // Write something
                var str = "Hello Test3.dat File...";
                byte[] strBytes = Encoding.Default.GetBytes(str);
                fs.Write(strBytes, 0, strBytes.Length);
            }



        }


    }

    // --------------------------------------------------------------
    #endregion

    #region FileMode, FileAccess, and FileShare Enums
    // ------------------------ FileMode, FileAccess, and FileShare Enums -------------------------


    // FileMode Enum
    // -----------------------------------------------------------------
    //    public enum FileMode
    //    {
    //        CreateNew,
    //        Create,
    //        Open,
    //        OpenOrCreate,
    //        Truncate,
    //        Append
    //    }
    //
    // 
    //  Table 20-5. Members of the FileMode Enumeration         Member Meaning in Life
    // ------------------------------------------------------------------------------------------------------
    //  CreateNew     Informs the OS to make a new file.If it already exists, an IOException is thrown.
    //  Create        Informs the OS to make a new file.If it already exists, it will be overwritten.
    //  Open          Opens an existing file.If the file does not exist, a FileNotFoundException is thrown.
    //  OpenOrCreate  Opens the file if it exists; otherwise, a new file is created.
    //  Truncate      Opens an existing file and truncates the file to 0 bytes in size.
    //  Append        Opens a file, moves to the end of the file, and begins write operations(you can use this
    //                flag only with a write-only stream). If the file does not exist, a new file is created.



    // FileAccess Enum
    // --------------------
    // You use the second parameter of the Open() method, a value from the FileAccess enumeration, to
    // determine the read/write behavior of the underlying stream, as follows:
    // public enum FileAccess
    // {
    //     Read,
    //     Write,
    //     ReadWrite
    // }



    // FileShare Enum
    // --------------------
    // Finally, the third parameter of the Open() method, FileShare, specifies how to share the file among
    // other file handlers.Here are the core names:
    // 
    // public enum FileShare
    // {
    //     Delete,
    //     Inheritable,
    //     None,
    //     Read,
    //     ReadWrite,
    //     Write
    // }
    //
    //
    // Summary:
    //     Contains constants for controlling the kind of access other System.IO.FileStream
    //     objects can have to the same file.
    // [ComVisible(true)]
    // [Flags]
    // public enum FileShare
    // {
    //     //
    //     // Summary:
    //     //     Declines sharing of the current file. Any request to open the file (by this process
    //     //     or another process) will fail until the file is closed.
    //     None = 0,
    //     //
    //     // Summary:
    //     //     Allows subsequent opening of the file for reading. If this flag is not specified,
    //     //     any request to open the file for reading (by this process or another process)
    //     //     will fail until the file is closed. However, even if this flag is specified,
    //     //     additional permissions might still be needed to access the file.
    //     Read = 1,
    //     //
    //     // Summary:
    //     //     Allows subsequent opening of the file for writing. If this flag is not specified,
    //     //     any request to open the file for writing (by this process or another process)
    //     //     will fail until the file is closed. However, even if this flag is specified,
    //     //     additional permissions might still be needed to access the file.
    //     Write = 2,
    //     //
    //     // Summary:
    //     //     Allows subsequent opening of the file for reading or writing. If this flag is
    //     //     not specified, any request to open the file for reading or writing (by this process
    //     //     or another process) will fail until the file is closed. However, even if this
    //     //     flag is specified, additional permissions might still be needed to access the
    //     //     file.
    //     ReadWrite = 3,
    //     //
    //     // Summary:
    //     //     Allows subsequent deleting of a file.
    //     Delete = 4,
    //     //
    //     // Summary:
    //     //     Makes the file handle inheritable by child processes. This is not directly supported
    //     //     by Win32.
    //     Inheritable = 16
    // }


    // -------------------------------------------------------------------------
    #endregion

    #region The FileInfo.OpenRead() and FileInfo.OpenWrite() Methods
    // ------------------------ The FileInfo.OpenRead() and FileInfo.OpenWrite() Methods -------------------------
    // the FileInfo class also provides members named OpenRead() and OpenWrite(). As you might imagine, these methods
    // return a properly configured read-only or write-only FileStream object, without the need to supply various
    // enumeration values.
    // 
    // Like FileInfo.Create() and FileInfo.Open(), OpenRead() and OpenWrite() return a FileStream object
    // 
    public class FileInfoOpenReadAndOpenWrite
    {
        // Test Method
        public static void Test()
        {

            // ==============================> OpenRead() <==============================

            // Get a FileStream object with read-only permissions.
            FileInfo file = new FileInfo(@"C:\Test2.dat");

            using(FileStream fs = file.OpenRead())
            {
                // You are permissible to read data from file...

                // NotSupportedException Will be thrown if you try to write data with read only stream
                // System.NotSupportedException: Stream does not support writing.
                //fs.Write(new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 }, 0, 8);



                Console.WriteLine("Read from File...");
                string text = "";
                byte[] buffer = new byte[1024];
                int byteCount;
                do
                {
                    byteCount = fs.Read(buffer, 0, buffer.Length);
                    if(byteCount > 0)
                        text += Encoding.Default.GetString(buffer,0,byteCount);

                } while (byteCount > 0);
                
                //
                Console.WriteLine(text);
                
                
            }


            // ==============================> OpenWrite() <==============================
            // Get a FileStream object with Write-only permissions.
            FileInfo file2 = new FileInfo(@"C:\Test3.dat");

            using (FileStream fs = file2.OpenWrite())
            {
                // NotSupportedException Will be thrown if you try to read data with Write-only stream
                // System.NotSupportedException: Stream does not support reading.
                //byte[] buffer = new byte[1024];
                //fs.Read(buffer, 0, buffer.Length);



                // You are permissible to Write data to file...
                byte[] data = Encoding.Default.GetBytes("Hello i can write to you!");
                fs.Write(data, 0, data.Length);
            }

        }


    }

    // --------------------------------------------------------------
    #endregion

    #region The FileInfo.OpenText() Method
    // ------------------------ The FileInfo.OpenText() Method -------------------------
    // - the OpenText() method returns an instance of the StreamReader type.
    // - the StreamReader type provides a way to read character data from the underlying file.
    public class FileInfoOpenText
    {
        // Test Method
        public static void Test()
        {
            FileInfo file = new FileInfo(@"C:\Test3.dat");

            Console.WriteLine("Read From File...");
            using(StreamReader reader = file.OpenText())
            {
                while(!reader.EndOfStream)
                    Console.WriteLine(reader.ReadLine());
            }

        }


    }

    // --------------------------------------------------------------
    #endregion

    #region The FileInfo.CreateText() and FileInfo.AppendText() Methods
    // ------------------------ The FileInfo.CreateText() and FileInfo.AppendText() Methods -------------------------

    // CreateText():  Creates a System.IO.StreamWriter that writes a new text file.
    // Returns: A new StreamWriter.
    
    // Creates a System.IO.StreamWriter that appends text to the file represented by
    // this instance of the System.IO.FileInfo.
    // Returns: A new StreamWriter.

    //  the StreamWriter type provides a way to write character data to the underlying file
    public class FileInfoCreateTextAndAppendText
    {
        // Test Method
        public static void Test()
        {

            // CreateText: create file and add text to it, if it exists, write on it (truncate FileMode).
            FileInfo f6 = new FileInfo(@"C:\Test6.txt");
            using (StreamWriter swriter = f6.CreateText())      // 
            {
                // Use the StreamWriter object...
                swriter.WriteLine("Hello World from StreamWriter from CreateText() Method");
            }

            // append text to the end of the file, if not exists, create it and append text to it
            FileInfo f7 = new FileInfo(@"C:\FinalTest.txt");
            using (StreamWriter swriterAppend = f7.AppendText())    
            {
                // Use the StreamWriter object...
                swriterAppend.WriteLine("Hello World from StreamWriter from CreateText() Method");
            }

        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Working with the File Type
    // ------------------------ Working with the File Type -------------------------
    // The File type uses several static members to provide functionality almost 
    // identical to that of the FileInfo type.
    public class WorkingWithTheFileType
    {
        // Test Method
        public static void Test()
        {
            // Obtain FileStream object via File.Create().
            using (FileStream fs = File.Create(@"C:\Test.dat"))
            { }

            // Obtain FileStream object via File.Open().
            using (FileStream fs2 = File.Open(@"C:\Test2.dat",
            FileMode.OpenOrCreate,
            FileAccess.ReadWrite, FileShare.None))
            { }

            // Get a FileStream object with read-only permissions.
            using (FileStream readOnlyStream = File.OpenRead(@"Test3.dat"))
            { }

            // Get a FileStream object with write-only permissions.
            using (FileStream writeOnlyStream = File.OpenWrite(@"Test4.dat"))
            { }

            // Get a StreamReader object.
            using (StreamReader sreader = File.OpenText(@"C:\boot.ini"))
            { }

            // Get some StreamWriters.
            using (StreamWriter swriter = File.CreateText(@"C:\Test6.txt"))
            { }

            using (StreamWriter swriterAppend = File.AppendText(@"C:\FinalTest.txt"))
            { }

        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Additional File-Centric Members
    // ------------------------ Additional File-Centric Members -------------------------
    // The File type also supports a few members, shown in Table 20-6, 
    // which can greatly simplify the processes of reading and writing textual data..

    // Table 20-6. Methods of the File Type
    // -----------------------------------------------------------------------------------------------------------------
    // Method            Meaning in Life
    // -----------------------------------------------------------------------------------------------------------------
    // ReadAllBytes()    Opens the specified file, returns the binary data as an array of bytes, and then closes the file
    // ReadAllLines()    Opens a specified file, returns the character data as an array of strings, and then closes the file
    // ReadAllText()     Opens a specified file, returns the character data as a System.String, and then closes the file
    // WriteAllBytes()   Opens the specified file, writes out the byte array, and then closes the file
    // WriteAllLines()   Opens a specified file, writes out an array of strings, and then closes the file
    // WriteAllText()    Opens a specified file, writes the character data from a specified string, and then closes the file
    // -----------------------------------------------------------------------------------------------------------------
    public class AdditionalFileCentricMembers
    {
        // Test Method
        public static void Test()
        {
            Console.WriteLine("***** Simple I/O with the File Type *****\n");
            string[] myTasks = {
                "Fix bathroom sink", "Call Dave",
                "Call Mom and Dad", "Play Xbox One" };
            // Write out all data to file on C drive.
            File.WriteAllLines(@"tasks.txt", myTasks);

            // Read it all back and print out.
            foreach (string task in File.ReadAllLines(@"tasks.txt"))
            {
                Console.WriteLine("TODO: {0}", task);
            }

            FileInfo file = new FileInfo(@"TestMoa.txt");
            file.Create();
            Console.WriteLine(file.FullName);

        }


    }

    // --------------------------------------------------------------
    #endregion

    
}
