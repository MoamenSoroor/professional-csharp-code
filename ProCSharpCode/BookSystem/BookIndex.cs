using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpCode.BookSystem
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

        public static string GetSubjectsInfo(IEnumerable<Subject> subjects)
        {
            StringBuilder builder = new StringBuilder();
            if (subjects != null)
                foreach (var subject in subjects)
                {
                    builder.AppendLine(subject.ToString());
                }
            return builder.ToString();
        }

        /// <summary>
        /// this method is used to execute the whole book subjects
        /// </summary>
        public void ExecuteAll()
        {
            foreach (var chapter in Chapters)
            {
                chapter.Execute();
            }
        }


        [Obsolete]
        public void ExecuteSubjects(IEnumerable<Subject> subjects)
        {
            if (subjects != null)
                foreach (var subject in subjects)
                {
                    subject.Execute();
                }

        }

        [Obsolete]
        public void ExecuteChapters(IEnumerable<Chapter> chapters)
        {
            if (chapters != null)
                foreach (var chapter in chapters)
                {
                    chapter.Execute();
                }
        }

        [Obsolete]
        public void ExecuteSubject(Subject subject)
        {
            subject?.Execute();
        }

        [Obsolete]
        public void ExecuteChapter(Chapter chapter)
        {
            chapter?.Execute();
        }



        /// <summary>
        /// this method is used to execute specific subject in a chapter
        /// </summary>
        /// <param name="chapterId"> chapter id of the subject to execute </param>
        /// <param name="subjectId"> subject id to execute</param>
        public void ExecuteSubject(int chapterId,int subjectId)
        {
            ExecuteSubjects(chapterId, subjectId);
        }

        /// <summary>
        /// this method is used to execute specific subject in a chapter
        /// </summary>
        /// <param name="chapterId"> chapter id of the subjects to execute </param>
        /// <param name="subjectsIds">subjects ids to execute</param>
        public void ExecuteSubjects(int chapterId, params int[] subjectsIds)
        {
            this.Chapters.FirstOrDefault(c => c.ID == chapterId)
                ?.Subjects.Where(s => subjectsIds.Any(ids => ids == s.ID))?.ToList()
                .ForEach(c=> c.Execute());
        }

        /// <summary>
        /// this method can be used to execute all subjects in many chapters
        /// </summary>
        /// <param name="chaptersIds">ids of the chapters to execute</param>
        public void ExecuteChapters(params int[] chaptersIds)
        {
            this.Chapters.Where(c => chaptersIds.Any(ids => ids == c.ID))?.ToList()
                .ForEach(c => c.Execute());
        }

        /// <summary>
        /// this method can be used to execute all subjects in a chapter.
        /// </summary>
        /// <param name="chapterId">id of the chapter to execute all subjects in it.</param>
        public void ExecuteChapter(int chapterId)
        {
            this.Chapters.FirstOrDefault(c => chapterId == c.ID)?.Execute();
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
