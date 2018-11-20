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



    }
}