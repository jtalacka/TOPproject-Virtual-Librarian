using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using static VLibrarian.User;

namespace VLibrarian
{
    class Database
    {
        //from config file "appsettings.json"
        //public string databaseName { get; }
        //public Database(string dbName)
        //{
        //    databaseName = dbName;
        //}
        //= = = = = = = = = = = = = = = = = = = = 

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
        //    if (!File.Exists(dbFile))
        //    {
                using (var assets = asset.Open(databaseName))
                using (var dest = File.Create(dbFile))
                    assets.CopyTo(dest);
        //    }
            var path = dbFile;
            conn = new SQLiteConnection(path);
        }

        public Database()
        {
        }
        public static List<User> UserSelectRequest()
        {
            List<User> userlist = new List<User>();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://dbservice20181218121315.azurewebsites.net/api/User");//
                request.Method = "Get";
                request.KeepAlive = true;
                request.ContentType = "appication/json";
                //request.ContentType = "application/x-www-form-urlencoded";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string myResponse = "";
                using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    myResponse = sr.ReadToEnd();
                }
                myResponse = myResponse.Trim(new char[] { '[', ']' });
                myResponse = Regex.Replace(myResponse, ",", "");

                Console.WriteLine(myResponse);
                string[] userData = myResponse.Split('"');
                int i = 0;
                foreach (string word in userData)
                {
                    if (word != "")
                    {
                        string[] userData1 = word.Split('|');
                        userlist.Add(new User
                        {
                            username = userData1[0],
                            password=userData1[1],
                            name=userData1[2],
                            surname=userData1[3],
                            email=userData1[4],
                            birth=userData1[5],
                            UserType=(userType)Enum.Parse(typeof(userType), userData1[6])

                    });
                        Console.WriteLine(userlist.ElementAt(i).username + "-");
                 
                        i++;
                    }
            
                }
                return userlist;



            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }
    }
}