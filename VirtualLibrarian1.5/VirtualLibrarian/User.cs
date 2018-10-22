﻿using System;
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

        public User(string u, string p, string n, string s, string e, string b)
        {
            this.username = u;
            this.password = p;
            this.name = n;
            this.surname = s;
            this.email = e;
            this.birth = b;
        }

        //properties (in same order as written in in the file)
        public string username;
        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

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

        //List for all readers
        public static List<User> readerList = new List<User>();
    }
}