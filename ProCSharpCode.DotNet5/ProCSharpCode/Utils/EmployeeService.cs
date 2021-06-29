using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProCSharpCode.ProCSharpCode.Utils
{

    public class Employee
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname{ get; set; }
        public double Salary { get; set; }
        //public Employee Supervisor { get; set; }
    }

    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<IEnumerable<Employee>> GetByNameAsync(string name);
        Task<Employee> GetAsync(string name);
        Task<Employee> DeleteAsync(int id);
        Task<bool> AddAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync(CancellationToken stoppingToken);
        Task<IEnumerable<Employee>> GetByNameAsync(string name , CancellationToken stoppingToken);
        Task<Employee> GetAsync(string name , CancellationToken stoppingToken);
        Task<Employee> DeleteAsync(int id , CancellationToken stoppingToken);
        Task<bool> AddAsync(int id , CancellationToken stoppingToken);
    }


    public class MockingEmployeeService //: IEmployeeService
    {

        

        private List<Employee> employees = new List<Employee>()
        {
            new Employee(){ Id=1,Fname="Ahmed",Lname="mohammed"},
            new Employee(){ Id=2,Fname="mohammed",Lname="ahmed"},
            new Employee(){ Id=3,Fname="samira",Lname="Gamal"},
            new Employee(){ Id=4,Fname="aya",Lname="kamal"},
            new Employee(){ Id=5,Fname="Rahma",Lname="ali"},
            new Employee(){ Id=6,Fname="Kamal",Lname="Soroor"},
            new Employee(){ Id=7,Fname="Mona",Lname="Sarawy"},
            new Employee(){ Id=8,Fname="Ali",Lname="mobarak"},
            new Employee(){ Id=9,Fname="Gamal",Lname="mahmoud"},
            new Employee(){ Id=10,Fname="Hossam",Lname="Sabry"},
            new Employee(){ Id=11,Fname="Amina",Lname="Mahmoud"},
            new Employee(){ Id=12,Fname="Omar",Lname="Jamal"},
            new Employee(){ Id=13,Fname="Hesham",Lname="Kamal"},
            new Employee(){ Id=14,Fname="Omar",Lname="Hesam"},
            new Employee(){ Id=15,Fname="Yousef",Lname="Jamil"},
            new Employee(){ Id=16,Fname="Eslam",Lname="Ahmed"},
            new Employee(){ Id=17,Fname="MOhmmaed",Lname="waleed"},
            new Employee(){ Id=18,Fname="Hossam",Lname="Eslam"},
            new Employee(){ Id=19,Fname="Karim",Lname="hossam"},
            new Employee(){ Id=20,Fname="Hany",Lname="Mohammed"},
        };


        public List<Employee> Employees { get => employees; }


        public MockingEmployeeService()
        {
            var count = employees.Count;
            foreach (var item in employees)
            {
                //item.Salary = (item.Id * count * 1000) - ((item.Id % 3) * count * 100);
                //item.Salary = (7500 sin(x) + 7500 + 5000);
                item.Salary = (7500 * Math.Sin(2*Math.PI * item.Id/count ) + 7500 + 5000);
                //item.Supervisor = item;
            }
        }

        public static void Test()
        {
            var mock = new MockingEmployeeService();
            Console.WriteLine(mock);

        }

        public override string ToString()
        {
            var data = JsonConvert.SerializeObject(employees, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            return $"Employees: {data}";
        }

        public Task<bool> AddAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(int id, CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> DeleteAsync(int id, CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetAsync(string name, CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetByNameAsync(string name, CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
