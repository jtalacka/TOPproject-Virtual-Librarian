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


    class LibrarySystem
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



    }
}