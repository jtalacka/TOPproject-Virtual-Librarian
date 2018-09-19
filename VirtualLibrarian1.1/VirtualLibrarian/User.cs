using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian
{
    class User
    {
        //a constructor
        public User()
        {}

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
