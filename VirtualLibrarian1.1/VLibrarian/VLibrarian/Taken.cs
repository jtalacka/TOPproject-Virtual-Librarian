using SQLite;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace VLibrarian
{
    [System.ComponentModel.DataAnnotations.Schema.Table("dbo.Taken")]
    class Taken
    {
        public Taken() { }

        public Taken(string code, string user, string dateT, string dateR)
        {
            this.ISBN = code;
            this.Username = user;
            this.DateTaken = dateT;
            this.DateReturn = dateR;
        }

        //properties
        public string ISBN { get; set; }
        public string Username { get; set; }
        public string DateTaken { get; set; }
        public string DateReturn { get; set; }
    }
}