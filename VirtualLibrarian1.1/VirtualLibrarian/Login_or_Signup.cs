using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VirtualLibrarian
{
    class Login_or_Signup
    {

        // 
        // FUNCTIONALITY FROM Form1 AND FormSignup:
        //       login,
        //       signup,
        //       inputCheck,
        //       checkIfExistsInFile

        public static User user = null;

        //On buttonLogIn_Click
        public static string login(string username, string pass)
        {
            string line;
            bool correct = false;

            //check if input exists in login info file
            StreamReader file = new StreamReader("login.txt");
            while ((line = file.ReadLine()) != null)
            {
                //split line into strings
                string[] lineSplit = line.Split(';');
                //check if input correct / exists
                //first two strings in file are username and password
                if (lineSplit[0] == username)
                {
                    if (lineSplit[1] == pass)
                    {
                        //define user object parameters
                        user = new User(username, pass, lineSplit[2], lineSplit[3], lineSplit[4], lineSplit[5]);
                        //the 6th string is user type (reader or employee)
                        if (lineSplit[6] == "reader")
                        { user.type = User.userType.reader; }
                        else if (lineSplit[6] == "employee")
                        { user.type = User.userType.employee; }
                        else
                            return "wrong user type";

                        correct = true;
                        return "correct";
                    }
                    else
                    {
                        return "Incorrect password";
                    }
                }
            }
            file.Close();

            if (correct == false)
            {
                return "User with this username doesn't exist";
            }
            else
                return "correct";
        }

        //On buttonSignup_Click
        public static string signup(string name, string surname, string username, string pass,
             string birth, string email)
        {
            //define user class object user
            user = new User(username, pass, name, surname, email, birth);
            //by default any new user is a reader
            user.type = User.userType.reader;

            using (StreamWriter w = File.AppendText("login.txt"))
            {
                //information layout in file
                w.WriteLine(username + ";" + pass + ";" + name + ";" + surname + ";" + email + ";" + birth + ";" + user.type);
            }
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

        //check if username / ISBN exists in file 
        // if very_first_string_in_line == whatToLookFor => returns true;
        public static bool checkIfExistsInFile(string fileName, string whatToLookFor)
        {
            bool ExistsResult = false;

            string line;
            string[] lineSplit;
            StreamReader file = new StreamReader(fileName);

            while ((line = file.ReadLine()) != null)
            {
                lineSplit = line.Split(';');
                if (lineSplit[0] == whatToLookFor)
                {
                    //found that already exists
                    ExistsResult = true;
                    file.Close();
                    return ExistsResult;
                }
            }
            file.Close();
            return ExistsResult;
        }


    }
}
