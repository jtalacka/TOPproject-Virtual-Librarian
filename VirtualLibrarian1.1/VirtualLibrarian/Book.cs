using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian
{
    class Book : IComparable<Book>
    {
        //a constructor
        public Book(int isbn, string t, string a, List<string> g)
        {
            this.ISBN = isbn;
            this.title = t;
            this.author = a;
            this.genres = g;
            this.image = "";
        }
        public Book(int isbn, string t, string a, List<string> g, string lineRead)
        {
            this.ISBN = isbn;
            this.title = t;
            this.author = a;
            this.genres = g;
            this.image = "";
            this.bookLineRead = lineRead;
        }

        public Book(string line) { }
        public Book() { }

        //properties (in same order as written in in the file)
        public int ISBN;
        public string title;
        public string image;
        public string description;
        public string author;
        public string bookLineRead;//the line read from file
        public List<string> genres;
        public DateTime Dtaken;
        public DateTime Dreturned;

        //List for all books
        public static List<Book> bookList = new List<Book>();
        public static List<Book> sortList = new List<Book>();


        public int CompareTo(Book book)
        {
            if (this.title == book.title)
            {
                return this.title.CompareTo(book.title);
            }
            return this.title.CompareTo(book.title);
        }
    }
}
