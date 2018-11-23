using SQLite;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace VLibrarian
{
    [System.ComponentModel.DataAnnotations.Schema.Table("dbo.Taken")]
    class Taken
    {
        public Taken() { }

        //properties

        [ForeignKey("Book")]
        public string ISBN { get; set; }

        [ForeignKey("(User")]
        public string Username { get; set; }
        public string DateTaken { get; set; }
        public string DateReturn { get; set; }
    }
}