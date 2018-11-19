using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace VLibrarian
{
    class Database
    {
        public static SQLiteConnection conn;
        public Database(AssetManager asset)
        {

            string databaseName = "data.sqlite";
            var docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbFile = Path.Combine(docFolder, databaseName);

            /*if (!File.Exists(dbFile))
            {
                FileStream writeStream = new FileStream(dbFile, FileMode.OpenOrCreate, FileAccess.Write);
                AssetManager assets = this.Assets;

                assets.Open(databaseName).CopyTo(writeStream);
                assets.Close();
                writeStream.Close();

            }*/
            using (var assets = asset.Open(databaseName))
            using (var dest = File.Create(dbFile))
                assets.CopyTo(dest);

            var path = dbFile;
            conn = new SQLiteConnection(path);
        }
    }
}