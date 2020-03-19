using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using ProCSharpBook.BookSystem;

namespace ProCSharpBook
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Book book = BuildBook();

            Console.WriteLine(book);

            var subjects = book.Index.ToSubjects();

            var result = from subject in subjects
                         where subject.Chapter.ID == -1
                         select subject;

            book.Index.ExecuteSubjects(result);

            //book.Index.ExecuteAll();
            //Console.WriteLine("Press any key to continue . . .");
            Console.ReadLine();
        }


        public static Book BuildBook()
        {
            Book book = new Book(100, "Pro C#7 Book");

            #region Chapter 3 : Core C# Programming Constructs, Part I
            Chapter chapter3 = new Chapter(3, "3 - Core C# Programming Constructs, Part I");
            book.Index.Chapters.Add(chapter3);
            chapter3.Subjects.Add(new Subject(01, "DataTypes Basics", chapter3, CSharpBasics.DataTypesBasics.TestBasics));
            chapter3.Subjects.Add(new Subject(02, "Methods Basics", chapter3, CSharpBasics.MethodsBasics.TestMethods));
            chapter3.Subjects.Add(new Subject(03, "ControlFlow Training", chapter3, CSharpBasics.ControlFlowTraining.TestControlFlow));
            chapter3.Subjects.Add(new Subject(04, "Arrays Training", chapter3, CSharpBasics.ArraysTraining.TestArrays));
            chapter3.Subjects.Add(new Subject(05, "Strings Training", chapter3, CSharpBasics.StringsTraining.TestStrings));
            #endregion

            #region Chapter 4 : Core C# Programming Constructs, Part II
            Chapter chapter4 = new Chapter(4, "4 - Core C# Programming Constructs, Part II");
            book.Index.Chapters.Add(chapter4);
            chapter4.Subjects.Add(new Subject(01, "Enums Training",       chapter4, CSharpBasics.EnumsTraining.TestEnums));
            chapter4.Subjects.Add(new Subject(02, "Structures Training",         chapter4, CSharpBasics.StructuresTraining.TestStructures));
            chapter4.Subjects.Add(new Subject(03, "Tuples Training",   chapter4, CSharpBasics.TuplesTraining.TestTuples));
            chapter4.Subjects.Add(new Subject(04, "Nullables Training",        chapter4, CSharpBasics.NullablesTraining.TestNullables));

            #endregion

            #region Chapter 5 : Understanding Encapsulation
            Chapter chapter5 = new Chapter(5, "Chapter 5: Understanding Encapsulation");
            book.Index.Chapters.Add(chapter5);
            chapter5.Subjects.Add(new Subject(01, "Understanding Encapsulation", chapter5, OOPEncapsulation.OOPTraining.TestOOP));

            #endregion

            #region Chapter 6 : Understanding Inheritance and Polymorphism
            Chapter chapter6 = new Chapter(6, "Chapter 6: Understanding Inheritance and Polymorphism");
            book.Index.Chapters.Add(chapter6);
            chapter6.Subjects.Add(new Subject(01, "Understanding Inheritance and Polymorphism", chapter6, OOPInheritanceAndPlymorphism.OOPTraining.TestOOP));
            #endregion

            #region Chapter 7 : Understanding Structured Exception Handling
            Chapter chapter7 = new Chapter(7, "Chapter 7: Understanding Structured Exception Handling");
            book.Index.Chapters.Add(chapter7);
            chapter7.Subjects.Add(new Subject(01, "Exception Handling", chapter7, ExceptionHandling.ExceptionHandlingTraining.TestExceptionHandling));
            #endregion

            #region Chapter 8 : Working with Interfaces
            Chapter chapter8 = new Chapter(8, "Chapter 8: Working with Interfaces");
            book.Index.Chapters.Add(chapter8);
            chapter8.Subjects.Add(new Subject(01, "Working with Interfaces", chapter8, OOPInterfaces.OOPTraining.TestOOP));
            #endregion

            #region Chapter 9 : Collections and Generics
            Chapter chapter9 = new Chapter(9, "Chapter 9: Collections and Generics");
            book.Index.Chapters.Add(chapter9);
            chapter9.Subjects.Add(new Subject(01, "Generics", chapter9, CSharpGenerics.GenericsTraining.Test));
            chapter9.Subjects.Add(new Subject(02, "Collections", chapter9, CSharpCollections.CollectionsTraining.TestCollections));
            #endregion

            #region Chapter 10 : Delegates, Events, and Lambda Expressions
            Chapter chapter10 = new Chapter(10, "Chapter 10: Delegates, Events, and Lambda Expressions");
            book.Index.Chapters.Add(chapter10);
            chapter10.Subjects.Add(new Subject(01, "Delegates, Events, and Lambda Expressions", chapter10, CSharpDelegates.DelegateTraining.Test));
            chapter10.Subjects.Add(new Subject(02, "Interrface Based Event Listener System ", chapter10, EventListenerSystem.TestEventListenerSystem.Test));
            #endregion

            #region Chapter 11: Advanced C# Language Features
            Chapter chapter11 = new Chapter(11, "Chapter 11: Advanced C# Language Features");
            book.Index.Chapters.Add(chapter11);
            chapter11.Subjects.Add(new Subject(01, "Indexer", chapter11, CSharpOperatorOverloading.IndexerMethods.Test));
            chapter11.Subjects.Add(new Subject(02, "Operator Overloading", chapter11, CSharpOperatorOverloading.OperatorOverloading.Test));
            chapter11.Subjects.Add(new Subject(03, "Custom Type Conversion", chapter11, CSharpOperatorOverloading.CustomTypeConversions.Test));
            chapter11.Subjects.Add(new Subject(04, "Extension Methods", chapter11, ExtensionMethods.MyExtensionMethods.Test));
            chapter11.Subjects.Add(new Subject(05, "Anonymous Types", chapter11, AnonymousTypes.MyAnonymousTypes.Test));
            #endregion
           
            #region Chapter 12 : LINQ To Objects
            Chapter chapter12 = new Chapter(12, "12- LINQ TO Object");
            book.Index.Chapters.Add(chapter12);
            chapter12.Subjects.Add(new Subject(01, "Applying LINQ Queries to Primitive Arrays", chapter12, LINQTraining.LinqToArrays.Test));
            chapter12.Subjects.Add(new Subject(02, "The Role of Deferred Execution", chapter12, LINQTraining.DeferredExecution.Test));
            chapter12.Subjects.Add(new Subject(03, "The Role of Immediate Execution", chapter12, LINQTraining.ImmediateExecution.Test));
            chapter12.Subjects.Add(new Subject(04, "Returning the Result of a LINQ Query", chapter12, LINQTraining.ReturningTheResultOfLINQ.Test));
            chapter12.Subjects.Add(new Subject(05, "Applying LINQ Queries to Collection Objects", chapter12, LINQTraining.LINQToCollectionObjects.Test));
            chapter12.Subjects.Add(new Subject(06, "Investigating the C# LINQ Query Operators", chapter12, LINQTraining.TestLinqQueryOperators.Test));
            chapter12.Subjects.Add(new Subject(07, "The Internal Representation of LINQ Query Statements", chapter12, LINQTraining.InternalRepresentationOfLINQ.Test));
            #endregion

            #region Chapter 13 : Understanding Object Lifetime
            Chapter chapter13 = new Chapter(13, "13- Understanding Object Lifetime");
            book.Index.Chapters.Add(chapter13);
            chapter13.Subjects.Add(new Subject(01, "Garbage Collector", chapter13, ObjectLifeTime.GarbageCollector.Test));
            chapter13.Subjects.Add(new Subject(02, "Forcing Garbage Collection", chapter13, ObjectLifeTime.ForcingGarbageCollection.Test));
            chapter13.Subjects.Add(new Subject(03, "Building Finalizable Objects", chapter13, ObjectLifeTime.BuildingFinalizableObjects.Test));
            chapter13.Subjects.Add(new Subject(04, "Building Disposable Objects", chapter13, ObjectLifeTime.BuildingDisposableObjects.Test));
            chapter13.Subjects.Add(new Subject(05, "The Using Keyword With IDisposable Objects", chapter13, ObjectLifeTime.TheUsingKeywordWithIDisposableObjects.Test));
            chapter13.Subjects.Add(new Subject(06, "Building Finalizable and Disposable Types", chapter13, ObjectLifeTime.BuildingFinalizableAndDisposableTypes.Test));
            chapter13.Subjects.Add(new Subject(07, "Formalized Disposal Pattern", chapter13, ObjectLifeTime.FormalizedDisposalPattern.Test));
            chapter13.Subjects.Add(new Subject(08, "Lazy Object Instantiation", chapter13, ObjectLifeTime.LazyObjectInstantiation.Test));
            #endregion

            #region Chapter 15 : type reflection, late Binding, and attriBute-Based programming
            Chapter chapter15 = new Chapter(15, "type reflection, late Binding, and attriBute-Based programming");
            book.Index.Chapters.Add(chapter15);
            chapter15.Subjects.Add(new Subject(01, "Getting Type Reference Approaches", chapter15, ReflectionTraining.GettingTypeRefApproaches.Test));
            chapter15.Subjects.Add(new Subject(02, "Building a Custom Metadata Viewer", chapter15, ReflectionTraining.MetadataViewer.Test));
            chapter15.Subjects.Add(new Subject(03, "Dynamically Loading Assemblies", chapter15, ReflectionTraining.DynamicLoadAssembly.Test));
            chapter15.Subjects.Add(new Subject(04, "Understanding Late Binding", chapter15, ReflectionTraining.LateBinding.Test));
            chapter15.Subjects.Add(new Subject(05, "Reflecting on Attributes Using Early Binding", chapter15, Attributes.ReflectOnAttributesUsingEarlyBinding.Test));
            chapter15.Subjects.Add(new Subject(06, "Reflecting on Attributes Using Late Binding", chapter15, Attributes.ReflectOnAttributesUsingLateBinding.Test));
            #endregion

            #region Chapter 16 : Dynamic Types and the Dynamic Language Runtime
            Chapter chapter16 = new Chapter(16, "Dynamic Types and the Dynamic Language Runtime");
            book.Index.Chapters.Add(chapter16);
            chapter16.Subjects.Add(new Subject(01, "implicity typing - var keyword", chapter16, DynamicProgramming.ImplicityTyping.Test));
            chapter16.Subjects.Add(new Subject(02, "object Reference - object keyword", chapter16, DynamicProgramming.ObjectReferenceVariable.Test));
            chapter16.Subjects.Add(new Subject(03, "The Role of C# dynamic keyword", chapter16, DynamicProgramming.CSharpDynamicKeyword.Test));
            chapter16.Subjects.Add(new Subject(04, "Calling Members on Dynamically Declared Data", chapter16, DynamicProgramming.InvokeMembersOnDynamicData.Test));
            chapter16.Subjects.Add(new Subject(05, "The Role of the Microsoft.CSharp.dll Assembly", chapter16, DynamicProgramming.MicrosoftCSharpAssembly.Test));
            chapter16.Subjects.Add(new Subject(06, "Simplifying Late-Bound Calls Using Dynamic Types", chapter16, DynamicProgramming.SimplifyingLateBoundCallsUsingDynamicTypes.Test));
            chapter16.Subjects.Add(new Subject(07, "COM Interop Using C# Dynamic Data", chapter16, DynamicProgramming.COMInteropUsingDynamic.Test));
            #endregion

            #region Chapter 17 : Processes, AppDomains, and Object Contexts
            Chapter chapter17 = new Chapter(17, "Processes, AppDomains, and Object Contexts");
            book.Index.Chapters.Add(chapter17);
            chapter17.Subjects.Add(new Subject(01, "Processes Manipulator", chapter17, ProcessesTraining.Processes.Test));
            chapter17.Subjects.Add(new Subject(02, "Interacting with the Default Application Domain", chapter17, ProcessesTraining.DefaultAppDomain.Test));
            chapter17.Subjects.Add(new Subject(03, "Interacting with Custom Application Domain", chapter17, ProcessesTraining.CustomAppDomains.Test));
            #endregion

            return book;

        }


        public static void RunOldStyle()
        {

            CSharpBasics.DataTypesBasics.TestBasics();
            CSharpBasics.MethodsBasics.TestMethods();
            CSharpBasics.ControlFlowTraining.TestControlFlow();
            CSharpBasics.ArraysTraining.TestArrays();
            CSharpBasics.StringsTraining.TestStrings();


            CSharpBasics.EnumsTraining.TestEnums();
            CSharpBasics.StructuresTraining.TestStructures();
            CSharpBasics.TuplesTraining.TestTuples();
            CSharpBasics.NullablesTraining.TestNullables();

            ExceptionHandling.ExceptionHandlingTraining.TestExceptionHandling();


            OOPEncapsulation.OOPTraining.TestOOP();
            OOPInheritanceAndPlymorphism.OOPTraining.TestOOP();
            OOPInterfaces.OOPTraining.TestOOP();


            CSharpGenerics.GenericsTraining.Test();
            CSharpCollections.CollectionsTraining.TestCollections();

            CSharpDelegates.DelegateTraining.Test();
            EventListenerSystem.TestEventListenerSystem.Test();

            CSharpOperatorOverloading.OperatorOverloadingTraining.Test();
            ExtensionMethods.MyExtensionMethods.Test();
            AnonymousTypes.MyAnonymousTypes.Test();


        }


    }


}
