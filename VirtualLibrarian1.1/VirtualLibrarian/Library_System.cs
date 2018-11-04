using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian
{
    class Library_System
    {
        //FUNCTIONALITY from FormLibSys/NewBook/EditBook/...:
        //      checkIfExistsInDBBooks
        //      addBook,
        //      editBook,
        //
        //      allTakenBooks
        //      searchR,
        //      deleteBookFromReaderFile,
        //     


        //for connecting to the db
        public static SqlConnection conn = new SqlConnection();
        static string conectionS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\VirtualLibrarian1.1\VirtualLibrarian\DatabaseVL.mdf;Integrated Security=True";
        //query
        public static SqlCommand command;


        //check if ISBN exists in db Books, before adding a new one
        public static bool checkIfExistsInDBBooks(string whatToLookFor)
        {
            bool ExistsResult = false;

            conn.ConnectionString = conectionS;
            conn.Open();
            command = new SqlCommand("Select ISBN from Books", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetString(reader.GetOrdinal("ISBN")) == whatToLookFor)
                    {
                        //found that already exists
                        conn.Close();
                        ExistsResult = true;
                        return ExistsResult;
                    }
                }
                conn.Close();
                return ExistsResult;
            }
        }

        public static void addBook(Book book, List<string> checkedGenres)
        {
            conn.ConnectionString = conectionS;
            conn.Open();
            string sql = "Insert into Books " +
                "(ISBN, Title, Author, Genres, Quantity) " +
                "values('" + book.ISBN + "', '" + book.title + "', '" + book.author + "', " +
                       "'" + string.Join(" ", checkedGenres) + "', '" + book.quantity.ToString() + "')";
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
        }

        //edit/delete Book info. in table
        public static void editBook(string COMMAND)
        {
            conn.ConnectionString = conectionS;
            conn.Open();
            using (conn)
            {
                using (command = new SqlCommand(COMMAND, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
            conn.Close();
        }


        //gets all taken books into list
        public static List<string> allTakenBooks()
        {
            List<string> taken = new List<string>();
            string item;

            conn.ConnectionString = conectionS;
            conn.Open();
            command = new SqlCommand("Select * From  Taken", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // Check is the reader has any rows at all before starting to read.
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        item = reader.GetString(reader.GetOrdinal("ISBN")) + " --- " +
                            reader.GetString(reader.GetOrdinal("Username")) + " --- " +
                            reader.GetString(reader.GetOrdinal("DateTaken")) + " --- " +
                            reader.GetString(reader.GetOrdinal("DateReturn"));
                        taken.Add(item);
                    }
                }
            }
            conn.Close();
            return taken;
        }




        //searches User object - if it fits, returns obj. info to display as a string
        public static string searchR(string searchInfo, User currentU)
        {
            string infoToDisplay = "no match";

            if (currentU.username.ToLower().Contains(searchInfo.ToLower()) ||
                currentU.name.ToLower().Contains(searchInfo.ToLower())
                || currentU.surname.ToLower().Contains(searchInfo.ToLower()))
            {
                infoToDisplay = currentU.username + " --- " + currentU.name + " --- "
                              + currentU.surname + " --- " + currentU.email + " --- " + currentU.birth;
                return infoToDisplay;
            }
            return infoToDisplay;
        }


        //When a book is being returned - 
        //WRITE NEW INFO. INTO TABLES: Taken, Books
        public static void deleteBookFromReader(string COMMAND, string[] splitInfo)
        {
            //delete in Taken
            conn.ConnectionString = conectionS;
            conn.Open();
            using (conn)
            {
                using (command = new SqlCommand(COMMAND, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
            conn.Close();

            //change (add) quantity in Books
            //what's the current quantity in list?
            int quo = 0;
            //checks all the books in the list bookList
            foreach (Book tempBook in Book.bookList)
            {
                if (tempBook.ISBN == splitInfo[0] && tempBook.title == splitInfo[1])
                {
                    quo = tempBook.quantity;
                    break;
                }
            }
            quo = quo + 1;
            
            COMMAND = "Update Books set " +
            "Quantity='" + quo + "' Where ISBN='" + splitInfo[0] + "'";
            
            conn.ConnectionString = conectionS;
            conn.Open();
            using (conn)
            {
                using (command = new SqlCommand(COMMAND, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
            conn.Close();
        }



    }

}
