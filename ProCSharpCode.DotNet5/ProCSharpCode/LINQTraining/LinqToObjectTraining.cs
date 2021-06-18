using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProCSharpCode.ExtensionMethods;

namespace ProCSharpCode.LINQTraining
{

    // CHAPTER 12 LINQ to Objects
    // ====================================================================================================
    //    To be sure, data can be found in numerous locations,
    //including XML files, relational databases, in-memory collections, and primitive arrays.
    // The Language Integrated Query(LINQ) technology set, introduced initially in .NET 3.5, provides a concise,
    //symmetrical, and strongly typed manner to access a wide variety of data stores.

    //    LINQ-Specific Programming Constructs
    // -----------------------------------------------------------------------------------------------------
    //From a high level, LINQ can be understood as a strongly typed query language, embedded directly into the
    //grammar of C#. Using LINQ, you can build any number of expressions that have a look and feel similar to
    //that of a database SQL query.

    //    When LINQ was first introduced to the.NET platform in version 3.5, the C# and VB languages were each
    //expanded with a large number of new programming constructs used to support the LINQ technology set.
    //Specifically, the C# language uses the following core LINQ-centric features:
    //•	 Implicitly typed local variables
    //•	 Object/collection initialization syntax
    //•	 Lambda expressions
    //•	 Extension methods
    //•	 Anonymous types

    // Understanding the Role of LINQ
    // ------------------------------------------------------------
    // it is hard to deny that the vast majority of our programming time 
    // is spent obtaining and manipulating data.
    // Data Locations is: relational databases, XML documents, or simple text files.
    // ------------------------------------------------------------
    // Prior to.NET 3.5, interacting with a particular flavor of data required programmers to use very diverse
    // APIs. Consider, for example, Table 12-1

    // Table 12-1. Ways to Manipulate Various Types of Data
    //    The Data You Want             How to Obtain It
    // --------------------------------------------------------------------------------------------------------
    // Relational data                  System.Data.dll, System.Data.SqlClient.dll, and so on
    // XML document data                System.Xml.dll
    // Metadata tables The              System.Reflection namespace
    // Collections of objects           System.Array and the System.Collections/System.Collections.Generic namespaces

    //    Of course, nothing is wrong with these approaches to data manipulation.In fact, you can(and will)
    //certainly make direct use of ADO.NET, the XML namespaces, reflection services, and the various collection
    //types.However, the basic problem is that each of these APIs is an island unto itself, which offers little
    //in the way of integration. True, it is possible (for example) to save an ADO.NET DataSet as XML and
    //then manipulate it via the System.Xml namespaces, but nonetheless, data manipulation remains rather
    //asymmetrical.
    //The LINQ API is an attempt to provide a consistent, symmetrical manner in which programmers can
    //obtain and manipulate “data” in the broad sense of the term. Using LINQ, you are able to create directly
    //within the C# programming language constructs called query expressions. These query expressions are based
    //on numerous query operators that have been intentionally designed to look and feel similar (but not quite
    //identical) to a SQL expression

    // However, based on where you are applying your LINQ queries,
    // you will encounter various terms, such as the following:
    // •	 LINQ to Objects: This term refers to the act of applying LINQ queries to arrays and
    //       collections.
    // •	 LINQ to XML: This term refers to the act of using LINQ to manipulate and query
    //       XML documents.
    // •	 LINQ to DataSet: This term refers to the act of applying LINQ queries to ADO.NET
    //       DataSet objects.
    // •	 LINQ to Entities: This aspect of LINQ allows you to make use of LINQ queries within
    //       the ADO.NET Entity Framework (EF) API.
    // •	 Parallel LINQ (aka PLINQ): This allows for parallel processing of data returned from
    //       a LINQ query.

    // Today, LINQ is an integral part of the.NET base class libraries, managed languages, and Visual
    // Studio itself.

    // LINQ Expressions Are Strongly Typed
    // ------------------------------------------------------------
    // It is also important to point out that a LINQ query expression(unlike a traditional SQL statement) is
    // strongly typed.Therefore, the C# compiler will keep you honest and make sure that these expressions
    // are syntactically well-formed.

