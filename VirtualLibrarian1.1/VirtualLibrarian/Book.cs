using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian
{
    class Book
    {
        //a constructor
        public Book(int isbn, string t, string a, List<string> g)
        {
            this.ISBN = isbn;
            this.title = t;
            this.author = a;
            this.genres = g;
        }
        public Book() { }

        //properties (in same order as written in in the file)
        public int ISBN;
        public string title;
        public string author;
        public List<string> genres;
    }
}
