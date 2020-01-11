using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpBook.OOPExamples
{


    class Test1
    {
        public static void Main(string[] args)
        {
            Employee emp1 = new Manager();
            Employee emp2 = new SalesPerson();
            SalesPerson sales1 = new PTSalesPerson();
            object obj1 = new Manager();
            object obj2 = new SalesPerson();
            object obj3 = new PTSalesPerson();

            Manager m1 = (Manager)obj1;
            Manager m2 = (Manager)emp1;

            //SalesPerson person = (SalesPerson) m1;
            //person = m2 as SalesPerson;

            object obj4 = new Employee();
            Employee emp4 = new Employee();
            //Employee emp5 = obj4;
            Employee emp5 = (Employee)obj4;

            Console.WriteLine("Press Any Key to Continue!");
            Console.ReadLine();
        }
    }

    class Employee
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public string JobTitle { get; protected set; }

        public Employee(string firstName, string lastName, int age, double salary, string jobTitle)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
            JobTitle = jobTitle;
        }

        public Employee() : this("Custom FirstName", "Custom LastName", 22, 4000.00f, "Employee") { }

        public Employee(string firstName, string lastName, int age) : this(firstName, lastName, age, 4000.00f, "Employee") { }

        public override string ToString()
        {
            return $@"Employee
{{
    FirstName   : {FirstName},
    LastName    : {LastName},
    Age         : {Age},
    Salary      : {Salary},
    JobTitle    : {JobTitle},

}}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    class Manager : Employee
    {
        public Manager() : base()
        {
            this.JobTitle = "Manager";
        }
    }

    class SalesPerson : Employee
    {
        public SalesPerson() : base()
        {
            this.JobTitle = "SalesPerson";
        }
    }

    class PTSalesPerson : SalesPerson
    {
        public PTSalesPerson() : base()
        {
            this.JobTitle = "PartTimeSalesPerson";
        }
    }





}