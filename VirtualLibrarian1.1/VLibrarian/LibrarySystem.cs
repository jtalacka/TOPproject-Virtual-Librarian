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

namespace VLibrarian
{
    //
    // checkIfExistsInDBBooks
    //


    public class LibrarySystem
    {
        //check if ISBN exists in db Books, before adding a new one
        public static bool checkIfExistsInDBBooks(string whatToLookFor)
        {
            bool ExistsResult = false;

            var table = Database.conn.Table<Book>();
            foreach (var line in table)
            {
                if (line.ISBN == whatToLookFor)
                {
                    ExistsResult = true;
                    return ExistsResult;
                }
            }
            return ExistsResult;
        }
            //delete book
            public static void deleteBookInfo(Book book)
            {
                Database.conn.Delete(book);
            }

            //When a book is being taken/given - 
            //WRITE NEW INFO. INTO TABLES: Taken, Books
            public static void takeORGiveBook(User user, Book book)
            {
                //form date when taken
                string dateTaken = DateTime.Now.ToShortDateString();
                //form return date
                var dateReturn = DateTime.Now.AddMonths(1).ToShortDateString();

                //form Taken object
                Taken takenBook = new Taken(book.ISBN, user.username, dateTaken, dateReturn);

                //track all taken books in table Taken
                Database.conn.Insert(takenBook);

                //edit book quantity
                Database.conn.Update(user);
            }
    }
}