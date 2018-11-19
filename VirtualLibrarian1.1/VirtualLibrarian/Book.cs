using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian
{
    public class Book : IComparable, IFormattable
    {
        //constructors
        public Book(string isbn, string t, string a, List<string> g, int q, string des, byte[] image)
        {
            this.ISBN = isbn;
            this.title = t;
            this.author = a;
            this.genres = g;
            this.quantity = q;
            this.description = des;
            this.picture = image;

            this.image = "picture set";
        }
        public Book(string isbn, string t, string a, List<string> g, int q)
        {
            this.ISBN = isbn;
            this.title = t;
            this.author = a;
            this.genres = g;
            this.quantity = q;

            this.image = "show default";
        }

        public Book(string isbn) { }

        //properties
        public string ISBN;
        public string title;
        public string author;
        public List<string> genres;
        public int quantity;
        public string description;
        public string image;
        public byte[] picture;
                 

        //List for all books AND books to sort
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
                                 + currentBook.author + " --- " + genres + " --- "
                                 + currentBook.quantity;
            return infoToDisplay;
        }
    }
}
