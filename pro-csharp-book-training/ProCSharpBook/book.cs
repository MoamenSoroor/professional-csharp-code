using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpBook
{
    

    public class Book
    {
        public int ISBN { get; set; }

        public string Name { get; set; }

        public BookIndex Index { get; } = new BookIndex();

        public Book()
        {

        }
        public Book(int iSBN, string name)
        {
            ISBN = iSBN;
            Name = name;
        }

        public override string ToString()
        {
            return $"Book[ISBN:{ISBN}, Name:{Name}]";
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


    public class BookIndex
    {
        public HashSet<Chapter> Chapters { get; } = new HashSet<Chapter>();


        public BookIndex()
        {

        }


        public HashSet<Subject> ToSubjects()
        {
            HashSet<Subject> allSub = new HashSet<Subject>();
            foreach (var item in Chapters)
            {
                allSub.UnionWith(item.Subjects);
            }

            return allSub;
        }

        

        public void ExecuteAll()
        {
            foreach (var chapter in Chapters)
            {
                chapter.Execute();
            }
        }
        public void ExecuteSubjects(IEnumerable<Subject> subjects)
        {
            foreach (var subject in subjects)
            {
                subject.Execute();
            }
        }

        public void ExecuteChapters(IEnumerable<Chapter> chapters)
        {
            foreach (var chapter in chapters)
            {
                chapter.Execute();
            }
        }

        public void ExecuteSubject(Subject subject)
        {
            subject.Execute();
        }

        public void ExecuteChapter(Chapter chapter)
        {
            chapter.Execute();   
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in Chapters)
            {
                builder.AppendLine(item.ToString());
            }

            return $"Index[\n{builder.ToString()}\n]";
        }
    }

    public class Chapter
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public HashSet<Subject> Subjects { get; } = new HashSet<Subject>();

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
                builder.AppendLine(item.ToString());
            }

            return $"Chapter[ ID:{ID} ,Name:{Name}, Subjects[\n{builder.ToString()}\n]]";
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
            foreach (var item in Subjects)
            {
                item.Execute();
            }
        }
    }

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

        public Subject(int iD, string name, Chapter chapter, Action run) : this(iD, name,chapter)
        {
            Run += run;
        }

        public override string ToString()
        {
            return $"Subject[ ID:{ID} ,Name:{Name} ]";
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


    public interface IExecutable
    {
        public void ExecuteAll();
        public void Execute();
    }

}
