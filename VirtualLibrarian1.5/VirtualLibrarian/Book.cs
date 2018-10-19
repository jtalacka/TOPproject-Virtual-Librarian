using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian
{
    class Book : IComparable, IFormattable
    {
        //constructors
        public Book(string isbn, string t, string a, List<string> g)
        {
            this.ISBN = isbn;
            this.title = t;
            this.author = a;
            this.genres = g;
            this.image = "";
        }
        public Book(string isbn, string t, string a, List<string> g, string lineRead)
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
        public string ISBN;
        public string title;
        public string author;
        public List<string> genres;
        public DateTime Dtaken;
        public DateTime Dreturned;


        public string image;
        public string description;       
        public string bookLineRead;//the line read from file       
        
        //List for all books
        public static List<Book> bookList = new List<Book>();
        public static List<Book> sortList = new List<Book>();



        //  for Book.sortList.Sort();
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Book otherBook = obj as Book;
            if (otherBook != null)
                return this.title.CompareTo(otherBook.title);
            else
                throw new ArgumentException("Object is not a Book");
        }


        Book currentBook;
        //pass Book object - return its parameters as string
        public string ObToString(Book currentBook)
        {
            this.currentBook = currentBook;
            return this.ToString(null, null);
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            string genres = string.Join(" ", currentBook.genres);
            string infoToDisplay = currentBook.ISBN + " --- " + currentBook.title + " --- "
                                 + currentBook.author + " --- " + genres;
            return infoToDisplay;
        }
    }
}
