using SQLite;
using System.Collections.Generic;

namespace VLibrarian
{
    [Table("dbo.Taken")]
    public class Taken
    {

        //properties

        [PrimaryKey]
        public string ISBN { get; set; }
        [PrimaryKey]
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
        public Taken(string code, string user)
        {
            this.ISBN = code;
            this.Username = user;
        }

        public static List<Taken> allTaken = new List<Taken>();
    }
}