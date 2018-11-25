using SQLite;
using System.Collections.Generic;

namespace VLibrarian
{
    [Table("dbo.Users")]
    public class User
    {
        //a constructor
        public User()
        { }

        public User(string u, string p, string n, string s, string e, string b)
        {
            this.username = u;
            this.password = p;
            this.name = n;
            this.surname = s;
            this.email = e;
            this.birth = b;
        }
        public User(string u, string n, string s, string e, string b)
        {
            this.username = u;
            this.name = n;
            this.surname = s;
            this.email = e;
            this.birth = b;
        }

        //properties (in same order as written in in the file)
        [PrimaryKey]
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string birth { get; set; }

        //needed for determining if extra functions need to be shown
        public userType UserType { get; set; }
        public enum userType
        {
            reader, employee
        }

        //List for all readers
        public static List<User> readerList = new List<User>();

        public string ObToString(User currUser)
        {
            string infoToDisplay = currUser.username + " --- " + currUser.password + " --- "
                                 + currUser.name + " --- " + currUser.surname + " --- "
                                 + currUser.email + " --- " + currUser.birth;
            return infoToDisplay;
        }
    }
}