using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace VLibrarian
{
    //
    //       login,
    //       signup,
    //       inputCheck,
    //       checkIfExistsInDBUsers
    //

    public class Login_or_Signup : I_NewLogin
    {
        //interface object, through which we will be accessing the controller class methods
        static I_NewLogin L_or_S = new Login_or_Signup();

        //DEFINE DELEGATES
        public static Controller_linker.del check = L_or_S.login;
        public static Controller_linker.del2 check2 = L_or_S.checkIfExistsInDBUsers;
        public static Controller_linker.del3<string> check3 = L_or_S.signup;
        public static Controller_linker.delIN inputC = L_or_S.inputCheck;



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

            Database.conn.Insert(user);

            return "new reader added";
        }


        //input validation - email, date of birth, ISBN
        public int inputCheck(string whatToCheck, int c)
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