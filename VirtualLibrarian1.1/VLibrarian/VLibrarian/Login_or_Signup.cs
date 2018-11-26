using System;
using System.Globalization;
using SQLite;
using System.Text.RegularExpressions;

namespace VLibrarian
{
    //
    //       login,
    //       signup,
    //       inputCheck,
    //       checkIfExistsInDBUsers
    //

    public class Login_or_Signup
    {

        //interface object, through which we will be accessing the controller class methods
        static Login_or_Signup L_or_S = new Login_or_Signup();

        //define delegate that will point to L_or_S.login
        public delegate string del(string N, string P);
        public static del check = L_or_S.login;
        public static string runAdelegate(del d, string n, string p)
        {
            return d(n, p);
        }

        //define a delegate
        public delegate bool del2(string w);
        public static del2 check2 = L_or_S.checkIfExistsInDBUsers;
        public static bool runAdelegate(del2 d, string w)
        {
            return d(w);
        }

        //define a placeholder delegate
        public delegate T del3<T>(T u, T p, T n, T s, T b, T e);
        public static del3<string> check3 = L_or_S.signup;
        public static string runAdelegate3(del3<string> d, string u, string p, string n, string s, string b, string e)
        {
            return d(u, p, n, s, b, e);
        }


        //this needs to be defined in one of the functions below
        //to be passed to the next window -> Library
        public static User user = null;

        //On buttonLogIn_Click
        public string login(string username, string pass)
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
        public string signup(string username, string pass,
                                    string name, string surname, string birth, string email)
        {
            //define user class object
            user = new User(username, pass, name, surname, email, birth);
            //by default any new user is a reader
            user.UserType = User.userType.reader;

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
        public bool checkIfExistsInDBUsers(string whatToLookFor)
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