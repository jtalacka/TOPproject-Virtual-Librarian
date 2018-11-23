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
    // searchAuthororTitle
    // updateReaderInfo
    // deleteReaderInfo
    // selectTakenBooks
    //

    class Library
    {

        //load books
        public static void loadLibraryBooks()
        {
            //clear book list
            Book.bookList.Clear();
            //string gs;
            //List<string> genres;
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


        public static void updateReaderInfo(User user)
        {
            SQLiteCommand command = new SQLiteCommand(Database.conn);
            Database.conn.Update(user);
        }

        public static void deleteReaderInfo(User user)
        {
            SQLiteCommand command = new SQLiteCommand(Database.conn);
            Database.conn.Delete(user);
        }


        //gets all taken reader books into list
        public static List<String> selectTakenBooks(string user)
        {
            List<String> result = null;

            var taken = Database.conn.Table<Taken>();
            var books = Database.conn.Table<Book>();
            foreach (var line in taken)
            {
                foreach (var line2 in books)
                {
                    if (line.Username == user)
                        result.Add(line2.title + " --- " + line2.author + " ---" +
                                   line.DateTaken + " --- " + line.DateReturn);
                }
            }

            return result;
        }
    }
}