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
    interface I_InLibrary
    {
        void loadLibraryBooks();
        void loadReaders();

        string searchAuthororTitle(string searchInfo, Book currentBook);

        void updateReaderInfo(User user);
        void deleteReaderInfo(User user);

        List<String> selectTakenBooks(string user);
    }
}