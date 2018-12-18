using System.Collections.Generic;

namespace VLibrarian
{
    public class User
    {

        //properties (in same order as written in in the file)
        public string username;
        public string password;
        public string name;
        public string surname;
        public string email;
        public string birth;

        //needed for determining if extra functions need to be shown
        public userType type;
        public enum userType
        {
            reader, employee
        }

    }
}