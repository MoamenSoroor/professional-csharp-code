using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpBook
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickTests.QuickTest.Test();

            //CSharpBasics.DataTypesBasics.TestBasics();
            //CSharpBasics.MethodsBasics.TestMethods();
            //CSharpBasics.ControlFlowTraining.TestControlFlow();
            //CSharpBasics.ArraysTraining.TestArrays();
            //CSharpBasics.StringsTraining.TestStrings();




            //CSharpBasics.EnumsTraining.TestEnums();
            //CSharpBasics.StructuresTraining.TestStructures();
            //CSharpBasics.TuplesTraining.TestTuples();
            //CSharpBasics.NullablesTraining.TestNullables();

            //ExceptionHandling.ExceptionHandlingTraining.TestExceptionHandling();


            //OOPEncapsulation.OOPTraining.TestOOP();
            //OOPInheritanceAndPlymorphism.OOPTraining.TestOOP();
            //OOPInterfaces.OOPTraining.TestOOP();


            //CSharpGenerics.GenericsTraining.Test();
            //CSharpCollections.CollectionsTraining.TestCollections();

            //CSharpDelegates.DelegateTraining.Test();
            //EventListenerSystem.TestEventListenerSystem.Test();

            //CSharpOperatorOverloading.OperatorOverloadingTraining.Test();
            //ExtensionMethods.MyExtensionMethods.Test();
            //AnonymousTypes.MyAnonymousTypes.Test();
            //LINQTraining.LinqToObjectTraining.Test();

            Book book = BuildBook();

            //Console.WriteLine(book);
            //Console.WriteLine(book.Index);
            //Console.WriteLine();

            var subjects = book.Index.ToSubjects();

            var result = from subject in subjects
                         where subject.Chapter.ID == 17 && subject.ID == 1
                         select subject;

            book.Index.ExecuteSubjects(result);

            //book.Index.ExecuteAll();
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadLine();
        }


        public static Book BuildBook()
        {
            Book book = new Book(100, "Pro C#7 Book");

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

            #endregion

            return book;

        }


    }


}
