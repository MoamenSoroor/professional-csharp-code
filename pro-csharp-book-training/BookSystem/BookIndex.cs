using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpBook.BookSystem
{
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
            if (subjects != null)
                foreach (var subject in subjects)
                {
                    subject.Execute();
                }

        }

        public void ExecuteChapters(IEnumerable<Chapter> chapters)
        {
            if (chapters != null)
                foreach (var chapter in chapters)
                {
                    chapter.Execute();
                }
        }

        public void ExecuteSubject(Subject subject)
        {
            subject?.Execute();
        }

        public void ExecuteChapter(Chapter chapter)
        {
            chapter?.Execute();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in Chapters)
            {
                builder.AppendLine(item.ToString());
            }

            return $"Index: \n{builder.ToString()}\n********** End Of Index **********\n";
        }
    }
}
