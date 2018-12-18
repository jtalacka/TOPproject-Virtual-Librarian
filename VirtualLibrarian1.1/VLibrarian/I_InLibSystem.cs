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
    interface I_InLibSystem
    {
        bool checkIfExistsInDBBooks(string whatToLookFor);

        void addBook(Book book);
        void editBook(Book book);
        void deleteBook(Book book);

        void giveBook(User user, Book book);
        void returnBook(Book book, Taken taken);
    }
}