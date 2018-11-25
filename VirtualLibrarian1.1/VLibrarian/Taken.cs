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
    }
}