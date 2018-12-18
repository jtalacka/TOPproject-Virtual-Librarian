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

    // updateReaderInfo
    // deleteReaderInfo

    // selectTakenBooks
    //

    class Library : I_InLibrary
    {

        //interface object
        public static I_InLibrary Lib = new Library();

        public static Controller_linker.load loadL = Lib.loadLibraryBooks;
        public static Controller_linker.load loadU = Lib.loadReaders;
        public static Controller_linker.s searchB = Lib.searchAuthororTitle;
        public static Controller_linker.readerUpdate update = Lib.updateReaderInfo;
        public static Controller_linker.readerUpdate delete = Lib.deleteReaderInfo;
        public static Controller_linker.selectTaken getTaken = Lib.selectTakenBooks;

        public static List<int> array = new List<int>();

        //load books
        public void loadLibraryBooks()
        {
            //clear book list
            Book.bookList.Clear();
            

            var table = Database.conn.Table<Book>();
            foreach (var line in table)
            {
                line.genres = line.Genres.Split(' ').ToList();
                array.Add(line.picture.Length);

                Book.bookList.Add(line);
            }
        }

        //load readers
        public void loadReaders()
        {
            User.readerList.Clear();

            var table = Database.conn.Table<User>();
            foreach (var line in table)
            {
                User.readerList.Add(line);
            }
        }

        //searches Book object - if it fits, returns obj. info to display as a string
        public string searchAuthororTitle(string searchInfo, Book currentBook)
        {
            string infoToDisplay = "no match";

            if (currentBook.title.ToLower().Contains(searchInfo.ToLower())
                || currentBook.author.ToLower().Contains(searchInfo.ToLower()))
            {
                return currentBook.ObToString(currentBook);
            }
            return infoToDisplay;
        }

        //account update
        public void updateReaderInfo(User user)
        {
            Database.conn.Update(user);
        }
        public void deleteReaderInfo(User user)
        {
            Database.conn.Delete(user);
        }


        //gets all taken READER books into list
        public List<String> selectTakenBooks(string user)
        {
            List<String> result = new List<string>();

            var taken = Database.conn.Table<Taken>();
            var books = Database.conn.Table<Book>();

            //if getting specified user taken books
            foreach (var line in taken)
            {
                foreach (var line2 in books)
                {
                    if (line.Username == user && line2.ISBN == line.ISBN)
                    {
                        result.Add(line2.title + " --- " + line2.author + " ---" +
                                   line.DateTaken + " --- " + line.DateReturn);
                    }
                }
            }
            return result;
        }


        //gets ALL taken books into list
        public static List<String> selectAllTakenBooks()
        {
            List<String> result = new List<string>();

            var taken = Database.conn.Table<Taken>();
            var books = Database.conn.Table<Book>();

            foreach (var line in taken)
            {
                foreach (var line2 in books)
                {
                    if (line.ISBN == line2.ISBN)
                    {
                        result.Add(line.Username + " --- " + line2.title + " --- " + line2.author + " ---" +
                                   line.DateTaken + " --- " + line.DateReturn);

                        Taken.allTaken.Add(new Taken(line2.ISBN, line.Username, line.DateTaken, line.DateReturn));
                    }
                }
            }
            return result;
        }




    }
}