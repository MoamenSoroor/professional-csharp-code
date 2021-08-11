using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharpCode.BookSystem
{

    public class Book
    {
        public int ISBN { get; }

        public string Name { get; }

        public BookIndex Index { get; } = new BookIndex();

        public Book(int iSBN, string name)
        {
            ISBN = iSBN;
            Name = name;
        }

        public override string ToString()
        {
            return $"Book:\nISBN:{ISBN}\nName:{Name}\n{Index}";
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


    

    

    


    

}
