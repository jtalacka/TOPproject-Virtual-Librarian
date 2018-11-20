using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLitePCL;
using Xamarin.Android;

namespace VLibrarian
{

    public class DBHelper
    {
        async Task<SQLiteConnection> GetConnection()
        {

            var conn = new SQLiteConnection("");
            return conn;
        }
    }
}