using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpBookTraining
{
    // ======================================================================================
    // you will learn how to handle runtime anomalies in your C# code through the use of
    // structured exception handling.Not only will you examine the C# keywords that allow you 
    // to handle such matters(try, catch, throw, finally, when), but you will also come to
    // understand the distinction between application-level and system-level exceptions
    // ======================================================================================
    //  it should be clear that .NET structured exception handling is a technique
    // for dealing with runtime exceptions.
    // ======================================================================================
    // The C# programming language offers five keywords (try, catch, throw, finally, and when) 
    // that allow you to throw and handle exceptions.The object that represents the problem at
    // hand is a class extending System.Exception(or a descendent thereof). 
    // ====================================================================================== 
    // All exceptions ultimately derive from the System.Exception base class, 
    // which in turn derives from System.Object
    // ======================================================================================
    // By and large, exceptions should be thrown only when a more terminal condition has been
    // met(for example, not finding a necessary file, failing to connect to a database, 
    // and the like). 
    // ======================================================================================
    // Prior to C# 7, throw was a statement, which meant you could throw an exception only 
    // where statements are allowed.With C# 7, throw is available as an expression as well 
    // and can be called anywhere expressions are allowed.
    // ======================================================================================




    // ======================================================================================
    // public class Exception : ISerializable, _Exception
    // --------------------------------------------------------------------------------------
    // public Exception();
    // public Exception(string message);
    // public Exception(string message, Exception innerException);
    // protected Exception(SerializationInfo info, StreamingContext context);
    // 
    // public virtual string Source { get; set; }
    // public virtual string HelpLink { get; set; }
    // public virtual string StackTrace { get; }
    // public MethodBase TargetSite { get; }
    // public Exception InnerException { get; }
    // public virtual string Message { get; }
    // public int HResult { get; protected set; }
    // public virtual IDictionary Data { get; }

    // protected event EventHandler<SafeSerializationEventArgs> SerializeObjectState;

    // public virtual Exception GetBaseException();
    // public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
    // public Type GetType();
    // public override string ToString();
    // ======================================================================================

    // Core Members of the System.Exception Type
    // ======================================================================================
    // Data Property
    // --------------------------------------------------------------------------------------
    // This read-only property retrieves a collection of key-value pairs
    // (represented by an object implementing IDictionary) that provide
    // additional, programmer-defined information about the exception.By
    // default, this collection is empty.

    // HelpLink Property
    // --------------------------------------------------------------------------------------
    // This property gets or sets a URL to a help file or web site describing the error
    // in full detail.

    // InnerException Property
    // --------------------------------------------------------------------------------------
    // This read-only property can be used to obtain information about the
    // previous exceptions that caused the current exception to occur.The
    // previous exceptions are recorded by passing them into the constructor of
    // the most current exception.

    // Message Property
    // --------------------------------------------------------------------------------------
    // This read-only property returns the textual description of a given error. The
    // error message itself is set as a constructor parameter.
    // Source This property gets or sets the name of the assembly, or the object, that threw
    // the current exception.

    // StackTrace Property
    // --------------------------------------------------------------------------------------
    // This read-only property contains a string that identifies the sequence of
    // calls that triggered the exception.As you might guess, this property is useful
    // during debugging or if you want to dump the error to an external error log.

    // TargetSite Property
    // --------------------------------------------------------------------------------------
    // This read-only property returns a MethodBase object, which describes
    // numerous details about the method that threw the exception (invoking
    // ToString() will identify the method by name)


    // ======================================================================================
    // Using Exception Class VS Building Custom Exception class drived Exception
    // ======================================================================================
    // The Data property is useful in that it allows you to pack in custom information regarding 
    // the error at hand, without requiring the building of a new class type to extend the 
    // Exception base class. As helpful as the Data property may be, however, it is still common 
    // for .NET developers to build strongly typed exception classes, which handle custom data 
    // using strongly typed properties. This approach allows the caller to catch a specific 
    // exception-derived type, rather than having to dig into a data collection to obtain 
    // additional details.To understand how to do this, you need to examine the distinction 
    // between system-level and application-level exceptions.


    // System-Level Exceptions(System.SystemException)
    // ======================================================================================
    // The .NET base class libraries define many classes that ultimately derive from System.Exception.For
    // example, the System namespace defines core exception objects such as ArgumentOutOfRangeException,
    // IndexOutOfRangeException, StackOverflowException, and so forth.Other namespaces define exceptions
    // that reflect the behavior of that namespace.For example, System.Drawing.Printing defines printing
    // exceptions, System.IO defines input/output-based exceptions, System.Data defines database-centric
    // exceptions, and so forth.
    // Exceptions that are thrown by the.NET platform are (appropriately) called system exceptions. These
    // exceptions are generally regarded as nonrecoverable, fatal errors. System exceptions derive directly from a
    // base class named System.SystemException, which in turn derives from System.Exception(which derives
    // from System.Object).
    // public class SystemException : Exception
    // {
    //     // Various constructors.
    // }

    // Given that the System.SystemException type does not add any additional functionality beyond a set
    // of custom constructors, you might wonder why SystemException exists in the first place.Simply put, when
    // an exception type derives from System.SystemException, you are able to determine that the.NET runtime
    // is the entity that has thrown the exception, rather than the codebase of the executing application.



    // Application-Level Exceptions(System.ApplicationException)
    // ======================================================================================
    // Given that all.NET exceptions are class types, you are free to create your own application-specific exceptions.
    // However, because the System.SystemException base class represents exceptions thrown from the CLR, you
    // might naturally assume that you should derive your custom exceptions from the System.Exception type.You
    // could do this, but you could instead derive from the System.ApplicationException class.

    // public class ApplicationException : Exception
    // {
    //     // Various constructors.
    // }

    // Like SystemException, ApplicationException does not define any additional members beyond a set
    // of constructors.Functionally, the only purpose of System.ApplicationException is to identify the source
    // of the error.When you handle an exception deriving from System.ApplicationException, you can assume
    // the exception was raised by the codebase of the executing application, rather than by the .NET base class
    // libraries or.NET runtime engine.

    // in practice, few .net developers build custom exceptions that extend ApplicationException.
    // rather, it is more common to simply subclass System.Exception; however, either approach is technically valid.

    // Building Custom Exceptions
    // ======================================================================================
    // If you want to build a truly prim-and-proper custom exception class, you want to make sure your type
    // adheres to.NET best practices.Specifically, this requires that your custom exception does the following:
    //      - Derives from Exception/ApplicationException
    //      - Is marked with the [System.Serializable] attribute
    //      - Defines a default constructor
    //      - Defines a constructor that sets the inherited Message property
    //      - Defines a constructor to handle “inner exceptions”
    //      - Defines a constructor to handle the serialization of your type


    // InnerException
    // ======================================================================================

    // ======================================================================================
    // Summary
    // ======================================================================================
    // In this chapter, you examined the role of structured exception handling. When a method needs to send an
    // error object to the caller, it will allocate, configure, and throw a specific System.Exception-derived type via
    // the C# throw keyword. The caller is able to handle any possible incoming exceptions using the C# catch
    // keyword and an optional finally scope.Since C# 6.0, the ability to create exception filters using the optional
    // when keyword was added, and C# 7 has expanded the locations from where you can throw exceptions.
    // When you are creating your own custom exceptions, you ultimately create a class type deriving
    // from System.ApplicationException, which denotes an exception thrown from the currently executing
    // application.In contrast, error objects deriving from System.SystemException represent critical (and fatal)
    // errors thrown by the CLR. Last but not least, this chapter illustrated various tools within Visual Studio that
    // can be used to create custom exceptions (according to .NET best practices) as well as debug exceptions



    class ExceptionHandlingTraining
    {
        public static void TestExceptionHandling()
        {
            try
            {
                ExceptionHandlingCases();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception In {ex.TargetSite.DeclaringType}.{ex.TargetSite.Name} {ex.TargetSite.MemberType} {ex.TargetSite.MemberType}: {ex.Message}");
            }

        }
        public static void ExceptionHandlingCases()
        {
            //ExampleCar1();
            ExampleCar2(); // unhandled exception
            //ExampleCar22();
            //ExampleCar3();
            //ExampleCar4();
            //ExampleCar5();
            //ExampleCar52();
            //ExampleCar53();
            //ExampleCar54();
            //ExampleCar55();

        }
        

        // Without Exception Handling Mechanism
        // ---------------------------------------------------------------------------------------------------------------
        private static void ExampleCar1()
        {
            Console.WriteLine("***** Simple Exception Example *****");
            Console.WriteLine("=> Creating a car and stepping on it!");
            Car1 myCar = new Car1("Zippy", 20);
            myCar.CrankTunes(true);
            for (int i = 0; i < 10; i++)
                myCar.Accelerate(10);

            // separator
            Console.WriteLine("".PadLeft(40,'='));
        }

        // Exception Handling Mechanism , but Throws Exception without Handling
        // ---------------------------------------------------------------------------------------------------------------
        private static void ExampleCar2()
        {
            Console.WriteLine("***** Simple Exception Example *****");
            Console.WriteLine("=> Creating a car and stepping on it!");
            Car2 myCar = new Car2("Zippy", 20);
            myCar.CrankTunes(true);
            for (int i = 0; i < 10; i++)
                myCar.Accelerate(10);

            Console.WriteLine("".PadLeft(40, '='));
        }

        // Catching Exceptions
        // ---------------------------------------------------------------------------------------------------------------
        private static void ExampleCar22()
        {
            Console.WriteLine("***** Simple Exception Example *****");
            Console.WriteLine("=> Creating a car and stepping on it!");
            Car2 myCar = new Car2("Zippy", 20);
            myCar.CrankTunes(true);
            try
            {
                for (int i = 0; i < 10; i++)
                    myCar.Accelerate(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"-------------- Exception --------------");
                Console.WriteLine($"ex.TargetSite      : {ex.TargetSite}"); // the same as : ex.TargetSite.Name
                Console.WriteLine($"ex.MemberType      : {ex.TargetSite.MemberType}");
                Console.WriteLine($"ex.DeclaringType   : {ex.TargetSite.DeclaringType}");                
                Console.WriteLine($"ex.Message         : {ex.Message}");
                Console.WriteLine($"ex.Source          : {ex.Source}");
                //Console.WriteLine($"ex.StackTrace      :\n{ex.StackTrace}");

                // User modified properties in the Thrower:
                // HelpLink
                Console.WriteLine($"ex.HelpLink        : {ex.HelpLink}");

                // Data Dictionary
                Console.WriteLine("ex.Data: ");
                foreach (DictionaryEntry entry in ex.Data)
                {
                    Console.WriteLine($"{entry.Key} , {entry.Value}");
                }
                
            }
            // The error has been handled, processing continues with the next statement.
            Console.WriteLine("\n----------- Out of exception logic ----------- ");
            // separator
            Console.WriteLine("".PadLeft(40, '='));

            
        }

        // Custom Exception Class With Strongly-Typed Prperties : Message Override
        // ---------------------------------------------------------------------------------------------------------------
        private static void ExampleCar3()
        {
            Console.WriteLine("***** Custom Exception Example *****");
            Console.WriteLine("=> Creating a car and stepping on it!");
            Car3 myCar = new Car3("Zippy", 90);
            myCar.CrankTunes(true);
            try
            {
                // trip exception
                myCar.Accelerate(50);
            }
            catch (CarIsDeadException ex)
            {
                Console.WriteLine($"-------------- CarIsDeadException --------------");
                Console.WriteLine($"ex.Message         : {ex.Message}");
                Console.WriteLine($"ex.ErrorTimeStamp  : {ex.ErrorTimeStamp}");
                Console.WriteLine($"ex.CauseOfError    : {ex.CauseOfError}");

            }
            // The error has been handled, processing continues with the next statement.
            Console.WriteLine("\n----------- Out of exception logic ----------- ");
            // separator
            Console.WriteLine("".PadLeft(40, '='));


        }

        // Custom Exception Class With Strongly-Typed Prperties: Message Passed To base Constructor
        // ---------------------------------------------------------------------------------------------------------------
        private static void ExampleCar4()
        {
            Console.WriteLine("***** Custom Exception Example *****");
            Console.WriteLine("=> Creating a car and stepping on it!");
            Car4 myCar = new Car4("Zippy", 90);
            myCar.CrankTunes(true);
            try
            {
                // trip exception
                myCar.Accelerate(50);
            }
            catch (CarIsDeadException2 ex)
            {
                Console.WriteLine($"-------------- CarIsDeadException2 --------------");
                Console.WriteLine($"ex.Message         : {ex.Message}");
                Console.WriteLine($"ex.ErrorTimeStamp  : {ex.ErrorTimeStamp}");
                Console.WriteLine($"ex.CauseOfError    : {ex.CauseOfError}");

            }
            // The error has been handled, processing continues with the next statement.
            Console.WriteLine("\n----------- Out of exception logic ----------- ");
            // separator
            Console.WriteLine("".PadLeft(40, '='));


        }

        // Multiple Catch Clauses
        // ---------------------------------------------------------------------------------------------------------------
        private static void ExampleCar5()
        {
            Console.WriteLine("***** Custom Exception Example *****");
            Console.WriteLine("=> Creating a car and stepping on it!");
            Car5 myCar = new Car5("Zippy", 90);
            myCar.CrankTunes(true);
            try
            {
                // trip exception
                myCar.Accelerate(-10);
            }
            catch (CarIsDeadException2 ex)
            {
                Console.WriteLine($"-------------- CarIsDeadException2 --------------");
                Console.WriteLine($"ex.Message         : {ex.Message}");
                Console.WriteLine($"ex.ErrorTimeStamp  : {ex.ErrorTimeStamp}");
                Console.WriteLine($"ex.CauseOfError    : {ex.CauseOfError}");

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"-------------- ArgumentOutOfRangeException --------------");
                Console.WriteLine($"ex.Message         : {ex.Message}");
            }
            // This will catch any other exception
            // beyond CarIsDeadException or
            // ArgumentOutOfRangeException.
            catch (Exception e)
            {
                Console.WriteLine($"-------------- Exception --------------");
                Console.WriteLine(e.Message);
            }
            // The error has been handled, processing continues with the next statement.
            Console.WriteLine("\n----------- Out of exception logic ----------- ");
            // separator
            Console.WriteLine("".PadLeft(40, '='));


        }

        // General catch
        // ---------------------------------------------------------------------------------------------------------------
        // Note it is not good to use general catch clause, as it's make error finding very hard.
        // Obviously, this is not the most informative way to handle exceptions since you have no way to obtain
        // meaningful data about the error that occurred(such as the method name, call stack, or custom message).
        //Nevertheless, C# does allow for such a construct, which can be helpful when you want to handle all errors in
        //a general fashion.
        private static void ExampleCar52()
        {
            Console.WriteLine("***** Custom Exception Example *****");
            Console.WriteLine("=> Creating a car and stepping on it!");
            Car5 myCar = new Car5("Zippy", 90);
            myCar.CrankTunes(true);
            try
            {
                // trip exception
                myCar.Accelerate(-10);
            }
            catch
            {
                Console.WriteLine("Something bad happened...");
            }
            // The error has been handled, processing continues with the next statement.
            Console.WriteLine("\n----------- Out of exception logic ----------- ");
            // separator
            Console.WriteLine("".PadLeft(40, '='));


        }

        // Rethrowing Exceptions
        // ---------------------------------------------------------------------------------------------------------------
        // Be aware that if the Method is the Main() method, the ultimate receiver of Exception is the CLR because it
        // is the Main() method rethrowing the exception.Because of this, your end user is presented with a system 
        // supplied error dialog box.Typically, you would only rethrow a partial handled exception to a caller 
        // that has the ability to handle the incoming exception more gracefully.

        // Notice as well that you are not explicitly rethrowing the Exception object but rather making
        // use of the throw keyword with no argument. You’re not creating a new exception object; you’re just
        // rethrowing the original exception object (with all its original information). Doing so preserves
        //  the context of the original target.
        private static void ExampleCar53()
        {
            Console.WriteLine("***** Custom Exception Example *****");
            Console.WriteLine("=> Creating a car and stepping on it!");
            Car5 myCar = new Car5("Zippy", 90);
            myCar.CrankTunes(true);
            try
            {
                // trip exception
                myCar.Accelerate(-10);
            }
            catch(Exception ex)
            {
                throw;
            }
            // The error has been handled, processing continues with the next statement.
            Console.WriteLine("\n----------- Out of exception logic ----------- ");
            // separator
            Console.WriteLine("".PadLeft(40, '='));


        }

        // The finally Block
        // ---------------------------------------------------------------------------------------------------------------
        // A try/catch scope may also define an optional finally block.The purpose of a finally block is to ensure
        // that a set of code statements will always execute, exception(of any type) or not.To illustrate, assume you
        // want to always power down the car’s radio before exiting Main(), regardless of any handled exception.

        // In a more real-world scenario, when you need to dispose of objects, close a file, or detach from
        // a database(or whatever), a finally block ensures a location for proper cleanup.
        private static void ExampleCar54()
        {
            Console.WriteLine("***** Handling Multiple Exceptions *****\n");
            Car5 myCar = new Car5("Rusty", 90);
            myCar.CrankTunes(true);
            try
            {
                // Speed up car logic.
            }
            catch (CarIsDeadException e)
            {
                // Process CarIsDeadException.
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Process ArgumentOutOfRangeException.
            }
            catch (Exception e)
            {
                // Process any other Exception.
            }
            finally
            {
                // This will always occur. Exception or not.
                myCar.CrankTunes(false);
            }


        }


        // Exception Filters
        // ---------------------------------------------------------------------------------------------------------------
        // C# 6 introduced a new clause that can be placed on a catch scope, via the when keyword. When you add
        // this clause, you have the ability to ensure that the statements within a catch block are executed only if some
        // condition in your code holds true. This expression must evaluate to a Boolean (true or false) and can be
        // obtained by using a simple code statement in the when definition itself or by calling an additional method in
        // your code.In a nutshell, this approach allows you to add “filters” to your exception logic.
        // First, assume you have added a few custom properties to your CarIsDeadException.
        private static void ExampleCar55()
        {
            Console.WriteLine("***** Exception Filtering with When Clause Test *****");
            Console.WriteLine("=> Creating a car and stepping on it!");
            Car5 myCar = new Car5("Zippy", 90);
            myCar.CrankTunes(true);
            try
            {
                // trip exception
                myCar.Accelerate(-10);
            }
            catch (CarIsDeadException ex) when (ex.ErrorTimeStamp.DayOfWeek != DayOfWeek.Friday)
            {
                Console.WriteLine($"-------------- CarIsDeadException, when day is not Friday --------------");
                Console.WriteLine($"ex.Message         : {ex.Message}");
                Console.WriteLine($"ex.ErrorTimeStamp  : {ex.ErrorTimeStamp}");
                Console.WriteLine($"ex.CauseOfError    : {ex.CauseOfError}");

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"-------------- ArgumentOutOfRangeException --------------");
                Console.WriteLine($"ex.Message         : {ex.Message}");
            }
            // This will catch any other exception
            // beyond CarIsDeadException or
            // ArgumentOutOfRangeException.
            catch (Exception e)
            {
                Console.WriteLine($"-------------- Exception --------------");
                Console.WriteLine(e.Message);
            }
            // The error has been handled, processing continues with the next statement.
            Console.WriteLine("\n----------- Out of exception logic ----------- ");
            // separator
            Console.WriteLine("".PadLeft(40, '='));


        }

    }



    public class Radio
    {
        public Radio() { }
        public void TurnOn(bool on)
        {
            Console.WriteLine(on ? "Radio is Playing..." : "Radio is Stopped ...");
        }
    }

    class CarBase
    {
        // Constant for maximum speed.
        public const int MaxSpeed = 100;
        // Car properties.
        protected int CurrentSpeed { get; set; } = 0;
        protected string PetName { get; set; } = "";
        // Is the car still operational?
        protected bool carIsDead;
        // A car has-a radio.
        private Radio theMusicBox = new Radio();
        // Constructors.
        public CarBase() { }
        public CarBase(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        public void CrankTunes(bool state)
        {
            // Delegate request to inner object.
            theMusicBox.TurnOn(state);
        }

        // See if Car has overheated.
        public virtual void Accelerate(int delta)
        {
            Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            
        }
    }

    class Car1 : CarBase
    {

        public Car1() : base() { }
        public Car1(string name, int speed) : base(name, speed) { }

        public override void Accelerate(int delta)
        {
            if (carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    Console.WriteLine("{0} has overheated!", PetName);
                    CurrentSpeed = 0;
                    carIsDead = true;
                }
                else
                    base.Accelerate(delta);


            }


        }


    }

    class Car2 : CarBase
    {

        public Car2() : base() { }
        public Car2(string name, int speed) : base(name, speed) { }

        public override void Accelerate(int delta)
        {
            if (carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    CurrentSpeed = 0;
                    carIsDead = true;

                    
                    // create a local variable before throwing the Exception object.
                    Exception ex = new Exception($"{PetName} has overheated!");
                    // We need to call the HelpLink property
                    ex.HelpLink = "www.google.com";
                    // Stuff in custom data regarding the error.
                    ex.Data.Add("ExceptionTimeStamp", $"The car exploded at {DateTime.Now}");
                    ex.Data.Add("ExceptionCause", $"You have a leading Leg ...");
                    throw ex;
                }
                else
                    base.Accelerate(delta);


            }


        }


    }

    class Car3 : CarBase
    {

        public Car3() : base() { }
        public Car3(string name, int speed) : base(name, speed) { }

        public override void Accelerate(int delta)
        {
            if (carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    CurrentSpeed = 0;
                    carIsDead = true;


                    // create a local variable before throwing the Exception object.
                    CarIsDeadException ex = 
                        new CarIsDeadException($"{PetName} has overheated!", "You have a leading Leg ...",DateTime.Now);
                    // call the HelpLink property
                    ex.HelpLink = "www.google.com";
                    throw ex;
                }
                else
                    base.Accelerate(delta);


            }


        }


    }

    class Car4 : CarBase
    {

        public Car4() : base() { }
        public Car4(string name, int speed) : base(name, speed) { }

        public override void Accelerate(int delta)
        {

            if (carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    CurrentSpeed = 0;
                    carIsDead = true;


                    // create a local variable before throwing the Exception object.
                    CarIsDeadException2 ex =
                        new CarIsDeadException2($"{PetName} has overheated!", "You have a leading Leg ...", DateTime.Now);
                    // call the HelpLink property
                    ex.HelpLink = "www.google.com";
                    throw ex;
                }
                else
                    base.Accelerate(delta);


            }


        }


    }

    class Car5 : CarBase
    {

        public Car5() : base() { }
        public Car5(string name, int speed) : base(name, speed) { }

        public override void Accelerate(int delta)
        {
            if (delta < 0)
                throw new ArgumentOutOfRangeException("delta", "Speed must be greater than zero!");

            if (carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    CurrentSpeed = 0;
                    carIsDead = true;


                    // create a local variable before throwing the Exception object.
                    CarIsDeadException ex =
                        new CarIsDeadException($"{PetName} has overheated!", "You have a leading Leg ...", DateTime.Now);
                    // call the HelpLink property
                    ex.HelpLink = "www.google.com";
                    throw ex;
                }
                else
                    base.Accelerate(delta);


            }


        }


    }

    // This custom exception describes the details of the car-is-dead condition.
    // (Remember, you can also simply extend Exception.)
    // override Message property
    public class CarIsDeadException : ApplicationException
    {
        private string messageDetails = String.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public CarIsDeadException() { }
        public CarIsDeadException(string message, string cause, DateTime time)
        {
            messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
        // Override the Exception.Message property.
        public override string Message => $"Car Error Message: {messageDetails}";
    }

    // This custom exception describes the details of the car-is-dead condition.
    // diff from CarIsDeadException is here we pass message to base class constructor
    public class CarIsDeadException2 : ApplicationException
    {
        private string messageDetails = String.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public CarIsDeadException2() { }
        public CarIsDeadException2(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
        
    }

}



