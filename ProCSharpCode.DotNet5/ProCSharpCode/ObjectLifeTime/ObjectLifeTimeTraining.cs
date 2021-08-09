using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpCode.ObjectLifeTime
{
    #region Introduction
    // ------------------------ Introduction -------------------------
    // Now you will see how the CLR manages allocated class instances (aka objects) via garbage collection.
    // .NET objects are allocated to a region of memory termed the managed
    // heap, where they will be automatically destroyed by the garbage collector “sometime in the future.

    // you’ll learn how to programmatically
    // interact with the garbage collector using the System.GC class type (which is something you will typically not
    // be required to do for a majority of your.NET projects).

    // Next, you’ll examine how the virtual System.Object.
    // Finalize() method and IDisposable interface can be used to build classes that release internal unmanaged
    // resources in a predictable and timely manner.

    //    You will also delve into some functionality of the garbage collector introduced in .NET 4.0, including
    //background garbage collections and lazy instantiation using the generic System.Lazy<> class. 
    // -------------------------------------------------------------------------
    #endregion

    #region The System.GC Type
    // ------------------------ The System.GC Type -------------------------

    public class GarbageCollector
    {
        // Test Method
        public static void Test()
        {


        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Forcing a Garbage Collection
    // ------------------------ Forcing a Garbage Collection -------------------------

    public class ForcingGarbageCollection
    {
        // Test Method
        public static void Test()
        {


        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Building Finalizable Objects
    // ------------------------ Building Finalizable Objects -------------------------

    public class BuildingFinalizableObjects
    {
        // Test Method
        public static void Test()
        {


        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Building Disposable Objects
    // ------------------------ Building Disposable Objects -------------------------

    public class BuildingDisposableObjects
    {
        // Test Method
        public static void Test()
        {


        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Reusing the C# using Keyword
    // ------------------------ Reusing the C# using Keyword -------------------------

    public class TheUsingKeywordWithIDisposableObjects
    {
        // Test Method
        public static void Test()
        {


        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Building Finalizable and Disposable Types
    // ------------------------ Building Finalizable and Disposable Types -------------------------

    public class BuildingFinalizableAndDisposableTypes
    {
        // Test Method
        public static void Test()
        {


        }


    }

    // --------------------------------------------------------------
    #endregion

    #region A Formalized Disposal Pattern
    // ------------------------ A Formalized Disposal Pattern -------------------------

    public class FormalizedDisposalPattern
    {
        // Test Method
        public static void Test()
        {


        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Understanding Lazy Object Instantiation
    // ------------------------ Understanding Lazy Object Instantiation -------------------------

    public class LazyObjectInstantiation
    {
        // Test Method
        public static void Test()
        {


        }


    }

    // --------------------------------------------------------------
    #endregion


    class ObjectLifeTimeTraining
    {
        public static void Test()
        {

        }

    }
}