    // The Core LINQ Assemblies
    // ------------------------------------------------------------
    //    Table 12-2. Core LINQ-Centric Assemblies
    // Assembly          Meaning in Life
    // -----------------------------------------------------------------------------------------------------
    // System.Core.dll   
    //                  Defines the types that represent the core LINQ API.This is the
    //                  one assembly you must have access to if you want to use any
    //                  LINQ API, including LINQ to Objects.
    //
    // System.Data.DataSetExtensions.dll 
    //                  Defines a handful of types to integrate ADO.NET types into the
    //                  LINQ programming paradigm (LINQ to DataSet).
    // 
    // System.Xml.Linq.dll 
    //                  Provides functionality for using LINQ with XML document data(LINQ to XML).
    // -----------------------------------------------------------------------------------------------------

    // LINQ and Implicitly Typed Local Variables
    // ------------------------------------------------------------------------------------------------------------
    // As a rule of thumb, you will always want to make use of implicit typing when capturing the results
    // of a LINQ query. Just remember, however, that (in a vast majority of cases) the real return value is a type
    // implementing the generic IEnumerable<T> interface.
    // Exactly what this type is under the covers (OrderedEnumerable<TElement, TKey>,
    // WhereArrayIterator<T>, etc.) is irrelevant and not necessary to discover. 
    // you can simply use the var keyword within a foreach construct to iterate over the fetched data

    #region Applying LINQ Queries to Primitive Arrays
    // ------------------------ Applying LINQ Queries to Primitive Arrays -------------------------
    // LINQ query expressions can be used to iterate over data
    // containers that implement the generic IEnumerable<T> interface. However, the.NET System.Array class
    // type (used to represent the array of strings and array of integers) does not implement this contract.

    // While System.Array does not directly implement the IEnumerable<T> interface, it indirectly gains
    // the required functionality of this type (as well as many other LINQ-centric members) via the static
    // System.Linq.Enumerable class type.
    // This utility class defines a good number of generic extension methods(such as Aggregate<T>(),
    // First<T>(), Max<T>(), etc.), which System.Array(and other types) acquires in the background.



    class LinqToArrays
    {
        public static void Test()
        {
            // Assume we have an array of strings.
            string[] names = {
                "Moamen Mohammed Gamal Soroor",
                "Rahma Mohammed Gamal Soroor",
                "Abd-Allah Mostafa Kamal Amer",
                "Ali Elhafy",
                "Waleed Soroor",
                "Ahmed Mohammed Kabil",
                "Ali Mohammed Kabil"
            };

            QuerySyntaxFindNamesInArray(names);
            MethodSyntaxFindNamesInArray(names);
            PrimitivesFindNamesInArray(names);


        }



        #region Simle Example with Array of Integers
        // ------------------------ Simle Example with Array of Integers -------------------------
        // ====================================================================================================

        // Using Query Syntax / Query Expression
        public static void SubSetIntegers(int[] ints)
        {
            // Query Create
            IEnumerable<int> subset = from i in ints
                                      where i > 10 && i < 20
                                      orderby i
                                      select i;

            // Reflect Over Linq
            Console.WriteLine($"***** Info about your query using Query Expression *****");
            Console.WriteLine($@"    resultSet Type: {subset.GetType().Name}");
            Console.WriteLine($@"resultSet Assembly: {subset.GetType().Assembly.GetName().Name}");
            Console.WriteLine("".Padding(40, "-"));

            // Query Execution/ Extraction
            // Print out the results.
            foreach (int number in subset)
            {
                Console.WriteLine($@"number: {number}");
            }

        }

        // Using Extension Methods Syntax / Methods Syntax
        public static void SubSetIntegersUsingExtensionMethods(int[] ints)
        {
            // Query Create
            IEnumerable<int> subset = ints.Where(i => i < 20 && i > 10)
                .OrderBy(i => i)
                .Select(i => i);



        }
        // -------------------------------------------------------------------------
        #endregion

        #region Find Names in String Array
        // ------------------------ Find Names in String Array -------------------------
        // =============================================================================
        // Using Query Syntax / Query Expression
        public static void QuerySyntaxFindNamesInArray(string[] names)
        {
            // Build a query expression to find the names in the array that have Soroor Keyword.
            IEnumerable<string> query = from name in names
                                        where name.Contains("Soroor")
                                        orderby name
                                        select name;
            // Note that the Next two method calls are my custom extension Methods
            query.Execute("Find Names in Array With Query Syntax");
            query.ReflectOverLinq("Query Syntax");
        }

