using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dbservice.Models
{
    public enum userType
    {
        reader, employee
    }

    public class User
    {
        public string username { get; set; }
        public string password { get; set; }

        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string birth { get; set; }

        //needed for determining if extra functions need to be shown
        public userType UserType { get; set; }

    }
}
