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

        //properties
        public string name;
        public string surname;
        public string username;
        public string password;
        public int birth;
        public string email;

        public userType type;
        public enum userType
        {
            reader, employee
        }


    }
}
