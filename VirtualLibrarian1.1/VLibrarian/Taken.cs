using SQLite;
using System.Collections.Generic;

namespace VLibrarian
{
    [Table("dbo.Taken")]
    public class Taken
    {

        //properties


        public string ISBN { get; set; }

        public string Username { get; set; }
        public string DateTaken { get; set; }
        public string DateReturn { get; set; }

        public Taken() { }

        public Taken(string code, string user, string dateT, string dateR)
        {
            this.ISBN = code;
            this.Username = user;
            this.DateTaken = dateT;
            this.DateReturn = dateR;
        }
    }
}