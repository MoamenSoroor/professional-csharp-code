using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpCode.BookSystem
{
    public class Chapter
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public HashSet<Subject> Subjects { get; } = new HashSet<Subject>();

        public event Action OnStart;
        public event Action OnFinish;

        public Chapter()
        {

        }

        public Chapter(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in Subjects)
            {
                builder.AppendLine("\t\t" + item.ToString());
            }

            return $"   Chapter Info:\n\tID:{ID}\n\tName:{Name}\n\tSubjects:\n{builder.ToString()}\n";
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
            OnStart?.Invoke();
            foreach (var item in Subjects)
            {
                item.Execute();
            }
            OnFinish?.Invoke();
        }


        public bool In(params Chapter[] chapters)
        {
            return chapters.Any(ch => this.Equals(ch));
        }

        public bool In(params int[] IDs )
        {
            return IDs.Any(id => this.ID.Equals(id));
        }
    }
}
