using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpCode.ProCSharpCode.Assemblies
{
    public class AssembliesDemos
    {

    }

    #region Testing Assembly Embedded Resources
    // Testing Assembly Embedded Resources
    // --------------------------------------------------------------------
    //    To directly embed a resource using Visual Studio:
    // - Add the file to your project
    // - Set its build action to Embedded Resource
    // - Visual Studio always prefixes resource names with the project’s default namespace,
    // plus the names of any subfolders in which the file is contained.So, if your project’s
    // default namespace was Westwind.Reports and your file was called banner.jpg in the
    // folder pictures, the resource name would be Westwind.Reports.pictures.banner.jpg.


    public class EmbeddedResourceTest
    {
        public static void Test()
        {
            Console.WriteLine("Embedded resources Test");
            Assembly asm = Assembly.GetEntryAssembly();

            // First Scenario: file is exists and embedded
            // ---------------------------------------------------
            // reading info.txt file in Resources folder
            // note string passed to GetManifestResourceStream is defaultNamespace.folderName.fileName
            using StreamReader stream = new StreamReader(asm.GetManifestResourceStream("ProCSharpCode.Resources.info.txt") ?? Stream.Null);
            if (stream.BaseStream != Stream.Null)
            {
                Console.WriteLine(stream.ReadToEnd());

            }
            else
            {
                Console.WriteLine("No Embedded File exist with that name.");
            }




            // First Scenario: file is not exist or not marked as embedded.
            // ---------------------------------------------------
            // reading notexistfile.txt file in Resources folder
            // note string passed to GetManifestResourceStream is defaultNamespace.folderName.fileName
            using StreamReader stream2 = new StreamReader(asm.GetManifestResourceStream("ProCSharpCode.Resources.notexistfile.txt") ?? Stream.Null);
            if (stream2.BaseStream != Stream.Null)
            {
                Console.WriteLine(stream.ReadToEnd());

            }
            else
            {
                Console.WriteLine("No Embedded File exist with that name.");
            }



            // reading sea.jpg image file in Resources folder
            //using Stream stream3 = asm.GetManifestResourceStream("ProCSharpCode.Resources.sea.jpg")?? Stream.Null;
            //var image = System.Drawing.Image.FromStream(stream3); // you need wpf


            // The stream returned is seekable, so you can also do this:
            // ====================================================================
            using Stream stream4 = asm.GetManifestResourceStream("ProCSharpCode.Resources.Images.sea.jpg") ?? Stream.Null;
            if (stream4 != Stream.Null)
            {
                byte[] data;
                data = new BinaryReader(stream4).ReadBytes((int)stream4.Length);


                // print only the first 30 byte of the image in hex format
                Console.WriteLine(string.Join(" ",data.Select(d=> $"{d:x2}").Take(30)));
            }
            else
                Console.WriteLine("No Embedded File exist with that name.");
        }


    }


    #endregion



}
