using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpBook.BookSystem
{
    public class Subject
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Chapter Chapter { get; set; }

        public event Action Run;

        public Subject()
        {

        }
        public Subject(int iD, string name, Chapter chapter)
        {
            ID = iD;
            Name = name;
            Chapter = chapter;
        }

        public Subject(int iD, string name, Chapter chapter, Action run) : this(iD, name, chapter)
        {
            Run += run;
        }

        public override string ToString()
        {
            return $"\t\tSubject[ ID:{ID} ,Name:{Name} ]";
        }

        public override bool Equals(object obj)
        {
            return this.ToString().Equals(obj?.ToString());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public void Execute()
        {
            Run?.Invoke();
        }





    }
}
