using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpCode.ProCSharpCode.Assemblies
{
    // The Role of.NET Core Assemblies
    // ------------------------------------------------------------------------------------
    //.NET Core applications are constructed by piecing together any number of assemblies.
    // Simply put, an assembly is a versioned, self-describing binary file hosted by the
    // CoreCLR.Now, despite that .NET Core assemblies have the same file extensions (*.exe
    // or *.dll) as previous Windows binaries, they have little in common under the hood
    // with those files
    //  - assemblies promot code reuse
    //  - assemblies are versionable units
    //  - assemblies establish a type boundary
    //  -assemblies are self-describing.

    //  a .NET Core assembly (*.dll or *.exe) consists of the following elements:
    //  ------------------------------------------------------------------------------------
    //• An operating system(e.g.Windows) file header
    //• A CLR file header
    //• CIL code
    //• Type metadata
    //• An assembly manifest
    //• Optional embedded resources

    // Installing the C++ Profiling Tools
    // -----------------------------------------------
    // you can search for it in the visual studio search
    // dumpbin /headers CarLibrary.dll
    // dumpbin /clrheader CarLibrary.dll
    //
    //

    // 1- The Operating System (Windows) File Header
    //  --------------------------------------------------------------------------------------
    //  The operating system file header establishes the fact that the assembly can be loaded and 
    //  manipulated by the target operating system(in the following example, Windows). 
    //  This header data also identifies the kind of application(console-based, GUI-based, 
    //  or*.dll code library) to be hosted by the operating system.


    // 2- The CLR File Header
    //  --------------------------------------------------------------------------------------
    //  The CLR header is a block of data that all.NET Core assemblies must support 
    //  (to be hosted by the CoreCLR. In a nutshell, this header defines numerous flags 
    //  that enable the runtime to understand the layout of the managed file. For example, 
    //  flags exist that identify the location of the metadata and resources within the file, 
    //  the version of the runtime the assembly was built against, the value of the (optional) 
    //  public key, and so forth.




    // 3-CIL Code (Common Intermediate Language Code): also it is called MSIL/IL
    //  --------------------------------------------------------------------------------------
    //At its core, an assembly contains CIL code, which, as you recall, is a platform- and CPU-agnostic
    //intermediate language.At runtime, the internal CIL is compiled on the fly using a just-in-time(JIT) compiler,
    //according to platform- and CPU-specific instructions.Given this design, .NET Core assemblies can indeed
    //execute on a variety of architectures, devices, and operating systems.




    // 4- The type Metadata
    // --------------------------------------------------------------------------------------
    // An assembly also contains metadata that completely describes the format of the contained types,
    // as well as the format of external types referenced by this assembly.The.NET Core
    // runtime uses this metadata to resolve the location of types (and their members) within
    // the binary, lay out types in memory, and facilitate remote method invocations.




    // 5- Assembly Metadata (Manifest)
    //  --------------------------------------------------------------------------------------
    //  An assembly must also contain an associated manifest(also referred to as assembly metadata). The
    //  manifest documents each module within the assembly, establishes the version of the assembly, and also
    //  documents any external assemblies referenced by the current assembly.As you will see over the course of
    //  this chapter, the CLR makes extensive use of an assembly’s manifest during the process of locating external
    //  assembly references.

    // 6- Optional Assembly Resources
    // ------------------------------------------------------------------------------------------
    // Finally, a.NET Core assembly may contain any number of embedded resources, such as application icons,
    //image files, sound clips, or string tables.In fact, the.NET Core platform supports satellite assemblies that
    //contain nothing but localized resources. This can be useful if you want to partition your resources based
    //on a specific culture (English, German, etc.) for the purposes of building international software.


    // .NET Standard
    //--------------------------------------------------------------------------------------------
    //  NET Standard is a new type of
    //  class library project that was introduced with.NET Core, and can be referenced by.NET as well as
    //  .NET Core applications. Each.NET Standard version defines a common set of APIs that
    //  must be supported by all.NET versions (.NET, .NET Core, Xamarin, etc.) to conform to the standard.

    public class AssemblyHouses
    {
        public static void Test()
        {
            Console.WriteLine("*** Fun with Probing Paths ***");
            Console.WriteLine($"TRUSTED_PLATFORM_ASSEMBLIES: ");
            //Use ':' on non-Windows platforms
            var list = AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")
            .ToString().Split(';');
            foreach (var dir in list)
            {
                Console.WriteLine(dir);
            }
            Console.WriteLine();
            Console.WriteLine($"PLATFORM_RESOURCE_ROOTS: {AppContext.GetData("PLATFORM_RESOURCE_ROOTS")}");
            Console.WriteLine();
            Console.WriteLine($"NATIVE_DLL_SEARCH_DIRECTORIES: {AppContext.GetData("NATIVE_DLL_SEARCH_DIRECTORIES")}");
            Console.WriteLine();
            Console.WriteLine($"APP_PATHS: {AppContext.GetData("APP_PATHS")}");
            Console.WriteLine();
            Console.WriteLine($"APP_NI_PATHS: {AppContext.GetData("APP_NI_PATHS")}");
            Console.WriteLine();
            Console.ReadLine();
        }
    }











}
