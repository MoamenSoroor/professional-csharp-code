using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ProCSharpBook.SystemIO
{
    #region The Abstract Stream Class
    // ------------------------ The Abstract Stream Class -------------------------
    // In the world of I/O manipulation, a stream
    // represents a chunk of data flowing between a source and a destination.Streams provide a common way to
    // interact with a sequence of bytes, regardless of what kind of device (e.g., file, network connection, or printer)
    // stores or displays the bytes in question.
    //  
    // The abstract System.IO.Stream class defines several members that provide support for synchronous
    // and asynchronous interactions with the storage medium(e.g., an underlying file or memory location).
    // 
    // So, The concept of a stream is not limited to file I/O. To be sure, the .neT libraries provide 
    // stream access to networks, memory locations, and other stream-centric abstractions.
    // 
    // Stream descendants represent data as a raw stream of bytes; therefore, working directly with
    // raw streams can be quite cryptic.
    //
    // Seeking: 
    // --------
    // Some Stream-derived types support seeking, which refers to the process
    // of obtaining and adjusting the current position in the stream.

    // Table 20-7. Abstract Stream Members
    // --------------------------------------------------------------------------------------------------
    // Member        Meaning in Life
    // --------------------------------------------------------------------------------------------------
    // CanRead       |
    // CanWrite      |
    // CanSeek       | Determines whether the current stream supports reading, seeking, and/or writing.
    //  
    // Length        Returns the length of the stream in bytes.
    // 
    // Position      Determines the position in the current stream.
    //
    // Seek()        Sets the position in the current stream.  
    // SetLength()   Sets the length of the current stream.   
    // 
    // Close()       Closes the current stream and releases any resources(such as sockets and file handles)   
    //               associated with the current stream.Internally, this method is aliased to the Dispose() method;
    //               therefore, closing a stream is functionally equivalent to disposing a stream.
    // 
    // Flush()       Updates the underlying data source or repository with the current state of the buffer    
    //               and then clears the buffer. If a stream does not implement a buffer, this method does
    //               nothing.
    // 
    // 
    // Read()        |
    // ReadByte()    |
    // ReadAsync()   | Reads a sequence of bytes (or a single byte) from the current stream and advances
    //                 the current position in the stream by the number of bytes read.
    // 
    // Write()       |
    // WriteByte()   |
    // WrriteAsync() | Writes a sequence of bytes (or a single byte) to the current stream and advances the
    //                    current position in this stream by the number of bytes written.
    // --------------------------------------------------------------------------------------------------


    public class AbstractStream
    {
        // Test Method
        public static void Test()
        {
            using (FileStream fs = File.Open(@"MyMessage.dat", FileMode.Create))
            {
                string message = "Hello I am The Message.";
                byte[] messageInBytes = Encoding.Default.GetBytes(message);

                // Write message to file...
                fs.Write(messageInBytes, 0, messageInBytes.Length);

                // then let's read what we wrote.

                // set the position at the beginning of the file
                fs.Position = 0;

                // read bytes of file:
                Console.Write("Message in Bytes: ");
                for (int i = 0; i < fs.Length; i++)
                {
                    Console.Write(fs.ReadByte() + " ");
                }
                Console.WriteLine();


                // another way to read
                fs.Position = 0;

                StringBuilder builder = new StringBuilder();
                byte[] buffer = new byte[1024];
                int byteCount = 0;
                while ((byteCount = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    builder.Append(Encoding.Default.GetString(buffer, 0, byteCount));
                }

                Console.WriteLine("Message: " + builder.ToString());


            }

        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Working with StreamWriters, and abstract base class TextWriter
    // ------------------------ Working with StreamWriters-------------------------
    // The StreamWriter and StreamReader classes are useful whenever you need to read or write character-based
    // data(e.g., strings). Both of these types work by default with Unicode characters; however, you can change
    // this by supplying a properly configured System.Text.Encoding object reference. 

    // The StreamWriter type(as well as StringWriter ) derives from an abstract base class named TextWriter.
    // This class defines members that allow derived types to write textual data to a given character stream.


    //    Table 20-8. Core Members of TextWriter
    // ------------------------------------------------------------------------------------------------------
    // Member           Meaning in Life
    // ------------------------------------------------------------------------------------------------------
    // Close()          This method closes the writer and frees any associated resources.In the process,
    //                  the buffer is automatically flushed (again, this member is functionally equivalent to
    //                  calling the Dispose() method).
    // 
    // Flush()          This method clears all buffers for the current writer and causes any buffered data to
    //                  be written to the underlying device; however, it does not close the writer.
    // 
    // NewLine          This property indicates the newline constant for the derived writer class. The default
    //                  line terminator for the Windows OS is a carriage return, followed by a line feed(\r\n).
    // 
    // Write()
    // WriteAsync()
    //                  This overloaded method writes data to the text stream without a newline constant.
    // WriteLine()
    // WriteLineAsync()
    //                  This overloaded method writes data to the text stream with a newline constant.
    // ------------------------------------------------------------------------------------------------------

    // Console.WriteLine()
    // -------------------
    // The last two members of the TextWriter class probably look familiar to you. If you recall, the
    // System.Console type has Write() and WriteLine() members that push textual data to the standard
    // output device.In fact, the Console.In property wraps a TextReader, and the Console.Out property wraps a
    // TextWriter.

    // StreamWriter:
    // -------------
    // The derived StreamWriter class provides an appropriate implementation 
    // for the Write(), Close(), and Flush() methods, 
    // 
    // and it defines the additional AutoFlush property.When set to true, this property forces
    // StreamWriter to flush all data every time you perform a write operation. 
    // 
    // Be aware that you can gain better performance by setting AutoFlush to false, 
    // provided you always call Close() when you finish writing with a StreamWriter.
    // 
    public class WorkingWithStreamWriter
    {
        // Test Method
        public static void Test()
        {
            Console.WriteLine("***** Fun with StreamWriter / StreamReader *****\n");
            // Get a StreamWriter and write string data.
            using (StreamWriter writer = File.CreateText("Reminder.txt"))
            {
                writer.WriteLine("First Line");
                writer.WriteLine("Second Line");
                writer.WriteLine("Third Line");
                for (int i = 0; i < 10; i++)
                {
                    writer.Write("{0} ",i);
                }
                // Insert a new line.
                writer.Write(writer.NewLine);
            }
        }

        public static void DirectlyCreateStreamWriter()
        {
            using (StreamWriter writer = new StreamWriter("Reminder.txt"))
            {
                // ...
            }
        }



    }

    // --------------------------------------------------------------
    #endregion

    #region Working with StreamReaders , and abstract base class TextReader
    // ------------------------ Working with StreamReaders -------------------------
    // The StreamWriter and StreamReader classes are useful whenever you need to read or write character-based
    // data(e.g., strings). Both of these types work by default with Unicode characters; however, you can change
    // this by supplying a properly configured System.Text.Encoding object reference. 
    // 
    // StreamReader derives from an abstract type named TextReader, as does the related StringReader type
    // 
    // The TextReader base class provides a limited set of functionality to each of these descendants;
    // specifically, it provides the ability to read and peek into a character stream.

    // Table 20-9. TextReader Core Members
    // -----------------------------------------------------------------------------------------------------
    // Member            Meaning in Life
    // -----------------------------------------------------------------------------------------------------
    // Peek()            Returns the next available character(expressed as an integer) without actually
    //                   changing the position of the reader.A value of -1 indicates you are at the end of
    //                   the stream.
    // Read()
    // ReadAsync()
    //                   Reads data from an input stream.
    // ReadBlock()
    // ReadBlockAsync()
    //                   Reads a specified maximum number of characters from the current stream and
    //                   writes the data to a buffer, beginning at a specified index.
    // ReadLine()
    // ReadLineAsync()
    //                   Reads a line of characters from the current stream and returns the data as a
    //                   string (a null string indicates EOF).
    // ReadToEnd()
    // ReadToEndAsync()
    //                   Reads all characters from the current position to the end of the stream and
    //                   returns them as a single string.
    // -----------------------------------------------------------------------------------------------------
    public class WorkingWithStreamReader
    {
        // Test Method
        public static void Test()
        {
            Console.WriteLine("***** Fun with StreamWriter / StreamReader *****\n");
            using (StreamReader reader = File.OpenText("Reminder.txt"))
            {
                while(!reader.EndOfStream)
                    Console.WriteLine(reader.ReadLine());

                // the other way:
                // -----------------------------------------------
                //string input = null;
                //while ((input = reader.ReadLine()) != null)
                //    Console.WriteLine(input);
                // -----------------------------------------------
            }

        }

        public static void DirectlyCreateStreamReader()
        {
            using (StreamReader reader = new StreamReader("Reminder.txt"))
            {
                // ...
            }


        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Working with StringWriters and StringReaders
    // ------------------------ Working with StringWriters and StringReaders -------------------------
    // Working with StringWriters and StringReaders
    // You can use the StringWriter and StringReader types to treat textual information 
    // as a stream of inmemory characters.
    // 
    // This can prove helpful when you would like to append 
    // character-based information to an underlying buffer.
    public class WorkingWithStringWritersAndStringReaders
    {
        // Test Method
        public static void Test()
        {
            Console.WriteLine("***** Fun with StringWriter / StringReader *****\n");
            // Create a StringWriter and emit character data to memory.
            using (StringWriter strWriter = new StringWriter())
            {
                strWriter.WriteLine("Don't forget Mother's Day this year...");
                // Get a copy of the contents (stored in a string) and dump
                // to console.
                Console.WriteLine("Contents of StringWriter:\n{0}", strWriter);
            }

            using (StringWriter strWriter = new StringWriter())
            {
                strWriter.WriteLine("Don't forget Mother's Day this year...");
                Console.WriteLine("Contents of StringWriter:\n{0}", strWriter);
                // Get the internal StringBuilder.
                StringBuilder sb = strWriter.GetStringBuilder();
                sb.Insert(0, "Hey!! ");
                Console.WriteLine("-> {0}", sb.ToString());
                sb.Remove(0, "Hey!! ".Length);
                Console.WriteLine("-> {0}", sb.ToString());
            }

            using (StringWriter strWriter = new StringWriter())
            {
                strWriter.WriteLine("Don't forget Mother's Day this year...");
                Console.WriteLine("Contents of StringWriter:\n{0}", strWriter);
                // Read data from the StringWriter.
                using (StringReader strReader = new StringReader(strWriter.ToString()))
                {
                    string input = null;
                    while ((input = strReader.ReadLine()) != null)
                        Console.WriteLine(input);
                }
            }

        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Working with BinaryWriters and BinaryReaders
    // ------------------------ Working with BinaryWriters and BinaryReaders -------------------------

    public class BinaryWritersAndBinaryReaders
    {
        // Test Method
        public static void Test()
        {
            WriteBinary();
            ReadBinary();
        }


        public static void WriteBinary()
        {
            // Open a binary writer for a file.
            FileInfo f = new FileInfo("BinFile.dat");
            using (BinaryWriter writer = new BinaryWriter(f.OpenWrite()))
            {
                Console.WriteLine("base stream: {0}", writer.BaseStream);

                double d = 12.23;
                int i = 1000;
                string str = "Hello World!";

                writer.Write(d);
                writer.Write(i);
                writer.Write(str);
            }

            Console.WriteLine("Write Done!");
        }


        public static void ReadBinary()
        {
            // Open a binary writer for a file.
            FileInfo f = new FileInfo("BinFile.dat");
            using (BinaryReader reader = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine("base stream: {0}", reader.BaseStream);

                Console.WriteLine(reader.ReadDouble());
                Console.WriteLine(reader.ReadInt32());
                Console.WriteLine(reader.ReadString());

            }

            Console.WriteLine("Read Done!");
        }



    }

    // --------------------------------------------------------------
    #endregion

    #region Watching Files Programmatically
    // ------------------------ Watching Files Programmatically -------------------------
    // Now that you have a better handle on the use of various readers and writers, you’ll look at the role of the
    // FileSystemWatcher class. This type can be quite helpful when you want to monitor(or “watch”) files on your
    // system programmatically.Specifically, you can instruct the FileSystemWatcher type to monitor files for
    // any of the actions specified by the System.IO.NotifyFilters enumeration (many of these members are
    // self-explanatory, but you should still check the .NET Framework 4.7 SDK documentation for more details).
    // 
    // public enum NotifyFilters
    // {
    //     Attributes, CreationTime,
    //     DirectoryName, FileName,
    //     LastAccess, LastWrite,
    //     Security, Size
    // }
    // 
    // To begin working with the FileSystemWatcher type, you need to set the Path property to specify the
    // name(and location) of the directory that contains the files you want to monitor, as well as the Filter
    // property that defines the file extensions of the files you want to monitor.
    // At this point, you may choose to handle the Changed, Created, and Deleted events, all of which work in
    // conjunction with the FileSystemEventHandler delegate. This delegate can call any method matching the
    // following pattern:
    // ---------------------------------------------------------------------------
    // // The FileSystemEventHandler delegate must point
    // // to methods matching the following signature.
    // void MyNotificationHandler(object source, FileSystemEventArgs e)
    // ---------------------------------------------------------------------------
    // 
    // You can also handle the Renamed event using the RenamedEventHandler delegate type, which can call
    // methods that match the following signature:
    // ---------------------------------------------------------------------------
    // // The RenamedEventHandler delegate must point
    // // to methods matching the following signature.
    // void MyRenamedHandler(object source, RenamedEventArgs e)
    // ---------------------------------------------------------------------------
    //
    public class WatchingFiles
    {
        // Test Method
        public static void Test()
        {
            Console.WriteLine("-------------- File Watcher --------------");
            FileSystemWatcher watcher = new FileSystemWatcher();

            try
            {
                // Establish the path to the directory to watch.
                watcher.Path = @"C:\MyFolder";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ArgumentException: " + ex.Message);
            }

            // Set up the things to be on the lookout for.
            watcher.NotifyFilter = NotifyFilters.LastWrite
                | NotifyFilters.LastAccess
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName
                | NotifyFilters.Size;

            // Only watch text and docx files.
            watcher.Filter = "*.txt";

            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Changed;
            watcher.Deleted += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;

            // Start Monitoring
            watcher.EnableRaisingEvents = true;

            // wait until user press q
            Console.WriteLine("Press Q to Exit Monitor");
            while (Console.Read() != 'q') ;

        }

        private static void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1}",e.OldFullPath,e.FullPath);
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: {0} {1}", e.FullPath, e.ChangeType);
        }
    }

    // --------------------------------------------------------------
    #endregion

}
