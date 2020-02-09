
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using static System.Environment;

namespace ProCSharpBook.EventListenerSystem
{

    #region Abstraction Of General Multicast Event Listener System Without C# delegate 
    // ------------------------ Abstraction Of General Multicast Delegation System Without C# delegate -------------------------
    public class EventArgs
    {

    }

    public class EventSource<TEventArgs>
        where TEventArgs : EventArgs
    {

        private readonly List<EventListener<TEventArgs>> listenerList = new List<EventListener<TEventArgs>>();
        public List<EventListener<TEventArgs>> ListenerList { get => listenerList; }

        public void AddListener(EventListener<TEventArgs> listener)
        {
            if (!ListenerList.Contains(listener))
                ListenerList.Add(listener);
            else
                throw new Exception("Handler is Registered Before");
        }

        public void RemoveListener(EventListener<TEventArgs> listener)
        {
            if (ListenerList.Contains(listener))
                ListenerList.Remove(listener);
            else
                throw new Exception("Handler is  not Registered Before");
        }


        public void Invoke(object sender, TEventArgs e)
        {

            foreach (var item in ListenerList)
            {
                item.Listen(sender, e);
            }

        }

    }

    public interface EventListener<TEventArgs>
        where TEventArgs : EventArgs
    {
        public void Listen(object sender, TEventArgs e);

    }

    // --------------------- End of Abstraction Of General Multicast Delegation System ---------------------
    #endregion





    // test
    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary
        {
            get => salary.Value; 
            set
            {
                salary.Value = value;
                salaryEvent.Invoke(this, new SalaryEventArgs(salary));

            }
        }

        private Salary salary;

        private EventSource<SalaryEventArgs> salaryEvent = new EventSource<SalaryEventArgs>();

        public void AddListener(EventListener<SalaryEventArgs> listener)
        {
            salaryEvent.AddListener(listener);
        }

        public void RemoveListener(EventListener<SalaryEventArgs> listener)
        {
            salaryEvent.RemoveListener(listener);
        }

        public Person() : this(0, "None",0.0) { }
        public Person(int iD, string name, double salary)
        {
            this.ID = iD;
            this.Name = name;
            this.salary = new Salary(salary);

        }


    }

    class SalaryEventArgs : EventArgs
    {
        
        public SalaryEventArgs(Salary salaryInfo)
        {
            this.SalaryInfo = salaryInfo;
        }

        public Salary SalaryInfo { get; }

    }

    struct Salary
    {
        private double value;
        private double delta;

        public Salary(double salary)
        {
            this.value = salary;
            this.delta = 0.0;
            this.SalaryChange = SalaryState.Constant;
        }
        public double Delta { get => delta; private set => delta = value; }
        public SalaryState SalaryChange { get; private set; }
        public double Value
        {
            get { return value; }
            set
            {
                double old = this.value;
                this.value = value;
                this.delta = this.value - old;
                this.SalaryChange = delta > 0 ? SalaryState.Increased : delta < 0 ? SalaryState.Decreased : SalaryState.Constant;

            }
        }

        public override string ToString()
        {
            //return base.ToString();
            return @$"Salary Value: {Value} After {SalaryChange} with {Delta}";
        }
    }

    enum SalaryState
    {
        Increased=0,Decreased,Constant
    }


    class SalaryListener1 : EventListener<SalaryEventArgs>
    {
        public void Listen(object sender, SalaryEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Salary Handler 1: ");
            Console.WriteLine($"Sender:{sender}");
            Console.WriteLine($@"EventArgs: {e.SalaryInfo}");
            Console.WriteLine("".PadLeft(40,'-'));

        }
    }

    class SalaryListener2 : EventListener<SalaryEventArgs>
    {
        public void Listen(object sender, SalaryEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Salary Handler 2: ");
            Console.WriteLine($"Sender:{sender}");
            Console.WriteLine($@"EventArgs: {e.SalaryInfo}");
            Console.WriteLine("".PadLeft(40, '-'));

        }
    }

    class TestEventListenerSystem
    {
        public static void Test()
        {
            Person p1 = new Person(10, "Moamen", 10_000.0);
            //Person p2 = new Person(20, "Mohammed", 20_000.0);

            SalaryListener1 listener1 = new SalaryListener1();
            SalaryListener2 listener2 = new SalaryListener2();

            p1.Salary += 100;
            p1.Salary += 300;
            p1.AddListener(listener1);
            p1.AddListener(listener2);

            p1.Salary += 100;
            p1.Salary += 300;
            p1.RemoveListener(listener1);

            p1.Salary += 400;
            p1.Salary += 500;
            p1.RemoveListener(listener2);

            p1.Salary += 100;
            p1.Salary += 300;

            Console.WriteLine("----------------------- End -----------------------");
        }

        

    }
}