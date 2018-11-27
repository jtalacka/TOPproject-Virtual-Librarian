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
    //
    // loadLibraryBooks
    // loadReaders

    // searchAuthororTitle

    // takeORGiveBook

    // updateReaderInfo
    // deleteReaderInfo

    // selectTakenBooks
    //

    class Library
    {
        public delegate void load();
        public static load loadL = loadLibraryBooks;

        //load books
        public static void loadLibraryBooks()
        {
            //clear book list
            Book.bookList.Clear();
            string descr = "Not added";

            var table = Database.conn.Table<Book>();
            foreach (var line in table)
            {
                line.genres = line.Genres.Split(' ').ToList();
                if (line.description != "")
                    descr = line.description;
                else
                    descr = "Not added";

                Book.bookList.Add(line);
            }
        }

        //load readers
        public static void loadReaders()
        {
            User.readerList.Clear();

            var table = Database.conn.Table<User>();
            foreach (var line in table)
            {
                User.readerList.Add(line);
            }
        }

        //searches Book object - if it fits, returns obj. info to display as a string
        public static string searchAuthororTitle(string searchInfo, Book currentBook)
        {
            string infoToDisplay = "no match";

            if (currentBook.title.ToLower().Contains(searchInfo.ToLower())
                || currentBook.author.ToLower().Contains(searchInfo.ToLower()))
            {
                return currentBook.ObToString(currentBook);
            }
            return infoToDisplay;
        }


        //When a book is being taken/given - 
        //WRITE NEW INFO. INTO TABLES: Taken, Books
        public void takeORGiveBook(Taken takenBook, Book book)
        {
            //form date when taken
            string dateTaken = DateTime.Now.ToShortDateString();
            //form return date
            var dateReturn = DateTime.Now.AddMonths(1).ToShortDateString();

            //track all taken books in table Taken
            //string sql = "Insert into Taken " +
            //             "(ISBN, Username, DateTaken, DateReturn) " +
            //             "values('" + code + "', '" + user + "', '" + dateTaken + "', '" + dateReturn + "')";

            var sqlite_InsertCmd = new SQLiteCommand(Database.conn);
            Database.conn.Insert(takenBook);

            //change quantity in table Books
            //sql = "Update Books set Quantity='" + quo + "' where ISBN='" + splitInfo[0] + "'";

            SQLiteCommand command = new SQLiteCommand(Database.conn);
            Database.conn.Update(book);

        }

        //account update
        public static void updateReaderInfo(User user)
        {
            Database.conn.Update(user);
        }

        public static void deleteReaderInfo(User user)
        {
            Database.conn.Delete(user);
        }


        //gets all taken reader books into list
        public static List<String> selectTakenBooks(string user)
        {
            List<String> result = new List<string>();

            var taken = Database.conn.Table<Taken>();
            var books = Database.conn.Table<Book>();


                foreach (var line in taken)
                {
                foreach (var line2 in books)
                {
                    if (line.Username == user && line2.ISBN==line.ISBN)
                    {
                        result.Add(line2.title + " --- " + line2.author + " ---" +
                                   line.DateTaken + " --- " + line.DateReturn);
                    }
                }
                }

                return result;

            }


        
    }
}