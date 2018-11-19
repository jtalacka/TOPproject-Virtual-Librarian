using System.Text;
using System;
using System.Data.SqlClient;
using System.Globalization;
using SQLite;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using Android.Widget;
using VLibrarian.Resources.Data;
using System.Threading.Tasks;
using Android.App;
using Android.Content.Res;

namespace VLibrarian
{

    public static class Login_or_Signup
    {

        //this needs to be defined in one of the functions below
        //to be passed to the next form -> FormLibrary
        //public static User user = null;
        public static User user = null;


        //for connecting to the db
        //query

        public static string login(string username, string pass)
        {
            var table = Database.conn.Table<User>();
            int a = 0;
            bool correct = false;
            foreach (var t in table)
            {
                Console.WriteLine(t.username);
            
                if (t.username == username)
                {
                    if (t.password == pass)
                    {
                        //define user object parameters
                        user = t;


                        correct = true;
                        return "correct";
                    }
                    else
                    {
                        return "Incorrect password";
                    }

                }
            }

            if (correct == false)
                return "User with this username doesn't exist";
            else
            
                return "correct";


        }


    }
}

