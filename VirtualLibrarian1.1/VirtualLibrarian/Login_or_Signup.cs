using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        //       checkIfExistsInDBUsers
        //       checkIfExistsInDBBooks
        //

        public static User user = null;

        //On buttonLogIn_Click
        public static string login(string username, string pass)
        {
            //does username exist in db, is password correct, etc.
            bool correct = false;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\VirtualLibrarian1.1\VirtualLibrarian\DatabaseVL.mdf;Integrated Security=True";
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from Users", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetString(reader.GetOrdinal("Username")) == username)
                    {
                        if (reader.GetString(reader.GetOrdinal("Password")) == pass)
                        {
                            //define user object parameters
                            user = new User(
                             reader.GetString(reader.GetOrdinal("Username")),
                             reader.GetString(reader.GetOrdinal("Password")),
                             reader.GetString(reader.GetOrdinal("Name")),
                             reader.GetString(reader.GetOrdinal("Surname")),
                             reader.GetString(reader.GetOrdinal("Email")),
                             reader.GetDataTypeName(reader.GetOrdinal("Birth")));

                            //the 6th string is user type (reader or employee)
                            if (reader.GetString(reader.GetOrdinal("UserType")) == "reader")
                            { user.type = User.userType.reader; }
                            else if (reader.GetString(reader.GetOrdinal("UserType")) == "employee")
                            { user.type = User.userType.employee; }
                            else
                                return "wrong specified user type";

                            correct = true;
                            return "correct";
                        }
                        else
                        {
                            return "Incorrect password";
                        }
                    }
                }
            }
            conn.Close();

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

            //using (StreamWriter w = File.AppendText("login.txt"))
            //{
            //    //information layout in file
            //    w.WriteLine(username + ";" + pass + ";" + name + ";" + surname + ";" + email + ";" + birth + ";" + user.type);
            //}
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\VirtualLibrarian1.1\VirtualLibrarian\DatabaseVL.mdf;Integrated Security=True";
            conn.Open();
            string sql = "Insert into Users " +
                "([Username], [Password], [Name], [Surname], [Email], [Birth], [UserType]) " +
                "values(username, pass, name, surname, email, birth, User.userType.reader)";
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
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
            bool ExistsResult = false;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\VirtualLibrarian1.1\VirtualLibrarian\DatabaseVL.mdf;Integrated Security=True";
            conn.Open();
            SqlCommand command = new SqlCommand("Select Username from Users", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetString(reader.GetOrdinal("Username")) == whatToLookFor)
                    {
                        //found that already exists
                        ExistsResult = true;
                        conn.Close();
                        return ExistsResult;
                    }
                }
                conn.Close();
                return ExistsResult;
            }
        }

        //check if ISBN exists in db Books
        public static bool checkIfExistsInDBBooks(string comma, string whatToLookFor)
        {
            bool ExistsResult = false;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\VirtualLibrarian1.1\VirtualLibrarian\DatabaseVL.mdf;Integrated Security=True";
            conn.Open();
            SqlCommand command = new SqlCommand(comma, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetString(reader.GetOrdinal("ISBN")) == whatToLookFor)
                    {
                        //found that already exists
                        ExistsResult = true;
                        conn.Close();
                        return ExistsResult;
                    }
                }
                conn.Close();
                return ExistsResult;
            }
        }


    }
}