        // Using Extension Methods Syntax / Methods Syntax
        public static void MethodSyntaxFindNamesInArray(string[] names)
        {

            // Build a query expression to find the names in the array that have Soroor Keyword.
            IEnumerable<string> query =
                names.Where(n => n.Contains("Soroor"))
                .OrderBy(n => n)
                .Select(n => n);

            query.Execute("Find Names in Array With Methods Syntax");
            query.ReflectOverLinq("Method Syntax");
        }


        // use of programming primitives such as if statements and for loops. 
        public static void PrimitivesFindNamesInArray(string[] args)
        {

            //  use of programming primitives such as if statements and for loops. 
            string[] result = new string[args.Length];

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Contains("Soroor"))
                    result[i] = args[i];
                else
                    result[i] = null;
            }

            Array.Sort(result);

            // Print out the results.
            result.Execute("Find Names in Array using programming primitives");
        }

        // While I am sure you can think of ways to tweak the previous method, the fact remains that LINQ queries
        // can be used to radically simplify the process of extracting new subsets of data from a source.Rather than
        // building nested loops, complex if/else logic, temporary data types, and so on, the C# compiler will perform
        // the dirty work on your behalf, once you create a fitting LINQ query

        // ------------------------------------------------------------------------------------
        #endregion




    }
    // -------------------------------------------------------------------------
    #endregion

    #region The Role of Deferred Execution
    // ------------------------ The Role of Deferred Execution -------------------------
    //    Another important point regarding LINQ query expressions is that they are not actually evaluated until you
    //iterate over the sequence.Formally speaking, this is termed deferred execution.The benefit of this approach
    //is that you are able to apply the same LINQ query multiple times to the same container and rest assured you
    //are obtaining the latest and greatest results.
    public class DeferredExecution
    {
        // Test Method
        public static void Test()
        {

            int[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

            var query = from number in numbers where number > 0 && number < 50 select number;

            // LINQ statement evaluated here! (foreach inside Execute method is what exectute the query)
            query.Execute("The Role of Deferred Execution: Before Change");

            numbers[0] = 60;

            // LINQ statement evaluated again! changes will be affected the new result sequence
            query.Execute("The Role of Deferred Execution: After Change");

        }


    }

    // --------------------------------------------------------------
    #endregion

    #region The Role of Immediate Execution
    // ------------------------ The Role of Immediate Execution -------------------------
    // When you need to evaluate a LINQ expression from outside the confines of foreach logic, you are
    // able to call any number of extension methods defined by the Enumerable type such as ToArray<T>(),
    // ToDictionary<TSource, TKey>(), and ToList<T>(). These methods will cause a LINQ query to execute 
    // at the exact moment you call them to obtain a snapshot of the data. After you have done so, 
    // the snapshot of data may be independently manipulated.

    // The usefulness of immediate execution is obvious when you need to return the results of a LINQ query
    // to an external caller.

    public class ImmediateExecution
    {
        // Test Method
        public static void Test()
        {
            int[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

            // Get data RIGHT NOW as int[].
            int[] arr = (from n in numbers where n > 20 && n < 60 select n).ToArray<int>();
            //int[] arr2 = (from n in numbers where n > 20 && n < 60 select n).ToArray();
            arr.Execute("The Role of Immediate Execution: Before Target Change");

            numbers[0] = 35;
            arr.Execute("The Role of Immediate Execution: After Target Change");

            Console.WriteLine("You can Find the array from the linq doesn't affect with target update.");
            Console.WriteLine();

            // Get data RIGHT NOW as List<int>
            List<int> list = (from n in numbers where n > 20 && n < 60 select n).ToList<int>();
            //List<int> list2 = (from n in numbers where n > 20 && n < 60 select n).ToList();
            arr.Execute();
        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Returning the Result of a LINQ Query
    // ------------------------ Returning the Result of a LINQ Query -------------------------
    // It is possible to define a field within a class (or structure) whose value is the result of a LINQ query. To do
    // so, however, you cannot make use of implicit typing (as the var keyword cannot be used for fields), and the
    // target of the LINQ query cannot be instance-level data; therefore, it must be static.
    // ---------------------------------------------------------------------------------------

    public class ReturningTheResultOfLINQ
    {
        private int[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

        private static int[] staticNumbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

        // Can't use var, and the target can't be instance-level.
        //private IEnumerable<int> numbersQuery= from n in numbers where n > 20 && n < 60 select n;

        private IEnumerable<int> staticNumbersQuery = from n in staticNumbers where n > 20 && n < 60 select n;

        public void PrintNumbers()
        {
            staticNumbersQuery.Execute("Returning The Result Of LINQ");
        }

        // Linq as return
        static IEnumerable<string> GetStringSubset()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            // Note subset is an IEnumerable<string>-compatible object.
            IEnumerable<string> theRedColors = from c in colors where c.Contains("Red") select c;
            return theRedColors;
        }

        // Returning LINQ Results via Immediate Execution
        static string[] GetStringSubsetAsArray()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            var theRedColors = from c in colors where c.Contains("Red") select c;
            // Map results into an array.
            return theRedColors.ToArray();
        }
        //Immediate execution is also critical when attempting to return to the caller the results of a LINQ
        //projection.You’ll examine this topic a bit later in the chapter.Next up, let’s look at how to apply LINQ
        //queries to generic and nongeneric collection objects.



        // Test Method
        public static void Test()
        {
            ReturningTheResultOfLINQ linq = new ReturningTheResultOfLINQ();
            linq.PrintNumbers();

            IEnumerable<string> resultQuery = GetStringSubset();
            resultQuery.Execute("Returning LINQ Results");

            string[] array = GetStringSubsetAsArray();
            array.Execute("Returning LINQ Results via Immediate Execution");


        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Applying LINQ Queries to Collection Objects
    // ------------------------ Applying LINQ Queries to Collection Objects -------------------------
    class Car
    {
        
        public string PetName { get; set; } = "";
        public string Color { get; set; } = "";
        public int Speed { get; set; }
        public string Make { get; set; } = "";
    }

    
    public class LINQToCollectionObjects
    {
        #region Linq queries

        // Applying LINQ Queries to Generic Collections
        static void GetFastCars(List<Car> myCars)
        {
            // Find all Car objects in the List<>, where the Speed is
            // greater than 55.
            var fastCars = from c in myCars where c.Speed > 55 select c;

            // Execute the fastcar query
            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
        }

        // Applying LINQ Queries to Generic Collections
        static void GetFastBMWs(List<Car> myCars)
        {
            // Find the fast BMWs!
            var fastCars = from c in myCars where c.Speed > 90 && c.Make == "BMW" select c;

            // Execute the fast BMWs
            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
        }

        // Applying LINQ Queries to Nongeneric Collections
        static void LINQOverArrayList()
        {
            Console.WriteLine("***** LINQ over ArrayList *****");

            // Here is a nongeneric collection of cars.
            ArrayList myCars = new ArrayList() 
            {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };

            // Transform ArrayList into an IEnumerable<T>-compatible type.
            var myCarsEnum = myCars.OfType<Car>();

            // Create a query expression targeting the compatible type.
            var fastCars = from c in myCarsEnum where c.Speed > 55 select c;

            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }

        }

        // Applying LINQ Queries to Nongeneric Collections, using OfType<>() Method as Filter
        static void OfTypeAsFilter()
        {
            // Extract the ints from the ArrayList.
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "string data" });
            var myInts = myStuff.OfType<int>();

            // Prints out 10, 400, and 8.
            foreach (int i in myInts)
            {
                Console.WriteLine("Int value: {0}", i);
            }
        }
        #endregion

        // Test Method
        public static void Test()
        {
            Console.WriteLine("***** LINQ over Generic Collections *****\n");

            // Make a List<> of Car objects.
            List<Car> myCars = new List<Car>() {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };

            GetFastCars(myCars);
            Console.WriteLine();

            GetFastBMWs(myCars);
            Console.WriteLine();

            LINQOverArrayList();
            Console.WriteLine();

            OfTypeAsFilter();
            Console.WriteLine();

        }


    }

    // --------------------------------------------------------------
    #endregion

    #region Investigating the C# LINQ Query Operators

    // ------------------------ Investigating the C# LINQ Query Operators -------------------------
    //    Table 12-3. Common LINQ Query Operators
    // Query Operators                   Meaning in Life
    // -----------------------------------------------------------------------------------------------------------
    // from, in                          Used to define the backbone for any LINQ expression, which allows
    //                                   you to extract a subset of data from a fitting container.
    // 
    // Where                             Used to define a restriction for which items to extract from a container.
    //
    // Select                            Used to select a sequence from the container.
    // 
    // join, on, equals, into            Performs joins based on specified key.Remember, these “joins” do
    //                                   not need to have anything to do with data in a relational database.
    // 
    // orderby, ascending, descending    Allows the resulting subset to be ordered in ascending or descending order.
    // group, by                         Yields a subset with data grouped by a specified value.
    // -----------------------------------------------------------------------------------------------------------


    class ProductInfo
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int NumberInStock { get; set; }

        public override string ToString() => $@"
ProductInfo: Name={Name}, Description={Description}, Number in Stock={NumberInStock}";
    }

    #region Test Linq Query Operators
    // ------------------------ TestLinqQueryOperators -------------------------

    public class TestLinqQueryOperators
    {
        // Test Method
        public static void Test()
        {
            // This array will be the basis of our testing...
            ProductInfo[] itemsInStock = new[] {
                new ProductInfo{ Name = "Mac's Coffee",
                                Description = "Coffee with TEETH",
                                NumberInStock = 24},
                new ProductInfo{ Name = "Milk Coffee",
                                Description = "Coffee with Milk",
                                NumberInStock = 26},
                new ProductInfo{ Name = "Milk Maid Milk",
                                Description = "Milk cow's love",
                                NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu",
                                Description = "Bland as Possible",
                                NumberInStock = 120},
                new ProductInfo{ Name = "Cruchy Pops",
                                Description = "Cheezy, peppery goodness",
                                NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water",
                                Description = "From the tap to your wallet",
                                NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza",
                                Description = "Everyone loves pizza!",
                                NumberInStock = 73}
                };

            // We will call various methods here!

            SelectAllCoffee(itemsInStock);
            Console.WriteLine();

            ListProductNames(itemsInStock);
            Console.WriteLine();

            GetOverstock(itemsInStock);
            Console.WriteLine();

            GetNamesAndDescriptions(itemsInStock);
            Console.WriteLine();

            Array objs = GetProjectedSubsetAsArray(itemsInStock);
            foreach (object o in objs)
            {
                Console.WriteLine(o); // Calls ToString() on each anonymous object.
            }
            Console.WriteLine();


            GetCountFromQuery();
            Console.WriteLine();

            DisplayConcat();
            Console.WriteLine();

            DisplayDiff();
            Console.WriteLine();

            DisplayIntersection();
            Console.WriteLine();

            DisplayUnion();
            Console.WriteLine();

            DisplayConcatNoDups();
            Console.WriteLine();

            AggregateOps();



        }

        #region Linq queries 
        static void SelectEverything(ProductInfo[] products)
        {
            // Get everything!
            Console.WriteLine("All product details:");

            var allProducts = from product in products select product;

            foreach (var product in allProducts)
            {
                Console.WriteLine(product.ToString());
            }

        }

        static void SelectAllCoffee(ProductInfo[] products)
        {
            // Get everything!
            Console.WriteLine("All Coffee Products details:");
            var allCoffee = from p in products where p.Name.Contains("Coffee") select p;

            foreach (var item in allCoffee)
            {
                Console.WriteLine(item.ToString());
            }


        }

        static void ListProductNames(ProductInfo[] products)
        {
            // Now get only the names of the products.
            Console.WriteLine("Only product names:");
            var names = from p in products select p.Name;

            foreach (var n in names)
            {
                Console.WriteLine("Name: {0}", n);
            }
        }

        static void GetOverstock(ProductInfo[] products)
        {
            Console.WriteLine("The overstock items!");

            // Get only the items where we have more than
            // 25 in stock.
            var overstock = from p in products where p.NumberInStock > 25 select p;

            foreach (ProductInfo c in overstock)
            {
                Console.WriteLine(c.ToString());
            }
        }

        // Projecting New Data Types
        // -----------------------------------------------------------------------------------------------
        //It is also possible to project new forms of data from an existing data source.Let’s assume you want to take the
        //incoming ProductInfo[] parameter and obtain a result set that accounts only for the name and description
        //of each item.To do so, you can define a select statement that dynamically yields a new anonymous type.
        static void GetNamesAndDescriptions(ProductInfo[] products)
        {
            Console.WriteLine("Names and Descriptions:");
            var nameDesc = from p in products select new { p.Name, p.Description };
            foreach (var item in nameDesc)
            {
                // Could also use Name and Description properties directly.
                Console.WriteLine(item.ToString());
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Description);
            }
        }

        // Note that you must use a literal System.Array object and cannot make use of the C# array declaration
        // syntax, given that you don’t know the underlying type of type because you are operating on a compilergenerated anonymous class! Also note that you are not specifying the type parameter to the generic
        // ToArray<T>() method, as you once again don’t know the underlying data type until compile time, which is
        // too late for your purposes.
        // The obvious problem is that you lose any strong typing, as each item in the Array object is assumed to
        // be of type Object. Nevertheless, when you need to return a LINQ result set that is the result of a projection
        // operation, transforming the data into an Array type (or another suitable container via other members of the
        // Enumerable type) is mandatory.
        static Array GetProjectedSubsetAsArray(ProductInfo[] products)
        {
            Console.WriteLine("Get Projected Subset As Array or list - Names and Descriptions:");
            var nameDesc = from p in products select new { p.Name, p.Description };

            // Map set of anonymous objects to an Array object.
            Array result = nameDesc.ToArray();
            
            return result;
        }

        static void GetCountFromQuery()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                                "Fallout 3", "Daxter", "System Shock 2"};

            // Get count from the query.
            int numb = (from g in currentVideoGames where g.Length > 6 select g).Count();

            // Print out the number of items.
            Console.WriteLine("{0} items honor the LINQ query.", numb);
        }

        static void ReverseEverything(ProductInfo[] products)
        {
            Console.WriteLine("Product in reverse:");
            var allProducts = from p in products select p;
            foreach (var prod in allProducts.Reverse())
            {
                Console.WriteLine(prod.ToString());
            }
        }

        static void AlphabetizeProductNames(ProductInfo[] products)
        {
            // Get names of products, alphabetized.
            var subset = from p in products orderby p.Name select p;

            Console.WriteLine("Ordered by Name:");
            foreach (var p in subset)
            {
                Console.WriteLine(p.ToString());
            }
        }

        // Except() extension method, which will return a LINQ result set that contains the differences between two
        // containers.
        static void DisplayDiff()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };

            var carDiff = (from c in myCars select c)
              .Except(from c2 in yourCars select c2);

            Console.WriteLine("Here is what you don't have, but I do:");
            foreach (string s in carDiff)
                Console.WriteLine(s); // Prints Yugo.
        }

        //The Intersect() method will return a result set that contains the common data items in a set of
        //containers.
        static void DisplayIntersection()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };

            // Get the common members.
            var carIntersect = (from c in myCars select c).Intersect(from c2 in yourCars select c2);

            Console.WriteLine("Here is what we have in common:");
            foreach (string s in carIntersect)
                Console.WriteLine(s); // Prints Aztec and BMW.
        }

        //The Union() method, as you would guess, returns a result set that includes all members of a batch of
        //LINQ queries.Like any proper union, you will not find repeating values if a common member appears more
        //than once.
        static void DisplayUnion()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };

            // Get the union of these containers.
            var carUnion = (from c in myCars select c).Union(from c2 in yourCars select c2);

            Console.WriteLine("Here is everything:");
            foreach (string s in carUnion)
                Console.WriteLine(s); // Prints all common members.
        }

        //the Concat() extension method returns a result set that is a direct concatenation of LINQ result sets.
        static void DisplayConcat()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };

            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);

            // Prints:
            // Yugo Aztec BMW BMW Saab Aztec.
            foreach (string s in carConcat)
                Console.WriteLine(s);
        }

        // In other cases, you might want to remove duplicate entries in your data.
        // To do so, simply call the Distinct() extension method
        static void DisplayConcatNoDups()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };

            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);

            // Prints:
            // Yugo Aztec BMW Saab Aztec.
            foreach (string s in carConcat.Distinct())
                Console.WriteLine(s);
        }


        //LINQ queries can also be designed to perform various aggregation operations on the result set.The Count()
        //extension method is one such aggregation example.Other possibilities include obtaining an average,
        //maximum, minimum, or sum of values using the Max(), Min(), Average(), or Sum() members of the
        //Enumerable class.
        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };

            // Various aggregation examples.
            Console.WriteLine("Max temp: {0}", (from t in winterTemps select t).Max());

            Console.WriteLine("Min temp: {0}", (from t in winterTemps select t).Min());

            Console.WriteLine("Avarage temp: {0}", (from t in winterTemps select t).Average());

            Console.WriteLine("Sum of all temps: {0}", (from t in winterTemps select t).Sum());
        }
        #endregion
    }

    // --------------------------------------------------------------
    #endregion

    // -------------------------------------------------------------------------
    #endregion

    #region The Internal Representation of LINQ Query Statements
    // ------------------------ The Internal Representation of LINQ Query Statements -------------------------
    //    At this point, you have been introduced to the process of building query expressions using various C# query
    //operators(such as from, in, where, orderby, and select). Also, you discovered that some functionality of
    //the LINQ to Objects API can be accessed only when calling extension methods of the Enumerable class.
    //The truth of the matter, however, is that when compiled, the C# compiler actually translates all C# LINQ
    //operators into calls on methods of the Enumerable class.
    //A great many of the methods of Enumerable have been prototyped to take delegates as arguments.In
    //particular, many methods require a generic delegate named Func<>

    public class InternalRepresentationOfLINQ
    {
        
        public static void Test()
        {
            Console.WriteLine("======== The Internal Representation of LINQ Query Statements ========");
            QueryStringWithOperators();
            Console.WriteLine();

            QueryStringsWithEnumerableAndLambdas();
            Console.WriteLine();

            QueryStringsWithAnonymousMethods();
            Console.WriteLine();

            QueryStringsWithRawDelegates();
            Console.WriteLine();

        }

        #region Use Linq operators
        static void QueryStringWithOperators()
        {
            Console.WriteLine("***** Using Query Operators *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

            var subset = from game in currentVideoGames
                         where game.Contains(" ")
                         orderby game
                         select game;

            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }
        #endregion

        #region With enumerable and lambdas
        static void QueryStringsWithEnumerableAndLambdas()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

            // Build a query expression using extension methods
            // granted to the Array via the Enumerable type.
            var subset = currentVideoGames.Where(game => game.Contains(" "))
              .OrderBy(game => game).Select(game => game);

            // Print out the results.
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();

        }
        static void QueryStringsWithEnumerableAndLambdas2()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

            // Break it down!
            var gamesWithSpaces = currentVideoGames.Where(game => game.Contains(" "));
            var orderedGames = gamesWithSpaces.OrderBy(game => game);
            var subset = orderedGames.Select(game => game);

            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }
        #endregion

        #region With anonymous methods
        static void QueryStringsWithAnonymousMethods()
        {
            Console.WriteLine("***** Using Anonymous Methods *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

            // Build the necessary Func<> delegates using anonymous methods.
            Func<string, bool> searchFilter =
                delegate (string game) { return game.Contains(" "); };
            Func<string, string> itemToProcess = delegate (string s) { return s; };

            // Pass the delegates into the methods of Enumerable.
            var subset = currentVideoGames.Where(searchFilter)
                .OrderBy(itemToProcess).Select(itemToProcess);

            // Print out the results.
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }
        #endregion


        #region With Raw Delegates
        public static void QueryStringsWithRawDelegates()
        {
            Console.WriteLine("***** Using Raw Delegates *****");

            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

            // Build the necessary Func<> delegates.
            Func<string, bool> searchFilter = new Func<string, bool>(Filter);
            Func<string, string> itemToProcess = new Func<string, string>(ProcessItem);

            // Pass the delegates into the methods of Enumerable.
            var subset = currentVideoGames
              .Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);

            // Print out the results.
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }

        // Delegate targets.
        public static bool Filter(string game) { return game.Contains(" "); }
        public static string ProcessItem(string game) { return game; } 
        #endregion

    }

    // --------------------------------------------------------------
    #endregion


}
