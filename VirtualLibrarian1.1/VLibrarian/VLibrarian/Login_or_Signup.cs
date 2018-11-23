using System.Text;
using System;
using System.Data.SqlClient;
using System.Globalization;
using SQLite;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using Android.Widget;
using System.Threading.Tasks;
using Android.App;
using Android.Content.Res;
using VLibrarian;
using System.Text.RegularExpressions;

namespace VLibrarian
{
    //
    //       login,
    //       signup,
    //       inputCheck,
    //       checkIfExistsInDBUsers
    //

    public static class Login_or_Signup
    {

        //this needs to be defined in one of the functions below
        //to be passed to the next window -> Library
        public static User user = null;


        //On buttonLogIn_Click
        public static string login(string username, string pass)
        {
            var table = Database.conn.Table<User>();
            //tikrinti ar input correct
            bool correct = false;

            foreach (var line in table)
            {
                //Console.WriteLine(t.username);

                if (line.username == username)
                {
                    if (line.password == pass)
                    {
                        //define user object parameters
                        user = line;

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



        //On buttonSignup_Click
        public static string signup(string username, string pass,
                                    string name, string surname, string birth, string email)
        {
            //define user class object
            user = new User(username, pass, name, surname, email, birth);
            //by default any new user is a reader
            user.type = User.userType.reader;

            var sqlite_InsertCmd = new SQLiteCommand(Database.conn);
            Database.conn.Insert(user);

            return "new reader added";
        }


        //input validation - email, date of birth, ISBN
        public static int inputCheck(string whatToCheck, int c)
        {
            Regex emailRegex = new Regex(@"^([\w]+)@([\w]+)\.([\w]+)$");
            var dateFormats = new[] { "yyyy.MM.dd", "yyyy-MM-dd" };
            Regex ISBNRegex = new Regex(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$");

            if (c == 1)
            {
                //1. email check - if NOT ok - returns 0
                if (!emailRegex.IsMatch(whatToCheck))
                    return 0;
                else
                    return 1;
            }
            else if (c == 2)
            {
                //2.Birth date check - if NOT ok - returns 0
                DateTime date;
                bool validDate = DateTime.TryParseExact(whatToCheck, dateFormats,
                    DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out date);
                if (!validDate)
                    return 0;
                else
                    return 1;
            }
            else if (c == 3)
            {
                //3. isbn check - if NOT ok - returns 0
                if (ISBNRegex.IsMatch(whatToCheck))
                    return 1;
                else
                    return 0;
            }
            else
                return 1;
        }


        //check if username exists in db
        public static bool checkIfExistsInDBUsers(string whatToLookFor)
        { 
            //check if exists
            bool existsResult = false;
            var table = Database.conn.Table<User>();

            foreach (var line in table)
            {
                //Console.WriteLine(t.username);

                if (line.username == whatToLookFor)
                {
                    //found that already exists
                    existsResult = true;
                    return existsResult;
                }
            }

            return existsResult;
        }



    }
}