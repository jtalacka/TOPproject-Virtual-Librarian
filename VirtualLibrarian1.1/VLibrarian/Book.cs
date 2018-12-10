using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace VLibrarian
{
    [Table("dbo.Books")]
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
            this.Genres = String.Join(" ", g.ToArray());

            //this.image = "picture set";
        }
        public Book(string isbn, string t, string a, List<string> g, int q)
        {
            this.ISBN = isbn;
            this.title = t;
            this.author = a;
            this.genres = g;
            this.quantity = q;
            this.Genres = String.Join(" ", g.ToArray());

            //this.image = "show default";
        }

        public Book() { }

        //properties
        [PrimaryKey]
        public string ISBN { get; set; }
        [Column("Title")]
        public string title { get; set; }
        [Column("Author")]
        public string author { get; set; }
        public string Genres { get; set; }
        [Column("Genres")]
        public List<string> genres { get; set; }
        [Column("Quantity")]
        public int quantity { get; set; }
        [Column("Description")]
        public string description { get; set; }
        [Column("Picture")]
        public byte[] picture { get; set; }


        //[Ignore]
        //public string image { get; set; }

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